using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace YSMS.DataManage
{
    public class PLCInformation
    {
        #region 实例对象（单例）
        private static PLCInformation instance;
        /// <summary>
        /// 获取单例对象
        /// </summary>
        /// <returns></returns>
        public static PLCInformation getInstance()
        {
            if (instance == null)
            {
                lock (typeof(PLCInformation))
                {
                    if (instance == null)
                    {
                        instance = new PLCInformation();
                    }
                }
            }
            return instance;
        }

        private PLCInformation()
        {
        }
        #endregion


        public Dictionary<uint, PLCFault> PLCFaultDic = new Dictionary<uint, PLCFault>();


        public int Load(string path, ref string exMessage)
        {
            int result = 0;
            try
            {
                System.Xml.Linq.XDocument xDoc = System.Xml.Linq.XDocument.Load(path);
                XElement root = xDoc.Root;
                //尺寸
                XElement PLCFaults = root.Element("PLCFaults");
                PLCFaultDic.Clear();
                foreach (var v in PLCFaults.Elements())
                {
                    PLCFault f = XmlSerializer.Deserialize(v, typeof(PLCFault)) as PLCFault;
                    PLCFaultDic.Add(f.ID, f);
                }
            }
            catch (System.Exception ex)
            {
                SoftwareInfo.getInstance().WriteLog("Load:\n"+ex .ToString ());
                exMessage = ex.Message;
                result = 1;
            }
            return result;
        }


    }
}
