using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace YSMS.DataManage
{
    public class SizeAlgorithm : AlgorithmBasis, INotifyPropertyChanged, ICloneable
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public SizeAlgorithm() { }

        private int m_SizeNum;
        /// <summary>
        /// 尺寸数量
        /// </summary>
        public int SizeNum
        {
            get
            {
                return m_SizeNum;
            }
            set
            {
                m_SizeNum = value;
                OnPropertyChanged("SizeNum");
            }
        }

        private double m_Std;
        /// <summary>
        /// 公称值
        /// </summary>
        public double Std
        {
            get
            {
                return m_Std;
            }
            set
            {
                m_Std = value;
                OnPropertyChanged("Std");
            }
        }


        private double m_Up;
        /// <summary>
        /// 上公差
        /// </summary>
        public double Up
        {
            get
            {
                return m_Up;
            }
            set
            {
                m_Up = value;
                OnPropertyChanged("Up");
            }
        }

        private double m_Down;
        /// <summary>
        /// 下公差
        /// </summary>
        public double Down
        {
            get
            {
                return m_Down;
            }
            set
            {
                m_Down = value;
                OnPropertyChanged("Down");
            }
        }

        private double m_Compensate;
        /// <summary>
        /// 补偿值
        /// </summary>
        public double Compensate
        {
            get
            {
                return m_Compensate;
            }
            set
            {
                m_Compensate = value;
                OnPropertyChanged("Compensate");
            }
        }

        private int m_IsShow;
        /// <summary>
        /// 是否显示(0不显示，1显示)
        /// </summary>
        public int IsShow
        {
            get { return m_IsShow; }
            set
            {
                m_IsShow = value;
                OnPropertyChanged("IsShow");
            }
        }

        private List<AlgorithmParas> m_GenericAlgorithmParasList;
        /// <summary>
        /// 参数列
        /// </summary>
        public List<AlgorithmParas> GenericAlgorithmParasList
        {
            get
            {
                if (m_GenericAlgorithmParasList == null)
                {
                    m_GenericAlgorithmParasList = new List<AlgorithmParas>();
                }
                return m_GenericAlgorithmParasList;
            }
            set
            {
                m_GenericAlgorithmParasList = value;
                OnPropertyChanged("GenericAlgorithmParasList");
            }
        }

        public Object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
