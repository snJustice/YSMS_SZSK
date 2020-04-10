using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YSMS.DataManage;
using HalconDotNet;

using System.Collections.ObjectModel;
using System.IO;
using System.Diagnostics;
using System.Windows.Controls;

using System.Windows.Interop;
using System.Windows;
using System.Threading;
using YSMS_SZSK.Lib;

namespace YSMS_130Standard
{
    public static class Global
    {
        public static double StartCodeValue1 = 0;
        public static double StartCodeValue2 = 0;

        public static List<HRect> TempHRectList = new List<HRect>();

        public static List<HCircle> TempHCircleList = new List<HCircle>();

        public static List<HPolygon> TempHPolygonList = new List<HPolygon>();

        /// <summary>
        /// 生成框矩阵
        /// </summary>
        public static HTuple HomMat2DForGenerateRect = new HTuple();
        /// <summary>
        /// 阵列用矩阵
        /// </summary>
        public static HTuple HomMat2DForArray = new HTuple();

        /// <summary>
        /// 用户等级
        /// </summary>
        public static int UserLevel = -1;

        /// <summary>
        /// 使用密码产生的权限次数
        /// </summary>
        public static int UserCodePower = 0;

        ///// <summary>
        ///// 软件信息
        ///// </summary>
        //public static SoftwareInfo m_SoftwareInfo = SoftwareInfo.getInstance();

        ///// <summary>
        ///// 系统运行模式 0：脱机模式 1：联机模式
        ///// </summary>
        //public static int m_systemRunMode =0;

        ///// <summary>
        ///// 异常图片路径
        ///// </summary>
        //public static string errorImagePath = "d:\\异常图片";

        ///// <summary>
        ///// 算法普通参数个数
        ///// </summary>
        //public static int AlgorithmNormalParasNum = 10;

        ///// <summary>
        ///// 算法普通参数个数
        ///// </summary>
        //public static int AlgorithmSeniorParasNum = 10;

        /// <summary>
        /// 阵列之前的起始操作步骤
        /// </summary>
        public static int m_startOperateStep = 0;

        /// <summary>
        /// 阵列之后的终止操作步骤
        /// </summary>
        public static int m_endOperateStep = 0;

        /// <summary>
        /// 是否提示异常
        /// </summary>
        public static bool m_isShowError = true;

        /// <summary>
        /// 异常信息列表
        /// </summary>
        public static List<string> m_errorInfos = new List<string>();



        /// <summary>
        /// 光源控制类
        /// </summary>
        public static LightControls m_lightControls = LightControls.CreateInstance();

        /// <summary>
        /// 相机参数类
        /// </summary>
        public static CameraS m_dicCameraS = new CameraS();

        /// <summary>
        /// 缺陷算法集合
        /// </summary>
        public static List<GenericAlgorithm> m_defectAlgorithmS = new List<GenericAlgorithm>();

        /// <summary>
        /// 可用缺陷算法集合
        /// </summary>
        public static List<GenericAlgorithm> m_EnabledefectAlgorithmS = new List<GenericAlgorithm>();

        /// <summary>
        /// 创建缺陷中间对象
        /// </summary>
        public static MeasureDefect m_MeasureDefect = new MeasureDefect();
        /// <summary>
        /// 创建尺寸中间对象
        /// </summary>
        public static MeasureSize m_MeasureSize = new MeasureSize();

        /// <summary>
        /// 尺寸算法集合
        /// </summary>
        public static ObservableCollection<SizeAlgorithm> m_sizeAlgorithmS = new ObservableCollection<SizeAlgorithm>();


        /// <summary>
        /// 尺寸算法集合
        /// </summary>
        public static ObservableCollection<SizeAlgorithm> m_EnablesizeAlgorithmS = new ObservableCollection<SizeAlgorithm>();

        ///// <summary>
        ///// 特殊区域算法集合
        ///// </summary>
        //public static List<GenericAlgorithm> m_specialRegionAlgorithmS = new List<GenericAlgorithm>();

         /// <summary>
        /// 批量生成框算法集合
        /// </summary>
        public static List<GenericAlgorithm> m_batchGenRectAlgorithmS = new List<GenericAlgorithm>();
        
          /// <summary>
        /// 批量模板生成框算法集合
        /// </summary>
        public static List<GenericAlgorithm> m_batchGenModelRectAlgorithmS = new List<GenericAlgorithm>();

          /// <summary>
        /// 多框模板阵列算法
        /// </summary>
        public static List<GenericAlgorithm> m_batchMultiGenModelRectAlgorithmS = new List<GenericAlgorithm>();
        
        
        ///// <summary>
        ///// 数据管理
        ///// </summary>
        //public static Product ProductDataManager = new Product();

        /// <summary>
        /// 通道1产品是否要重新加载
        /// </summary>
        public static bool NeedReloadChannel1 = false;
        /// <summary>
        /// 通道2产品是否要重新加载
        /// </summary>
        public static bool NeedReloadChannel2 = false;
        /// <summary>
        /// 处理定义测量不保存产品 需要在定义或者批量重新打开该产品的情况。
        /// </summary>
        public static List<bool> NeedReloadChannelProduct = new List<bool>() { NeedReloadChannel1, NeedReloadChannel2 };

