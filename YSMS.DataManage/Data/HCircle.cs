using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using HalconDotNet;

namespace YSMS.DataManage
{

    /// <summary>
    /// 圆信息
    /// </summary>
    public partial class HCircle : INotifyPropertyChanged, IChangeShowName
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

        public HCircle()
        {
            m_IsVisable = true;
        }


        private GraphType m_Type;
        /// <summary>
        /// 框类型（根据类型推断颜色）
        /// </summary>
        public GraphType Type
        {
            get { return m_Type; }
            set
            {
                m_Type = value;
                OnPropertyChanged("Type");
            }
        }




        private string m_Id;
        /// <summary>
        /// 编号
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


        private string m_RectName;
        /// <summary>
        /// Rect名称
        /// </summary>
        public string RectName
        {
            get
            {
                return m_RectName;
            }
            set
            {
                m_RectName = value;
                OnPropertyChanged("RectName");
            }
        }

        private double m_Row;
        /// <summary>
        /// 中心点 Row = Y
        /// </summary>
        public double Row
        {
            get
            {
                return m_Row;
            }
            set
            {
                m_Row = value;
                OnPropertyChanged("Row");
            }
        }

        private double m_Column;
        /// <summary>
        /// 中心点 Column = X
        /// </summary>
        public double Column
        {
            get
            {
                return m_Column;
            }
            set
            {
                m_Column = value;
                OnPropertyChanged("Column");
            }
        }

        private double m_Radius;
        /// <summary>
        /// 半径
        /// </summary>
        public double Radius
        {
            get
            {
                return m_Radius;
            }
            set
            {
                m_Radius = value;
                OnPropertyChanged("Radius");
            }
        }
        /// <summary>
        /// 圆形框变换后的图形
        /// </summary>
        private HObject m_Circle_xld;

        public HObject Circle_xld
        {
            get
            {
                return m_Circle_xld;
            }
            set
            {
                m_Circle_xld = value;
            }
        }

        private bool m_IsSelected;
        /// <summary>
        /// 是否被选中
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return m_IsSelected;
            }
            set
            {
                m_IsSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }


        private bool m_IsVisable;
        /// <summary>
        /// 是否可见
        /// </summary>
        public bool IsVisable
        {
            get
            {
                return m_IsVisable;
            }
            set
            {
                m_IsVisable = value;
                OnPropertyChanged("IsVisable");
            }
        }

        public override string ToString()
        {
            return this.RectName;
        }

        void IChangeShowName.ChangeName(string showName)
        {
            this.RectName = showName;
        }



        public void Copy(HCircle hCircle)
        {
            this.Column = hCircle.Column;
            this.Id = hCircle.Id;
            this.IsSelected = hCircle.IsSelected;
            this.IsVisable = hCircle.IsVisable;
            this.Radius = hCircle.Radius;
            this.RectName = hCircle.RectName;
            this.Row = hCircle.Row;
            this.Type = hCircle.Type;
            this.Circle_xld = hCircle.Circle_xld;
        }



        #region 阵列用

        private HCircle baseHCircle;
        /// <summary>
        /// 相对框
        /// </summary>
        public HCircle BaseHCircle
        {
            set
            {
                baseHCircle = value;
            }
            get
            {
                return baseHCircle;
            }
        }

        private double relativeX;
        /// <summary>
        /// 相对框偏移X
        /// </summary>
        public double RelativeX
        {
            get
            {
                if (baseHCircle != null)
                {
                    relativeX = this.Column - baseHCircle.Column;
                }
                return relativeX;
            }
            set
            {
                relativeX = value;
                if (baseHCircle != null)
                {
                    this.m_Column = baseHCircle.Column + relativeX;
                }
                OnPropertyChanged("RelativeX");
            }
        }

        private double relativeY;
        /// <summary>
        /// 相对框偏移Y
        /// </summary>
        public double RelativeY
        {
            get
            {
                if (baseHCircle != null)
                {
                    relativeY = this.Row - baseHCircle.Row;
                }
                return relativeY;
            }
            set
            {

                relativeY = value;
                if (baseHCircle != null)
                {
                    this.m_Row = baseHCircle.m_Row + relativeY;
                }
                OnPropertyChanged("RelativeY");
            }
        }
        #endregion

    }

   
}
