using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;
using HalconDotNet;

namespace YSMS.DataManage
{
    [Serializable]
    public class GenerateModelParas : INotifyPropertyChanged
    {

        #region MyRegion

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
        #endregion


        public GenerateModelParas()
        {
            //m_CreateChannel = SoftwareInfo.getInstance().DefaultCreateChannel;
            //m_DetectChannel = SoftwareInfo.getInstance().DefaultDetectChannel;
            m_LightOrDark = SoftwareInfo.getInstance().HasBacklit;
            m_RangeProduct = SoftwareInfo.getInstance().ProductGrayDefault;
            m_RangeLocation = SoftwareInfo.getInstance().HoleGrayDefault;
            m_MinScore = SoftwareInfo.getInstance().MinScoreDefault;
        }

        private bool m_IsGenerateModel;
        /// <summary>
        /// 是否已经生成了模板
        /// </summary>
        public bool IsGenerateModel
        {
            get { return m_IsGenerateModel; }
            set
            {
                m_IsGenerateModel = value;
                OnPropertyChanged("IsGenerateModel");
            }
        }   

        //1、亮产品（电镀 0）/黑产品（冲压 1）LightOrDark
        private int m_LightOrDark = 1;
        /// <summary>
        /// 亮产品（电镀 0）/黑产品（冲压 1）
        /// </summary>
        public int LightOrDark
        {
            get { return m_LightOrDark; }
            set
            {
                m_LightOrDark = value;
                OnPropertyChanged("LightOrDark");
            }
        }
        ////2、创建模板时选择的通道Channel_Create
        //private int m_CreateChannel = 1;

        //public int CreateChannel
        //{
        //    get { return m_CreateChannel; }
        //    set
        //    {
        //        m_CreateChannel = value;
        //        OnPropertyChanged("CreateChannel");
        //    }
        //}
        //3、产品灰度阈值RangeH
        private int m_RangeProduct = 120;
        public int RangeProduct
        {
            get { return m_RangeProduct; }
            set
            {
                m_RangeProduct = value;
                OnPropertyChanged("RangeProduct");
            }
        }
        //3、定位区域灰度阈值RangeLocation
        private int m_RangeLocation = 120;
        public int    RangeLocation
        {
            get { return m_RangeLocation; }
            set
            {
                m_RangeLocation = value;
                OnPropertyChanged("RangeLocation");
            }
        }
        //4、匹配角度报警阈值Angle_Modle
        private int m_Angle_Modle = 20;
        public int Angle_Modle
        {
            get { return m_Angle_Modle; }
            set
            {
                m_Angle_Modle = value;
                OnPropertyChanged("Angle_Modle");
            }
        }
        //5、选择模板面积区域 (表面区/背景区) Select_MD
        private int m_Select_MD = 0;
        public int Select_MD
        {
            get { return m_Select_MD; }
            set
            {
                m_Select_MD = value;
                OnPropertyChanged("Select_MD");
            }
        }
        //6、创建定位区域是否为封闭区IsClosedZone(0 非封闭 1 封闭)
        private int m_IsClosedZone = 1;
        public int IsClosedZone
        {
            get { return m_IsClosedZone; }
            set
            {
                m_IsClosedZone = value;
                OnPropertyChanged("IsClosedZone");
            }
        }
        //7、匹配分数阈值MinScore
        private double m_MinScore = 0.8;
        /// <summary>
        /// 最小匹配分数
        /// </summary>
        public double MinScore
        {
            get { return m_MinScore; }
            set
            {
                m_MinScore = value;
                OnPropertyChanged("MinScore");
            }
        }

        //8、框外是否要检
        private int m_ModelPriority = 0;
        /// <summary>
        /// 优先匹配模板
        /// </summary>
        public int ModelPriority
        {
            get { return m_ModelPriority; }
            set
            {
                m_ModelPriority = value;
                //OnPropertyChanged("MinScore");
            }
        }

