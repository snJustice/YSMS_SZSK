namespace YSMS_SZSK.Basic.PublicClass
{
    public delegate void RectValueChange();

    public class RectangleD
    {
        public event RectValueChange UpdateValue;

        private PointD m_center;
        /// <summary>
        /// 矩形中心点
        /// </summary>
        public PointD Center
        {
            get { return m_center; }
            set
            {
                if (m_center == null)
                {
                    m_center = new PointD(value);
                }
                else
                {
                    m_center.PointD_Copy(value);
                }

                if (UpdateValue != null)
                {
                    UpdateValue();
                }
            }
        }

        private double m_length1;
        /// <summary>
        /// 矩形半长1
        /// </summary>
        public double Length1
        {
            get { return m_length1; }
            set
            {
                m_length1 = value;

                if (UpdateValue != null)
                {
                    UpdateValue();
                }
            }
        }

        private double m_length2;
        /// <summary>
        /// 矩形半长2
        /// </summary>
        public double Length2
        {
            get { return m_length2; }
            set
            {
                m_length2 = value;

                if (UpdateValue != null)
                {
                    UpdateValue();
                }
            }
        }

        private double m_rotateArc;
        /// <summary>
        /// 旋转弧度
        /// </summary>
        public double RotateArc
        {
            get { return m_rotateArc; }
            set
            {
                m_rotateArc = value;

                if (UpdateValue != null)
                {
                    UpdateValue();
                }
            }
        }

        private double m_rotateAngle;
        /// <summary>
        /// 旋转角度
        /// </summary>
        public double RotateAngle
        {
            get { return m_rotateAngle; }
            set
            {
                m_rotateAngle = value;

                if (UpdateValue != null)
                {
                    UpdateValue();
                }
            }
        }

        /// <summary>
        /// 构造函数（无参数）
        /// </summary>
        public RectangleD()
        {
            PublicFunction1();
        }

        /// <summary>
        /// 构造函数（有参数）
        /// </summary>
        /// <param name="center"></param>
        /// <param name="rotateArc"></param>
        /// <param name="length1"></param>
        /// <param name="length2"></param>
        public RectangleD(PointD center, double rotateArc, double length1, double length2)
        {
            if (this.Center == null)
            {
                this.Center = new PointD(center);
            }
            else
            {
                this.Center.PointD_Copy(center);
            }

            this.RotateArc = rotateArc;
            this.Length1 = length1;
            this.Length2 = length2;
        }

        /// <summary>
        /// 构造函数（基于实例）
        /// </summary>
        /// <param name="instance"></param>
        public RectangleD(RectangleD instance)
        {
            PublicFunction2(instance);
        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        public void RectangleD_Init()
        {
            PublicFunction1();
        }

        /// <summary>
        /// 拷贝函数
        /// </summary>
        /// <param name="instance"></param>
        public void RectangleD_Copy(RectangleD instance)
        {
            PublicFunction2(instance);
        }

        /// <summary>
        /// 公共函数1
        /// </summary>
        public void PublicFunction1()
        {
            if (this.Center == null)
            {
                this.Center = new PointD();
            }
            else
            {
                this.Center.PointD_Init();
            }

            this.Length1 = 0;
            this.Length2 = 0;
            this.RotateArc = 0;
            this.RotateAngle = 0;
        }

        /// <summary>
        /// 公共函数2
        /// </summary>
        /// <param name="instance"></param>
        public void PublicFunction2(RectangleD instance)
        {
            if (this.Center == null)
            {
                this.Center = new PointD(instance.Center);
            }
            else
            {
                this.Center.PointD_Copy(instance.Center);
            }

            this.Length1 = instance.Length1;
            this.Length2 = instance.Length2;
            this.RotateArc = instance.RotateArc;
            this.RotateAngle = instance.RotateAngle;
        }

    }
}