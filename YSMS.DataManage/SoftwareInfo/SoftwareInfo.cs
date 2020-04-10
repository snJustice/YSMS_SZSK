using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace YSMS.DataManage
{
    public class SoftwareInfo
    {

        #region 实例对象（单例）
        private static SoftwareInfo instance ;
        /// <summary>
        /// 获取单例对象
        /// </summary>
        /// <returns></returns>
        public static SoftwareInfo getInstance()
        {
            if (instance == null)
            {
                lock (typeof(SoftwareInfo))
                {
                    if (instance == null)
                    {
                        instance = new SoftwareInfo();
                    }
                }
            }
            return instance;
        }

        private SoftwareInfo()
        {
        }
        #endregion


        public string SaveAllImagePathTips = "【保存图像的路径】";
        public string SaveAllImagePath = "";

        public string Folw1IsSaveOkImageTips = "【通道1是否保存ok图像：1保存/0不保存】";
        public bool Folw1IsSaveOkImage = false;

        public string Folw1IsSaveNGImageTips = "【通道1是否保存NG图像：1保存/0不保存】";
        public bool Folw1IsSaveNGImage = false;


        public string Folw2IsSaveOkImageTips = "【通道2是否保存ok图像：1保存/0不保存】";
        public bool Folw2IsSaveOkImage = false;

        public string Folw2IsSaveNGImageTips = "【通道2是否保存NG图像：1保存/0不保存】";
        public bool Folw2IsSaveNGImage = false;

        public string Folw3IsSaveOkImageTips = "【通道3是否保存ok图像：1保存/0不保存】";
        public bool Folw3IsSaveOkImage = false;

        public string Folw3IsSaveNGImageTips = "【通道3是否保存NG图像：1保存/0不保存】";
        public bool Folw3IsSaveNGImage = false;

        /// <summary>
        /// 系统运行模式 0：脱机模式 1：联机模式 
        /// </summary>
        public string SystemRunModeTips = " 【系统运行模式： 0脱机模式 / 1联机模式】 ";
        public int SystemRunMode = 0;

        /// <summary>
        /// 语言模式
        /// </summary>
        public string LanguageTips = " 【语言模式： 中文/English】 ";
        public string Language = "中文";


        /// <summary>
        /// 是否存储运行数据信息
        /// </summary>
        public string IsSaveRunInfoDataTips = " 【是否存储运行数据信息： true/false】 ";
        public bool IsSaveRunInfoData = false;

        /// <summary>
        /// 软件类型：普通条带 片式
        /// </summary>
        public string SoftwareTypeTips = " 【软件类型：Normal电镀冲压/Pieces片式/ContinueUDP】 ";
        public SoftwareTypeEnum SoftwareType = SoftwareTypeEnum.Normal;

        /// <summary>
        /// 生成模板选择：true固定模板/false常规模板
        /// </summary>
        public string IsNormalHardWareTips = " 【生成模板选择：true固定模板/false常规模板】 ";
        public bool IsNormalHardWare = false;

        /// <summary>
        /// 是否是频闪光源
        /// </summary>
        public string IsStrobeTips = " 【是否是频闪光源：true/false】 ";
        public bool IsStrobe = false;

        /// <summary>
        /// 与PLC通讯方式：udp/7230/2210
        /// </summary>
        public string SoftwareComTypeTips = " 【与PLC通讯方式：udp/7230/2210】 ";
        public string SoftwareComType = "7230";

        /// <summary>
        /// 是否要做片式简化进程处理（一个工位一次错误，后面都不检测 片式才检测）
        /// </summary>
        public string PiecesSimplyModeTips = " 【是否要做片式简化进程处理（一个工位一次错误，后面都不检测 片式才检测）：true/false】 ";
        public bool PiecesSimplyMode = false;

        /// <summary>
        /// 是否启用未匹配隐藏模式
        /// </summary>
        public string IsHideUnmatchModelTips = " 【是否启用未匹配隐藏模式：true/false】 ";
        public bool IsHideUnmatchModel = false;

        /// <summary>
        /// 是否启用模糊图片隐藏模式
        /// </summary>
        public string IsHideFuzzyImageTips = " 【是否启用模糊图片隐藏模式：true/false】 ";
        public bool IsHideFuzzyImage = false;

        /// <summary>
        /// 是否开启扫码枪扫码功能
        /// </summary>
        public string IsAutoReadCodeTips = " 【是否开启扫码枪扫码功能：true/false】 ";
        public bool IsAutoReadCode = false;

        /// <summary>
        /// 模糊图片最长时间
        /// </summary>
        public string HideFuzzyImageSecondsTips = " 【模糊图片最长时间：】 ";
        public int HideFuzzyImageSeconds = 10;

        /// <summary>
        /// 算法是否需要模板(特殊打印算法时用false)
        /// </summary>
        public string IsAlgorithmUseModelTips = " 【算法是否需要模板(特殊打印算法时用false)：true/false】 ";
        public bool IsAlgorithmUseModel = true;

        /// <summary>
        /// 是否有料盒模式
        /// </summary>
        public string IsBoxTypeTips = " 【是否有料盒模式：true/false】 ";
        public bool IsBoxType = false;

        /// <summary>
        /// 是否保存BMP图片
        /// </summary>
        public string IsSaveBmpImageTips = " 【是否保存BMP图片：true/false】 ";
        public bool IsSaveBmpImage = false;

        /// <summary>
        /// 是否自动设置是否背光
        /// </summary>
        public string IsAutoLightOrDarkTips = " 【是否自动设置是否背光：true/false】 ";
        public bool IsAutoLightOrDark = false;

        /// <summary>
        /// 是否同时启停--wzy20170629
        /// </summary>
        public string IsSameTimeTips = " 【是否同时启停：true/false】 ";
        public bool IsSameTime = false;


        /// <summary>
        /// 是否显示OK信息
        /// </summary>
        public string IsShowOKTips = " 【是否显示OK信息：true/false】 ";
        public bool IsShowOK = true;

        /// <summary>
        /// 是否网络传输报警
        /// </summary>
        public string IsNetWorkAlarmTips = " 【是否网络传输报警：true/false】 ";
        public bool IsNetWorkAlarm = false;
        public string IsClientTips = " 【本机是否是客户端：true/false】 ";
        public bool IsClient = true;
        public string DeviceIDTips = " 【本机在网络报警中的设备编号：】 ";
        public int DeviceID = 0;

        /// <summary>
        /// 是否软件控制电机冲床运动逻辑
        /// </summary>
        public string IsSoftwareCtrlDeviceTips = " 【是否软件控制电机冲床运动逻辑：true/false】 ";
        public bool IsSoftwareCtrlDevice = false;

        /// <summary>
        /// 是否有两个通道
        /// </summary>
        public string HasTwoChannelsTips = " 【是否有两个通道：true/false】 ";
        public bool HasTwoChannels = true;


        /// <summary>
        /// 是否进行远程协助
        /// </summary>
        public string HasAssistTips = " 【是否进行远程协助：true/false】 ";
        public bool HasAssist = false;


        /// <summary>
        /// 拍照模式 0：软件触发 1：硬件触发
        /// </summary>
        public string CameraPhotoTypeTips = " 【拍照模式： 0软件触发/1硬件触发】 ";
        public int CameraPhotoType = 0;

        /// <summary>
        /// 是否要编码器延时报警
        /// </summary>
        public string HasAlarmCodeTips = " 【是否要编码器延时报警： true/false】 ";
        public bool HasAlarmCode = false;

        /// <summary>
        /// 毫米到编码器值的转换系数
        /// </summary>
        public string DistanceToAlarmCodeTips = " 【毫米到编码器值的转换系数：】 ";
        public double DistanceToAlarmCode = 10;

        /// <summary>
        /// 产品单元长度 通道1
        /// </summary>
        public string UniteLenthTips = " 【产品单元长度 通道1：】 ";
        public double UniteLenth = 10;

        /// <summary>
        /// 单元长度通道2
        /// </summary>
        public string UniteLenth2Tips = " 【产品单元长度 通道2：】 ";
        public double UniteLenth2 = 10;

        /// <summary>
        /// 最大数量报警停机（成都贴切）
        /// </summary>
        public string MaxLenthNumTips = " 【最大数量报警停机（成都贴切）：】 ";
        public string  MaxLenthNum = "34000000";

        /// <summary>
        /// 最大数量报警停机（成都贴切）
        /// </summary>
        public string MaxLenthNum1Tips = " 【最大数量报警停机（成都贴切）：】 ";
        public string MaxLenthNum1 = "34000000";


        /// <summary>
        /// 临时获得管理员权限的密码 系统运行密码 默认“yszn”
        /// </summary>
        public string SystemCodeTips = " 【临时获得管理员权限的密码 系统运行密码 默认“yszn”】 ";
        public string SystemCode = "yszn";

        /// <summary>
        /// 模板校正是否需要输入密码
        /// </summary>
        public string HasPwdCorrectionTips = " 【模板校正是否需要输入密码： true/false】 ";
        public bool  HasPwdCorrection = false;

        /// <summary>
        /// 料停后，是否继续检测（冲床启停与检测同步）与ALARM/Di_Pause_1端口配使用
        /// </summary>
        public string IsStopCheckTips = " 【料停后，是否继续检测（冲床启停与检测同步）与ALARM/Di_Pause_1端口配使用： true/false】 ";
        public bool IsStopCheck = false ;
       
        /// <summary>
        /// 是否是批量检测状态与IsStopCheck共用   0419 zyh
        /// </summary>
        public string IsBatchCheckTips = " 【是否是批量检测状态与IsStopCheck共用： true/false】 ";
        public bool IsBatchCheck = false;
       
        /// <summary>
        /// 是否固定模板顺序
        /// </summary>
        public string IsSureModelTips = " 【是否固定模板顺序： true/false】 ";
        public bool IsSureModel = false;

        /// <summary>
        /// 是否检测料带是停止状态(顺德)
        /// </summary>
        public string IsCheckProductStopTips = " 【是否检测料带是停止状态(顺德)： true/false】 ";
        public bool IsCheckProductStop = false;

        /// <summary>
        /// 是否检测料带移动(台湾住矿)
        /// </summary>
        public string IsCheckProductMoveTips = " 【是否检测料带移动(台湾住矿)： true/false】 ";
        public bool IsCheckProductMove = false;

        /// <summary>
        /// 多少次不移动判定为送料机构故障(台湾住矿)
        /// </summary>
        public string CheckProductMoveCntTips = " 【多少次不移动判定为送料机构故障(台湾住矿)： 整数】 ";
        public int CheckProductMoveCnt = 3;

        /// <summary>
        /// 第一通道的通道名称
        /// </summary>
        public string FirstChannelNameTips = " 【第一通道的通道名称： 】 ";
        public string FirstChannelName = "通道1";

        /// <summary>
        /// 第二通道的通道名称
        /// </summary>
        public string SecondChannelNameTips = " 【第二通道的通道名称： 】 ";
        public string SecondChannelName = "通道2";

        /// <summary>
        /// 曝光时间
        /// </summary>
        public string ExposureTimeRawTips = " 【曝光时间： ExposureTimeRaw】 ";
        public string ExposureTimeRaw = "ExposureTimeRaw";

        /// <summary>
        /// 图像增益
        /// </summary>
        public string GainRawTips = " 【图像增益： GainRaw】 ";
        public string GainRaw = "GainRaw";

        /// <summary>
        /// 上一次检测的产品名称
        /// </summary>
        public string LastProductNameTips = " 【上一次检测的产品名称： 】 ";
        public string LastProductName = string.Empty;

        /// <summary>
        /// 上一次第一通道检测的产品名称
        /// </summary>
        public string FirstChannelLastProductNameTips = " 【上一次第一通道检测的产品名称： 】 ";
        public string FirstChannelLastProductName = string.Empty;

        /// <summary>
        /// 上一次第二通道检测的产品名称
        /// </summary>
        public string SecondChannelLastProductNameTips = " 【上一次第二通道检测的产品名称： 】 ";
        public string SecondChannelLastProductName = string.Empty;

        /// <summary>
        /// 上一次第一通道检测的产品批号
        /// </summary>
        public string FirstChannelLastBatchNumberTips = " 【上一次第一通道检测的产品批号： 】 ";
        public string FirstChannelLastBatchNumber = "01";

        /// <summary>
        /// 上一次第二通道检测的产品批号
        /// </summary>
        public string SecondChannelLastBatchNumberTips = " 【上一次第二通道检测的产品批号： 】 ";
        public string SecondChannelLastBatchNumber = "01";

        #region 框颜色
        /*
        'black', 'white', 'red', 'green', 'blue', 'cyan', 'magenta', 'yellow', 'dim gray', 'gray', 'light gray', 'medium slate blue', 'coral', 'slate blue', 'spring green', 'orange red', 'orange', 'dark olive green', 'pink', 'cadet blue'
        '黑'，'白'，'红'，'绿色'，'蓝'，'青'，'红'，'黄'，'暗灰色”，“灰色”，“灰色”、“中石板蓝”，“珊瑚”、“石板蓝'，'春绿'，'红色'，'橙'，'黑橄榄绿'，'粉红'，'灰蓝色的
        */

        /// <summary>
        /// 区域被选中 //baicx baicx 20200305 改变选中时的颜色
        /// </summary>
        public string ColorSelectTips = " 【区域被选中： yellow】 ";
        public string ColorSelect = "yellow";

        /// <summary>
        /// ROI区
        /// </summary>
        public string ColorRoiTips = " 【ROI区： green】 ";
        public string ColorRoi = "green";
        /// <summary>
        /// 屏蔽区域
        /// </summary>
        public string ColorShieldingAreaTips = " 【屏蔽区域： orange】 ";
        public string ColorShieldingArea = "orange";
        /// <summary>
        /// 检测区域
        /// </summary>
        public string ColorDetectionAreaTips = " 【检测区域： green】 ";
        public string ColorDetectionArea = "green";
        /// <summary>
        /// 定位区域
        /// </summary>
        public string ColorLocationAreaTips = " 【定位区域： cyan】 ";
        public string ColorLocationArea = "cyan";
        /// <summary>
        /// 尺寸
        /// </summary>
        public string ColorSizeTips = " 【尺寸： coral】 ";
        public string ColorSize = "coral";
        /// <summary>
        /// 缺陷
        /// </summary>
        public string ColorDefectTips = " 【缺陷： red】 ";
        public string ColorDefect = "red";
        #endregion

       

        /// <summary>
        /// 保存错误日志文件90天
        /// </summary>
        public string SaveErrorLogTimeTips = " 【保存错误日志文件90天： 】 ";
        public int  SaveErrorLogTime = 90;

        /// <summary>
        /// 产品类型选择路径
        /// </summary>
        public string ProductSetPathTips = " 【产品类型选择路径： 】 ";
        public string ProductSetPath = "D:\\YSMS_130StandardV4_Info\\产品分类";

        /// <summary>
        /// 报表模板路径
        /// </summary>
        public string ExcelTemplatePathTips = " 【报表模板路径： 】 ";
        public string ExcelTemplatePath = "D:\\YSMS_130StandardV4_Info\\报表模板.xls";


        /// <summary>
        /// 正常图片路径
        /// </summary>
        public string OKImagePathTips = " 【正常图片路径： 】 ";
        public string OKImagePath = "D:\\YSMS_130StandardV4_Info\\正常图片";

        /// <summary>
        /// 异常图片路径
        /// </summary>
        public string ErrorImagePathTips = " 【异常图片路径： 】 ";
        public string ErrorImagePath = "D:\\YSMS_130StandardV4_Info\\异常图片";

        /// <summary>
        /// 原图路径
        /// </summary>
        public string OriginImagePathTips = " 【 原图路径： 】 ";
        public string OriginImagePath = "D:\\YSMS_130StandardV4_Info\\原图";

        /// <summary>
        /// 重大缺陷图片存储路径
        /// </summary>
        public string AlarmImagePathTips = " 【重大缺陷图片存储路径： 】 ";
        public string AlarmImagePath = "D:\\YSMS_130StandardV4_Info\\AlarmImage";

        /// <summary>
        /// 日志路径
        /// </summary>
        public string LogPathTips = " 【日志路径： 】 ";
        public string LogPath = "D:\\YSMS_130StandardV4_Info\\日志";


        /// <summary>
        /// 错误日志路径，必须设置为最终要存的地址
        /// 在软件没load之前，配置文件内容无效
        /// </summary>
        public string ErrorLogPathTips = " 【错误日志路径，必须设置为最终要存的地址 在软件没load之前，配置文件内容无效】 ";
        public string ErrorLogPath = "E:\\HelpFiles\\错误日志";

        /// <summary>
        /// 图片确认信息文档保存路径
        /// </summary>
        public string PicInfoConfirmFilePathTips = " 【 图片确认信息文档保存路径： 】 ";
        public string PicInfoConfirmFilePath = "E:\\PicInfoConfirmData";

        /// <summary>
        /// 静态检测图像1路径
        /// </summary>
        public string StaticMeasureImagePath_1Tips = " 【静态检测图像1路径： 】 ";
        public string StaticMeasureImagePath_1 = "D:\\YSMS_130StandardV4_Info\\TestImage\\1.bmp";

        /// <summary>
        /// 静态检测图像2路径
        /// </summary>
        public string StaticMeasureImagePath_2Tips = " 【静态检测图像2路径： 】 ";
        public string StaticMeasureImagePath_2 = "D:\\YSMS_130StandardV4_Info\\TestImage\\2.bmp";
        /// <summary>
        /// 静态检测图像3路径
        /// </summary>
        public string StaticMeasureImagePath_3Tips = " 【静态检测图像3路径： 】 ";
        public string StaticMeasureImagePath_3 = "D:\\YSMS_130StandardV4_Info\\TestImage\\3.bmp";
        /// <summary>
        /// 静态检测图像4路径
        /// </summary>
        public string StaticMeasureImagePath_4Tips = " 【静态检测图像4路径： 】 ";
        public string StaticMeasureImagePath_4 = "D:\\YSMS_130StandardV4_Info\\TestImage\\4.bmp";

        /// <summary>
        /// 模板校正图片路径
        /// </summary>
        public string AdjustImagePathTips = " 【模板校正图片路径： 】 ";
        public string AdjustImagePath = "D:\\YSMS_130StandardV4_Info\\TestImage\\Adjust_1.bmp";       
        
        /// <summary>
        /// 授权码文件路径
        /// </summary>
        public string AuthorizeInfoPathTips = " 【授权码文件路径： 】 ";
        public string AuthorizeInfoPath = "D:\\AuthorizeInfo.ini";

        /// <summary>
        /// 图片信息保存路径
        /// </summary>
        public string PicInfoPathTips = " 【图片信息保存路径： 】 ";
        public string PicInfoPath = "";

        /// <summary>
        /// 远程协助文件路径
        /// </summary>
        public string AssistFilesPartInfoPathTips = " 【远程协助文件路径： 】 ";
        public string AssistFilesPartInfoPath = "";

        /// <summary>
        /// 远程模板文件路径
        /// </summary>
        public string AssistParasPathTips = " 【远程模板文件路径： 】 ";
        public string AssistParasPath = "";

        /// <summary>
        /// 远程图片文件路径
        /// </summary>
        public string AssistFilesPicPathTips = " 【 远程图片文件路径： 】 ";
        public string AssistFilesPicPath = "";

        /// <summary>
        /// 远程配置文件路径
        /// </summary>
        public string AssistInfoPathTips = " 【远程配置文件路径： 】 ";
        public string AssistInfoPath = "";


        /// <summary>
        /// 远程协助子文件路径
        /// </summary>
        public string AssistFilesInfoPathTips = " 【远程协助子文件路径： 】 ";
        public string AssistFilesInfoPath = "E:\\HelpFiles";

        /// <summary>
        /// 框移动步长
        /// </summary>
        public string MoveAlterTips = " 【框移动步长： 整数】 ";
        public  int MoveAlter =1;

        /// <summary>
        /// 默认算法下标
        /// </summary>
        public string ChooseAlgIndexTips = " 【默认算法下标： 整数】 ";
        public int ChooseAlgIndex = 0;
        /// <summary>
        /// 存图缓存最大图片数量
        /// </summary>
        public string SaveImageQueueMaxNumTips = " 【存图缓存最大图片数量： 20】 ";
        public int SaveImageQueueMaxNum = 20;

        /// <summary>
        /// 算法普通参数个数
        /// </summary>
        public string AlgorithmNormalParasNumTips = " 【算法普通参数个数：整数】 ";
        public int AlgorithmNormalParasNum = 10;

        /// <summary>
        /// 算法高级参数个数
        /// </summary>
        public string AlgorithmSeniorParasNumTips = " 【算法高级参数个数： 整数】 ";
        public int AlgorithmSeniorParasNum = 10;

        /// <summary>
        /// 尺寸算法参数个数
        /// </summary>
        public string AlgorithmSizeParasNumTips = " 【尺寸算法参数个数： 整数】 ";
        public int AlgorithmSizeParasNum = 10;

        /// <summary>
        /// 模板未匹配报警次数
        /// </summary>
        public string ModelUnMatchAlarmNumTips = " 【模板未匹配报警次数： 整数】 ";
        public int ModelUnMatchAlarmNum = 10;

        /// <summary>
        /// 相机拍照间隔
        /// </summary>
        public string CameraPhotoIntervalTips = " 【相机拍照间隔： 整数】 ";
        public int CameraPhotoInterval = 150;

        /// <summary>
        /// 相机拍照张数
        /// </summary>
        public string CameraPhotoCountTips = " 【相机默认拍照张数：整数】 ";
        public int CameraPhotoCount = 10;

        /// <summary>
        /// 相机拍照开始位置
        /// </summary>
        public string CameraStartPhotoPositionTips = " 【相机默认拍照开始位置： 整数】 ";
        public int CameraStartPhotoPosition = 0;

        /// <summary>
        /// 相机拍照间隔位置
        /// </summary>
        public string CameraIntervalPhotoPositionTips = " 【相机默认拍照间隔位置： 整数】 ";
        public int CameraIntervalPhotoPosition = 0;

        /// <summary>
        /// 每次尺寸测量间隔拍照次数
        /// </summary>
        public string PhotoNumForOneSizeTips = " 【每次尺寸测量间隔拍照次数： 整数】 ";
        public int PhotoNumForOneSize = 50;


        /// <summary>
        /// 多模板时连续未匹配到一个模板几次报警
        /// </summary>
        public string MultiModelALarmUnmatchedTimesTips = " 【 多模板时连续未匹配到一个模板几次报警： 整数】 ";
        public int MultiModelALarmUnmatchedTimes = 20;

        // /// <summary>
        ///// 优先匹配模版
        ///// </summary>
        //public int PriorityStationModel = 0;

        
        /// <summary>
        /// 检测区域中心偏移默认值
        /// </summary>
        public string DetectionAreaOffCentersTips = " 【检测区域中心偏移默认值： 整数】 ";
        public int DetectionAreaOffCenters = 0;


        /// <summary>
        /// 检测区域高宽最大值
        /// </summary>
        public string DetectionAreaMaxTips = " 【检测区域高宽最大值： 整数】 ";
        public int DetectionAreaMax = 50;

        /// <summary>
        /// 默认创建通道
        /// </summary>
        public string DefaultCreateChannelTips = " 【默认创建通道： 整数】 ";
        public int DefaultCreateChannel = 2;

        /// <summary>
        /// 默认检测通道
        /// </summary>
        public string DefaultDetectChannelTips = " 【默认检测通道：整数】 ";
        public int DefaultDetectChannel = 4;

        /// <summary>
        /// 有无背光（0：无;1：有）
        /// </summary>
        public string HasBacklitTips = " 【有无背光：0无/1有】 ";
        public int HasBacklit = 1;

        /// <summary>
        /// 产品边界灰度
        /// </summary>
        public string ProductGrayDefaultTips = " 【产品边界灰度： 整数】 ";
        public int ProductGrayDefault = 120;

        /// <summary>
        /// 定位孔边界灰度
        /// </summary>
        public string HoleGrayDefaultTips = " 【定位孔边界灰度：整数】 ";
        public int HoleGrayDefault = 120;

        /// <summary>
        /// 最小匹配分数
        /// </summary>
        public string MinScoreDefaultTips = " 【最小匹配分数： 浮点数】 ";
        public double MinScoreDefault = 0.8;


        /// <summary>
        /// 产品日期需要修正的分钟数
        /// </summary>
        public string AddMinutesTips = " 【产品日期需要修正的分钟数： 整数】 ";
        public int AddMinutes = 0;

        /// <summary>
        /// 机器号
        /// </summary>
        public string MachineTips = " 【机器号： 】 ";
        public string Machine = "01";

        /// <summary>
        /// 通道1工位数
        /// </summary>
        public string ChannelStationNumTips = " 【 通道1工位数： 整数】 ";
        public int ChannelStationNum = 3;

        /// <summary>
        /// 是否保存OK截图
        /// </summary>
        public string SaveDumpImage_OKTips = " 【是否保存OK截图： true/false】 ";
        public bool SaveDumpImage_OK = false;

        /// <summary>
        /// 是否保存NG截图
        /// </summary>
        public string SaveDumpImage_NGTips = " 【是否保存NG截图： true/false】 ";
        public bool SaveDumpImage_NG = false;

        /// <summary>
        /// 是否保存未匹配截图
        /// </summary>
        public string SaveDumpImage_WPPTips = " 【是否保存未匹配截图： true/false】 ";
        public bool SaveDumpImage_WPP = false;

        /// <summary>
        /// 是否保存OK原图
        /// </summary>
        public string SaveOriginImage_OKTips = " 【是否保存OK原图： true/false】 ";
        public bool SaveOriginImage_OK = false;

        /// <summary>
        /// 是否保存NG未标记原图
        /// </summary>
        public string SaveOriginImage_NGTips = " 【是否保存NG未标记原图： true/false】 ";
        public bool SaveOriginImage_NG = false;

        /// <summary>
        /// 是否保存NG标记原图
        /// </summary>
        public string SaveMarkOriginImage_NGTips = " 【是否保存NG标记原图： true/false】 ";
        public bool SaveMarkOriginImage_NG = false;

        /// <summary>
        /// 是否保存未匹配原图
        /// </summary>
        public string SaveOriginImage_WPPTips = " 【是否保存未匹配原图： true/false】 ";
        public bool SaveOriginImage_WPP = false;

        /// <summary>
        /// 是否保存未报警的未匹配图片
        /// </summary>
        public string SaveALLImage_WPPTips = " 【是否保存未报警的未匹配图片： true/false】 ";
        public bool SaveALLImage_WPP = false;

        /// <summary>
        /// 是否保存无产品图片
        /// </summary>
        public string SaveNoProductTips = " 【是否保存无产品图片： true/false】 ";
        public bool SaveNoProduct = false;

        /// <summary>
        /// 是否保存尺寸错误原图
        /// </summary>
        public string SaveOriginImage_SizeTips = " 【是否保存尺寸错误原图： true/false】 ";
        public bool SaveOriginImage_Size = false;

        /// <summary>
        /// 是否保存图像异常的原图
        /// </summary>
        public string SaveOriginImage_ImageErrorTips = " 【是否保存图像异常的原图： true/false】 ";
        public bool SaveOriginImage_ImageError = true;

        /// <summary>
        /// 是否在界面上显示图像异常的原图
        /// </summary>
        public string ShowOriginImage_ImageErrorTips = " 【是否在界面上显示图像异常的原图： true/false】 ";
        public bool ShowOriginImage_ImageError = false;

        /// <summary>
        /// 尺寸错误是否报警
        /// </summary>
        public string IsSizeErrorAlarmTips = " 【尺寸错误是否报警： true/false】 ";
        public bool IsSizeErrorAlarm = false;

        /// <summary>
        /// 是否保存测量数据到数据库
        /// </summary>
        public string SaveMeasureValue2DBTips = " 【是否保存测量数据到数据库： true/false】 ";
        public bool SaveMeasureValue2DB = false;

        /// <summary>
        /// 报警软件是否停机
        /// </summary>
        public string IsAlarmSoftwareStopTips = " 【报警软件是否停机： true/false】 ";
        public bool IsAlarmSoftwareStop = true;

        /// <summary>
        /// 报警硬件是否停机
        /// </summary>
        public string IsAlarmDeviceStopTips = " 【报警硬件是否停机： true/false】 ";
        public bool IsAlarmDeviceStop = true;

        /// <summary>
        /// 是否停机延迟  Qiyi Li
        /// </summary>
        public string IsAlarmDeviceStopDelayTips = " 【是否停机延迟： true/false】 ";
        public bool IsAlarmDeviceStopDelay = false;

        /// <summary>
        /// 停机延迟时间ms Qiyi Li
        /// </summary>
        public string HardwaredelayTimeTips = " 【停机延迟时间ms： 整数】 ";
        public int HardwaredelayTime = 0;

        /// <summary>
        /// 延时停机并做标记（台湾住矿）
        /// </summary>
        public string IsDelayAlarmAndMarkTips = " 【延时停机并做标记（台湾住矿）手动打标： true/false】 ";
        public bool IsDelayAlarmAndMark = false;

        /// <summary>
        /// 是否可暂停（台湾住矿）
        /// </summary>
        public string IsPauseTips = " 【是否可暂停（台湾住矿）： true/false】 ";
        public bool IsPause = false;


        /// <summary>
        /// 设备运行速度（台湾住矿）
        /// </summary>
        public string SpeedTips = " 【设备运行速度（台湾住矿）：整数 】 ";
        public int Speed = 150;

        /// <summary>
        /// 延时标记时间ms（台湾住矿）
        /// </summary>
        public string DelayAlarmAndMarkTimeTips = " 【延时标记时间ms（台湾住矿）： 整数】 ";
        public int DelayAlarmAndMarkTime = 1000;

        /// <summary>
        /// 暂停时间ms（台湾住矿）
        /// </summary>
        public string PauseDefectTimeTips = " 【暂停时间ms（台湾住矿）： 整数】 ";
        public int PauseDefectTime = 10000;

        /// <summary>
        /// 匹配角度（台湾住矿）
        /// </summary>
        public string MatchAngleTips = " 【匹配角度（台湾住矿）： 整数】 ";
        public int MatchAngle = 20;

        /// <summary>
        /// 米数文档记录功能是否开启
        /// </summary>
        public string IsMeterRecordEnableTips = " 【米数文档记录功能是否开启： true/false】 ";
        public bool IsMeterRecordEnable = false;

        /// <summary>
        /// 机台及产线编号
        /// </summary>
        public string DeviceLineNoTips = " 【机台及产线编号： 】 ";
        public string DeviceLineNo = "";

        /// <summary>
        /// 收卷长度1
        /// </summary>
        public string LineLength1Tips = " 【收卷长度1： 浮点数】 ";
        public double LineLength1 = 0;

        /// <summary>
        /// 收卷长度2
        /// </summary>
        public string LineLength2Tips = " 【收卷长度2： 浮点数】 ";
        public double LineLength2 = 0;

        /// <summary>
        /// 复位是否清空报警队列
        /// </summary>
        public string IsResetClearAlarmListTips = " 【复位是否清空报警队列： true/false】 ";
        public bool IsResetClearAlarmList = true;

        /// <summary>
        /// 报警软件是否亮灯和蜂鸣器
        /// </summary>
        public string IsAlarmLoudSoundTips = " 【报警软件是否亮灯和蜂鸣器： true/false】 ";
        public bool IsAlarmLoudSound = true;

        /// <summary>
        /// 是否保存测试图片
        /// </summary>
        public string IsSaveTestImageTips = " 【是否保存测试图片： true/false】 ";
        public bool IsSaveTestImage = false ;

        /// <summary>
        /// 是否抽样存图
        /// </summary>
        public string IsSaveSampleImageTips = " 【是否抽样存图： true/false】 ";
        public bool IsSaveSampleImage = false;

        /// <summary>
        /// 多少时间存一张图片ms（抽样存图）
        /// </summary>
        public string SampleImageNumTips = " 【多少时间存一张图片ms（抽样存图）： 】 ";
        public int SampleImageNum = 1000;

        /// <summary>
        /// 采集多少张出错重启
        /// </summary>
        public string GrabErrorNumRestartTips = " 【采集多少张出错重启： 整数】 ";
        public int GrabErrorNumRestart = 5;

        /// <summary>
        /// 是否显示算法时间
        /// </summary>
        public string IsShowMeasureTimeTips = " 【是否显示算法时间： true/false】 ";
        public bool IsShowMeasureTime = false;

        /// <summary>
        /// 是否无产品报警
        /// </summary>
        public string IsAlarmNoProductTips = " 【是否无产品报警： true/false】 ";
        public bool IsAlarmNoProduct = true;

        /// <summary>
        /// 检测区域操作步骤
        /// </summary>
        public string ROIOperationStepsTips = " 【检测区域操作步骤： 】 ";
        public string ROIOperationSteps = string.Empty;

        /// <summary>
        /// 定位区域操作步骤
        /// </summary>
        public string LocatingHoleOperationStepsTips = " 【定位区域操作步骤： 】 ";
        public string LocatingHoleOperationSteps = string.Empty;

        /// <summary>
        /// 模板生成操作步骤
        /// </summary>
        public string GenerateModelOperationStepsTips = " 【模板生成操作步骤： 】 ";
        public string GenerateModelOperationSteps = string.Empty;

        /// <summary>
        /// 缺陷设定操作步骤
        /// </summary>
        public string DefectDetectionOperationStepsTips = " 【缺陷设定操作步骤： 】 ";
        public string DefectDetectionOperationSteps = string.Empty;

        /// <summary>
        /// 尺寸设定操作步骤
        /// </summary>
        public string SizeDetectionOperationStepsTips = " 【尺寸设定操作步骤： 】 ";
        public string SizeDetectionOperationSteps = string.Empty;

        /// <summary>
        /// 特殊区域操作步骤
        /// </summary>
        public string SpecialRegionOperationStepsTips = " 【特殊区域操作步骤：】 ";
        public string SpecialRegionOperationSteps = string.Empty;

        /// <summary>
        ///初始化信号读取地址
        /// </summary>
        public string PLCResetTips = " 【初始化信号读取地址： 整数】 ";
        public int PLCReset = 96;
        /// <summary>
        ///通道2 OK读取地址
        /// </summary>
        public string PLCOK2Tips = " 【通道2 OK读取地址：整数 】 ";
        public int PLCOK2 = 108;
        /// <summary>
        ///通道2 NG读取地址
        /// </summary>
        public string PLCNG2Tips = " 【通道2 NG读取地址： 整数】 ";
        public int PLCNG2 = 116;
        
        /// <summary>
        /// 脉冲距离比（多少个脉冲代表一个毫米）片式使用
        /// </summary>
        public string PulsePerMMTips = " 【脉冲距离比（多少个脉冲代表一个毫米）片式使用： 浮点数】 ";
        public double PulsePerMM = 2500;

        /// <summary>
        /// 是否显示报警图片
        /// </summary>
        public string IsShowAlarmImageTips = " 【是否显示报警图片： true/false】 ";
        public bool IsShowAlarmImage = false;

        /// <summary>
        /// 缓存图像报警
        /// </summary>
        public string IsCacheImageAlarmTips = " 【缓存图像报警： true/false】 ";
        public bool IsCacheImageAlarm = false;

        /// <summary>
        /// 缓存图像报警数目
        /// </summary>
        public string CacheAlarmNumerTips = " 【缓存图像报警数目： 1-19】 ";
        public int CacheAlarmNumer = 10;
                
        /// <summary>
        /// 是否学习V型孔间隔  Qiyi Li 20200307
        /// </summary>
        public string IsLearnVTips = " 【是否学习V型孔间隔】 ";
        public bool IsLearnV = false;

        /// <summary>
        ///  间隔拍照的间隔信号次数 Qiyi Li 20200311
        /// </summary>
        public int CountPhotoModeNumCh1 = 3;
        public int CountPhotoModeNumCh2 = 3;

        /// <summary>
        ///  是否使用相机参数自定义范围 Qiyi Li 20200320
        /// </summary>
        public string IsUserCamParaTips = " 【是否使用相机参数自定义范围】 ";
        public bool IsUserCamPara = false;
     
		/// <summary>
        /// 是否显示模板使用情况
        /// </summary>
        public string IsShowTemplatesUsageTips = " 【是否显示模板使用情况：true/false】 ";
        public bool IsShowTemplatesUsage = false;
        
        /// <summary>
        /// 是否开启三色灯检测线程
        /// </summary>
        public string IsStartThreadReadWriteLightTips = " 【是否开启三色灯检测线程：true/false】 ";
        public bool IsStartThreadReadWriteLight = false;

        //默认欧姆龙：0  三菱FX5U：1
        public string PLCTypeTips = " 【默认欧姆龙：0  三菱FX5U：1】 ";
        public int PLCType = 0;


        /// <summary>
        /// 片式NG报警是否可以设定NG个数 20200330 Qiyi Li
        /// </summary>
        public string IsPieceAlarmTips = " 【片式NG报警是否可以设定NG个数：true/false】 ";
        public bool IsPieceAlarm = true;


        public int save(string path, ref string exMessage)
        {
            int result = 0;
            try
            {
                using (Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(SoftwareInfo));
                    serializer.Serialize(fStream, instance);
                }
            }
            catch (System.Exception ex)
            {
                WriteLog("save:\n" + ex.ToString());
                exMessage = ex.Message;
                result = 1;
            }
            return result;
        }


        public int load(string path, ref string exMessage)
        {
            int result = 0;
            try
            {
                using (Stream fStream = File.OpenRead(path))
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(SoftwareInfo));
                    instance = serializer.Deserialize(fStream) as SoftwareInfo;
                }

                if (instance != null)
                {
                    if (instance.CacheAlarmNumer > 20)
                    {
                        instance.CacheAlarmNumer = 20;
                    }
                }
            }
            catch (System.Exception ex)
            {
                WriteLog("load:\n"+ ex.ToString());
                exMessage = ex.Message;
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// 写文件，异常写入
        /// </summary>
        /// <param name="str"></param>
        int rowCnt = 0;
        int rowCntTimes = 0;
        public void WriteLog(string str)
        {
            try
            {
                List<string> ListErrLogFileName = new List<string>() { };
                List<string> timeList = new List<string>() { };
                string[] strArray = new string[] { };
                if (File.Exists(SoftwareInfo.getInstance().ErrorLogPath))
                {
                    ListErrLogFileName = Directory.GetFiles(SoftwareInfo.getInstance().ErrorLogPath).ToList();
                }
                int count = 0;

                foreach (string ErrLogFileName in ListErrLogFileName)
                {
                    strArray = ErrLogFileName.Split(' ');
                    timeList.Add(strArray[strArray.Length - 1].Split('.')[0].Split ('_')[0]);
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

                rowCnt++;
                string path = SoftwareInfo.getInstance().ErrorLogPath;
                string pathtxt = path + "\\ErrLog " + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                if (rowCnt > 20)
                {
                    rowCnt = 0;
                    rowCntTimes++;
                }

                int cntTemp = 0;
                while (File.Exists(pathtxt) && cntTemp < 10 && rowCntTimes!=0)
                {
                    cntTemp++;
                    pathtxt = path + "\\" + rowCntTimes + "_" + "ErrLog " + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                }

               
                using (StreamWriter sw = new StreamWriter(pathtxt, true))
                {
                    sw.WriteLine(DateTime.Now.ToString());
                    sw.WriteLine(str);
                    sw.WriteLine("---------------------------------------------------------");
                    sw.Close();
                }
            }
            catch
            { }
        }       
    }
}
