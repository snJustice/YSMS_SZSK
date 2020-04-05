using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace YSMS.DataManage
{
    /// <summary>
    /// 通用算法类
    /// </summary>
    public class GenericAlgorithm : AlgorithmBasis, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public GenericAlgorithm()
        {

        }


        private int m_TimesToAlarm = 1;
        /// <summary>
        /// 连续出现几次报警 0-10
        /// </summary>
        public int TimesToAlarm
        {
            get { return m_TimesToAlarm; }
            set
            {
                m_TimesToAlarm = value;
                OnPropertyChanged("TimesToAlarm");
            }
        }

        /// <summary>
        /// 精确等级 0-8 默认7
        /// </summary>
        private int m_PrecisionLevel = 1;
        public int PrecisionLevel
        {
            get { return m_PrecisionLevel; }
            set
            {
                m_PrecisionLevel = value;
                OnPropertyChanged("PrecisionLevel");
            }
        }

        /// <summary>
        /// 是否连续报警
        /// </summary>
        private bool m_IsContinuousAlarm ;
        public bool IsContinuousAlarm
        {
            get { return m_IsContinuousAlarm; }
            set
            {
                m_IsContinuousAlarm = value;
                OnPropertyChanged("IsContinuousAlarm");
            }
        }

        /// <summary>
        /// 多少张图判断一次报警
        /// </summary>
        private int m_GroupNumAlarm = 20;
        public int GroupNumAlarm
        {
            get { return m_GroupNumAlarm; }
            set
            {
                m_GroupNumAlarm = value;
                OnPropertyChanged("GroupNumAlarm");
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
        public void Copy(GenericAlgorithm genericAlgorithm)
        {
            List<AlgorithmParas> genericAlgorithmParasList = new List<AlgorithmParas>();
            foreach (var item in genericAlgorithm.GenericAlgorithmParasList)
            {
                genericAlgorithmParasList.Add(new AlgorithmParas()
                {
                    Name = item.Name,
                    IsSenior = item.IsSenior,
                    Tip = item.Tip,
                    Value = item.Value
                });
            }

            this.TimesToAlarm = genericAlgorithm.TimesToAlarm;
            this.PrecisionLevel = genericAlgorithm.PrecisionLevel;
            this.IsContinuousAlarm = genericAlgorithm.IsContinuousAlarm;
            this.GroupNumAlarm = genericAlgorithm.GroupNumAlarm;
            this.GenericAlgorithmParasList = genericAlgorithmParasList;
            this.m_AlgId = genericAlgorithm.m_AlgId;
            this.m_AlgName = genericAlgorithm.m_AlgName;
        }

    }
   
}
