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
    public class GraphicsTemplateToolElement : GraphicsMeasureBase
    {
        #region 常量
        private double minRectHalfLength;
        private double arrowStickLength;
        private double arrowLength;
        #endregion

        #region 构造函数
        public GraphicsTemplateToolElement(Point centerPoint, double halfWidth, double halfHeight, double angle)
            : this()
        {
            TemplateToolElement = new TemplateToolElement();
            RectCenter = centerPoint;
            HalfWidth = halfWidth;
            HalfHeight = halfHeight;
            RotateAngle = angle;
           // Global.m_Pfc.AddMeasureElement(Global.m_Pvb, PublicEnum.MeasureElementSubType.TemplateTool, TemplateToolElement);
          //  Global.m_Pfc.AddGraphicsMeasureElement(Global.m_Pvb, this);
        }



        public GraphicsTemplateToolElement(TemplateToolElement templateToolElement)
            : this()
        {
            this.TemplateToolElement = templateToolElement;
       //     Global.m_Pfc.AddMeasureElement(Global.m_Pvb, PublicEnum.MeasureElementSubType.TemplateTool, TemplateToolElement);
       //     Global.m_Pfc.AddGraphicsMeasureElement(Global.m_Pvb, this);
        }

        public GraphicsTemplateToolElement()
        {
            minRectHalfLength = Global.m_SoftwareParas.MinRectHalfLength;
            arrowStickLength = Global.m_SoftwareParas.ArrowStickLength;
            arrowLength = Global.m_SoftwareParas.ArrowLength;
        }
        #endregion


        #region 属性

        //本体
        public TemplateToolElement TemplateToolElement
        {
            get
            {
                return element as TemplateToolElement;
            }
            set
            {
                element = value;
            }
        }
        //矩形中心
        public Point RectCenter
        {
            get
            {
                PointD center = TemplateToolElement.CanvasRect.Center;
                return new Point(center.X, center.Y);
            }
            set
            {
                TemplateToolElement.CanvasRect.Center = new PointD(value.X, value.Y);
            }
        }

        //矩形半宽
        public double HalfWidth
        {
            get
            {
                return TemplateToolElement.CanvasRect.Length1;
            }
            set
            {
                TemplateToolElement.CanvasRect.Length1 = value;
            }
        }

        //矩形半高
        public double HalfHeight
        {
            get
            {
                return TemplateToolElement.CanvasRect.Length2;
            }
            set
            {
                TemplateToolElement.CanvasRect.Length2 = value;
            }
        }

        //矩形角度
        public double RotateAngle
        {
            get
            {
                return TemplateToolElement.CanvasRect.RotateAngle;
            }
            set
            {
                TemplateToolElement.CanvasRect.RotateAngle = value;
            }
        }

        #endregion


        #region 重写

        /// <summary>
        /// 绘制设备
        /// </summary>
        public override void Draw(DrawingContext drawingContext)
        {
            if (!TemplateToolElement.IsHide)
            {
                if (drawingContext == null)
                {
                    throw new ArgumentNullException("drawingContext");
                }

                base.Draw(drawingContext);

                RotateTransform rotateTransform = new RotateTransform(RotateAngle, RectCenter.X, RectCenter.Y);
                drawingContext.PushTransform(rotateTransform);

                drawingContext.DrawRectangle(
                    null,
                    new Pen(new SolidColorBrush(ObjectColor), ActualLineWidth),
                    new Rect(RectCenter.X - HalfWidth, RectCenter.Y - HalfHeight, HalfWidth * 2, HalfHeight * 2));

                //绘制箭头

                Point arrowBottomPoint = new Point();
                Point arrowheadPoint = new Point();

                arrowBottomPoint.X = RectCenter.X;
                arrowBottomPoint.Y = RectCenter.Y - (HalfHeight);

                arrowheadPoint.X = RectCenter.X;
                arrowheadPoint.Y = RectCenter.Y - (HalfHeight + arrowStickLength);

                Vector v = new Vector(arrowheadPoint.X - arrowBottomPoint.X, arrowheadPoint.Y - arrowBottomPoint.Y);
                v.Normalize();
                Matrix matrix1 = new Matrix();
                matrix1.Rotate(150);
                Vector v1 = Vector.Multiply(v, matrix1);
                Matrix matrix2 = new Matrix();
                matrix2.Rotate(-150);
                Vector v2 = Vector.Multiply(v, matrix2);

                drawingContext.DrawLine(
                  new Pen(new SolidColorBrush(ObjectColor), ActualLineWidth),
                  arrowBottomPoint,
                  arrowheadPoint);

                drawingContext.DrawLine(
                  new Pen(new SolidColorBrush(ObjectColor), ActualLineWidth),
                  arrowheadPoint,
                  arrowheadPoint + v1 * arrowLength);


                drawingContext.DrawLine(
                  new Pen(new SolidColorBrush(ObjectColor), ActualLineWidth),
                  arrowheadPoint,
                  arrowheadPoint + v2 * arrowLength);
            }
        }

        /// <summary>
        /// 旋转至m某点
        /// </summary>
        public override void Rotate(Point point)
        {
            Vector startVector = new Vector(0, -1);
            Vector endVector = Point.Subtract(point, RectCenter);

            double angle = Vector.AngleBetween(startVector, endVector);

            RotateAngle = angle;
            RefreshDrawing();
        }

        /// <summary>
        /// 获取控制点个数
        /// </summary>
        public override int HandleCount
        {
            get
            {
                return 9;
            }
        }

        /// <summary>
        /// 获取控制点坐标
        /// </summary>
        public override Point GetHandle(int handleNumber)
        {

            double x, y, xCenter, yCenter, halfWidth, halfHeight, halfObliqueLine;

            xCenter = RectCenter.X;
            yCenter = RectCenter.Y;
            x = RectCenter.X - HalfWidth;
            y = RectCenter.Y - HalfHeight;
            halfWidth = HalfWidth;
            halfHeight = HalfHeight;
            halfObliqueLine = Math.Sqrt(halfWidth * halfWidth + halfHeight * halfHeight);
            double internlAngle = Math.Atan(halfWidth / halfHeight);

            switch (handleNumber)
            {
                case 1:
                    x = xCenter + halfObliqueLine * Math.Cos(internlAngle + (90 - RotateAngle) / 180 * Math.PI);
                    y = yCenter + halfObliqueLine * Math.Cos(internlAngle + (180 - RotateAngle) / 180 * Math.PI);
                    break;
                case 2:
                    x = xCenter + halfHeight * Math.Cos((90 - RotateAngle) / 180 * Math.PI);
                    y = yCenter + halfHeight * Math.Cos((180 - RotateAngle) / 180 * Math.PI);
                    break;
                case 3:
                    x = xCenter + halfObliqueLine * Math.Cos(-internlAngle + (90 - RotateAngle) / 180 * Math.PI);
                    y = yCenter + halfObliqueLine * Math.Cos(-internlAngle + (180 - RotateAngle) / 180 * Math.PI);
                    break;
                case 4:
                    x = xCenter + halfWidth * Math.Cos((0 - RotateAngle) / 180 * Math.PI);
                    y = yCenter + halfWidth * Math.Cos((90 - RotateAngle) / 180 * Math.PI);
                    break;
                case 5:
                    x = xCenter + halfObliqueLine * Math.Cos(internlAngle + (-90 - RotateAngle) / 180 * Math.PI);
                    y = yCenter + halfObliqueLine * Math.Cos(internlAngle + (0 - RotateAngle) / 180 * Math.PI);
                    break;
                case 6:
                    x = xCenter + halfHeight * Math.Cos((-90 - RotateAngle) / 180 * Math.PI);
                    y = yCenter + halfHeight * Math.Cos((0 - RotateAngle) / 180 * Math.PI);
                    break;
                case 7:
                    x = xCenter + halfObliqueLine * Math.Cos(-internlAngle + (-90 - RotateAngle) / 180 * Math.PI);
                    y = yCenter + halfObliqueLine * Math.Cos(-internlAngle + (0 - RotateAngle) / 180 * Math.PI);
                    break;
                case 8:
                    x = xCenter + halfWidth * Math.Cos((-180 - RotateAngle) / 180 * Math.PI);
                    y = yCenter + halfWidth * Math.Cos((-90 - RotateAngle) / 180 * Math.PI);
                    break;
                case 9:
                    x = xCenter + (halfHeight + arrowStickLength) * Math.Cos((90 - RotateAngle) / 180 * Math.PI);
                    y = yCenter + (halfHeight + arrowStickLength) * Math.Cos((180 - RotateAngle) / 180 * Math.PI);
                    break;
            }

            return new Point(x, y);
        }

        /// <summary>
        /// 点命中测试
        /// </summary>
        public override bool Contains(Point point)
        {
            if (TemplateToolElement.IsChooseEnable)
            {
                Rect rectangle = new Rect(RectCenter.X - HalfWidth, RectCenter.Y - HalfHeight, HalfWidth * 2, HalfHeight * 2);
                Matrix matrix = new Matrix();
                matrix.RotateAt(-RotateAngle, RectCenter.X, RectCenter.Y);
                rectangle = Rect.Transform(rectangle, matrix);
                return rectangle.Contains(point);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///点命中测试
        /// 返回: -1 - 未命中
        ///        0 - 图形中任何位置
        ///      > 1 - 控制点号
        /// </summary>
        public override int MakeHitTest(Point point)
        {
            if (TemplateToolElement.IsChooseEnable)
            {
                if (TemplateToolElement.IsChoosed)
                {
                    for (int i = 1; i <= HandleCount; i++)
                    {
                        if (GetHandleRectangle(i).Contains(point))
                            return i;
                    }
                }

                if (Contains(point))
                    return 0;
            }
            return -1;
        }

        /// <summary>
        /// 框选命中测试
        /// </summary>
        public override bool IntersectsWith(Rect rectangle)
        {
            //if (TemplateToolElement.IsChooseEnable)
            //{
            //    Rect rect = new Rect(RectCenter.X - HalfWidth, RectCenter.Y - HalfHeight, HalfWidth * 2, HalfHeight * 2);

            //    return rect.IntersectsWith(rectangle);
            //}
            //else
            //{
            //    return false;
            //}
            return false;
        }

        /// <summary>
        /// 整体移动
        /// </summary>
        public override void Move(double deltaX, double deltaY)
        {
            if (TemplateToolElement.IsEditEnable)
            {
                RectCenter = new Point(RectCenter.X + deltaX, RectCenter.Y + deltaY);

                RefreshDrawing();
            }
        }

        /// <summary>
        /// 移动控制点
        /// </summary>
        public override void MoveHandleTo(Point point, int handleNumber)
        {
            if (TemplateToolElement.IsEditEnable)
            {
                double oldhalfWidth = HalfWidth;
                double oldhalfHeight = HalfHeight;
                //double oldhalfObliqueLine = Math.Sqrt(HalfWidth * HalfWidth + HalfHeight * HalfHeight);
                //double newLine = Math.Sqrt(Math.Pow((point.X - RectCenter.X), 2) + Math.Pow((point.Y - RectCenter.Y), 2));
                Matrix matrix = new Matrix();
                matrix.RotateAt(-RotateAngle, RectCenter.X, RectCenter.Y);
                Point pointRotated = Point.Multiply(point, matrix);
                double newhalfWidth = pointRotated.X - RectCenter.X;
                double newhalfHeight = pointRotated.Y - RectCenter.Y;

                switch (handleNumber)
                {
                    case 1:
                        if (-newhalfWidth > minRectHalfLength)
                        {
                            HalfWidth = -newhalfWidth;
                        }
                        if (-newhalfHeight > minRectHalfLength)
                        {
                            HalfHeight = -newhalfHeight;
                        }
                        break;
                    case 2:
                        if (-newhalfHeight > minRectHalfLength)
                        {
                            HalfHeight = -newhalfHeight;
                        }
                        break;
                    case 3:
                        if (newhalfWidth > minRectHalfLength)
                        {
                            HalfWidth = newhalfWidth;
                        }
                        if (-newhalfHeight > minRectHalfLength)
                        {
                            HalfHeight = -newhalfHeight;
                        }
                        break;
                    case 4:
                        if (newhalfWidth > minRectHalfLength)
                        {
                            HalfWidth = newhalfWidth;
                        }
                        break;
                    case 5:
                        if (newhalfWidth > minRectHalfLength)
                        {
                            HalfWidth = newhalfWidth;
                        }
                        if (newhalfHeight > minRectHalfLength)
                        {
                            HalfHeight = newhalfHeight;
                        }
                        break;
                    case 6:
                        if (newhalfHeight > minRectHalfLength)
                        {
                            HalfHeight = newhalfHeight;
                        }
                        break;
                    case 7:
                        if (-newhalfWidth > minRectHalfLength)
                        {
                            HalfWidth = -newhalfWidth;
                        }
                        if (newhalfHeight > minRectHalfLength)
                        {
                            HalfHeight = newhalfHeight;
                        }
                        break;
                    case 8:
                        if (-newhalfWidth > minRectHalfLength)
                        {
                            HalfWidth = -newhalfWidth;
                        }
                        break;
                }

                RefreshDrawing();
            }
        }

        /// <summary>
        /// 获取控制点对应的鼠标指针类型
        /// </summary>
        public override Cursor GetHandleCursor(int handleNumber)
        {
            switch (handleNumber)
            {
                //case 1:
                //case 2:
                //case 3:
                //case 4:
                //case 5:
                //case 6:
                //case 7:
                //case 8:
                //    return Cursors.SizeAll;
                case 9:
                    return Cursors.Hand;
                default:
                    return Cursors.Arrow;
            }
        }
        #endregion
    }
}