        /// <summary>
        /// 通道1
        /// </summary>
        public static ProductChannel ProductChannel1 = new ProductChannel();

        /// <summary>
        /// 通道2
        /// </summary>
        public static ProductChannel ProductChannel2 = new ProductChannel();

        /// <summary>
        /// 通道列表
        /// </summary>
        public static List<ProductChannel> ProductChannelArray = new List<ProductChannel>() { ProductChannel1, ProductChannel2 };

        /// <summary>
        /// 用户管理
        /// </summary>
        //  public static UserXml UserManager = new UserXml();/////////////////////////////////////////////////////////////zyy


        /// <summary>
        /// halcon
        /// </summary>
        //  public static Ys.Algorithm.S130.HalconAlgorithm Halcon_Algorithm = new Ys.Algorithm.S130.HalconAlgorithm();//////////////////////////////////////////////////zyy


        /// <summary>
        /// 输入输出
        /// </summary>
        //  public static YSMS.S130Alarm.Alarm m_alarmIO = null;///////////////////////////////////////////////////zyy
        //片式标准的通信
        //   public static Communication m_Communication = Communication.getInstance();////////////////////////////////////////////zyy
        /// <summary>
        ///PLC、7230是否注册标志位
        /// </summary>
        public static bool IsCommunicationRegister = false;
        //通道1清空数据
        public static bool ClearPlc_1 = false;          
        //通道2清空数据
        public static bool ClearPlc_2 = false;

        //远程协助拷贝文件
        public static  bool ? RemmberInfo = false;
        public static bool ? RemmberImage = false;
        /// <summary>
        /// 远程协助拷贝文件
        /// </summary>
        public static bool ? RemmberInfo_Batch = false;
        public static bool ? RemmberImage_Batch = false;


        /// <summary>
        /// 保存OK文件
        /// </summary>
        public static bool ? OKImage_Batch_g = false;

        public static bool StartAssist = false;


        public static bool ShortcutKey = false;


        //  public static ProgressBarForm MyProgressBar = new ProgressBarForm();//////////////////////////////////////////////////zyy

        #region 定义测量


        /// <summary>
        ///  定义测量窗口
        /// </summary>
    //    public static DefineMeasureWindow DefineMeasureWindow;//////////////////////////////////////////////////zyy

        /// <summary>
        /// 定义测量使用的通道序号
        /// </summary>
        public static int DefineChannelIndex = 0;

        /// <summary>
        /// 定义测量当前产品工位管理
        /// </summary>
        public static Station StationDataManager = null;

        /// <summary>
        /// 定义测量当前模板数据管理
        /// </summary>
        public static Model ModelDataManager = new Model();

        /// <summary>
        /// 定义测量当前绘图引擎
        /// </summary>
       // public static DrawingEnergy DefineDrawingEnergy = new DrawingEnergy();///////////////////////////////////////////////zyy

        /// <summary>
        /// 定义测量缩放的comboBox
        /// </summary>
        public static ComboBox DefineZoomComboBox = new ComboBox();

        //复制参数
        public static MeasureDefect CopyDefect = new MeasureDefect();

        //复制工位所有信息
        //public static Model CopyStationDefect = new Model();
        public static List<Model> CopyStationDefectList = new List<Model>() { { new Model() }, { new Model() }, { new Model() }, { new Model() } };

        //复制单模板参数
        public static List<Model> CopyModelDefectList = new List<Model>() { { new Model() }, { new Model() }, { new Model() }, { new Model() } };

        //上一值
        public static MeasureDefect OrginDefect = new MeasureDefect();

        //复制尺寸参数
        public static MeasureSize CopySizeDefect = new MeasureSize();

        //尺寸上一值
        public static MeasureSize OrginSizeDefect = new MeasureSize();
        //MeasureSize md = SizelistBox.SelectedItem as MeasureSize;
        //        md.Copy(TempMeasureSize);

        public enum MoveType
        {
            UpAdd=384,
            UpSubtract=382,
            DownAdd=404,
            DownSubtract = 402,
            LeftAdd=374,
            LeftSubtract=372,
            RightAdd = 394,
            RightSubtract=392,
            Up = 380,            
            Down = 400,
            Left=370,
            Right=390,
            Copy = 672,
            Paste = 862,
        
        }

        /// <summary>
        /// 改变框形状的方式
        /// </summary>
        public static int NowMoveType=0;

        public static bool NowMoveRegion = false ;

        public static bool  NowMoveLocation = false;

        public static bool NowMoveDefect = false;

        /// <summary>
        /// 键盘事件注册
        /// </summary>
        //public static bool RegisterKeyFlag = false;

        

        ///// <summary>
        ///// 定义测量当前窗口
        ///// </summary>
        //public static HWindowControlWPF DefineCurrentHWindow = new HWindowControlWPF();

        ///// <summary>
        ///// 定义测量的图像
        ///// </summary>
        //public static HObject[] Define_Images = new HObject[3];


        ///// <summary>
        ///// 定义测量分通道后的的图像
        ///// </summary>
        //public static HObject[] Define_Intensitys = new HObject[3];


        #endregion

        #region 批量测量

        /// <summary>
        ///通道1是否有产品
        /// </summary>
        public static bool BatchHasProductChannel1 = false;

