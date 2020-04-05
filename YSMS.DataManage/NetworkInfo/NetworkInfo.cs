using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace YSMS.DataManage
{
    public class NetworkInfo
    {
        #region 实例对象（单例）
        private static NetworkInfo instance;
        /// <summary>
        /// 获取单例对象
        /// </summary>
        /// <returns></returns>
        public static NetworkInfo getInstance()
        {
            if (instance == null)
            {
                lock (typeof(SoftwareInfo))
                {
                    if (instance == null)
                    {
                        instance = new NetworkInfo();
                    }
                }
            }
            return instance;
        }

        private NetworkInfo()
        {
        }
        #endregion

        /// <summary>
        /// 网络报警ip
        /// </summary>      
        public string AlarmIP = "192.168.100.2";
        /// <summary>
        /// 网络报警port
        /// </summary>     
        public int AlarmPort = 9700;

        


        #region PLC信息
        /// <summary>
        /// 前缀
        /// </summary>
        public string PrefixCode = "8000020001000002000001";

        public string PlcIP = "192.168.250.1";

        public int PlcPort = 9600;

        /// <summary>
        /// UDP  IP Port 参数
        /// </summary>
        /// <summary>      
        public string OperRead = "01";
        public string OperWrite = "02";
       
        

        

        #endregion
        /// <summary>
        /// 载入网络通讯参数
        /// </summary>
        /// <param name="path"></param>
        /// <param name="exMessage"></param>
        /// <returns></returns>
        public int load(string path, ref string exMessage)
        {
            int result = 0;
            try
            {
                using (Stream fStream = File.OpenRead(path))
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(NetworkInfo));
                    instance = serializer.Deserialize(fStream) as NetworkInfo;
                }
            }
            catch (System.Exception ex)
            {
                SoftwareInfo.getInstance (). WriteLog("load:\n" + ex.ToString());
                exMessage = ex.Message;
                result = 1;
            }
            return result;
        }
    }
}
