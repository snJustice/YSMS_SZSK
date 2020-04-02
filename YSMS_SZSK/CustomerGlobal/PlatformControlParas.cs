using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using YSMS_SZSK.LibCustomerDataManager;
using YSMS_SZSK.MessagePrompt;

namespace YSMS_SZSK.CustomerGlobal
{
    public class PlatformControlParas : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        /// <summary>
        /// 回原点起始速度
        /// </summary>
        private double m_returnStartSpeed;
        public double ReturnStartSpeed
        {
            get { return m_returnStartSpeed; }
            set
            {
                m_returnStartSpeed = value;
                OnPropertyChanged("ReturnStartSpeed");
            }
        }

        /// <summary>
        /// 回原点过程速度
        /// </summary>
        private double m_returnRunSpeed;
        public double ReturnRunSpeed
        {
            get { return m_returnRunSpeed; }
            set
            {
                m_returnRunSpeed = value;
                OnPropertyChanged("ReturnRunSpeed");
            }
        }

        /// <summary>
        /// 回原点加速时间
        /// </summary>
        private double m_returnAccTime;
        public double ReturnAccTime
        {
            get { return m_returnAccTime; }
            set
            {
                m_returnAccTime = value;
                OnPropertyChanged("ReturnAccTime");
            }
        }

        /// <summary>
        /// 回原点减速时间
        /// </summary>
        private double m_returnDecTime;
        public double ReturnDecTime
        {
            get { return m_returnDecTime; }
            set
            {
                m_returnDecTime = value;
                OnPropertyChanged("ReturnDecTime");
            }
        }

        /// <summary>
        /// 运动起始速度
        /// </summary>
        private double m_moveStartSpeed;
        public double MoveStartSpeed
        {
            get { return m_moveStartSpeed; }
            set
            {
                m_moveStartSpeed = value;
                OnPropertyChanged("MoveStartSpeed");
            }
        }

        /// <summary>
        /// 运动过程速度
        /// </summary>
        private double m_moveRunSpeed;
        public double MoveRunSpeed
        {
            get { return m_moveRunSpeed; }
            set
            {
                m_moveRunSpeed = value;
                OnPropertyChanged("MoveRunSpeed");
            }
        }

        /// <summary>
        /// 运动加速时间
        /// </summary>
        private double m_moveAccTime;
        public double MoveAccTime
        {
            get { return m_moveAccTime; }
            set
            {
                m_moveAccTime = value;
                OnPropertyChanged("MoveAccTime");
            }
        }

        /// <summary>
        /// 运动减速时间
        /// </summary>
        private double m_moveDecTime;
        public double MoveDecTime
        {
            get { return m_moveDecTime; }
            set
            {
                m_moveDecTime = value;
                OnPropertyChanged("MoveDecTime");
            }
        }


        /// <summary>
        /// 点动起始速度
        /// </summary>
        private double m_pointStartSpeed;
        public double PointStartSpeed
        {
            get { return m_pointStartSpeed; }
            set
            {
                m_pointStartSpeed = value;
                OnPropertyChanged("PointStartSpeed");
            }
        }

        /// <summary>
        /// 点动过程速度
        /// </summary>
        private double m_pointRunSpeed;
        public double PointRunSpeed
        {
            get { return m_pointRunSpeed; }
            set
            {
                m_pointRunSpeed = value;
                OnPropertyChanged("PointRunSpeed");
            }
        }

        /// <summary>
        /// 点动加速时间
        /// </summary>
        private double m_pointAccTime;
        public double PointAccTime
        {
            get { return m_pointAccTime; }
            set
            {
                m_pointAccTime = value;
                OnPropertyChanged("PointAccTime");
            }
        }

        /// <summary>
        /// 点动减速时间
        /// </summary>
        private double m_pointDecTime;
        public double PointDecTime
        {
            get { return m_pointDecTime; }
            set
            {
                m_pointDecTime = value;
                OnPropertyChanged("PointDecTime");
            }
        }

        /// <summary>
        /// 点动运动距离
        /// </summary>
        private double m_pointRunDistance;
        public double PointRunDistance
        {
            get { return m_pointRunDistance; }
            set
            {
                m_pointRunDistance = value;
                OnPropertyChanged("PointRunDistance");
            }
        }

        public PlatformControlParas()
        {
            PlatformControlParasInit();
        }

        public bool SavePlatformControlParas()
        {
            bool result = true;
            string filePath = ProductFilesInfo.getInstance().MoveParasXmlNamePath;

            //2015-11-09 ludc 临时修复程序
            if (Global.m_OpenDefineMeasureType == PublicEnum.OpenDefineMeasureType.ProgrameRepair)
            {
                filePath = filePath.Replace("\\Products\\" + ProductFilesInfo.getInstance().ProductName + "\\", "\\TempFiles\\");
            }

            FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);

            XElement root = new XElement("Root");

            root.Add(XmlSerializer.Serialize(Global.m_PlatformControlParasX));

            try
            {
                root.Save(stream);
                stream.Close();
            }
            catch (Exception e)
            {
                MyMessageBox.GetInstance().tipsInfo = "保存发生未知错误: \n" + e.Message;
                MyMessageBox.GetInstance().ShowWindow(PublicEnum.MessageType.Tips);

                result = false;
            }

            return result;
        }

        public bool LoadPlatformControlParas(string filePath)
        {
            bool result = true;

            XElement root = null;
            try
            {
                root = XElement.Load(filePath);
            }
            catch (Exception e)
            {
                MyMessageBox.GetInstance().tipsInfo = "加载软件配置文件出错：\n" + e.Message;
                MyMessageBox.GetInstance().ShowWindow(PublicEnum.MessageType.Tips);

                result = false;
            }

            Global.m_PlatformControlParasX = XmlSerializer.Deserialize(root.Elements().First(), typeof(PlatformControlParas)) as PlatformControlParas;

            return result;
        }

        /// <summary>
        /// 参数初始化
        /// </summary>
        public void PlatformControlParasInit()
        {
            m_returnStartSpeed = 500;
            m_returnRunSpeed = 30000;
            m_returnAccTime = 0.1;
            m_returnDecTime = 0.1;
            m_moveStartSpeed = 500;
            m_moveRunSpeed = 30000;
            m_moveAccTime = 0.1;
            m_moveDecTime = 0.1;
            m_pointStartSpeed = 500;
            m_pointRunSpeed = 30000;
            m_pointAccTime = 0.1;
            m_pointDecTime = 0.1;
            m_pointRunDistance = 1000;
        }
    }
}