        //9、框外是否要检
        private int m_DetectionOver = 0;
        /// <summary>
        /// 优先匹配模板
        /// </summary>
        public int DetectionOver
        {
            get { return m_DetectionOver; }
            set
            {
                m_DetectionOver = value;
                //OnPropertyChanged("MinScore");
            }
        }

        /// <summary>
        /// 定位方式（常规、打印、触发、坐标交点）
        /// </summary>
        private int m_LocationType = 0;
        public int LocationType
        {
            get { return m_LocationType; }
            set
            {
                m_LocationType = value;
                OnPropertyChanged("LocationType");
            }
        }

        private int m_DirectionY = 0;
        /// <summary>
        /// Y轴交点方向
        /// </summary>
        public int DirectionY
        {
            get { return m_DirectionY; }
            set
            { 
                m_DirectionY = value;
                OnPropertyChanged("DirectionY");
            }
        }

        private int m_DirectionX = 1;
        /// <summary>
        /// X轴交点方向
        /// </summary>
        public int DirectionX
        {
            get { return m_DirectionX; }
            set
            {
                m_DirectionX = value;
                OnPropertyChanged("DirectionX");
            }
        }

        private int m_StretchY = 1;
        /// <summary>
        /// Y轴图像拉伸系数
        /// </summary>
        public int StretchY
        {
            get { return m_StretchY; }
            set
            { 
                m_StretchY = value;
                OnPropertyChanged("StretchY");
            }
        }

        private int m_StretchX = 1;
        /// <summary>
        /// X轴图像拉伸系数
        /// </summary>
        public int StretchX
        {
            get { return m_StretchX; }
            set
            {
                m_StretchX = value;
                OnPropertyChanged("StretchX");
            }
        }

        [XmlIgnore]
        public HTuple ModelID = new HTuple();//引线框架单元模板ID
        [XmlIgnore]
        public HTuple ModelID_LH = new HTuple();//定位区域模板ID
        [XmlIgnore]
        public HTuple VarModelID = new HTuple();//图像比对模板ID
        [XmlIgnore]
        public HObject Region = new HObject();//Region
        //模板图像
        [XmlIgnore]
        public HObject Region_BigArea = new HObject();//Region
        [XmlIgnore]
        public HObject Region_Column = new HObject();//Region
        [XmlIgnore]
        public HObject Region_Row = new HObject();//Region
        [XmlIgnore]
        public HObject Region_Remove = new HObject();//Region


        //模板图像
        [XmlIgnore]
        public HObject ModelImage = new HObject();
        //临时图像
        [XmlIgnore]
        public HObject TempImage = new HObject();

        public void Copy(GenerateModelParas generateModeParas)
        {
            this.LightOrDark = generateModeParas.LightOrDark;
            this.IsGenerateModel = generateModeParas.IsGenerateModel;
            this.RangeProduct = generateModeParas.RangeProduct;
            this.RangeLocation = generateModeParas.RangeLocation;
            this.Angle_Modle = generateModeParas.Angle_Modle;
            this.Select_MD = generateModeParas.Select_MD;
            this.IsClosedZone = generateModeParas.IsClosedZone;
            this.MinScore = generateModeParas.MinScore;
            this.LocationType = generateModeParas.LocationType;

            this.DirectionY = generateModeParas.DirectionY;
            this.DirectionX = generateModeParas.DirectionX;
            this.StretchY = generateModeParas.StretchY;
            this.StretchX = generateModeParas.StretchX;
            this.DetectionOver = generateModeParas.DetectionOver;
            this.ModelPriority = generateModeParas.ModelPriority;
            this.ModelID = generateModeParas.ModelID;
            this.ModelID_LH = generateModeParas.ModelID_LH;
            this.VarModelID = generateModeParas.VarModelID;
            this.Region = generateModeParas.Region;
            this.ModelImage = generateModeParas.ModelImage;
            this.TempImage = generateModeParas.TempImage;


            //this.HoleGray = generateModeParas.HoleGray;
            //this.ProductGray = generateModeParas.ProductGray;
        }
    }
}