        /// <summary>
        ///通道2是否有产品
        /// </summary>
        public static bool BatchHasProductChannel2 = false;

        /// <summary>
        ///通道1批量测量是否正在运行
        /// </summary>
        public static bool BatchMeasureRunning1 = false;

        /// <summary>
        ///通道2批量测量是否正在运行
        /// </summary>
        public static bool BatchMeasureRunning2 = false;

        /// <summary>
        /// 通道1编码器值
        /// </summary>
        public static double  Channel1Code = 0;

        /// <summary>
        /// 通道2编码器值
        /// </summary>
        public static double Channel2Code = 0;

        /// <summary>
        /// 设置料带单位 1代表mm 1000代表m
        /// </summary>
        public static int SetUnit = 1;

        public static bool IsshowSpeed = false;

        /// <summary>
        /// 频场图片保存路径加名称
        /// 
        /// 产品配置路\\+通道名称\\产品名称+产品号"
        /// </summary>
        public static string savePCImgPath = "";

        /// <summary>
        /// 频场校正原图
        /// </summary>
        public static string savePC_temp_ImgName = "tempImg.bmp";
        /// <summary>
        /// 频场校正图
        /// </summary>
        public static string savePC_JZ_ImgName = "jcImg.bmp";


        /// <summary>
        /// 顺德报警记录
        /// </summary>
        //public static string AlarmImagePath = ""  ;
        //public static string AlarmImageType = ""  ;

        

        /// <summary>
        /// 设置通道编码器值
        /// </summary>
        /// <param name="ChannelNo"></param>
        /// <param name="CodeNum"></param>
        public static void SetChannelCode(int ChannelNo, double CodeNum)
        {
            if (ChannelNo == 0)
            {
                Channel1Code =Convert.ToDouble (CodeNum / SoftwareInfo.getInstance().DistanceToAlarmCode *SoftwareInfo.getInstance().UniteLenth);
            }
            else if (ChannelNo == 1)
            {
                Channel2Code = Convert.ToDouble(CodeNum / SoftwareInfo.getInstance().DistanceToAlarmCode * SoftwareInfo.getInstance().UniteLenth2);
            }
        }

        /// <summary>
        /// 获取通道编码器值
        /// </summary>
        /// <param name="ChannelNo"></param>
        /// <returns></returns>
        public static double GetChannelCode(int ChannelNo)
        {
            double ret = 0;
            if (ChannelNo == 0)
            {
                ret = Channel1Code;
            }
            else if (ChannelNo == 1)
            {
                ret = Channel2Code;
            }
            return ret;
        }

        /// <summary>
        ///批量测量测量组
        /// </summary>
        public static string MeasureGroup = null;

        /// <summary>
        /// 批量测量测量组中的流水号
        /// </summary>
        public static string SerialNumber = null;

        /// <summary>
        /// 批量测量窗口
        /// </summary>
     //   public static BatchMeasureWindow BatchMeasureWindow;//////////////////////////////////////////////////zyy

        public static string UnitStr = "*1";
        public static string UnitStr1 = "*1";

        public static bool IsReadKeyVal = true;

        public static void ShowUnit(int channelNo,int unit)
        { 
            switch (unit)
            {
                case 1:
                    if (channelNo == 0)
                    {
                        UnitStr = "(*1)";
                    }
                    else
                    {
                        UnitStr1 = "(*1)";
                    }
                    break ;
                case 1000:
                    if (channelNo == 0)
                    {
                        UnitStr = "(*10^3)";
                    }
                    else
                    {
                        UnitStr1 = "(*10^3)";
                    }
                    break ;
                case 1000000:
                    if (channelNo == 0)
                    {
                        UnitStr = "(*10^6)";
                    }
                    else
                    {
                        UnitStr1 = "(*10^6)";
                    }
                    break ;
            
            }
        
        }

        // Qiyi Li 20200307
        public static int VInterval = 0;
        public static bool StartLearnV = false;
        
        #endregion

        #region "定义程序时全局参数"

        /// <summary>
        /// 当前工位编号
        /// </summary>
        public static string m_nowStationNo = "01";

        #endregion

