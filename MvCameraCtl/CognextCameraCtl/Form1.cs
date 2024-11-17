using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonFunc.Common.WinformControl;
using CommonFunc.Camera.CognexCamera.Model;
using Cognex.VisionPro;


namespace CognextCameraCtl
{

    
    public partial class Form1 : Form
    {

        private CogFrameGrabbers FrameGrabbers = null; //声明图像采集器集合对象
        private ICogFrameGrabber FrameGrabber = null; //声明图像采集器集合对象
        private ICogAcqFifo ICogAcqFifo = null; //声明图像采集器管道对象
       
        public Cognex.VisionPro.CogLineSegment VerticalLine = null;
        public Cognex.VisionPro.CogLineSegment HorizonLine = null;

        public Form1()
        {
            InitializeComponent();
            InitData();
        }

        /// <summary>
        /// 从选中的设备初始化支持的视频格式数据
        /// </summary>
        private void SupportVideoFormats()
        {
            if (FrameGrabbers.Count == 0)
            {
                return;
            }
            ICogFrameGrabber frameGrabber = FrameGrabbers[cbbDeviceList.SelectedIndex];
            foreach (string videoFormat in frameGrabber.AvailableVideoFormats)
            {
                cbb_VideoFormat.Items.Add(videoFormat);
            }
            cbb_VideoFormat.SelectedIndex = 0;
        }

        /// <summary>
        /// 初始化采集工具
        /// </summary>
        private void InitAcqFifo()
        {
            
            ICogFrameGrabber frameGrabber = FrameGrabbers[cbbDeviceList.SelectedIndex];
            ICogAcqFifo = FrameGrabbers[cbbDeviceList.SelectedIndex].CreateAcqFifo(frameGrabber.AvailableVideoFormats[0], CogAcqFifoPixelFormatConstants.Format8Grey, 0, true);
            //ICogAcqFifo.OwnedTriggerParams.TriggerEnabled = true;
            //MessageBox.Show(ICogAcqFifo.OwnedGigEVisionTransportParams.PacketSizeMax.ToString());
            //软触发
            //ICogAcqFifo.OwnedTriggerParams.TriggerModel = Cognex.VisionPro.CogAcqTriggerModelConstants.Manual;
            //导致采集失败
            //ICogAcqFifo.OwnedGigEVisionTransportParams.PacketSize = 8000;


            //too many consecutive resends
            ICogAcqFifo.OwnedGigEVisionTransportParams.LatencyLevel = (int)NudLatencyLevel.Value;
            //ms 单位
            ICogAcqFifo.OwnedExposureParams.Exposure = (int)nud_Exposure.Value/1000;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            RefreshshDevice();
            SupportVideoFormats();

            nud_Exposure.Maximum = 30000;
            nud_Exposure.Minimum = 0;
            nud_Exposure.Value = 5000;     

            cogDisplayStatusBarV21.Display = cogDisplay1;
        }

        /// <summary>
        /// 刷新可用设备
        /// </summary>
        private void RefreshshDevice()
        {
            cbbDeviceList.Items.Clear();
            FrameGrabbers = new CogFrameGrabbers();
            if (FrameGrabbers.Count > 0)
            {
                foreach (ICogFrameGrabber item in FrameGrabbers)
                {
                    cbbDeviceList.Items.Add(item.Name);
                }
                cbbDeviceList.SelectedIndex = 0;
            }
            else
            {
                btGrabing.Enabled = false;
                cbbDeviceList.Items.Add("Not fount camera");
            }

        }


        /// 当选择相机的时候触发此事件
        private void OnFramerGrabberChanged(object sender, EventArgs e)
        {
            cbb_VideoFormat.Items.Clear();
            for (int i = 0; i < FrameGrabbers[cbbDeviceList.SelectedIndex].AvailableVideoFormats.Count; i++)
            {
                cbb_VideoFormat.Items.Add(FrameGrabbers[cbbDeviceList.SelectedIndex].AvailableVideoFormats[i]);
            }
        }

        /// 关闭窗体的时候断开相机
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrameGrabbers[cbbDeviceList.SelectedIndex].Disconnect(false);
        }

        private void cogDisplay1_Enter(object sender, EventArgs e)
        {

        }

