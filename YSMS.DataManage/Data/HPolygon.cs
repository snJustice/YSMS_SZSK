using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using HalconDotNet;

namespace YSMS.DataManage
{
    public  class HPolygon: INotifyPropertyChanged, IChangeShowName
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

        public HPolygon()
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

        private List<double> m_Row = new List<double> { };
        /// <summary>
        /// 顶点 Row = Y
        /// </summary>
        public List <double> Row
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

        private List<double> m_Column = new List<double> { };
        /// <summary>
        /// 顶点 Column = X
        /// </summary>
        public List<double> Column
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
        private HObject m_Polygon_xld;

        public HObject Polygon_xld
        {
            get
            {
                return m_Polygon_xld;
            }
            set
            {
                m_Polygon_xld = value;
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



        public void Copy(HPolygon hPolygon)
        {
            if (this.Column != null)
            {
                this.Column.Clear();
            }
            else 
            {
                this.Column = new List<double> { };
            }
            if (this.Row != null)
            {
                this.Row.Clear();
            }
            else
            {
                this.Row = new List<double> { };
            }
            this.Column .AddRange (hPolygon.Column);
            this.Id = hPolygon.Id;
            this.IsSelected = hPolygon.IsSelected;
            this.IsVisable = hPolygon.IsVisable;
            this.Radius = hPolygon.Radius;
            this.RectName = hPolygon.RectName;
            this.Row.AddRange( hPolygon.Row);
            this.Type = hPolygon.Type;
            this.Polygon_xld = hPolygon.Polygon_xld;
        }



        #region 阵列用

        private HPolygon baseHPolygon;
        /// <summary>
        /// 相对框
        /// </summary>
        public HPolygon BaseHPolygon
        {
            set
            {
                baseHPolygon = value;
            }
            get
            {
                return baseHPolygon;
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
                if (baseHPolygon != null)
                {
                    relativeX = this.Column[0] - baseHPolygon.Column[0];
                }
                return relativeX;
            }
            set
            {
                relativeX = value;
                if (baseHPolygon != null)
                {
                    for (int i = 0; i < baseHPolygon.Column.Count; i++)
                    {
                        this.m_Column[i] = baseHPolygon.Column[i] + relativeX;
                    }
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
                if (baseHPolygon != null)
                {
                    relativeY = this.Row[0] - baseHPolygon.Row[0];
                }
                return relativeY;
            }
            set
            {

                relativeY = value;
                if (baseHPolygon != null)
                {
                    for (int i = 0; i < baseHPolygon.m_Row.Count; i++)
                    {
                        this.m_Row[i] = baseHPolygon.m_Row[i] + relativeY;
                    }
                }
                OnPropertyChanged("RelativeY");
            }
        }
        #endregion
    }
}
