using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YSMS_SZSK.Basic.PublicClass;
using YSMS_SZSK.Communication;
using YSMS_SZSK.CustomerDataManager;

namespace YSMS_SZSK.CustomerGlobal
{
    public static class Global
    {
        public static HTuple hv_Image_Path = "";
        public static HTuple hv_Model_Path = @"D:\YSMS_D100_Info\config\model.shm";
        public static HTuple hv_RectROI = new HTuple(1095.77, 1718.66, -1.76279, 400.897, 73.0748, 1119.86, 921.487, -1.33505, 400.897, 73.0748);
        /// <summary>
        /// 定义是否拍照(0否1是)
        /// </summary>
        public static int IsdefineTakePhoto = 0;
        public static ProfileToleranceParas profileTolerancePara = new ProfileToleranceParas();
        public static string ProfileToleranceProductFilePath = @"D:\YSMS_D100_Info\TolerancePosition\Products";

        //public static double X_scale = 0.0421;
        //public static double Y_scale = 0.0421;
        ///// <summary>
        ///// 0=关闭maltab窗口 1=打开
        ///// </summary>
        //public static double IsShowMatlabWindow = 1;
        /// <summary>
        /// 定义界面
        /// </summary>
        /// 

        public static MainWindow m_DefineMeasureWindow = null;



        /// <summary>
        /// 系统运行模式 0：脱机模式 1：联机模式
        /// </summary>
        public static int m_systemRunMode = 1;

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
        /// 当前选中元素
        /// </summary>
        public static Element m_SelectElement = null;

        /// <summary>
        /// 用户等级
        /// </summary>
        public static int UserLevel = -1;


        #region  程序修复
        /// <summary>
        /// 程序修复 
        /// </summary>
        public static PublicEnum.OpenDefineMeasureType m_OpenDefineMeasureType = PublicEnum.OpenDefineMeasureType.Nomal;

        public static HalconDotNet.HObject m_programReapairHObjectImage = null;
        public static HalconDotNet.HObject m_programReapairHObjectZippedImage = null;
        public static System.Windows.Media.Imaging.BitmapImage m_programReapairBitmapImageSource = null;
        #endregion


        /// <summary>
        /// 操作树文字配对字典
        /// </summary>
        public static SortedDictionary<PublicEnum.AllModuleType, string> m_AllModuleType = new SortedDictionary<PublicEnum.AllModuleType, string>();

        /// <summary>
        /// 测量元素名称文字配对字典
        /// </summary>
        public static SortedDictionary<PublicEnum.MeasureElementSubType, string> m_ElementNameType = new SortedDictionary<PublicEnum.MeasureElementSubType, string>();

        /// <summary>
        /// 元素预置名称集合
        /// </summary>
        public static Dictionary<string, int> m_predefineNameIDs = new Dictionary<string, int>();

        /// <summary>
        /// 当前选中的预置名称
        /// </summary>
        public static string m_choosedPreName = "";


        /// <summary>
        /// 数据管理
        /// </summary>
        public static DataManager m_DataManager = new DataManager();

        
       
        /// <summary>
        /// 软件参数
        /// </summary>
        public static SoftwareParas m_SoftwareParas = new SoftwareParas();

        /// <summary>
        /// 图像获取-运动参数（X轴）
        /// </summary>
        public static PlatformControlParas m_PlatformControlParasX = new PlatformControlParas();
        
        /// <summary>
        /// 公共变量实例 
        /// </summary>
        public static PublicVariable m_Pvb = new PublicVariable();

        /// <summary>
        /// 公共函数实例
        /// </summary>
      //  public static PublicFunction m_Pfc = new PublicFunction();//**********************************
        

        #region "定义测量（操作提示）+右侧UC界面中 温馨提示"

        public static Dictionary<PublicEnum.AllModuleType, string> m_dicTiShiCreate = new Dictionary<PublicEnum.AllModuleType, string>();

        public static Dictionary<PublicEnum.AllModuleType, string> m_dicWenXinCreate = new Dictionary<PublicEnum.AllModuleType, string>();


        public static Dictionary<PublicEnum.AllModuleType, string> m_dicTiShiEdit = new Dictionary<PublicEnum.AllModuleType, string>();

        public static Dictionary<PublicEnum.AllModuleType, string> m_dicWenXinEdit = new Dictionary<PublicEnum.AllModuleType, string>();

        #endregion

       /*********************************************************
        public static ProfileToleranceProduct toleranceProduct = new ProfileToleranceProduct();

        public static YsModule.ModuleList m_ModuleList = new YsModule.ModuleList();*/

        #region 自动对焦全局
        /// <summary>
        /// 自动对焦时选的区域框ROI
        /// </summary>
        public static HalconDotNet.HTuple RectValue = null;

        public static bool IsFoucsing = false;

        public static bool IsFoucsingSaveimage = false;
        #endregion

       
        public static LightControlConfig lightSerialControl = new LightControlConfig();
        
        public static Lights lights = new Lights();

        public static void lightControlLoad()
        {
            if (1 == Global.m_systemRunMode)
            {
                foreach (var item in Global.lightSerialControl.lightControlList)
                {
                    item.Register();
                    item.Open();
                    item.ChannelON(Global.lights.Light1, Global.lights.Light2, Global.lights.Light3, Global.lights.Light4);
                }
            }
        }
        public static void ProfileTolerancelightControlLoad()
        {
            if (1 == Global.m_systemRunMode)
            {
                foreach (var item in Global.lightSerialControl.lightControlList)
                {
                    item.Register();
                    item.Open();
                    item.ChannelON(230, 255, 255, 0);
                }
            }
        }

        public static void ProfileTolerancelightControlLoad_beiguang()
        {
            if (1 == Global.m_systemRunMode)
            {
                foreach (var item in Global.lightSerialControl.lightControlList)
                {
                    item.Register();
                    item.Open();
                    item.ChannelON(230, 0, 0, 0);
                }
            }
        }

        public static void lightControlClose()
        {
            if (1 == Global.m_systemRunMode)
            {
                foreach (var item in Global.lightSerialControl.lightControlList)
                {
                    item.Close();
                    //item.ChannelON(Global.lights.Light1, Global.lights.Light2, Global.lights.Light3, Global.lights.Light4);
                }
            }
        }
    }

    [Serializable]
    public class Lights : System.ComponentModel.INotifyPropertyChanged
    {

        int light1;
        public int Light1
        {
            get { return light1; }
            set
            {


                if (light1 != value)
                {
                    light1 = value;

                    OnChangeProperty("Light1");
                }
            }
        }
        int light2;
        public int Light2
        {
            get { return light2; }
            set
            {
                if (light2 != value)
                {
                    light2 = value;
                    OnChangeProperty("Light2");
                }
            }
        }
        int light3;
        public int Light3
        {
            get { return light3; }
            set
            {
                if (light3 != value)
                {
                    light3 = value;
                    OnChangeProperty("Light3");
                }
            }
        }
        int light4;
        public int Light4
        {
            get { return light4; }
            set
            {
                if (light4 != value)
                {
                    light4 = value;
                    OnChangeProperty("Light4");
                }
            }
        }
        public Lights()
        {
            Light1 = 230;
            Light2 = 0;
            Light3 = 0;
            Light4 = 0;
        }
        public void Init()
        {
            Light1 = 230;
            Light2 = 0;
            Light3 = 0;
            Light4 = 0;
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;


        private void OnChangeProperty(string proname)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(proname));
        }
    }




    public class ProfileToleranceParas
    {
        public double X_scale { get; set; }
        public double Y_scale { get; set; }
        public double IsShowMatlabWindow { get; set; }
    }
}
