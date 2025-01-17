//********************************************运行参数设置**RunParams*************************************  
//********************************************                       *************************************  
 
//设置->分段->模式   
SegmentationParams.Mode = CogBlobSegmentationModeConstants.{
	Map;                                                     //映射
	HardFixedThreshold;                               	 	 //硬阈值（固定）
	HardDynamicThreshold;                             		 //硬阈值（动态）
	HardRelativeThreshold ;                           		 //硬阈值（相对）
	SoftFixedThreshold;                               		 //软阈值（固定）
	SoftRelativeThreshold;                            		 //软阈值（相对）
	SubtractionImage;                                 		 //剪影图像	
	None;                                             		 //无
}
 
//设置->分段->极性
SegmentationParams.Polarity = CogBlobSegmentationPolarityConstants.{
	DarkBlobs;                                        		 //白底黑点
	LightBlobs;                                       		 //黑底白点
}
 
//设置->连通性->模式
ConnectivityMode = CogBlobConnectivityModeConstants.{
	Labeled;                                          		 //已标记
	GreyScale;                                        		 //灰度
	WholeImageGreyScale;                              		 //整个图像
}
 
//设置->连通性->清除
ConnectivityCleanup = CogBlobConnectivityCleanupConstants.{
	Prune;                                            		 //修剪
	Fill;                                             		 //填充
	None;                                             		 //无
}
 
//设置->连通性->最小面积
ConnectivityMinPixels = 整数                          		 //设置最小面积
 
//区域->区域形状
Region = {
	CogCircle ;                                       		 //圆形
	CogEllipse ;                                      		 //椭圆
	CogPolygon ;                                      		 //多边形
	CogRectangle ;                                    		 //矩形
	CogRectangleAffine ;                              		 //矩形仿射
	CogCircularAnnulusSection ;                       		 //环形截面
	CogEllipcalAnnulusSection ;                       		 //椭圆翼剖面
	null;                                             		 //使用整个图像
}
 
//测得尺寸->属性   固定值
RuntimeMeasures.Item[0].Measure = Area ;  
RuntimeMeasures.Item[1].Measure = CenterMassX ;  
RuntimeMeasures.Item[2].Measure = CenterMassY ;  
RuntimeMeasures.Item[3].Measure = Lable ;  
 
//测得尺寸->尺寸/过滤
RunTimeMeasures.Item[0].Mode = CogBlobMeasureModeConstants.{
	Filter;                                           		 //过滤
	None;                                             		 //网格
	PreCompute;                                       		 //运行时
}
 
//测得尺寸->范围
RuntimeMeasures.Item[0].FilterMode = CogBlobFilterModeConstants.{
	IncludeBlobsInRange;                              		 //包含
	ExcludeBlobsInRange;                              		 //排除
}
RuntimeMeasures.Item[0].FilterRangeHigh = double类型  		 //高
RuntimeMeasures.Item[0].FilterRangLow =  double类型   		 //低
 
 
//Results
//结果
GetBlobs().Count                                      		 //结果数量
GetBlobs().Item[0].Area                               		 //面积
GetBlobs().Item[0].CenterMassX                        		 //x轴坐标
GetBlobs().Item[0].CenterMassY                        		 //y轴坐标
 
 
 
