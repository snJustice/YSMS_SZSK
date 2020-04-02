using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using YSMS_SZSK.Basic.PublicClass;
using YSMS_SZSK.CustomerGlobal;

namespace YSMS_SZSK.ImageDrawing
{
    public abstract class GraphicsBase : DrawingVisual
    {
        #region 常量
        protected double HitTestWidth = Global.m_SoftwareParas.HitTestWidth;
        protected double HandleSize = Global.m_SoftwareParas.HandleSize;

        //线宽
        protected double graphicsUnchoosedLineWidth = Global.m_SoftwareParas.BasicUnchoosedLineWidth;
        protected double graphicsChoosedLineWidth = Global.m_SoftwareParas.BasicChoosedLineWidth;

        //图形颜色
        protected Color graphicsUnchoosedColor = Global.m_SoftwareParas.BasicElementUnchoosedColor;
        protected Color graphicsChoosedColor = Global.m_SoftwareParas.BasicElementChoosedColor;

        //控制点
        //外圈颜色
        static SolidColorBrush handleBrush1 = new SolidColorBrush(Global.m_SoftwareParas.HandleOutSideColor);
        //中间颜色
        static SolidColorBrush handleBrush2 = new SolidColorBrush(Global.m_SoftwareParas.HandleMidSideColor);
        //内圈颜色
        static SolidColorBrush handleBrush3 = new SolidColorBrush(Global.m_SoftwareParas.HandleInSideColor);

        #endregion

        #region 变量

        public Element element;

        #endregion

        #region 属性
        public Color ObjectColor
        {
            get
            {
                if (IsChoosed)
                {
                    return graphicsChoosedColor;
                }
                else
                {
                    return graphicsUnchoosedColor;
                }
            }
        }

        /// <summary>
        /// 是否隐藏
        /// 这个属性更改会自动调用刷新图像
        /// </summary>
        public bool IsHide
        {
            get
            {
                return element.IsHide;
            }

            set
            {
                element.IsHide = value;
                RefreshDrawing();
            }
        }

        /// <summary>
        /// 是否选中
        /// 这个属性更改会自动调用刷新图像
        /// </summary>
        public bool IsChoosed
        {
            get
            {
                return element.IsChoosed;
            }

            set
            {
                if (element.IsChooseEnable)
                {
                    element.IsChoosed = value;
                }
                else
                {
                    element.IsChoosed = false;
                }
                RefreshDrawing();
            }
        }

        /// <summary>
        /// 是否可选中
        /// 这个属性更改会自动调用刷新图像
        /// </summary>
        public bool IsChooseEnable
        {
            get
            {
                return element.IsChooseEnable;
            }

            set
            {
                element.IsChooseEnable = value;

                RefreshDrawing();
            }
        }


        protected double ActualLineWidth
        {
            get
            {
                return IsChoosed ? ActuaChoosedlLineWidth : ActualUnchoosedLineWidth;
            }
        }

        protected double ActualUnchoosedLineWidth
        {
            get
            {
                return graphicsUnchoosedLineWidth / Global.m_Pvb.m_ZoomScale;
            }
        }

        protected double ActuaChoosedlLineWidth
        {
            get
            {
                return graphicsChoosedLineWidth / Global.m_Pvb.m_ZoomScale;
            }
        }

        protected double ActualHandleSize
        {
            get
            {
                return HandleSize / Global.m_Pvb.m_ZoomScale;
            }
        }


        //线的判定宽度
        protected double LineHitTestWidth
        {
            get
            {
                return Math.Max(HitTestWidth / Global.m_Pvb.m_ZoomScale, ActualLineWidth);
            }
        }



        #endregion

        #region 抽象方法与属性
        /// <summary>
        /// 获取控制点个数
        /// </summary>
        public abstract int HandleCount
        {
            get;
        }

        /// <summary>
        /// 获取控制点坐标
        /// </summary>
        public abstract Point GetHandle(int handleNumber);

        /// <summary>
        /// 点命中测试
        /// </summary>
        public abstract bool Contains(Point point);

        /// <summary>
        ///点命中测试
        /// 返回: -1 - 未命中
        ///        0 - 图形中任何位置
        ///      > 1 - 控制点号
        /// </summary>
        public abstract int MakeHitTest(Point point);

        /// <summary>
        /// 框选命中测试
        /// </summary>
        public abstract bool IntersectsWith(Rect rectangle);

        /// <summary>
        /// 移动整体
        /// </summary>
        public abstract void Move(double deltaX, double deltaY);

        /// <summary>
        /// 移动控制点
        /// </summary>
        public abstract void MoveHandleTo(Point point, int handleNumber);

        ///
        ///获取控制点对应的鼠标指针类型
        /// </summary>
        public abstract Cursor GetHandleCursor(int handleNumber);


        #endregion

        #region 虚方法
        /// <summary>
        /// 旋转至某点
        /// </summary>
        public virtual void Rotate(Point point)
        {
        }

        /// <summary>
        /// 通过某个控制点旋转至某点
        /// </summary>
        public virtual void Rotate(Point point, int handleNumber)
        {
        }

        /// <summary>
        /// 绘制图形
        /// </summary>
        /// <param name="drawingContext"></param>
        public virtual void Draw(DrawingContext drawingContext)
        {
            if (!element.IsHide)
            {
                if (element.IsChoosed)
                {
                    DrawTracker(drawingContext);
                }
            }
        }

        /// <summary>
        /// 绘制边框
        /// </summary>
        /// <param name="drawingContext"></param>
        public virtual void DrawTracker(DrawingContext drawingContext)
        {
            for (int i = 1; i <= HandleCount; i++)
            {
                DrawHandleCircle(drawingContext, i);
            }
        }
        #endregion

        #region 其他方法
        /// <summary>
        /// 绘制控制点图形
        /// </summary>
        public void DrawHandleCircle(DrawingContext drawingContext, int handleNumber)
        {
            Point center = GetHandle(handleNumber);
            double size = Math.Max(ActualHandleSize, ActualLineWidth * 1.1);
            // 外圈
            drawingContext.DrawEllipse(handleBrush1, null, center, size / 2, size / 2);

            // 中圈
            drawingContext.DrawEllipse(handleBrush2, null, center, size * 3 / 8, size * 3 / 8);

            // 内圈
            drawingContext.DrawEllipse(handleBrush3, null, center, size / 4, size / 4);

        }

        //获取控制点的区域
        public Rect GetHandleRectangle(int handleNumber)
        {
            Point point = GetHandle(handleNumber);

            double size = Math.Max(ActualHandleSize, ActualLineWidth * 1.1);

            return new Rect(point.X - size / 2, point.Y - size / 2,
                size, size);
        }

        /// <summary>
        /// 刷新图形绘制
        /// </summary>
        public void RefreshDrawing()
        {
            DrawingContext dc = this.RenderOpen();

            Draw(dc);

            dc.Close();
        }
        #endregion

    }
}
