namespace YSMS_SZSK.CustomerGlobal
{
    public class ProductFilesInfo
    {
        #region 实例对象（单例）
        private static ProductFilesInfo instance;
        /// <summary>
        /// 获取单例对象
        /// </summary>
        /// <returns></returns>
        public static ProductFilesInfo getInstance()
        {
            if (instance == null)
            {
                lock (typeof(ProductFilesInfo))
                {
                    if (instance == null)
                    {
                        instance = new ProductFilesInfo();
                    }
                }
            }
            return instance;
        }
        #endregion 

        private string configInfoPath;
        /// <summary>
        /// 配置文件总路径
        /// </summary>
        public string ConfigInfoPath
        {
            get { return configInfoPath; }
        }

        private string allProductsFilesPath;
        /// <summary>
        /// 所有产品文件夹路径
        /// </summary>
        public string AllProductsFilesPath
        {
            get { return allProductsFilesPath; }
        }

        private string tempFilesPath;
        /// <summary>
        /// 临时文件夹路径
        /// </summary>
        public string TempFilesPath
        {
            get { return tempFilesPath; }
        }



        private string productName;
        /// <summary>
        /// 产品名
        /// </summary>
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        /// <summary>
        /// 产品文件夹路径
        /// </summary>
        public string ProductFilesPath
        {
            get { return allProductsFilesPath + "\\" + productName; }
        }

        private string xmlFileName;
        /// <summary>
        /// 工程文件名
        /// </summary>
        public string XmlFilePath
        {
            get { return allProductsFilesPath + "\\" + productName + "\\" + xmlFileName; }
        }

        /// <summary>
        /// 临时工程文件名
        /// </summary>
        public string TempXmlFilePath
        {
            get { return tempFilesPath + "\\" + xmlFileName; }
        }



        private string imageFileName;
        /// <summary>
        /// 原始图片路径
        /// </summary>
        public string ImageFilePath
        {
            get { return allProductsFilesPath + "\\" + productName + "\\" + imageFileName; }
        }
        /// <summary>
        /// 临时原始图片路径
        /// </summary>
        public string TempImageFilePath
        {
            get { return tempFilesPath + "\\" + imageFileName; }
        }

        private string trolerallProductsFilesPath;
        /// <summary>
        /// 所有产品文件夹路径
        /// </summary>
        public string TrolerallProductsFilesPath
        {
            get { return trolerallProductsFilesPath; }
        }

        private ProductFilesInfo()
        {
            //获取路径
            getproductFilesPath();
        }



        private void getproductFilesPath()
        {
            //获取文件路径
            try
            {
                configInfoPath = System.Configuration.ConfigurationManager.AppSettings["CfgInfoPath"].Trim();


                allProductsFilesPath = configInfoPath + System.Configuration.ConfigurationManager.AppSettings["ProductFilesPath"].Trim();
                tempFilesPath = configInfoPath + System.Configuration.ConfigurationManager.AppSettings["TempFilesPath"].Trim();

                xmlFileName = System.Configuration.ConfigurationManager.AppSettings["XmlFileName"].Trim();
                imageFileName = System.Configuration.ConfigurationManager.AppSettings["ImageFileName"].Trim();
                //2015824 czf
                moveParasXmlName = System.Configuration.ConfigurationManager.AppSettings["MoveParasXml"].Trim();
                trolerallProductsFilesPath = configInfoPath + System.Configuration.ConfigurationManager.AppSettings["trolerallProductsFilesPath"].Trim();
            }
            catch
            {

            }
        }

        public void Init()
        {
            //2015-11-09 ludc 程序修复的时候 不需要清空
            if (Global.m_OpenDefineMeasureType == PublicEnum.OpenDefineMeasureType.Nomal)
            {
                getproductFilesPath();
                productName = string.Empty;
            }
        }


        //2015824 czf
        private string moveParasXmlName;
        /// <summary>
        /// 移动参数文件路径
        /// </summary>
        public string MoveParasXmlNamePath
        {
            get { return allProductsFilesPath + "\\" + productName + "\\" + moveParasXmlName; }
        }
    }
}