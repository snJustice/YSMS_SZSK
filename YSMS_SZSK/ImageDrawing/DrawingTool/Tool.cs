using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using YSMS_SZSK.Basic.PublicClass;

namespace YSMS_SZSK.ImageDrawing.DrawingTool
{
    public abstract class Tool
    {
        private int step;
        /// <summary>
        /// 工具步骤
        /// </summary>
        protected int ToolStep
        {
            get
            {
                return step;
            }
            set
            {
                step = value;
            }
        }


        private Cursor toolCursor;
        /// <summary>
        /// 工具的鼠标指针类型
        /// </summary>
        public Cursor ToolCursor
        {
            get
            {
                return toolCursor;
            }
            set
            {
                toolCursor = value;
            }
        }

        protected static void AddNewObject(DrawingCanvas drawingCanvas, GraphicsBase o)
        {
            HelperFunctions.UnselectAll(drawingCanvas);

            o.element.IsChoosed = true;
            o.Clip = new RectangleGeometry(new Rect(0, 0, drawingCanvas.ActualWidth, drawingCanvas.ActualHeight));

            drawingCanvas.GraphicsList.Add(o);
            o.RefreshDrawing();
            //drawingCanvas.RefreshClip();
            //drawingCanvas.CaptureMouse();
        }

        protected static void DeleteObject(DrawingCanvas drawingCanvas, GraphicsBase o)
        {
            HelperFunctions.UnselectAll(drawingCanvas);

            drawingCanvas.GraphicsList.Remove(o);
            //drawingCanvas.RefreshClip();
            //drawingCanvas.CaptureMouse();
        }

        public virtual void OnMouseDown(DrawingCanvas drawingCanvas, MouseButtonEventArgs e)
        {

        }

        public virtual void OnMouseMove(DrawingCanvas drawingCanvas, MouseEventArgs e)
        {

        }

        public virtual void OnMouseUp(DrawingCanvas drawingCanvas, MouseButtonEventArgs e)
        {

        }

        public virtual void SetCursor(DrawingCanvas drawingCanvas)
        {
            drawingCanvas.Cursor = this.toolCursor;
        }

        public virtual void OnMouseDoubleClick(DrawingCanvas drawingCanvas, MouseButtonEventArgs e)
        {

        }


        public virtual void OnMouseDown_Right(DrawingCanvas drawingCanvas, MouseButtonEventArgs e)
        {

        }

        //创建开始的函数
        public virtual void CreateStart(DrawingCanvas drawingCanvas)
        {

        }

        //创建取消的函数
        public virtual void CreateCancel(DrawingCanvas drawingCanvas)
        {

        }

        //创建完成的函数
        public virtual void CreateFinish(DrawingCanvas drawingCanvas)
        {

        }

        //编辑开始的函数
        public virtual void EditStart(DrawingCanvas drawingCanvas, MeasureElement measureElement)
        {

        }

        //编辑取消的函数
        public virtual void EditCancel(DrawingCanvas drawingCanvas)
        {

        }

        //编辑完成的函数
        public virtual void EditFinish(DrawingCanvas drawingCanvas)
        {

        }

        //删除控件的函数
        public virtual void Delete(DrawingCanvas drawingCanvas, MeasureElement measureElement)
        {

        }

        //读取控件并显示的函数
        public virtual void Read(DrawingCanvas drawingCanvas, MeasureElement measureElement)
        {

        }

        //读取取消的函数
        public virtual void ReadCancel(DrawingCanvas drawingCanvas)
        {

        }

        public void Operate(EnumCURD operationType, DrawStatusType operationStatusType, DrawingCanvas drawingCanvas, MeasureElement measureElement)
        {
            switch (operationType)
            {
                case EnumCURD.Create:
                    switch (operationStatusType)
                    {
                        case DrawStatusType.Start:
                            CreateStart(drawingCanvas);
                            return;
                        case DrawStatusType.Finished:
                            CreateFinish(drawingCanvas);
                            return;
                        case DrawStatusType.Cancel:
                            CreateCancel(drawingCanvas);
                            return;
                    }
                    return;
                case EnumCURD.Update:
                    switch (operationStatusType)
                    {
                        case DrawStatusType.Start:
                            EditStart(drawingCanvas, measureElement);
                            return;
                        case DrawStatusType.Finished:
                            EditFinish(drawingCanvas);
                            return;
                        case DrawStatusType.Cancel:
                            EditCancel(drawingCanvas);
                            return;
                    }
                    return;
                case EnumCURD.Delete:
                    Delete(drawingCanvas, measureElement);
                    return;
                case EnumCURD.Read:
                    switch (operationStatusType)
                    {
                        case DrawStatusType.Cancel:
                            ReadCancel(drawingCanvas);
                            return;
                        default:
                            Read(drawingCanvas, measureElement);
                            return;
                    }

                //刷新  2015-08-10 ludc
                case EnumCURD.Refresh:
                    if (measureElement != null)
                    {
                        Read(drawingCanvas, measureElement);
                    }
                    break;
            }
        }

    }
}