        public static bool Save(int channelNo)
        {
            bool ret = true;

            ProductChannel channel = ProductChannelArray[channelNo];
            if (channel.IsEnable)
            {
                //检验model是否真的已经生成
                foreach (var v in channel.ProductData.StationList)
                {
                    foreach (var model in v.ModeList)
                    {
                            if (model.generateModeParas.IsGenerateModel)
                            {
                                model.IsEnable = true;
                            }
                            else
                            {
                                model.IsEnable = false;
                            }
                    }
                }

                string fileName = InfoPath.getInstance().ProductPath + "\\" + channel.ChannelName + "\\" + channel.ProductData.ProductName + "\\product.xml";

                using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    if (File.Exists(fileName))
                    {
                        System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Product));
                        xmlSerializer.Serialize(fStream, channel.ProductData);
                    }
                    else
                    {
                        Console.WriteLine("暂无此文件：" + fileName);
                        //MessageBox.Show("暂无此文件：" + fileName);
                    }
                }
            }

            return ret;
        }


        public static string Load(int channelIndex, string path)
        {

            string ret = string.Empty;
            try
            {
                if (File.Exists(path + "\\product.xml"))
                {
                    using (Stream fStream = File.OpenRead(path + "\\product.xml"))
                    {
                        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Product));
                        ProductChannelArray[channelIndex].ProductData = serializer.Deserialize(fStream) as Product;
                    }
                    ProductChannelArray[channelIndex].IsEnable = true;
                }
                else
                {
                    ProductChannelArray[channelIndex].IsEnable = false;
                }
                if (ProductChannelArray[channelIndex].IsEnable == true)
                {

                    Global.m_dicCameraS.SetCamerasGrabActionMode(0, false);
                    Global.m_dicCameraS.SetCamerasGrabActionMode(1, false);

                    foreach (var v in ProductChannelArray[channelIndex].ProductData.StationList)
                    {
                        foreach (var model in v.ModeList)
                        {
                            if (model.IsEnable)
                            {
                                string stationPath = InfoPath.getInstance().ProductPath + "\\" + ProductChannelArray[channelIndex].ChannelName + "\\" + ProductChannelArray[channelIndex].ProductData.ProductName + "\\" + v.StationNo + "\\";
                                string modelfilePath = stationPath + "Model" + model.ModelNo + ".shm";
                                string Imagepath = stationPath + "Model" + model.ModelNo + ".bmp";

                                if (File.Exists(modelfilePath))
                                {
                                    HTuple ReadError = new HTuple();//函数执行成功标志位
                                    List<double> CreateParaList = new List<double>();
                                    CreateParaList.Add(model.generateModeParas.LightOrDark);
                                    CreateParaList.Add(v.ImageChannel);
                                    CreateParaList.Add(model.generateModeParas.RangeProduct);
                                    CreateParaList.Add(model.generateModeParas.Angle_Modle);
                                    CreateParaList.Add(model.generateModeParas.Select_MD);
                                    CreateParaList.Add(model.generateModeParas.IsClosedZone);
                                    CreateParaList.Add(model.generateModeParas.MinScore);
                                    CreateParaList.Add(model.generateModeParas.RangeLocation);
                                    //zyh 20190531
                                    foreach (var defect in model.MeasureDefectList)
                                    {
                                        if (defect.DefectAlgorithm.PrecisionLevel != 0 && defect.DefectAlgorithm.PrecisionLevel != 1)
                                        {
                                            defect.DefectAlgorithm.PrecisionLevel = 1;
                                        }
                                    }
                                    CreateParaList.Add(model.generateModeParas.ModelPriority);
                                    CreateParaList.Add(model.generateModeParas.DetectionOver);
                                    CreateParaList.Add(Global.ModelDataManager.generateModeParas.LocationType);
                                    CreateParaList.Add(model.generateModeParas.DirectionY);
                                    CreateParaList.Add(model.generateModeParas.DirectionX);
                                    CreateParaList.Add(model.generateModeParas.StretchY);
                                    CreateParaList.Add(model.generateModeParas.StretchX);
                                    model.hv_Create_Range_Tuple = CreateParaList.ToArray();

                                    if (SoftwareInfo.getInstance().IsAlgorithmUseModel)
                                    {

                                        /*  Halcon_Algorithm.Read_Model_Varmodel(out model.generateModeParas.Region, stationPath + "Model", model.ModelNo, model.hv_Create_Range_Tuple,
                                              out model.generateModeParas.ModelID, out model.generateModeParas.ModelID_LH, out model.generateModeParas.VarModelID, out ReadError);

                                          Halcon_Algorithm.Read_Model_New4Region(out model.generateModeParas.Region_BigArea, out model.generateModeParas.Region_Column,
                                              out model.generateModeParas.Region_Row, out model.generateModeParas.Region_Remove, stationPath + "Model", model.ModelNo);*///////////////////////////////////////////////////zyy
                                    }
                                    model.Contour = model.generateModeParas.Region;
                                }

                                if (!File.Exists(Imagepath))
                                {
                                    ret += Imagepath + " 图像不存在!\r\n";
                                }
                                else
                                {
                                    HOperatorSet.ReadImage(out model.generateModeParas.ModelImage, Imagepath);
                                    HOperatorSet.ReadImage(out model.generateModeParas.TempImage, Imagepath);
                                }
                            }
                        }
                    }

                    Global.m_dicCameraS.SetCamerasGrabActionMode(0, true);
                    Global.m_dicCameraS.SetCamerasGrabActionMode(1, true);
                }

                savePCImgPath = InfoPath.getInstance().ProductPath + "\\" + ProductChannelArray[DefineChannelIndex].ChannelName
                                       + "\\" + ProductChannelArray[DefineChannelIndex].ProductData.ProductName + InfoPath.getInstance().ProductNo;

            }
            catch (System.Exception ex)
            {
                Global.m_dicCameraS.SetCamerasGrabActionMode(0, true);
                Global.m_dicCameraS.SetCamerasGrabActionMode(1, true);

                SoftwareInfo.getInstance().WriteLog("Load:\n"+ex.ToString ());
                ret += ex.Message;
            }

            return ret;
        }


        /// <summary>
        /// 频闪方式采图开始
        /// </summary>
        public static void IsGrab(bool isStart)
        {
            if (SoftwareInfo.getInstance().IsStrobe && SoftwareInfo.getInstance().SystemRunMode == 1)
            {
                //   Global.m_alarmIO.Grab(isStart);//////////////////////////////////////////////////zyy
            }

        }   

        public static string ClearData(int channelNo)
        {
            string ret = string.Empty;
            Global.ProductChannelArray[channelNo].IsEnable = false;
            Global.ProductChannelArray[channelNo].ProductData = new Product(0, 0);
            return ret;
        }



        //生成所有模板的算法所需参数
        public static string GenerateModelHalconParas(int channelNo)
        {
            string ret = string.Empty;

            try
            {
                ProductChannel channel = ProductChannelArray[channelNo];
                if (!string.IsNullOrEmpty(channel.ProductData.ProductName))
                {
                    foreach (var v in channel.ProductData.StationList)
                    {
                        foreach (var model in v.ModeList)
                        {
                            if (model.IsEnable)
                            {
                                if (0 != model.GenerateHalconParas(SoftwareInfo.getInstance().AlgorithmNormalParasNum, SoftwareInfo.getInstance().AlgorithmSeniorParasNum, v))
                                {
                                    ret += "通道" + channel.ChannelName + "产品" + channel.ProductData.ProductName + "工位" + v.StationNo + "模版" + model.ModelNo
                                        + "生成参数错误\r\n";
                                }

                            }

                        }
                    }
                }
            }
            catch(Exception ex)
            {
                string str ="GenerateModelHalconParas  生成模板参数出错:\n"+ ex.ToString();
                SoftwareInfo.getInstance().WriteLog("GenerateModelHalconParas:\n"+str);               
                ret += "GenerateModelHalconParas  生成模板参数出错";
            }

            return ret;
        }


        //生成单个模板的算法所需参数
        public static string GenerateModelHalconParas(int channelNo, int stationNo, int modelNo)
        {
            string ret = string.Empty;
            try
            {
                ProductChannel channel = ProductChannelArray[channelNo];
            
                if (!string.IsNullOrEmpty(channel.ProductData.ProductName))
                {
                    Station station = channel.ProductData.StationList[stationNo];
                    Model model = station.ModeList[modelNo];

                    if (0 != model.GenerateHalconParas(SoftwareInfo.getInstance().AlgorithmNormalParasNum, SoftwareInfo.getInstance().AlgorithmSeniorParasNum, station))
                    {
                        ret += "通道" + channel.ChannelName + "产品" + channel.ProductData.ProductName + "工位" + station.StationNo + "模版" + model.ModelNo
                            + "生成参数错误\r\n";
                    }
                }
              
            }
            catch(Exception ex)
            {
                string str = "GenerateModelHalconParas  生成模板参数出错:\n" + ex.ToString();
                SoftwareInfo.getInstance().WriteLog("GenerateModelHalconParas:\n"+str);
                ret += "GenerateModelHalconParas  生成模板参数出错";
            }
            return ret;
        }
        #region 强制关闭
        public static void ShutdownNow()
        {
            //关闭所有Excel进程
            Process[] YSMSProcess = Process.GetProcessesByName("YSMS_130Standard");
            foreach (Process p in YSMSProcess)
            {
                p.Kill();
            }
            Process now = Process.GetCurrentProcess();
            now.Kill();
        }
        #endregion

        public static uint PLCInformation = 0;

        public static uint OKNum = 0;

        public static uint NGNum = 0;

        public static uint OKNumCh2 = 0;

        public static uint NGNumCh2 = 0;

        public static uint ResetStr = 0;

        #region 图像编码值
        public static List<int> StationImageCodeList1 = new List<int>() { 0, 0, 0, 0, 0, 0 };
        public static List<int> StationImageCodeList2 = new List<int>() { 0, 0, 0, 0, 0, 0 };

        public static List<int> StationImageCodeList = new List<int>() { 0, 0, 0, 0, 0, 0 };
        public static List<int> StationImageCodeStateList = new List<int>() { 0, 0, 0, 0, 0, 0 };

        //获取编码器值
        public static int GetStationImageCode(int channelNo,int StationNo)
        {
            int ret = 0;
            //if (StationImageCodeList1.Count > StationNo)
            //{
            //    if (channelNo == 0)
            //    {
            //        ret = StationImageCodeList1[StationNo];
            //    }
            //    else
            //    {
            //        ret = StationImageCodeList2[StationNo];
            //    }
            //}

            if (channelNo == 0)
            {
                ret = StationImageCodeList1[StationNo];
            }
            else
            {
                ret = StationImageCodeList2[StationNo];
            }

            //Console.WriteLine("Code: >>>>>>>>>>>>>>> " + ret);

            return ret;
        }
        
        #endregion

        #region 远程协助文件
        /// <summary>
        /// [0]帮助文件路径 [1]配置文件路径 
        /// </summary>
        /// <param name="FilePathList"></param>
        public static void AssistFile(string str)
        {
            string path = SoftwareInfo.getInstance().AssistFilesInfoPath ;
            string pathFinnal = path + "\\" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")+"-"+str;
            SoftwareInfo.getInstance().AssistFilesPartInfoPath = pathFinnal;
            SoftwareInfo.getInstance().AssistParasPath = pathFinnal + "\\参数文件";
            SoftwareInfo.getInstance().AssistInfoPath = pathFinnal + "\\配置文件";     
            
            
            if (!Directory.Exists(path))
            {              
                Directory.CreateDirectory(SoftwareInfo.getInstance().AssistInfoPath);  
            }


            //配置文件
            //   Tools.copyDirectory(InfoPath.getInstance().Path + "\\conf", SoftwareInfo.getInstance().AssistInfoPath);//////////////////////////////////////////////////zyy
            //产品文件
            //BasicTool.copyDirectory(productPath + "\\conf", pathFinnal);
            //日志文件
            //BasicTool.copyDirectory(SoftwareInfo.getInstance().LogPath, pathFinnal);
        }

        /// <summary>
        /// 远程协助保存图片
        /// </summary>
        /// <param name="path"></param>
        /// <param name="picName">图片名称</param>
        /// <param name="paraStr">HelpFiles\2017-07-21 16-56-32-批量\参数文件\批量测量\缺陷检测\工位1</param>
        /// <param name="paraType">缺陷检测参数</param>
        /// <param name="image">处理原图</param>
        /// <param name="t">图片处理时间</param>        
        public static void saveAssistImage(string path, string picName, string paraStr, string paraType, HTuple HalconWindow, HObject image, string t, string stateString)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            Write_Paras(paraStr, path + "\\" + t + paraType + stateString + ".txt");
            HOperatorSet.DumpWindow(HalconWindow, "bmp", path + "\\" + t + picName + "-" + stateString + "截图" + ".bmp");
            HOperatorSet.WriteImage(image, "bmp", 0, path + "\\" + t + picName + "-" + stateString + "原图1" + ".bmp");
        }

        public static void Write_Paras(string str, string historyDirectory)
        {
            
            if (!File.Exists(historyDirectory))
            {
                FileStream fs1 = new FileStream(historyDirectory, FileMode.Create, FileAccess.Write);//创建写入文件 
                fs1.Close();
            }
            if (File.ReadAllLines(historyDirectory) == null)
            {
                CreateOneLine(str, historyDirectory);
            }
            else
            {
                AppendOneLine(str, historyDirectory);
            }
        }

        /// <summary>
        /// 在文本文件创建一行
        /// </summary>
        /// <param name="strLineInfo">插入内容</param>
        /// <param name="strFilePath">文件路径</param>
        private static void CreateOneLine(string strLineInfo, string strFilePath)
        {
            FileStream fileStream = new FileStream(strFilePath, FileMode.Create, FileAccess.Write);//创建写入文件
            StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8);
            sw.WriteLine(strLineInfo);//开始写入值
            sw.Close();
            fileStream.Close();
        }

        /// <summary>
        /// 在文本文件增加一行
        /// </summary>
        /// <param name="strLineInfo">插入内容</param>
        /// <param name="strFilePath">文件路径</param>
        private  static void AppendOneLine(string strLineInfo, string strFilePath)
        {
            FileStream fileStream = new FileStream(strFilePath, FileMode.Append, FileAccess.Write);//创建写入文件
            StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8);
            sw.WriteLine(strLineInfo);//开始写入值
            sw.Close();
            fileStream.Close();
        }

        #endregion

        #region 全局快捷键

        public static void UnRegisterShortcutKey()
        {
            IntPtr Handle= new IntPtr();
            //    IntPtr Handle = new WindowInteropHelper(Global.DefineMeasureWindow).Handle;//////////////////////////////////////////////////zyy
            HotKey.Unregister(Handle, HotKey.KeyFlags.MOD_SHIFT, System.Windows.Forms.Keys.Up);
            HotKey.Unregister(Handle, HotKey.KeyFlags.MOD_CONTROL, System.Windows.Forms.Keys.Up);
            HotKey.Unregister(Handle, HotKey.KeyFlags.MOD_SHIFT, System.Windows.Forms.Keys.Down);
            HotKey.Unregister(Handle, HotKey.KeyFlags.MOD_CONTROL, System.Windows.Forms.Keys.Down);
            HotKey.Unregister(Handle, HotKey.KeyFlags.MOD_SHIFT, System.Windows.Forms.Keys.Left);
            HotKey.Unregister(Handle, HotKey.KeyFlags.MOD_CONTROL, System.Windows.Forms.Keys.Left);
            HotKey.Unregister(Handle, HotKey.KeyFlags.MOD_SHIFT, System.Windows.Forms.Keys.Right);
            HotKey.Unregister(Handle, HotKey.KeyFlags.MOD_CONTROL, System.Windows.Forms.Keys.Right);

            HotKey.Unregister(Handle, HotKey.KeyFlags.MOD_NONE, System.Windows.Forms.Keys.Up);
            HotKey.Unregister(Handle, HotKey.KeyFlags.MOD_NONE, System.Windows.Forms.Keys.Down);
            HotKey.Unregister(Handle, HotKey.KeyFlags.MOD_NONE, System.Windows.Forms.Keys.Left);
            HotKey.Unregister(Handle, HotKey.KeyFlags.MOD_NONE, System.Windows.Forms.Keys.Right);

            HotKey.Unregister(Handle, HotKey.KeyFlags.MOD_CONTROL, System.Windows.Forms.Keys.C);
            HotKey.Unregister(Handle, HotKey.KeyFlags.MOD_CONTROL, System.Windows.Forms.Keys.V);

            HotKey.KeyPair.Clear();

        }


        public static  void RegisterShortcutKey()
        {
            /*
            HotKey upAdd = new HotKey(Global.DefineMeasureWindow, HotKey.KeyFlags.MOD_SHIFT, System.Windows.Forms.Keys.Up);
            HotKey upSubtract = new HotKey(Global.DefineMeasureWindow, HotKey.KeyFlags.MOD_CONTROL, System.Windows.Forms.Keys.Up);
            HotKey downAdd = new HotKey(Global.DefineMeasureWindow, HotKey.KeyFlags.MOD_SHIFT, System.Windows.Forms.Keys.Down);
            HotKey downSubtract = new HotKey(Global.DefineMeasureWindow, HotKey.KeyFlags.MOD_CONTROL, System.Windows.Forms.Keys.Down);
            HotKey leftAdd = new HotKey(Global.DefineMeasureWindow, HotKey.KeyFlags.MOD_SHIFT, System.Windows.Forms.Keys.Left);
            HotKey leftSubtract = new HotKey(Global.DefineMeasureWindow, HotKey.KeyFlags.MOD_CONTROL, System.Windows.Forms.Keys.Left);
            HotKey rightAdd = new HotKey(Global.DefineMeasureWindow, HotKey.KeyFlags.MOD_SHIFT, System.Windows.Forms.Keys.Right);
            HotKey rightSubtract = new HotKey(Global.DefineMeasureWindow, HotKey.KeyFlags.MOD_CONTROL, System.Windows.Forms.Keys.Right);

            HotKey up = new HotKey(Global.DefineMeasureWindow, HotKey.KeyFlags.MOD_NONE, System.Windows.Forms.Keys.Up);
            HotKey down = new HotKey(Global.DefineMeasureWindow, HotKey.KeyFlags.MOD_NONE, System.Windows.Forms.Keys.Down);
            HotKey left = new HotKey(Global.DefineMeasureWindow, HotKey.KeyFlags.MOD_NONE, System.Windows.Forms.Keys.Left);
            HotKey right = new HotKey(Global.DefineMeasureWindow, HotKey.KeyFlags.MOD_NONE, System.Windows.Forms.Keys.Right);

            HotKey copy = new HotKey(Global.DefineMeasureWindow, HotKey.KeyFlags.MOD_CONTROL, System.Windows.Forms.Keys.C);
            HotKey paste = new HotKey(Global.DefineMeasureWindow, HotKey.KeyFlags.MOD_CONTROL, System.Windows.Forms.Keys.V);

            //HotKey.OnHotkeyEventHandeler s = new HotKey.OnHotkeyEventHandeler(k_OnHotKey);
            //object o = 1;
            //s.Invoke(2);


            upAdd.OnHotKey += new HotKey.OnHotkeyEventHandeler(k_OnHotKey);
            upSubtract.OnHotKey += new HotKey.OnHotkeyEventHandeler(k_OnHotKey);
            downAdd.OnHotKey += new HotKey.OnHotkeyEventHandeler(k_OnHotKey);
            downSubtract.OnHotKey += new HotKey.OnHotkeyEventHandeler(k_OnHotKey);
            leftAdd.OnHotKey += new HotKey.OnHotkeyEventHandeler(k_OnHotKey);
            leftSubtract.OnHotKey += new HotKey.OnHotkeyEventHandeler(k_OnHotKey);
            rightAdd.OnHotKey += new HotKey.OnHotkeyEventHandeler(k_OnHotKey);
            rightSubtract.OnHotKey += new HotKey.OnHotkeyEventHandeler(k_OnHotKey);

            up.OnHotKey += new HotKey.OnHotkeyEventHandeler(k_OnHotKey);
            down.OnHotKey += new HotKey.OnHotkeyEventHandeler(k_OnHotKey);
            left.OnHotKey += new HotKey.OnHotkeyEventHandeler(k_OnHotKey);
            right.OnHotKey += new HotKey.OnHotkeyEventHandeler(k_OnHotKey);

            copy.OnHotKey += new HotKey.OnHotkeyEventHandeler(k_OnHotKey);
            paste.OnHotKey += new HotKey.OnHotkeyEventHandeler(k_OnHotKey);
            *///////////////////////////////////////////////////zyy

        }



        private static  void k_OnHotKey(int num)
        {
            Global.NowMoveType = num;

            //return true;
        }
        #endregion

        /// <summary>
        /// 写文件，异常写入
        /// </summary>
        /// <param name="str"></param>
        public  static void WriteLog(string str)
        {
            try
            {
                List<string> ListErrLogFileName = new List<string>() { };
                List<string> timeList = new List<string>() { };
                string[] strArray = new string[] { };
                ListErrLogFileName = Directory.GetFiles(SoftwareInfo.getInstance().ErrorLogPath).ToList();
                int count = 0;

                foreach (string ErrLogFileName in ListErrLogFileName)
                {
                    strArray = ErrLogFileName.Split(' ');
                    timeList.Add(strArray[strArray.Length - 1].Split('.')[0]);
                }
                foreach (string time in timeList)
                {

                    //相等：0 小于today：1 大于today：-1
                    DateTime fileTime = Convert.ToDateTime(time);
                    DateTime fileTimeNew = fileTime.AddDays(SoftwareInfo.getInstance().SaveErrorLogTime);

                    if (DateTime.Today.CompareTo(fileTimeNew) == 1)
                    {
                        File.Delete(ListErrLogFileName[count]);
                    }
                    //dates t = DateTime.Today-fileTime;
                    count++;
                }
                string path = SoftwareInfo.getInstance().ErrorLogPath;
                string pathtxt = path + "\\ErrLog " + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (StreamWriter sw = new StreamWriter(pathtxt, true))
                {
                    sw.WriteLine(DateTime.Now.ToString());
                    sw.WriteLine(str);
                    sw.WriteLine("---------------------------------------------------------");
                    sw.Close();
                }
            }
            catch(Exception ex)
            {
                WriteLog(ex.Message);
            }
        }

        private static  string timeStr = "";
        private static string pathPictxt = "";
        private static List<string> picList = new List<string>() { };
        /// <summary>
        /// 写文件，图片信息
        /// </summary>
        /// <param name="str"></param>
        public static void WritePicLog(int channelNo, List< string> strList)
        {           
            try
            {
                //存在多线程访问同一文件占用问题，暂时不启用 wuqh 20200102
                return;

                //DateTime.Now.ToString("HH-mm-ss-fff")
#pragma warning disable CS0162 // 检测到无法访问的代码
                string str = "";
#pragma warning restore CS0162 // 检测到无法访问的代码
                if (strList.Count < 6)
                {
                    return;
                }
               
                for (int i = strList.Count - 6; i < strList.Count; i++)
                { str += strList[i]+"\t"; }
                string path = SoftwareInfo.getInstance().OriginImagePath + "\\标记异常\\" + DateTime.Now.ToString("yyyy-MM-dd");
                if (strList.Count > 6)
                {
                    path += "\\" + strList[5] + "\\" + strList[6];
                }
                if (!Directory.Exists(path))
                {

                    Directory.CreateDirectory(path);
                    
                }
                //SoftwareInfo.getInstance().PicInfoPath = path ;
                if (string.IsNullOrEmpty(pathPictxt))
                {
                    pathPictxt =path+ SoftwareInfo.getInstance().PicInfoPath;
                }

                
                if (File.Exists(pathPictxt))
                {
                    picList.Clear();
                    picList = File.ReadAllLines(pathPictxt).ToList ();
                }
                if (picList.Count > 0 && picList.Count<5000)
                {
                    if (!File.Exists(path + SoftwareInfo.getInstance().PicInfoPath))
                    {
                        timeStr = DateTime.Now.ToString("HH-mm-ss-fff");
                        pathPictxt = path + "\\缺陷信息_" + timeStr + ".txt";
                        SoftwareInfo.getInstance().PicInfoPath = "\\缺陷信息_" + timeStr + ".txt";
                    
                    }
                    using (StreamWriter sw = new StreamWriter(pathPictxt, true))
                    {
                        sw.WriteLine(str);
                        sw.Close();
                    }
                }
                else
                {
                    timeStr = DateTime.Now.ToString("HH-mm-ss-fff");
                    pathPictxt = path + "\\缺陷信息_" + timeStr + ".txt";
                    SoftwareInfo.getInstance().PicInfoPath = "\\缺陷信息_" + timeStr + ".txt";

                    using (StreamWriter sw = new StreamWriter(pathPictxt, true))
                    {
                        sw.WriteLine("型号\t批号\t通道\t工位\t缺陷名称\t图片名称\t倍数");
                        if (channelNo == 0)
                        {
                            sw.WriteLine(str + Global.UnitStr);
                        }
                        else
                        {
                            sw.WriteLine(str + Global.UnitStr1);
                        }
                        sw.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("写入图片信息出错！"+ex.Message .ToString () );
            }
        }


        /// <summary>
        /// 写文件，编码值清0记录
        /// </summary>
        /// <param name="str"></param>
        public static void WriteClrEncoderLog(int channelNo,string str)
        {
            try
            {

                string path = SoftwareInfo.getInstance().OriginImagePath + "\\标记异常\\" + DateTime.Now.ToString("yyyy-MM-dd");
                string pathtxt = path + "\\编码值清0记录表.txt";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (StreamWriter sw = new StreamWriter(pathtxt, true))
                {
                    if (channelNo == 0)
                    {
                        sw.WriteLine("编码值清0;清0值：" + str + UnitStr + ";时间：" + DateTime.Now.ToString("HH-mm-ss-fff"));
                    }
                    else
                    {
                        sw.WriteLine("编码值清0;清0值：" + str + UnitStr1 + ";时间：" + DateTime.Now.ToString("HH-mm-ss-fff"));
                    }
                    sw.Close();
                }

            }
            catch
            { }
        }

        public static void DeleteFileDir(string srcPath)
        {
            try
            {
                if (!Directory.Exists(srcPath))
                {
                    return;
                }
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }

                Directory.Delete(srcPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("DelectFileDir()异常！" + ex.Message);
            }
        }

    }
}
