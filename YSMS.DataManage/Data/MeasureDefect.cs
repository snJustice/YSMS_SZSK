using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using HalconDotNet;

namespace YSMS.DataManage
{
    /// <summary>
    /// 缺陷检测
    /// </summary>
    [Serializable]
    public class MeasureDefect : INotifyPropertyChanged, IChangeShowName
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


        private GenericAlgorithm m_DefectAlgorithm;
        /// <summary>
        /// 算法
        /// </summary>
        public GenericAlgorithm DefectAlgorithm
        {
            get
            {
                if (m_DefectAlgorithm == null)
                {
                    m_DefectAlgorithm = new GenericAlgorithm();
                }
                return m_DefectAlgorithm;
            }
            set
            {
                m_DefectAlgorithm = value;
                OnPropertyChanged("DefectAlgorithm");
            }
        }


        private string m_Id;
        /// <summary>
        /// 缺陷编号
        /// </summary>
        public string Id
        {
            get
            {
                return m_Id;
            }
            set
            {
                m_Id = value;
                OnPropertyChanged("Id");
            }
        }


        private string m_DefectName;
        /// <summary>
        /// 缺陷名称
        /// </summary>
        public string DefectName
        {
            get
            {
                return m_DefectName;
            }
            set
            {
                m_DefectName = value;
                OnPropertyChanged("DefectName");
            }
        }

        private ObservableCollection<HRect> m_HRectList;
        /// <summary>
        /// 矩形框列表
        /// </summary>
        public ObservableCollection<HRect> HRectList
        {
            get
            {
                if (m_HRectList == null)
                {
                    m_HRectList = new ObservableCollection<HRect>();
                }
                return m_HRectList;
            }
            set
            {
                m_HRectList = value;
                OnPropertyChanged("HRectList");
            }
        }

        private ObservableCollection<HCircle> m_HCircleList;
        /// <summary>
        /// 圆列表
        /// </summary>
        public ObservableCollection<HCircle> HCircleList
        {
            get
            {
                if (m_HCircleList == null)
                {
                    m_HCircleList = new ObservableCollection<HCircle>();
                }
                return m_HCircleList;
            }
            set
            {
                m_HCircleList = value;
                OnPropertyChanged("HCircleList");
            }
        }

        private ObservableCollection<HPolygon> m_HPolygonList;
        /// <summary>
        /// 多变形列表
        /// </summary>
        public ObservableCollection<HPolygon> HPolygonList
        {
            get
            {
                if (m_HPolygonList == null)
                {
                    m_HPolygonList = new ObservableCollection<HPolygon>();
                }
                return m_HPolygonList;
            }
            set
            {
                m_HPolygonList = value;
                OnPropertyChanged("HPolygonList");
            }
        }

        private HObject m_Hcontour;
        /// <summary>
        /// 轮廓
        /// </summary>
        public HObject Hcontour
        {
            get
            {
                if (m_Hcontour == null)
                {
                    m_Hcontour = new HObject();
                }
                return m_Hcontour;
            }
            set
            {
                m_Hcontour = value;
                OnPropertyChanged("Hcontour");
            }
        }


        private ObservableCollection<HCross> m_HCrossList;
        /// <summary>
        /// 十字列表
        /// </summary>
        public ObservableCollection<HCross> HCrossList
        {
            get
            {
                if (m_HCrossList == null)
                {
                    m_HCrossList = new ObservableCollection<HCross>();
                }
                return m_HCrossList;
            }
            set
            {
                m_HCrossList = value;
                OnPropertyChanged("HCrossList");
            }
        }

        private ObservableCollection<HCross> m_HDotList;
        /// <summary>
        /// 点列表
        /// </summary>
        public ObservableCollection<HCross> HDotList
        {
            get
            {
                if (m_HDotList == null)
                {
                    m_HDotList = new ObservableCollection<HCross>();
                }
                return m_HDotList;
            }
            set
            {
                m_HDotList = value;
                OnPropertyChanged("HCrossList");
            }
        }

        

        public override string ToString()
        {
            return this.DefectName;
        }

        void IChangeShowName.ChangeName(string showName)
        {
            this.DefectName = showName;
        }

        public MeasureDefect()
        {

        }

        public void Copy(MeasureDefect measureDefect)
        {
            this.DefectAlgorithm.Copy(measureDefect.DefectAlgorithm);
            
            this.DefectName = measureDefect.DefectName;

            this.HRectList.Clear();
            foreach (var item in measureDefect.HRectList)
            {
                HRect hRect = new HRect();
                hRect.Copy(item);
                this.HRectList.Add(hRect);
            }

            this.HCircleList.Clear();
            foreach (var item in measureDefect.HCircleList)
            {
                HCircle hCircle = new HCircle();
                hCircle.Copy(item);
                this.HCircleList.Add(hCircle);
            }

            this.HPolygonList .Clear();
            foreach (var item in measureDefect.HPolygonList)
            {
                HPolygon hPolygon = new HPolygon();
                hPolygon.Copy(item);
                this.HPolygonList.Add(hPolygon);
            }

            this.Id = measureDefect.Id;
        }

        public void CopyDefectAlgorithm(MeasureDefect measureDefect)
        {
            this.DefectAlgorithm.Copy(measureDefect.DefectAlgorithm);
            this.DefectName = measureDefect.DefectName;
        }
        //public void Init()
        //{
        //    this.DefectAlgorithm = new GenericAlgorithm();
        //    this.DefectName = "";
        //    this.HRectList = new ObservableCollection<HRect>();
        //    this.Id = "";
        //}
    }
}
