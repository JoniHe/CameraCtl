using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MvCameraControl;
using CommonFunc.Common;
using CommonFunc.Camera.MvCamera;
using System.Threading;

namespace MvCameraCtl
{
    public enum Status
    {
        OpenDevice = 0,
        CloseDevice = 1,
        Grabing = 2,
        StopGrab = 3,
        Recording = 4,
        StopRecord = 5,
    }

    public partial class Form_BasicCtl : Form
    {
        readonly DeviceTLayerType enumTLayerType = DeviceTLayerType.MvGigEDevice | DeviceTLayerType.MvUsbDevice
            | DeviceTLayerType.MvGenTLGigEDevice | DeviceTLayerType.MvGenTLCXPDevice | DeviceTLayerType.MvGenTLCameraLinkDevice | DeviceTLayerType.MvGenTLXoFDevice;

        List<IDeviceInfo> deviceInfoList = new List<IDeviceInfo>();
        IDevice device = null;
        bool isGrabbing = false;        // ch:是否正在取图 | en: Grabbing flag
        bool isRecord = false;          // ch:是否正在录像 | en: Video record flag
        Thread threadIoStream = null;    // ch:接收图像线程 | en: Receive image thread


        private IFrameOut frameForSave;                         // ch:获取到的帧信息, 用于保存图像 | en:Frame for save image
        private readonly object saveImageLock = new object();


