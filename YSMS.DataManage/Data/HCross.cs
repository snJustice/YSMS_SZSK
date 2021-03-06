﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using HalconDotNet;

namespace YSMS.DataManage
{
    /// <summary>
    /// 后续增加形状添加位置，临时显示
    /// </summary>
    public partial class HCross : INotifyPropertyChanged, IChangeShowName
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

        public HCross()
        {
            m_IsVisable = true;
        }


        private GraphType m_Type = GraphType.none;
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

        private double m_Phi;
        /// <summary>
        /// 旋转弧度
        /// </summary>
        public double Phi
        {
            get
            {
                return m_Phi;
            }
            set
            {
                m_Phi = value;
                OnPropertyChanged("Phi");
            }
        }

        private double m_Length1;
        /// <summary>
        /// 半长
        /// </summary>
        public double Length1
        {
            get
            {
                return m_Length1;
            }
            set
            {
                m_Length1 = value;
                OnPropertyChanged("Lenght1");
            }
        }


        private double m_Length2;
        /// <summary>
        /// 半宽
        /// </summary>
        public double Length2
        {
            get
            {
                return m_Length2;
            }
            set
            {
                m_Length2 = value;
                OnPropertyChanged("Lenght2");
            }
        }

        /// <summary>
        /// 矩形框变换后的图形
        /// </summary>
        private HObject  m_Rect_xld;

        public HObject  Rect_xld
        {
            get
            {
                return m_Rect_xld;
            }
            set 
            {
                m_Rect_xld = value;
            }
        }

         /// <summary>
        /// 十字
        /// </summary>
        private HObject m_Cross_xld;

        public HObject Cross_xld
        {
            get
            {
                return m_Cross_xld;
            }
            set 
            {
                m_Cross_xld = value;
            }
        }

        /// <summary>
        /// 线
        /// </summary>
        private HObject m_line_xld;

        public HObject line_xld
        {
            get
            {
                return m_line_xld;
            }
            set
            {
                m_line_xld = value;
            }
        }
        /// <summary>
        /// 行1
        /// </summary>
        private double  m_Row1;

        public double Row1
        {
            get
            {
                return m_Row1;
            }
            set
            {
                m_Row1 = value;
            }
        }
        /// <summary>
        /// 行2
        /// </summary>
        private double m_Row2;

        public double Row2
        {
            get
            {
                return m_Row2;
            }
            set
            {
                m_Row2 = value;
            }
        }
        /// <summary>
        /// 列1
        /// </summary>
        private double m_Colum1;

        public double Colum1
        {
            get
            {
                return m_Colum1;
            }
            set
            {
                m_Colum1 = value;
            }
        }
        /// <summary>
        /// 列2
        /// </summary>
        private double m_Colum2;

        public double Colum2
        {
            get
            {
                return m_Colum2;
            }
            set
            {
                m_Colum2 = value;
            }
        }

        /// <summary>
        /// 字符
        /// </summary>
        private List<string> m_strList = new List<string> { } ;

        public List<string> StrList
        {
            get
            {
                return m_strList;
            }
            set
            {
                m_strList = value;
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



        //public void Copy(HCross hRect)
        //{
        //    this.Column = hRect.Column;
        //    this.Id = hRect.Id;
        //    this.IsSelected = hRect.IsSelected;
        //    this.IsVisable = hRect.IsVisable;
        //    this.Length1 = hRect.Length1;
        //    this.Length2 = hRect.Length2;
        //    this.Phi = hRect.Phi;
        //    this.RectName = hRect.RectName;
        //    this.Row = hRect.Row;
        //    this.Type = hRect.Type;
        //    this.m_Rect_xld = hRect.m_Rect_xld;            
        //}



        #region 阵列用

        private HCross baseHRect;
        /// <summary>
        /// 相对框
        /// </summary>
        public HCross BaseHRect
        {
            set
            {
                baseHRect = value;
            }
            get
            {
                return baseHRect;
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
                if (baseHRect != null)
                {
                    relativeX = this.Column - baseHRect.Column;
                }
                return relativeX;
            }
            set
            {
                relativeX = value;
                if (baseHRect != null)
                {
                    this.m_Column = baseHRect.Column + relativeX;
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
                if (baseHRect != null)
                {
                    relativeY = this.Row - baseHRect.Row;
                }
                return relativeY;
            }
            set
            {

                relativeY = value;
                if (baseHRect != null)
                {
                    this.m_Row = baseHRect.m_Row + relativeY;
                }
                OnPropertyChanged("RelativeY");
            }
        }
        #endregion

    }

   
}
