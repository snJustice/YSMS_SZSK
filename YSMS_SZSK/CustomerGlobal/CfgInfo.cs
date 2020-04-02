using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YSMS_SZSK.MessagePrompt;

namespace YSMS_SZSK.CustomerGlobal
{
    class CfgInfo
    {

        #region 实例对象（单例） 
        private static CfgInfo instance;
        /// <summary>
        /// 获取单例对象
        /// </summary>
        /// <returns></returns>
        public static CfgInfo getInstance()
        {
            if (instance == null)
            {
                lock (typeof(CfgInfo))
                {
                    if (instance == null)
                    {
                        instance = new CfgInfo();
                    }
                }
            }
            return instance;
        }
        #endregion 

        private string cfgInfoPath;
        /// <summary>
        /// 程序文件路径
        /// </summary>
        public string CfgInfoPath
        {
            get { return cfgInfoPath; }
        }

        private string enumShowNameIniPath;
        /// <summary>
        /// 枚举文字显示配对.ini   路径
        /// </summary>
        public string EnumShowNameIniPath
        {
            get { return enumShowNameIniPath; }
        }


        private string camerParasXmlPath;
        /// <summary>
        /// 相机参数配置路径
        /// </summary>
        public string CamerParasIniPath
        {
            get { return camerParasXmlPath; }
        }




        private string operateTipsPath;
        /// <summary>
        /// 操作提示 +温馨提示 配置文件路径
        /// </summary>
        public string OperateTipsPath
        {
            get { return operateTipsPath; }
        }

        private string predefineNameIniPath;
        /// <summary>
        /// 预置名称配置路径
        /// </summary>
        public string PredefineNameIniPath
        {
            get { return predefineNameIniPath; }
        }






        /// <summary>
        /// 模块路径
        /// </summary>
        public string ModulePath
        {
            get;
            set;
        }

        /// <summary>
        /// 报警路径
        /// </summary>
        public string AlarmPath
        {
            get;
            set;
        }

        /// <summary>
        /// 相机打开文件路径
        /// </summary>
        public string CameraParaXmlPath
        {
            get;
            set;
        }

        /// <summary>
        /// 光源控制器配置文件路径
        /// </summary>
        public string LightControXmlPath { get; set; }

        private CfgInfo()
        {
            //获取配置路径
            getCfgInfoPath();

            getFiledIniPath(ref enumShowNameIniPath, "EnumShowNameIni", "文件丢失 : [枚举文字显示配对.ini] ,", true);

            getFiledIniPath(ref camerParasXmlPath, "CameraParasXml", "文件丢失 : [相机打开参数.xml] ,", true);


            getFiledIniPath(ref predefineNameIniPath, "PredefineNameIniPath", "文件丢失 : [元素预置名称.ini] ,", true);

            // getFiledIniPath(ref LightControXmlPath, "LightControXmlPath", "文件丢失 : [LightControl.xml] ,", true);

            getOperateTipsPath();
        }

        /// <summary>
        /// 获取配置路径
        /// </summary>
        private void getCfgInfoPath()
        {
            //获取文件路径
            try
            {
                cfgInfoPath = System.Configuration.ConfigurationManager.AppSettings["CfgInfoPath"].Trim();
            }
            catch
            {

            }
            if (cfgInfoPath == "")
            {
                MyMessageBox.GetInstance().tipsInfo = "程序配置文件路径错误（" + cfgInfoPath + "）!";
                MyMessageBox.GetInstance().ShowWindow(PublicEnum.MessageType.Tips);
                StaticPublicFunction.KillCurrentProcess();
            }
            if (!cfgInfoPath.Equals(""))
            {
                //不存在 创建配置文件路径
                if (!System.IO.Directory.Exists(cfgInfoPath))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(cfgInfoPath);

                    }
                    catch
                    {
                        MyMessageBox.GetInstance().tipsInfo = "程序配置文件路径错误（" + cfgInfoPath + "）!";
                        MyMessageBox.GetInstance().ShowWindow(PublicEnum.MessageType.Tips);
                        StaticPublicFunction.KillCurrentProcess();
                    }
                }
            }

            //模块路径 2017-02-05 ludc
            ModulePath = cfgInfoPath + System.Configuration.ConfigurationManager.AppSettings["ModulePath"].Trim();

            //报警文件路径 2017-03-22
            AlarmPath = cfgInfoPath + System.Configuration.ConfigurationManager.AppSettings["AlarmPath"].Trim();


            CameraParaXmlPath = cfgInfoPath + System.Configuration.ConfigurationManager.AppSettings["CameraParasXml"].Trim();
            LightControXmlPath = cfgInfoPath + System.Configuration.ConfigurationManager.AppSettings["lightControXml"].Trim();
        }
        /// <summary>
        /// 获取 字段文件路径
        /// </summary>
        /// <param name="filed">rel 字段</param>
        /// <param name="appCfgKey">app.config 配置信息</param>
        /// <param name="errorShow">错误提示信息</param>
        private void getFiledIniPath(ref string filed, string appCfgKey, string errorShow, bool errorKillProcess)
        {
            try
            {
                filed = cfgInfoPath + "\\" + System.Configuration.ConfigurationManager.AppSettings[appCfgKey];
            }
            catch
            {
            }
            if (!System.IO.File.Exists(filed))
            {
                MyMessageBox.GetInstance().errorNumber = 1021;
                MyMessageBox.GetInstance().errorDescribe = "配置文件异常";
                MyMessageBox.GetInstance().errorAnalysis = errorShow + " （" + filed + "）!";
                MyMessageBox.GetInstance().errorSolution = "检查文件是否存在或是否已损坏";
                MyMessageBox.GetInstance().ShowWindow(PublicEnum.MessageType.Error);

                //System.Windows.MessageBox.Show(errorShow + " （" + filed + "）!");

                if (errorKillProcess)
                    StaticPublicFunction.KillCurrentProcess();
            }
        }


        /// <summary>
        /// 操作提示 +温馨提示 配置文件路径
        /// </summary>
        private void getOperateTipsPath()
        {
            //获取文件路径
            try
            {
                operateTipsPath = System.Configuration.ConfigurationManager.AppSettings["OperateTipsPath"].Trim();
            }
            catch
            {

            }
            if (operateTipsPath == "")
            {
                MyMessageBox.GetInstance().tipsInfo = "程序配置文件路径错误（" + operateTipsPath + "）!";
                MyMessageBox.GetInstance().ShowWindow(PublicEnum.MessageType.Tips);

                //System.Windows.MessageBox.Show("程序配置文件路径错误（" + cfgInfoPath + "）!");
                StaticPublicFunction.KillCurrentProcess();
            }
            if (!operateTipsPath.Equals(""))
            {
                //不存在 创建配置文件路径
                if (!System.IO.Directory.Exists(operateTipsPath))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(operateTipsPath);

                    }
                    catch
                    {
                        MyMessageBox.GetInstance().tipsInfo = "程序配置文件路径错误（" + operateTipsPath + "）!";
                        MyMessageBox.GetInstance().ShowWindow(PublicEnum.MessageType.Tips);

                        //System.Windows.MessageBox.Show("程序配置文件路径错误（" + cfgInfoPath + "）!");
                        StaticPublicFunction.KillCurrentProcess();
                    }
                }
            }
        }
    }
}
