using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YSMS_SZSK.Lib
{
    public class InfoPath
    {
        #region 实例对象（单例）
        private static InfoPath instance;
        /// <summary>
        /// 获取单例对象
        /// </summary>
        /// <returns></returns>
        public static InfoPath getInstance()
        {
            if (instance == null)
            {
                lock (typeof(InfoPath))
                {
                    if (instance == null)
                    {
                        instance = new InfoPath();
                    }
                }
            }
            return instance;
        }

        private InfoPath()
        {
            GetInfoFrom_AppConfig();
        }
        #endregion

        private string path;
        /// <summary>
        /// 配置文件总路径
        /// </summary>
        public string Path
        {
            get { return path; }
        }

        /// <summary>
        /// 用户文件
        /// </summary>
        public string User
        {
            get { return path + "\\conf\\User.xml"; }
        }

        /// <summary>
        /// 软件参数文件
        /// </summary>
        public string SoftwareInfo
        {
            get { return path + "\\conf\\SoftwareInfo.xml"; }
        }
        /// <summary>
        /// 网络通信参数文件
        /// </summary>
        public string NetworkInfo
        {
            get { return path + "\\conf\\NetworkInfo.xml"; }
        }

        /// <summary>
        /// PLC参数文件
        /// </summary>
        public string PLCInformation
        {
            get { return path + "\\conf\\PLCInformation.xml"; }
        }

        /// <summary>
        /// 光源控制文件 LightControlS.xml
        /// </summary>
        public string LightControls
        {
            get { return path + "\\conf\\LightControlS.xml"; }
        }

        /// <summary>
        /// 缺陷算法文件
        /// </summary>
        public string DefectAlgorithmS
        {
            get { return path + "\\conf\\DefectAlgorithmS.xml"; }
        }

        /// <summary>
        /// 尺寸算法文件
        /// </summary>
        public string SizeAlgorithmS
        {
            get { return path + "\\conf\\SizeAlgorithmS.xml"; }
        }

        /// <summary>
        /// 特殊区域算法文件
        /// </summary>
        public string SpecialRegionAlgorithmS
        {
            get { return path + "\\conf\\SpecialRegionAlgorithmS.xml"; }
        }

        /// <summary>
        /// 批量生成框算法算法文件
        /// </summary>
        public string BatchGenRectAlgorithmS
        {
            get { return path + "\\conf\\BatchGenRectAlgorithmS.xml"; }
        }

        /// <summary>
        /// 批量模板生成框算法算法文件
        /// </summary>
        public string BatchGenModelRectAlgorithmS
        {
            get { return path + "\\conf\\BatchGenModelRectAlgorithmS.xml"; }
        }

        /// <summary>
        /// 多框模板阵列算法
        /// </summary>
        public string BatchMultiGenModelRectAlgorithmS
        {
            get { return path + "\\conf\\BatchMultiGenModelRectAlgorithmS.xml"; }
        }

        public string TempFilesPath
        {
            get { return path + "\\TempFilesPath"; }
        }

        public string ProductPath
        {
            get { return path + "\\Products"; }
        }

        /// <summary>
        /// 光源亮度存储文件 ChannelBrightness.xml
        /// </summary>
        public static string ChannelBrightness;


        public string ProductNo
        {
            get;
            set;
        }

        /// <summary>
        /// 通道1产品名称
        /// </summary>
        public string FirstChannelProductName
        {
            get;
            set;
        }

        /// <summary>
        /// 通道2产品名称
        /// </summary>
        public string SecondChannelProductName
        {
            get;
            set;
        }

        ///// <summary>
        ///// 通道1比例系数
        ///// </summary>
        //public string FirstChannelRatio
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 通道2比例系数
        ///// </summary>
        //public string SecondChannelRatio
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// 相机配置文件 CameraS.xml
        /// </summary>
        public string CameraS
        {
            get { return path + "\\conf\\CameraS.xml"; }
        }

        /// <summary>
        /// 双通道相机配置文件 CameraS.xml
        /// </summary>
        public string CameraS2Ch
        {
            //get { return path + "\\conf\\CameraS2Ch.xml"; }
            get { return path + "\\conf\\CameraS.xml"; }
        }

        /// <summary>
        /// 从 app.config中获取配置信息
        /// </summary>
        private void GetInfoFrom_AppConfig()
        {
            //获取文件路径
            try
            {
                path = System.Configuration.ConfigurationManager.AppSettings["InfoPath"].Trim().TrimEnd('\\');

                //创建Conf目录
                if (!System.IO.Directory.Exists(path + "\\conf"))
                {
                    System.IO.Directory.CreateDirectory(path + "\\conf");
                }
            }
            catch (Exception ex)
            {
                string str = "*.config 文件中无 \r\n<appSettings>\r\n <add key=\"InfoPath\" value=\"**\" />\r\n</appSettings>" + ex.ToString();
                System.Windows.MessageBox.Show("*.config 文件中无 \r\n<appSettings>\r\n <add key=\"InfoPath\" value=\"**\" />\r\n</appSettings>");
               // Global.WriteLog("GetInfoFrom_AppConfig:\n" + str + "\n" + ex.ToString());
                //退出
                Environment.Exit(0);
            }
        }
    }
}