//*****************************************************例子**Example*******************************************
//*****************************************************             *******************************************  
 
 
//变量声明
CogImageCollection images = new CogImageCollection();    											//图片的集合
CogBlobTool m_blob = new CogBlobTool();                  											//斑点工具
CogBlobMeasure m_measure = new CogBlobMeasure();                                                    //筛选属性1
CogBlobMeasure m_measure2 = new CogBlobMeasure();													//筛选属性2
CogRectangle m_rectangle = new CogRectangle();          											//创建一个矩形区域
int m_PicNum;        																				//图片数量
int m_PerNum = 0;    																				//当前运行图片序号
double nPositionX;                                                                                  //X轴坐标
double nPositionY;																					//Y轴坐标                                                                                   
 
 
//加载图像源
CogImageFile ImageFiles = new CogImageFile();                                                       //创建图像源
images.Clear();
m_PicNum = 0;
using (FolderBrowserDialog lvse = new FolderBrowserDialog())                                        //打开本地文件夹
{
	if (lvse.ShowDialog() == DialogResult.OK)
	{
		DirectoryInfo dinfo = new DirectoryInfo(lvse.SelectedPath);
		FileInfo[] finfo = dinfo.GetFiles();
		foreach (FileInfo file in finfo)
		{
			ImageFiles.Open(file.FullName, CogImageFileModeConstants.Read);
			ICogImage image = ImageFiles[0];                                                        //将图片放入images容器中
			images.Add(image);
			m_PicNum++;
		}
	}
}
cogRecordDisplay1.Image = images[0];
cogRecordDisplay1.Fit(true);
 
	
//添加图像选择区域   
m_rectangle.GraphicDOFEnable = CogRectangleDOFConstants.All;                                        //启用对矩形旋转的交互式操作。
m_rectangle.Interactive = true;                                                                     //交互式属性允许选择此图形对象。
//m_rectangle.Width = 240;                                     										//矩形宽
//m_rectangle.Height = 240;                                    										//矩形高
//m_rectangle.X = 89.75;                                       										//矩形顶角X轴坐标
//m_rectangle.Y = 146.891;                                     										//矩形顶胶Y轴坐标
m_blob.Region = m_rectangle;                                                                        //m_blob形状为为矩形
cogRecordDisplay1.InteractiveGraphics.Clear();
cogRecordDisplay1.InteractiveGraphics.Add((ICogGraphicInteractive)m_blob.Region, "gu", false);      //画面上显示区域范围 
 
 
//运行处理
m_blob.InputImage = images[m_PerNum];                        										//输入图像源
m_blob.RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardDynamicThreshold;   //硬阈值（动态）
m_blob.RunParams.SegmentationParams.Polarity = CogBlobSegmentationPolarityConstants.DarkBlobs;      //白底黑点
m_blob.RunParams.ConnectivityMode = CogBlobConnectivityModeConstants.GreyScale;       				//灰度
m_blob.RunParams.ConnectivityCleanup = CogBlobConnectivityCleanupConstants.Fill;      				//填充
m_blob.RunParams.ConnectivityMinPixels = 10;                 										//设置最小面积   
 
m_blob.RunParams.RunTimeMeasures.Add(m_measure);             										//添加如下两种属性
m_blob.RunParams.RunTimeMeasures.Add(m_measure2);
 
m_blob.RunParams.RunTimeMeasures[0].Measure = CogBlobMeasureConstants.Area;
m_blob.RunParams.RunTimeMeasures[0].Mode = CogBlobMeasureModeConstants.Filter;        				//过滤
m_blob.RunParams.RunTimeMeasures[0].FilterMode = CogBlobFilterModeConstants.IncludeBlobsInRange;    //包含
m_blob.RunParams.RunTimeMeasures[0].FilterRangeLow = 1100;   										//下限
m_blob.RunParams.RunTimeMeasures[0].FilterRangeHigh = 1200;  										//上限
 
m_blob.RunParams.RunTimeMeasures[1].Measure = CogBlobMeasureConstants.Label;
m_blob.RunParams.RunTimeMeasures[1].Mode = CogBlobMeasureModeConstants.Filter;        				//过滤
m_blob.RunParams.RunTimeMeasures[1].FilterMode = CogBlobFilterModeConstants.IncludeBlobsInRange;    //包含
m_blob.RunParams.RunTimeMeasures[1].FilterRangeLow = 0.9;    										//下限
m_blob.RunParams.RunTimeMeasures[1].FilterRangeHigh = 1.1;   										//上限
 
m_blob.Run();   																					//运行
 
 
//获取结果
int num = m_blob.Results.GetBlobs().Count;                   										//结果数量
for (int i = 0; i <num; i++)
{
	nPositionX = m_blob.Results.GetBlobs()[i].CenterOfMassX; 										//X轴坐标
	nPositionY = m_blob.Results.GetBlobs()[i].CenterOfMassY; 										//Y轴坐标
}
 
 //每个斑点的边界
CogBlobTool bd = mToolBlock.Tools["CogBlobTool1"] as CogBlobTool;
CogBlobResultCollection bds = bd.Results.GetBlobs();
CogBlobResult item = bds[1];

CogPolygon pg = item.GetBoundary();
 
 
 //最小外接矩形
//最小外接矩形宽度和高度
CogRectangleAffine rectangleAffine = item.GetBoundingBox(CogBlobAxisConstants.Principal);
double 左上x = rectangleAffine.CornerOriginX;
double 左上y = rectangleAffine.CornerOriginY;
double 右上x = rectangleAffine.CornerXX;
double 右上y = rectangleAffine.CornerXY;
double 左下x = rectangleAffine.CornerYX;
double 左下y = rectangleAffine.CornerYY;
double 右下x = rectangleAffine.CornerOppositeX;
double 右下y = rectangleAffine.CornerOppositeY;
//外接矩形（方正）
double width = item.GetMeasure(CogBlobMeasureConstants.BoundingBoxExtremaAngleWidth);
double height = item.GetMeasure(CogBlobMeasureConstants.BoundingBoxExtremaAngleHeight);
 //像素对齐外接矩形
 
