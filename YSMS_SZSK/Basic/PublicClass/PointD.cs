using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YSMS_SZSK.Basic.PublicClass
{
    public delegate void PointValueChange();

    public class PointD
    {
        public event PointValueChange UpdateValue;

        private double m_x;
        /// <summary>
        /// X坐标
        /// </summary>
        public double X
        {
            get { return m_x; }
            set
            {
                m_x = value;

                if (UpdateValue != null)
                {
                    UpdateValue();
                }
            }
        }

        private double m_y;
        /// <summary>
        /// Y坐标系
        /// </summary>
        public double Y
        {
            get { return m_y; }
            set
            {
                m_y = value;

                if (UpdateValue != null)
                {
                    UpdateValue();
                }
            }
        }

        private double m_z;
        /// <summary>
        /// Z坐标
        /// </summary>
        public double Z
        {
            get { return m_z; }
            set
            {
                m_z = value;

                //if (UpdateValue != null)
                //{
                //    UpdateValue();
                //}
            }
        }

        //转成Point
        public Point ToPoint()
        {
            return new Point(X, Y);
        }

        /// <summary>
        /// 构造函数（无参数）
        /// </summary>
        public PointD()
        {
            this.PublicFunction1();
        }

        /// <summary>
        /// 构造函数（基于参数）
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public PointD(double x, double y)
        {
            this.X = x;
            this.Y = y;
            this.Z = 0;
        }

        /// <summary>
        /// 构造函数（基于参数）
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public PointD(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// 构造函数（基于实例）
        /// </summary>
        /// <param name="instance"></param>
        public PointD(PointD instance)
        {
            this.PublicFunction2(instance);
        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        public void PointD_Init()
        {
            this.PublicFunction1();
        }

        /// <summary>
        /// 拷贝函数
        /// </summary>
        /// <param name="instance"></param>
        public void PointD_Copy(PointD instance)
        {
            this.PublicFunction2(instance);
        }

        /// <summary>
        /// 公共函数1
        /// </summary>
        public void PublicFunction1()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
        }

        /// <summary>
        /// 公共函数2
        /// </summary>
        /// <param name="instance"></param>
        public void PublicFunction2(PointD instance)
        {
            this.X = instance.X;
            this.Y = instance.Y;
            this.Z = instance.Z;
        }

        //public override bool Equals(object obj)
        //{
        //    if (obj == null)
        //        return false;
        //    if (!obj.GetType().Equals(this.GetType()))
        //        return false;
        //    return Equals((PointD)obj);
        //}

        //private bool Equals( PointD obj)
        //{

        //    return this.m_x == obj.m_x && this.m_y == obj.m_y && this.m_z == obj.m_z;
        //}

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

    }
}
