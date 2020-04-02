using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Input;
using System.Windows.Media;
using YSMS_SZSK.CustomerGlobal;

namespace YSMS_SZSK.ImageDrawing
{
    /// <summary>
    /// 界面的一些辅助函数
    /// </summary>
    static class HelperFunctions
    {
        /// <summary>
        /// 默认的鼠标指针类型
        /// </summary>
        public static Cursor DefaultCursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        /// <summary>
        /// 选中所有的图形
        /// </summary>
        public static void SelectAll(DrawingCanvas drawingCanvas)
        {
            for (int i = 0; i < drawingCanvas.Count; i++)
            {

            }
        }


        /// <summary>
        /// 全部取消选择
        /// </summary>
        public static void UnselectAll(DrawingCanvas drawingCanvas)
        {
            for (int i = 0; i < drawingCanvas.Count; i++)
            {
                drawingCanvas[i].IsChoosed = false;
            }
        }

        /// <summary>
        /// 全部重绘
        /// </summary>
        public static void RefreshDrawingALL(DrawingCanvas drawingCanvas)
        {
            for (int i = 0; i < drawingCanvas.Count; i++)
            {
                drawingCanvas[i].RefreshDrawing();
            }
        }

        public static GraphicsBase GetSingleGraphicElement(DrawingCanvas drawingCanvas, MouseButtonEventArgs e, Type typea)
        {

            GraphicsBase graphElement = null;
            Point p = e.GetPosition(drawingCanvas);
            int handleNumber = -1;
            List<GraphicsBase> itemList = new List<GraphicsBase>();
            for (int i = drawingCanvas.GraphicsList.Count - 1; i >= 0; i--)
            {
                GraphicsBase o = drawingCanvas[i];

                //模板区域 除外
                if (o.GetType() == typeof(GraphicsTemplateToolElement))
                    continue;

                if (o.GetType() == typea ||
                    o.GetType().IsSubclassOf(typea))
                {
                    handleNumber = o.MakeHitTest(p);
                    if (handleNumber >= 0)
                    {
                        itemList.Add(o);
                    }
                }
            }
            if (itemList.Count == 1)
            {
                graphElement = itemList[0];
            }
            else if (itemList.Count > 1)
            {
                List<string> nameList = new List<string>();
                foreach (var v in itemList)
                {
                    nameList.Add(v.element.DefaultName);
                }
                SelectWindow selectWindow = new SelectWindow(drawingCanvas, nameList);
                Point mousePoint = drawingCanvas.PointToScreen(e.GetPosition(drawingCanvas));
                selectWindow.Left = mousePoint.X;
                selectWindow.Top = mousePoint.Y;
                if (selectWindow.ShowDialog() == true)
                {
                    graphElement = itemList[drawingCanvas.selectionIndex];
                }
                drawingCanvas.selectionIndex = -1;
            }
            return graphElement;
        }


        #region 阵列 时 添加到图形上

        public static void Array2GraphicsAddNewObject(DrawingCanvas drawingCanvas, GraphicsBase o)
        {
            //HelperFunctions.UnselectAll(drawingCanvas);

            //o.element.IsChoosed = true;
            o.Clip = new RectangleGeometry(new Rect(0, 0, drawingCanvas.ActualWidth, drawingCanvas.ActualHeight));

            drawingCanvas.GraphicsList.Add(o);
            //o.RefreshDrawing();          
        }


        public static void ArrayRefreshDrawingALL(DrawingCanvas drawingCanvas)
        {
            for (int i = 0; i < drawingCanvas.Count; i++)
            {
                drawingCanvas[i].IsChoosed = false;
                drawingCanvas[i].RefreshDrawing();
            }
        }

        /// <summary>
        /// 显示 所有工具
        /// </summary>
        
        

        /// <summary>
        /// 选择 基本元素 与 辅助元素
        /// </summary>
        /// <param name="drawingCanvas"></param>
        /// <param name="e"></param>
        /// <param name="typea"></param>
        /// <returns></returns>
        /// 
        /// 
         /*
        public static GraphicsBase GetSingleGraphicElement_WithOutLabel(DrawingCanvas drawingCanvas, MouseButtonEventArgs e)
        {

            GraphicsBase graphElement = null;
            Point p = e.GetPosition(drawingCanvas);
            int handleNumber = -1;
            List<GraphicsBase> itemList = new List<GraphicsBase>();

            //只需要 基本元素+辅助元素+坐标系
            IEnumerable<GraphicsMeasureBase> ieGMB = from item in Global.m_Pvb.m_GraphicsMeasureElementArray.Values
                                                     where ((item.measureElement.ElementMainType == PublicEnum.MeasureElementMainType.AssistElement || item.measureElement.ElementMainType == PublicEnum.MeasureElementMainType.BaseElement)

                                                     && item.measureElement.BindCRDID != 0)
                                                     || item.measureElement.ElementMainType == PublicEnum.MeasureElementMainType.CRDElement

                                                     select item;


            foreach (var o in ieGMB)
            {
                handleNumber = o.MakeHitTest(p);
                if (handleNumber >= 0)
                {
                    itemList.Add(o);
                }
            }



            //for (int i = drawingCanvas.GraphicsList.Count - 1; i >= 0; i--)
            //{
            //    GraphicsBase o = drawingCanvas[i];

            //    //模板区域 除外
            //    if (o.GetType() == typeof(GraphicsTemplateToolElement))
            //        continue;

            //    //标注元素 除外
            //    if (o.GetType().IsSubclassOf(typeof(GraphicsMeasureElement_Label)))
            //        continue;

            //        handleNumber = o.MakeHitTest(p);
            //        if (handleNumber >= 0)
            //        {
            //            itemList.Add(o);
            //        }

            //}
            if (itemList.Count == 1)
            {
                graphElement = itemList[0];
            }
            else if (itemList.Count > 1)
            {
                List<string> nameList = new List<string>();
                foreach (var v in itemList)
                {
                    nameList.Add(v.element.DefaultName);
                }
                SelectWindow selectWindow = new SelectWindow(drawingCanvas, nameList);
                Point mousePoint = drawingCanvas.PointToScreen(e.GetPosition(drawingCanvas));
                selectWindow.Left = mousePoint.X;
                selectWindow.Top = mousePoint.Y;
                if (selectWindow.ShowDialog() == true)
                {
                    graphElement = itemList[drawingCanvas.selectionIndex];
                }
                drawingCanvas.selectionIndex = -1;
            }
            return graphElement;
        }
        */
        #endregion
    }
}