        private void cbbDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btSearchDevice_Click(object sender, EventArgs e)
        {
            RefreshshDevice();
        }


        /// <summary>
        /// 辅助线
        /// </summary>
        /// <param name="image"></param>
        public void AddAssistLine(Cognex.VisionPro.CogImage8Grey image)
        {
            if (image == null)
                return;
            try
            {
                if (VerticalLine == null)
                {
                    VerticalLine = new CogLineSegment();
                    VerticalLine.Color = CogColorConstants.Red;
                    VerticalLine.LineStyle = CogGraphicLineStyleConstants.Solid;
                    VerticalLine.SetStartEnd(image.Width / 2, 0, image.Width / 2, image.Height);
                }
                if (HorizonLine == null)
                {
                    HorizonLine = new CogLineSegment();
                    HorizonLine.Color = CogColorConstants.Red;
                    HorizonLine.LineStyle = CogGraphicLineStyleConstants.Solid;
                    HorizonLine.SetStartEnd(0, image.Height / 2, image.Width, image.Height / 2);
                }
                cogDisplay1.StaticGraphics.Add(VerticalLine, "");
                cogDisplay1.StaticGraphics.Add(HorizonLine, "");
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 实时取像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGrabing_Click(object sender, EventArgs e)
        {

            try
            {
                if (cogDisplay1.LiveDisplayRunning)
                {
                    //关闭光源
                    cogDisplay1.StopLiveDisplay();
                    btGrabing.BackColor = Color.White;
                    return;
                }
                btGrabing.BackColor = Color.Green;

                InitAcqFifo();
                cogDisplay1.StartLiveDisplay(ICogAcqFifo, false);//控件绑定相机并显示画面
                cogDisplay1.Fit(true);

                AddAssistLine((CogImage8Grey)cogDisplay1.Image);

            }
            catch (Exception ex)
            {
                MessageBox.Show("采集失败：" + ex.ToString());
            }
            
        }

        private void nud_Exposure_ValueChanged(object sender, EventArgs e)
        {
        }

        private void cbbLatencyLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 拍照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtSnap_Click(object sender, EventArgs e)
        {
            int trgNum = 0;
            cogDisplay1.Image = ICogAcqFifo.Acquire(out trgNum);
            cogDisplay1.Fit(true);
        }
    }

}

/*
    public partial class Form1 : Form
    {
        private CogFrameGrabbers FrameGrabbers = null; //声明图像采集器集合对象
        private ICogAcqFifo ICogAcqFifo = null; //声明图像采集器对象
        private ICogFrameGrabber FrameGrabber = null; //声明图像采集器集合对象
        List<String> videoFormat = new List<String>();//相机信息列表
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(videoFormat.Count.ToString());//已连接相机数量

        }

        private void btGrabing_Click(object sender, EventArgs e)
        {
            FrameGrabbers = new CogFrameGrabbers();//取得相机列表
            FrameGrabber = FrameGrabbers[0];//取第一个相机，第二个相机依次增加
            ICogAcqFifo = FrameGrabber.CreateAcqFifo(FrameGrabber.AvailableVideoFormats[0],
            CogAcqFifoPixelFormatConstants.Format8Grey, 0, true);//初始化相机
            cogDisplay1.StartLiveDisplay(ICogAcqFifo, false);//控件绑定相机并显示画面

        }


        private void btGrab_Click(object sender, EventArgs e)
        {
            int trgNum = 0;
            cogDisplay1.Image = ICogAcqFifo.Acquire(out trgNum);
            cogDisplay1.Fit(true);
        }

        private void cbbDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btSearchDevice_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            FrameGrabbers = new CogFrameGrabbers();
            if (FrameGrabbers.Count < 1)
            {
                MessageBox.Show("没有找到相机设备！");
            }
            //遍历已连接相机信息，并添加进列表里（相机名，序列号，模式）
            for (int i = 0; i < FrameGrabbers.Count; i++)
            {
                FrameGrabber = FrameGrabbers[i];
                MessageBox.Show(FrameGrabber.Name + FrameGrabber.SerialNumber + FrameGrabber.AvailableVideoFormats[0]);
                videoFormat.Add(FrameGrabber.Name + FrameGrabber.SerialNumber + FrameGrabber.AvailableVideoFormats[0]);
            }
        }

    }
}

*/