        public Form_BasicCtl()
        {
            InitializeComponent();
            SDKSystem.Initialize();

            RefreshDeviceList();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        //
        // 错误处理
        //
        private void RefreshDeviceList()
        {
            // ch:创建设备列表 | en:Create Device List
            cbDeviceList.Items.Clear();
            int nRet = DeviceEnumerator.EnumDevices(enumTLayerType, out deviceInfoList);
            if (nRet != MvError.MV_OK)
            {

                MvErrorCode.ShowMsg(nRet, "Enumerate devices fail!");
                return;
            }

            // ch:在窗体列表中显示设备名 | en:Display device name in the form list
            for (int i = 0; i < deviceInfoList.Count; i++)
            {
                IDeviceInfo deviceInfo = deviceInfoList[i];
                if (deviceInfo.UserDefinedName != "")
                {
                    cbDeviceList.Items.Add(deviceInfo.TLayerType.ToString() + ": " + deviceInfo.UserDefinedName + " (" + deviceInfo.SerialNumber + ")");
                }
                else
                {
                    cbDeviceList.Items.Add(deviceInfo.TLayerType.ToString() + ": " + deviceInfo.ManufacturerName + " " + deviceInfo.ModelName + " (" + deviceInfo.SerialNumber + ")");
                }
            }

            // ch:选择第一项 | en:Select the first item
            if (deviceInfoList.Count != 0)
            {
                cbDeviceList.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 采集图像工作线程
        /// </summary>
        public void ThreadIoStream()
        {
            int nRet;

            Graphics graphics;   // ch:使用GDI在pictureBox上绘制图像 | en:Display frame using a graphics

            while (isGrabbing)
            {
                IFrameOut frameOut;
                //从设备获取一帧图像
                nRet = device.StreamGrabber.GetImageBuffer(1000, out frameOut);
                if (MvError.MV_OK == nRet)
                {
                    if (isRecord)
                    {
                        device.VideoRecorder.InputOneFrame(frameOut.Image);
                    }

                    lock (saveImageLock)
                    {
                        try
                        {
                            frameForSave = frameOut.Clone() as IFrameOut;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("IFrameOut.Clone failed, " + e.Message);
                            return;
                        }
                    }

#if !GDI_RENDER
                    nRet = device.ImageRender.DisplayOneFrame(pictureBox1.Handle, frameOut.Image);
                    if (MvError.MV_OK != nRet)
                    {
                        MvErrorCode.ShowMsg(nRet, "displayOnFrame error");
                        return;
                    }
#else
                    // 使用GDI绘制图像
                    try
                    {
                        using (Bitmap bitmap = frameOut.Image.ToBitmap())
                        {
                            if (graphics == null)
                            {
                                graphics = pictureBox1.CreateGraphics();
                            }

                            Rectangle srcRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                            Rectangle dstRect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
                            graphics.DrawImage(bitmap, dstRect, srcRect, GraphicsUnit.Pixel);
                        }
                    }
                    catch (Exception e)
                    {
                        device.StreamGrabber.FreeImageBuffer(frameOut);
                        MessageBox.Show(e.Message);
                        return;
                    }
#endif

                    //释放图像内存
                    device.StreamGrabber.FreeImageBuffer(frameOut);
                }
                else
                {
                    if (rbtnTriggerMode.Checked)
                    {
                        Thread.Sleep(5);
                    }
                }
            }
        }

        /// <summary>
        /// 打开设备时控件设置
        /// </summary>
        private void ControlOpenDeviceStatus()
        {
            bnOpen.Enabled = false;

            bnClose.Enabled = true;
            bnStartGrab.Enabled = true;
            bnStopGrab.Enabled = false;
            rbtnContinuesMode.Enabled = true;
            rbtnContinuesMode.Checked = true;
            rbtnTriggerMode.Enabled = true;
            cbSoftTrigger.Enabled = false;
            bnTriggerExec.Enabled = false;

            tbExposure.Enabled = true;
            tbGain.Enabled = true;
            tbFrameRate.Enabled = true;
            cbPixelFormat.Enabled = true;
            bnGetParam.Enabled = true;
            bnSetParam.Enabled = true;
        }

        private void ControlCloseDeviceStatus()
        {
            bnOpen.Enabled = true;

            bnClose.Enabled = false;
            bnStartGrab.Enabled = false;
            bnStopGrab.Enabled = false;
            rbtnContinuesMode.Enabled = false;
            rbtnTriggerMode.Enabled = false;
            cbSoftTrigger.Enabled = false;
            bnTriggerExec.Enabled = false;

            bnSaveBmp.Enabled = false;
            bnSaveJpg.Enabled = false;
            bnSaveTiff.Enabled = false;
            bnSavePng.Enabled = false;
            tbExposure.Enabled = false;
            tbGain.Enabled = false;
            tbFrameRate.Enabled = false;
            bnGetParam.Enabled = false;
            bnSetParam.Enabled = false;
            cbPixelFormat.Enabled = false;
            bnStartRecord.Enabled = false;
            bnStopRecord.Enabled = false;
        }
        private void ControlGrabingStatus()
        {
            bnStartGrab.Enabled = false;
            cbPixelFormat.Enabled = false;
            bnStopGrab.Enabled = true;

            if (rbtnTriggerMode.Checked && cbSoftTrigger.Checked)
            {
                bnTriggerExec.Enabled = true;
            }

            bnSaveBmp.Enabled = true;
            bnSaveJpg.Enabled = true;
            bnSaveTiff.Enabled = true;
            bnSavePng.Enabled = true;
            bnStartRecord.Enabled = true;
            bnStopRecord.Enabled = false;
        }

        private void ControlStopGrabStatus()
        {
            bnStartGrab.Enabled = true;
            cbPixelFormat.Enabled = true;
            bnStopGrab.Enabled = false;
            bnTriggerExec.Enabled = false;

            bnSaveBmp.Enabled = false;
            bnSaveJpg.Enabled = false;
            bnSaveTiff.Enabled = false;
            bnSavePng.Enabled = false;
            bnStartRecord.Enabled = false;
            bnStopRecord.Enabled = false;
        }

        private void ControlRecordingStatus()
        {
            bnStartRecord.Enabled = false;
            bnStopRecord.Enabled = true;
        }
        private void ControlStopRecordStatus()
        {
            bnStartRecord.Enabled = true;
            bnStopRecord.Enabled = false;
        }

        private void ControlStatus(Status status)
        {
            switch(status)
            {
                case Status.OpenDevice:
                    ControlOpenDeviceStatus();
                    break;
                case Status.CloseDevice:
                    ControlCloseDeviceStatus();
                    break;
                case Status.Grabing:
                    ControlGrabingStatus();
                    break;
                case Status.StopGrab:
                    ControlStopGrabStatus();
                    break;
                case Status.Recording:
                    ControlRecordingStatus();
                    break;
                case Status.StopRecord:
                    ControlStopRecordStatus();
                    break;
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }


        private void tbExposure_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbPixelFormat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void bnEnum_Click(object sender, EventArgs e)
        {
            RefreshDeviceList();
        }

        private void bnOpen_Click(object sender, EventArgs e)
        {
            if (deviceInfoList.Count == 0 || cbDeviceList.SelectedIndex == -1)
            {
                MvErrorCode.ShowMsg(0, "No device, please select");
                return;
            }

            // ch:获取选择的设备信息 | en:Get selected device information
            IDeviceInfo deviceInfo = deviceInfoList[cbDeviceList.SelectedIndex];
            try
            {
                // ch:打开设备 | en:Open device
                device = DeviceFactory.CreateDevice(deviceInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Create Device fail!" + ex.Message);
                return;
            }

            int result = device.Open();
            if (result != MvError.MV_OK)
            {
                MvErrorCode.ShowMsg(result, "Open Device fail!");
                return;
            }

            //ch: 判断是否为gige设备 | en: Determine whether it is a GigE device
            if (device is IGigEDevice)
            {
                //ch: 转换为gigE设备 | en: Convert to Gige device
                IGigEDevice gigEDevice = device as IGigEDevice;

                // ch:探测网络最佳包大小(只对GigE相机有效) | en:Detection network optimal package size(It only works for the GigE camera)
                int optionPacketSize;
                result = gigEDevice.GetOptimalPacketSize(out optionPacketSize);
                if (result != MvError.MV_OK)
                {
                    MvErrorCode.ShowMsg(result,"Warning: Get Packet Size failed!");
                }
                else
                {
                    result = device.Parameters.SetIntValue("GevSCPSPacketSize", (long)optionPacketSize);
                    if (result != MvError.MV_OK)
                    {
                        MvErrorCode.ShowMsg(result,"Warning: Set Packet Size failed!");
                    }
                }
            }

            // ch:设置采集连续模式 | en:Set Continues Aquisition Mode
            device.Parameters.SetEnumValueByString("AcquisitionMode", "Continuous");
            device.Parameters.SetEnumValueByString("TriggerMode", "Off");


            ControlStatus(Status.OpenDevice);

            // ch:获取参数 | en:Get parameters
            bnGetParam_Click(null, null);
        }



        //相机的图像采集模式分为内触发模式与外触发模式。Trigger Mode 选择 On 则为外触发模式， Trigger Mode 选择 Off 则为内触发模式
        //其中内触发模式包含连续采集、单帧采集两种形式；
        //1 实时视频流（continuous）
        //在 Acquisition Mode 选项框 中，若选择 Continuous，相机按照当前设置的帧率持续输出图像， 并给上位机送图像数据，可做实时显示

        //2 单帧采集（SingleFrame）
        //若选 SingleFrame， 相机只输出一张图片


        //外触发模式包含软件触发、硬件外触发


        /// <summary>
        /// 软触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnTriggerExec_Click(object sender, EventArgs e)
        {
            // ch:触发命令 | en:Trigger command
            int result = device.Parameters.SetCommandValue("TriggerSoftware");
            if (result != MvError.MV_OK)
            {
                MvErrorCode.ShowMsg(result, "Trigger Software Fail!");
            }
        }


        //
        private void bnTriggerMode_CheckedChanged(object sender, EventArgs e)
        {
            // ch:打开触发模式 | en:Open Trigger Mode
            if (rbtnTriggerMode.Checked)
            {
                device.Parameters.SetEnumValueByString("TriggerMode", "On");
                if (cbSoftTrigger.Checked)
                {
                    device.Parameters.SetEnumValueByString("TriggerSource", "Software");
                    if (isGrabbing)
                    {
                        bnTriggerExec.Enabled = true;
                    }
                }
                else
                {
                    device.Parameters.SetEnumValueByString("TriggerSource", "Line0");
                }
                cbSoftTrigger.Enabled = true;
            }
        }

        private void bnSaveBmp_Click(object sender, EventArgs e)
        {

        }

        private void cbPixelFormat_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void bnStartGrab_Click(object sender, EventArgs e)
        {
            try
            {
                // ch:标志位置位true | en:Set position bit true
                isGrabbing = true;
                threadIoStream = new Thread(ThreadIoStream);
                threadIoStream.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Start thread failed!, " + ex.Message);
                throw;
            }

            // ch:开始采集 | en:Start Grabbing
            int result = device.StreamGrabber.StartGrabbing();
            if (result != MvError.MV_OK)
            {
                isGrabbing = false;
                //同步直到线程退出
                threadIoStream.Join();
                MvErrorCode.ShowMsg(result,"Start Grabbing Fail!");
                return;
            }

            // ch:控件操作 | en:Control Operation
            ControlStatus(Status.Grabing);

        }

        private void bnStartRecord_Click(object sender, EventArgs e)
        {
            if (false == isGrabbing)
            {
                MvErrorCode.ShowMsg(0,"Not Start Grabbing");
                return;
            }

            IIntValue intValue;
            IEnumValue enumValue;

            uint width;
            uint height;
            MvGvspPixelType pixelType;

            int result;
            //获取相机特性
            result = device.Parameters.GetIntValue("Width", out intValue);
            if (result != MvError.MV_OK)
            {
                MvErrorCode.ShowMsg(result,"Get Width failed!");
                return;
            }
            width = (uint)intValue.CurValue;

            result = device.Parameters.GetIntValue("Height", out intValue);
            if (result != MvError.MV_OK)
            {
                MvErrorCode.ShowMsg(result,"Get Height failed!");
                return;
            }
            height = (uint)intValue.CurValue;

            result = device.Parameters.GetEnumValue("PixelFormat", out enumValue);
            if (result != MvError.MV_OK)
            {
                MvErrorCode.ShowMsg(result,"Get PixelFormat failed!");
                return;
            }
            pixelType = (MvGvspPixelType)enumValue.CurEnumEntry.Value;

            // ch:开始录像 | en:Start record
            RecordParam recordParam;
            recordParam.Width = width;
            recordParam.Height = height;
            recordParam.PixelType = pixelType;
            recordParam.FrameRate = float.Parse(tbFrameRate.Text);
            recordParam.BitRate = 1000;
            recordParam.FormatType = VideoFormatType.AVI;

            result = device.VideoRecorder.StartRecord("./Record.avi", recordParam);
            if (result != MvError.MV_OK)
            {
                MvErrorCode.ShowMsg(result,"Start Record Fail!");
                return;
            }

            isRecord = true;

            ControlStatus(Status.Recording);
        }

        private void bnStopGrab_Click(object sender, EventArgs e)
        {
            if (isRecord)
            {
                bnStopRecord_Click(sender, e);
            }

            // ch:标志位设为false | en:Set flag bit false
            isGrabbing = false;
            threadIoStream.Join();

            // ch:停止采集 | en:Stop Grabbing
            int result = device.StreamGrabber.StopGrabbing();
            if (result != MvError.MV_OK)
            {
                MvErrorCode.ShowMsg(result,"Stop Grabbing Fail!");
            }

            // ch:控件操作 | en:Control Operation
            ControlStatus(Status.StopGrab);
        }

        /// <summary>
        /// 停止录像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnStopRecord_Click(object sender, EventArgs e)
        {
            if (false == isGrabbing)
            {
                MvErrorCode.ShowMsg(0,"Not Grabbing");
                return;
            }

            int result = device.VideoRecorder.StopRecord();
            if (result != MvError.MV_OK)
            {
                MvErrorCode.ShowMsg(result,"Stop Record Fail!");
            }

            isRecord = false;
            ControlStatus(Status.StopRecord);
        }

        private void bnClose_Click(object sender, EventArgs e)
        {
            // ch:取流标志位清零 | en:Reset flow flag bit
            if (isGrabbing == true)
            {
                bnStopGrab_Click(sender, e);
            }

            // ch:关闭设备 | en:Close Device
            if (device != null)
            {
                device.Close();
                device.Dispose();
            }

            // ch:控件操作 | en:Control Operation
            ControlStatus(Status.CloseDevice);
        }

        private void rbtnContinuesMode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnContinuesMode.Checked)
            {
                device.Parameters.SetEnumValueByString("TriggerMode", "Off");
                cbSoftTrigger.Enabled = false;
                bnTriggerExec.Enabled = false;
            }
        }


        /// <summary>
        /// ch:获取触发模式 | en:Get Trigger Mode
        /// </summary>
        private void GetTriggerMode()
        {
            IEnumValue enumValue;
            int result = device.Parameters.GetEnumValue("TriggerMode", out enumValue);
            if (result == MvError.MV_OK)
            {
                if (enumValue.CurEnumEntry.Symbolic == "On")
                {
                    rbtnTriggerMode.Checked = true;
                    rbtnContinuesMode.Checked = false;

                    result = device.Parameters.GetEnumValue("TriggerSource", out enumValue);
                    if (result == MvError.MV_OK)
                    {
                        if (enumValue.CurEnumEntry.Symbolic == "TriggerSoftware")
                        {
                            cbSoftTrigger.Enabled = true;
                            cbSoftTrigger.Checked = true;
                            if (isGrabbing)
                            {
                                bnTriggerExec.Enabled = true;
                            }
                        }
                    }
                }
                else
                {
                    rbtnContinuesMode.Checked = true;
                    rbtnTriggerMode.Checked = false;
                }
            }
        }


        private void bnGetParam_Click(object sender, EventArgs e)
        {

            GetTriggerMode();

            IFloatValue floatValue;
            int result = device.Parameters.GetFloatValue("ExposureTime", out floatValue);
            if (result == MvError.MV_OK)
            {
                tbExposure.Text = floatValue.CurValue.ToString("F1");
            }

            result = device.Parameters.GetFloatValue("Gain", out floatValue);
            if (result == MvError.MV_OK)
            {
                tbGain.Text = floatValue.CurValue.ToString("F1");
            }

            result = device.Parameters.GetFloatValue("ResultingFrameRate", out floatValue);
            if (result == MvError.MV_OK)
            {
                tbFrameRate.Text = floatValue.CurValue.ToString("F1");
            }

            cbPixelFormat.Items.Clear();
            IEnumValue enumValue;
            result = device.Parameters.GetEnumValue("PixelFormat", out enumValue);
            if (result == MvError.MV_OK)
            {
                foreach (var item in enumValue.SupportEnumEntries)
                {
                    cbPixelFormat.Items.Add(item.Symbolic);
                    if (item.Symbolic == enumValue.CurEnumEntry.Symbolic)
                    {
                        cbPixelFormat.SelectedIndex = cbPixelFormat.Items.Count - 1;
                    }
                }

            }
        }

        private void bnSetParam_Click(object sender, EventArgs e)
        {
            try
            {
                float.Parse(tbExposure.Text);
                float.Parse(tbGain.Text);
                float.Parse(tbFrameRate.Text);
            }
            catch
            {
                MvErrorCode.ShowMsg(0,"Please enter correct type!");
                return;
            }

            device.Parameters.SetEnumValue("ExposureAuto", 0);
            int result = device.Parameters.SetFloatValue("ExposureTime", float.Parse(tbExposure.Text));
            if (result != MvError.MV_OK)
            {
                MvErrorCode.ShowMsg(result,"Set Exposure Time Fail!");
            }

            device.Parameters.SetEnumValue("GainAuto", 0);
            result = device.Parameters.SetFloatValue("Gain", float.Parse(tbGain.Text));
            if (result != MvError.MV_OK)
            {
                MvErrorCode.ShowMsg(result,"Set Gain Fail!");
            }

            result = device.Parameters.SetBoolValue("AcquisitionFrameRateEnable", true);
            if (result != MvError.MV_OK)
            {
                MvErrorCode.ShowMsg(result,"Set AcquisitionFrameRateEnable Fail!");
            }
            else
            {
                result = device.Parameters.SetFloatValue("AcquisitionFrameRate", float.Parse(tbFrameRate.Text));
                if (result != MvError.MV_OK)
                {
                    MvErrorCode.ShowMsg(result,"Set Frame Rate Fail!");
                }
            }
        }

        /// <summary>
        /// ch:程序关闭事件，释放SDK资源 | en:FormClosing, dispose SDK resources
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bnClose_Click(sender, e);

            SDKSystem.Finalize();
        }

        private void cbSoftTrigger_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSoftTrigger.Checked)
            {
                // ch:触发源设为软触发 | en:Set trigger source as Software
                device.Parameters.SetEnumValueByString("TriggerSource", "Software");
                if (isGrabbing)
                {
                    bnTriggerExec.Enabled = true;
                }
            }
            else
            {
                device.Parameters.SetEnumValueByString("TriggerSource", "Line0");
                bnTriggerExec.Enabled = false;
            }
        }
    }

}
