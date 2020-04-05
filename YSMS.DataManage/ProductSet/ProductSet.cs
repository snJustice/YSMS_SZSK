using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace YSMS.DataManage
{
    public class ProductSet
    {
          #region 实例对象（单例）
        private static ProductSet instance;
        /// <summary>
        /// 获取单例对象
        /// </summary>
        /// <returns></returns>
        public static ProductSet getInstance()
        {
            if (instance == null)
            {
                lock (typeof(ProductSet))
                {
                    if (instance == null)
                    {
                        instance = new ProductSet();
                    }
                }
            }
            return instance;
        }

        private ProductSet()
        {
        }
        #endregion


        /// <summary>
        /// 产品类型
        /// </summary>
        public string Type = string.Empty;

        /// <summary>
        /// 默认产品名称
        /// </summary>
        public string DefaultName = string.Empty;

        /// <summary>
        /// 默认色彩通道
        /// </summary>
        public int DefaultColorChannel = 0;

        /// <summary>
        /// 可用缺陷算法集合
        /// </summary>
        public List<int> EnableDefectAlgs = new List<int>();

        /// <summary>
        /// 可用尺寸算法集合
        /// </summary>
        public List<int> EnableSizeAlgs = new List<int>();

        //默认ROI宽度（mm）
        public int ROIWidth = 10;
        //默认ROI高度
        public int ROIHeight = 10;
        //触发模式 软件触发0 硬件触发1
        public int CameraPhotoType = 0;
        

        public int load(string path, ref string exMessage)
        {
            int result = 0;
            try
            {
                using (Stream fStream = File.OpenRead(path))
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(ProductSet));
                    instance = serializer.Deserialize(fStream) as ProductSet;
                }
            }
            catch (System.Exception ex)
            {
                SoftwareInfo.getInstance().WriteLog("load:\n"+ex.ToString ());
                exMessage = ex.Message;
                result = 1;
            }
            return result;
        }
    }
}
