using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using YSMS_SZSK.Basic.PublicClass;
using YSMS_SZSK.CustomerGlobal;
using YSMS_SZSK.ImageDrawing.DrawingTool;

namespace YSMS_SZSK.ImageDrawing
{
    public class DrawingCanvas : Canvas
    {
        public MainWindow m_defeineMeasureWindow = null;

        #region 画布通知事件

        public event DrawElementEventHandler drawElementEventHandler;

        public void OnElementEventHandler(ElementArgs e)
        {
            if (drawElementEventHandler != null)
            {
                drawElementEventHandler(e);
            }
        }


        /// <summary>
        /// 绘图出 多元素(元素相同) 通知
        /// </summary>
        public event DrawElementListEventHandler drawSameElementListEventHandler;
        /// <summary>
        /// 绘图出 多元素(元素相同) 通知
        /// </summary>
        /// <param name="e"></param>
        public void OnSameElementListEventHandler(ElementListArgs e)
        {
            if (drawSameElementListEventHandler != null)
            {
                drawSameElementListEventHandler(e);
            }
        }


        public event DrawElementListEventHandler drawArraySameElementListEventHandler;
        /// <summary>
        /// 阵列相同元素 通知
        /// </summary>
        /// <param name="e"></param>
        public void OnArraySameElementListEventHandler(ElementListArgs e)
        {
            if (drawArraySameElementListEventHandler != null)
            {
                drawArraySameElementListEventHandler(e);
            }
        }




        /// <summary>
        ///  绘图出 多元素(不同元素相同) 通知
        /// </summary>
        public event DrawElementListEventHandler drawDiffElementListEventHandler;
        /// <summary>
        /// 绘图出 多元素(不同元素相同) 通知
        /// </summary>
        /// <param name="e"></param>
        public void OnDiffElementListEventHandler(ElementListArgs e)
        {
            if (drawDiffElementListEventHandler != null)
            {
                drawDiffElementListEventHandler(e);
            }
        }




        //public event DrawDoubleClickHander drawDoubleClickHander;
        ///// <summary>
        ///// 画布双击 时间
        ///// </summary>
        ///// <param name="e"></param>
        //public void OnDrawDoubleClickHander(DrawDoubleClickEventArgs e)
        //{
        //    if (drawDoubleClickHander != null)
        //    {
        //        drawDoubleClickHander(e);
        //    }

        //}

        /// <summary>
        /// 绘图 双击委托
        /// </summary>
        public delegate void DrawDoubleClickHander(DrawDoubleClickEventArgs e);
        public class DrawDoubleClickEventArgs : EventArgs
        {
            /// <summary>
            /// 结果
            /// </summary>
            public bool Result { get; set; }
            /// <summary>
            /// 创建、 更新、读取、删除
            /// </summary>
            public EnumCURD CURD { get; set; }

        }





        #endregion

        #region 界面调用方法
        public void Operate(ElementArgs e)
        {
            tools[(int)Tool].Operate(e.CRUD, e.DrawStatusEnum, this, e.MeasureElement);
        }

        /// <summary>
        /// 删除元素,与字典中的内容
        /// </summary>
        /// <param name="e"></param>
        /// <param name="meToolType"></param>
        public void DeleteMeasureElement(MeasureElement me)
        {
            if (me == null) return;
            tools[(int)me.ToolEnum].Operate(EnumCURD.Delete, DrawStatusType.None, this, me);
        }
        #endregion

        public enum SelectionMode
        {
            None,
            Move,           // 移动
            Size,           // 缩放
            Rotate,         // 旋转
            GroupSelection
        }

        # region 成员变量
        //存储图形的列表
        private VisualCollection graphicsList;
        //鼠标点选类型
        public SelectionMode selectMode = SelectionMode.None;
        //上一次的鼠标位置
        public Point lastPoint;
        //用于控制移动界面位置
        public Point? moveStartPoint = null;
        //用于多单位命中的选择
        public int selectionIndex = -1;



        //工具
        public static readonly DependencyProperty ToolProperty;



        private SortedDictionary<int, Tool> tools = new SortedDictionary<int, Tool>();

        //todo  预留右键菜单
        //private ContextMenu contextMenu;

        public ZoomBox zoombox;


        public ScrollViewer ScrollViewer
        {
            get { return (ScrollViewer)GetValue(ScrollViewerProperty); }
            set { SetValue(ScrollViewerProperty, value); }
        }


        public static readonly DependencyProperty ScrollViewerProperty =
            DependencyProperty.Register("ScrollViewer", typeof(ScrollViewer), typeof(DrawingCanvas));


        #endregion

        #region 构造函数

        public DrawingCanvas()
            : base()
        {
            graphicsList = new VisualCollection(this);

            //CreateContextMenu();

            InitTools();

            // Create undo manager
            //undoManager = new UndoManager(this);
            //undoManager.StateChanged += new EventHandler(undoManager_StateChanged);


            this.FocusVisualStyle = null;

            this.Loaded += new RoutedEventHandler(DrawingCanvas_Loaded);
            this.MouseDown += new MouseButtonEventHandler(DrawingCanvas_MouseDown);
            this.MouseMove += new MouseEventHandler(DrawingCanvas_MouseMove);
            this.MouseUp += new MouseButtonEventHandler(DrawingCanvas_MouseUp);
            this.MouseWheel += new MouseWheelEventHandler(DrawingCanvas_MouseWheel);
            // 键盘事件  自己不调用 通过上层触发
            //this.KeyDown += new KeyEventHandler(DrawingCanvas_KeyDown);
            this.LostMouseCapture += new MouseEventHandler(DrawingCanvas_LostMouseCapture);
        }


        static DrawingCanvas()
        {
            PropertyMetadata metaData;

            // Tool
            metaData = new PropertyMetadata(PublicEnum.ToolType.Pointer);

            ToolProperty = DependencyProperty.Register(
                "Tool", typeof(PublicEnum.ToolType), typeof(DrawingCanvas),
                metaData);
        }

        private void InitTools()
        {
            /*
            // create array of drawing tools
            tools.Add((int)PublicEnum.ToolType.Pointer, new ToolPointer());
            tools.Add((int)PublicEnum.ToolType.RectangleToLine, new ToolRectangleToLine());
            tools.Add((int)PublicEnum.ToolType.RectangleToShortLine, new ToolRectangleToShortLine());

            tools.Add((int)PublicEnum.ToolType.RectangleToMidLine, new ToolRectangleToMidLine());
            //框选多直线
            tools.Add((int)PublicEnum.ToolType.RectangleToMultiLines, new ToolRectangleToMultiLines());
            //框选多中线
            tools.Add((int)PublicEnum.ToolType.RectangleToMultiMidLines, new ToolRectangleToMultiMidLines());

            tools.Add((int)PublicEnum.ToolType.CrossToCircle, new ToolCrossToCircle());

            tools.Add((int)PublicEnum.ToolType.RectToCircle, new ToolRectangleToCircle());

            tools.Add((int)PublicEnum.ToolType.CrossToPoint, new ToolCrossToPoint());

            //点选槽孔 孔心 2015-08-10 ludc
            tools.Add((int)PublicEnum.ToolType.CrossToCaoKong, new ToolCrossToCaoKongCenter());
            tools.Add((int)PublicEnum.ToolType.CrossToSingleCaoKong, new ToolCrossToSingleCaoKongCenter());
            //点选基岛中心  2015-08-13 czf
            tools.Add((int)PublicEnum.ToolType.CrossToJiDaoPoint, new ToolCrossToJiDaoPoint());
            tools.Add((int)PublicEnum.ToolType.LabelSmartJiDaoCenterToCRD, new ToolLabelSmartJiDaoCenterToCRD());


            tools.Add((int)PublicEnum.ToolType.CrossToScreenPoint, new ToolCrossToScreenPoint());
            tools.Add((int)PublicEnum.ToolType.TwoCircleToCRD, new ToolTwoCircleToCRD());

            tools.Add((int)PublicEnum.ToolType.LabelPointToCRD, new ToolLabelPointToCRD());
            tools.Add((int)PublicEnum.ToolType.LabelLineToCRD, new ToolLabelLineToCRD());
            tools.Add((int)PublicEnum.ToolType.LabelSmartCircleCenterToCRD, new ToolLabelSmartCircleCenterToCRD());
            tools.Add((int)PublicEnum.ToolType.LabelSmartSingleCaoKongToCRD, new ToolLabelSmartSingleCaoKongToCRD());
            tools.Add((int)PublicEnum.ToolType.LabelTwoPointDistance, new ToolLabelTwoPointDistance());
            tools.Add((int)PublicEnum.ToolType.LabelTwoCircleDistance, new ToolLabelTwoCircleDistance());
            tools.Add((int)PublicEnum.ToolType.LabelSmartTwoCircleDistance, new ToolLabelSmartTwoCircleDistance());
            tools.Add((int)PublicEnum.ToolType.LabelTwoLineDistance, new ToolLabelTwoLineDistance());
            //框选多线距离
            tools.Add((int)PublicEnum.ToolType.LabelRectangleToLineDistance, new ToolLabelRectangleToLineDistance());
            tools.Add((int)PublicEnum.ToolType.LabelPointLineDistance, new ToolLabelPointLineDistance());
            tools.Add((int)PublicEnum.ToolType.LabelCircleToRadius, new ToolLabelCircleToRadius());
            tools.Add((int)PublicEnum.ToolType.LabelCircleToDiameter, new ToolLabelCircleToDiameter());
            tools.Add((int)PublicEnum.ToolType.LabelSmartCircleToRadius, new ToolLabelSmartCircleToRadius());
            tools.Add((int)PublicEnum.ToolType.LabelSmartCircleToDiameter, new ToolLabelSmartCircleToDiameter());


            tools.Add((int)PublicEnum.ToolType.PointToSubCRD, new ToolPointToSubCRD());

            tools.Add((int)PublicEnum.ToolType.TemplateTool, new ToolTemplateToolElement());

            //两线交点
            tools.Add((int)PublicEnum.ToolType.TwoLineToPoint, new ToolTwoLineToPoint());

            //四边拟合矩形中心
            tools.Add((int)PublicEnum.ToolType.FourLineToPoint, new ToolFourLineToPoint());

            //两点生成线
            tools.Add((int)PublicEnum.ToolType.TwoPointToLine, new ToolTwoPointToLine());

            //两点中点
            tools.Add((int)PublicEnum.ToolType.TwoPointToPoint, new ToolTwoPointToPoint());

            //线线 拟合
            tools.Add((int)PublicEnum.ToolType.LinesToLine, new ToolLinesToLine());

            //两线中线
            tools.Add((int)PublicEnum.ToolType.TwoLineToLine, new ToolTwoLineToLine());

            //阵列尺寸元素		
            tools.Add((int)PublicEnum.ToolType.ArrayPointer, new ToolArrayPointer());

            //阵列基准元素		
            tools.Add((int)PublicEnum.ToolType.ArrayBasePointer, new ToolArrayBasePointer());

            //阵列设置 版组	
            tools.Add((int)PublicEnum.ToolType.ArraySetBanZu, new ToolArrarySetBanZuPointer());

            //两点选坐标
            tools.Add((int)PublicEnum.ToolType.TwoPointToCRD, new ToolTwoPointToCRD());

            //点选弧半径
            tools.Add((int)PublicEnum.ToolType.LabelArcToRadius, new ToolLabelArcRadius());

            //框选-设置元素隐藏
            tools.Add((int)PublicEnum.ToolType.KuangXuanSetElementHidden, new ToolKuangXuanSetElementHidden());

            //框选半圆（圆弧）圆心
            tools.Add((int)PublicEnum.ToolType.RectangleToSemiCircleCenterPoint, new ToolRectangleToSimeCircleCenterPoint());


            //划线取点
            tools.Add((int)PublicEnum.ToolType.ToolLineToPoint, new ToolLineToPoint());


            //获取区域灰度值
            tools.Add((int)PublicEnum.ToolType.Rectangle2GrayVal, new ToolRectangle2GrayVal());
            //框选轮廓线
            tools.Add((int)PublicEnum.ToolType.RectangleToOutLine, new ToolRectangleToOutLine());

            //线-框-边界点
            tools.Add((int)PublicEnum.ToolType.ToolLineRectangleToPoint, new ToolLineRectangleToPoint());

            //框选-管脚中心点
            tools.Add((int)PublicEnum.ToolType.ToolRectPinCenterPoint, new ToolRectPinCenterPoint());

            //框选-区域极值点
            tools.Add((int)PublicEnum.ToolType.ToolRectExtremumPoint, new ToolRectExtremumPoint());

            //多点拟合圆心点
            tools.Add((int)PublicEnum.ToolType.PointsFitToCircleCenterPoint, new ToolPointsFitToCircleCenterPoint());


            //形位公差 圆度
            tools.Add((int)PublicEnum.ToolType.LabelCircularity, new ToolLabelCircularity());

            //形位公差-直线度
            tools.Add((int)PublicEnum.ToolType.LabelStraightness, new ToolLabelStraightness());


            //位置公差-平行度
            tools.Add((int)PublicEnum.ToolType.LabelParallelism, new ToolLabelParallelism());

            //位置公差-垂直度
            tools.Add((int)PublicEnum.ToolType.LabelPerpendicularity, new ToolLabelPerpendicularity());

            //位置公差-垂直度
            tools.Add((int)PublicEnum.ToolType.LabelGradient, new ToolLabelGradient());

            //位置公差-同心度
            tools.Add((int)PublicEnum.ToolType.LabelConcentricity, new ToolLabelPositionConcentricity());


            //线线 夹角          
            tools.Add((int)PublicEnum.ToolType.Label2LineAngle, new ToolLabelTwoLineAngle());

            //框选弧
            tools.Add((int)PublicEnum.ToolType.RectToArc, new ToolRectToArc());




            //点选弧心坐标
            tools.Add((int)PublicEnum.ToolType.LabelArcPointCenterToCRD, new ToolLabelArcPointCenterToCRD());
            //线选主坐标系
            tools.Add((int)PublicEnum.ToolType.LineToCRD, new ToolLineToCRD());


            //4框选2线距离 2017/2/4 czf
            tools.Add((int)PublicEnum.ToolType.Label4RectangleTo2LineDistance, new ToolLabelMultiRectToLength_ZWD100());

            //框出直径 2017/2/4 czf
            tools.Add((int)PublicEnum.ToolType.LabelRectangleToDiameter, new ToolLabelRectangleToDiameter_ZWD100());

            //两框出基准线 2017/2/10 czf  TwoRectangleToBaseLine
            tools.Add((int)PublicEnum.ToolType.TwoRectangleToBaseLine, new ToolMultiRectToBaseLine_ZWD100());

            //点选圆弧夹角 
            tools.Add((int)PublicEnum.ToolType.Label2ArcAngle, new ToolLabelArcAngle());

            //点选圆环
            tools.Add((int)PublicEnum.ToolType.PointToRing, new ToolPointToRing());

            tools.Add((int)PublicEnum.ToolType.LabelArcLenth, new ToolLabelArcLenth());

            //框选圆弧
            tools.Add((int)PublicEnum.ToolType.RectToCircleArc, new ToolRectToCircleArc());
            //4框出2点距离
            tools.Add((int)PublicEnum.ToolType.Label4RectangleTo2PointDistance, new ToolLabelMultiRectTo2PointLength());
            tools.Add((int)PublicEnum.ToolType.ArcLineToPoint, new ToolArcLineToPoint());



            //两线交点
            tools.Add((int)PublicEnum.ToolType.ArcsToArc, new ToolArcsToArc());

            tools.Add((int)PublicEnum.ToolType.CircleToCircle, new ToolCircleToCircle());

            tools.Add((int)PublicEnum.ToolType.TemplateTool_Circle, new ToolTemplateToolElement_Circle());

            //线的起点与终点
            tools.Add((int)PublicEnum.ToolType.LineStartingPointEndPoint, new ToolLineStartingPointEndPoint());
            //线的中点
            tools.Add((int)PublicEnum.ToolType.LineMidpoint, new ToolLineMidpoint());


            //多框选弧-2019-09-29 ludc
            tools.Add((int)PublicEnum.ToolType.RectListToArc, new ToolRectangleListToArc());

            //多框选弧-2019-10-08 ludc
            tools.Add((int)PublicEnum.ToolType.RectangleListToLine, new ToolRectangleListToLine());

            //线弧 切点 2019-10-17 ludc
            tools.Add((int)PublicEnum.ToolType.ArcLineToPoint_Tangent, new ToolArcLineToPointTangent());
            */
        }
        #endregion

        #region  界面绘制
        //添加visual
        public void AddGraphics(Visual visual)
        {
            GraphicsList.Add(visual);

            base.AddVisualChild(visual);
            base.AddLogicalChild(visual);
        }

        //删除Visual
        public void RemoveVisual(Visual visual)
        {
            GraphicsList.Remove(visual);

            base.RemoveVisualChild(visual);
            base.RemoveLogicalChild(visual);
        }


        #endregion

        #region Tool

        /// <summary>
        /// 当前工具
        /// </summary>
        public PublicEnum.ToolType Tool
        {
            get
            {
                //return (PublicEnum.ToolType)GetValue(ToolProperty);
                return DrawParas.getInstance().ToolEnum;
            }
            set
            {
                SetValue(ToolProperty, value);
                tools[(int)Tool].SetCursor(this);
                DrawParas.getInstance().ToolEnum = value;
            }
        }

        ////改变工具类型
        //public void ChangeToolType(PublicEnum.ToolType tooltype)
        //{
        //    Tool = tooltype;
        //}

        #endregion Tool

        #region 属性

        /// <summary>
        /// 获取某图形
        /// </summary>
        internal GraphicsBase this[int index]
        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    return (GraphicsBase)graphicsList[index];
                }

                return null;
            }
        }

        /// <summary>
        /// 获取所有图像的个数
        /// </summary>
        internal int Count
        {
            get
            {
                return graphicsList.Count;
            }
        }

        /// <summary>
        /// 获取选中图像的个数
        /// </summary>
        internal int SelectionCount
        {
            get
            {
                int n = 0;

                foreach (GraphicsBase g in this.graphicsList)
                {
                    if (g.element.IsChoosed)
                    {
                        n++;
                    }
                }

                return n;
            }
        }

        /// <summary>
        /// 返回所有图形
        /// </summary>
        public VisualCollection GraphicsList
        {
            get
            {
                return graphicsList;
            }
        }

        /// <summary>
        /// 返回选中的集合
        /// </summary>
        internal IEnumerable<GraphicsBase> Selection
        {
            get
            {
                foreach (GraphicsBase o in graphicsList)
                {
                    if (o.element.IsChoosed)
                    {
                        yield return o;
                    }
                }
            }

        }

        #endregion

        #region 虚函数重写

        /// <summary>
        /// 获得子元素数量
        /// </summary>
        protected override int VisualChildrenCount
        {
            get
            {
                int n = graphicsList.Count;
                return n;
            }
        }

        /// <summary>
        /// 获取子元素
        /// </summary>
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= graphicsList.Count)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            return graphicsList[index];
        }

        #endregion Visual Children Overrides

        #region 鼠标事件

        /// <summary>
        /// 鼠标点击.
        /// 左键是工具事件.
        /// 右键弹出菜单.
        /// </summary>
        void DrawingCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(this);
            if (e.ChangedButton == MouseButton.Middle)
            {
                this.Cursor = Cursors.Hand;
                if (!this.IsMouseCaptured)
                {
                    this.CaptureMouse();
                }
                this.moveStartPoint = e.GetPosition(this);
                e.Handled = true;
            }

            if (tools[(int)Tool] == null)
            {
                return;
            }

            this.Focus();

            if (e.ChangedButton == MouseButton.Left)
            {
                if (e.ClickCount == 2)
                {
                    tools[(int)Tool].OnMouseDoubleClick(this, e);
                }
                else
                {
                    tools[(int)Tool].OnMouseDown(this, e);
                }
                //UpdateState();

                //更新灰度和选中设备
                m_imagePoint.X = point.X / 20;// Global.m_Pvb.m_CoordTrans.ImageWidthZippedFactor;
                m_imagePoint.Y = point.Y / 20;// Global.m_Pvb.m_CoordTrans.ImageHeightZippedFactor;
                if (m_defeineMeasureWindow != null)
                {
                    m_defeineMeasureWindow.UpdateImageGrayValue(m_imagePoint);

                    m_defeineMeasureWindow.ShowSlectedMeasureElementInfo();
                }
            }
            else if (e.ChangedButton == MouseButton.Right)
            {
                //todo
                //右键菜单
                //ShowContextMenu(e);

                tools[(int)Tool].OnMouseDown_Right(this, e);

            }
        }

        /// <summary>
        /// 鼠标移动.
        /// </summary>
        Point m_imagePoint = new Point();
        void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point point = e.GetPosition(this);


            if (e.MiddleButton != MouseButtonState.Pressed)
            {
                this.moveStartPoint = null;
            }
            if (this.moveStartPoint.HasValue)
            {
                //中键拖动图像 10-9 xudm修改
                if (this.ScrollViewer.HorizontalOffset + this.moveStartPoint.Value.X - point.X < this.ScrollViewer.ExtentWidth &&
                    this.ScrollViewer.HorizontalOffset + this.moveStartPoint.Value.X - point.X >= 0)
                {
                    this.ScrollViewer.ScrollToHorizontalOffset(this.ScrollViewer.HorizontalOffset + (this.moveStartPoint.Value.X - point.X) * Global.m_Pvb.m_ZoomScale);
                }
                else
                {

                }
                if (this.ScrollViewer.VerticalOffset + this.moveStartPoint.Value.Y - point.Y < this.ScrollViewer.ExtentHeight &&
                  this.ScrollViewer.VerticalOffset + this.moveStartPoint.Value.Y - point.Y >= 0)
                {
                    this.ScrollViewer.ScrollToVerticalOffset(this.ScrollViewer.VerticalOffset + (this.moveStartPoint.Value.Y - point.Y) * Global.m_Pvb.m_ZoomScale);
                }
                else
                {

                }

                return;
            }


            if (tools[(int)Tool] == null)
            {
                return;
            }

            if (e.MiddleButton == MouseButtonState.Released && e.RightButton == MouseButtonState.Released)
            {
                tools[(int)Tool].OnMouseMove(this, e);

                //UpdateState();
            }
            else
            {
                this.Cursor = HelperFunctions.DefaultCursor;
            }

            //获取对应图像中的像素坐标
            m_imagePoint.X = point.X /02;
            m_imagePoint.Y = point.Y / 20;// Global.m_Pvb.m_CoordTrans.ImageHeightZippedFactor;
            if (m_defeineMeasureWindow != null)
            {
                m_defeineMeasureWindow.UpdateImageGrayValue(m_imagePoint);
            }
        }

        /// <summary>
        /// 左键完成点击的事件
        /// </summary>
        void DrawingCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Middle)
            {
                this.Cursor = tools[(int)Tool].ToolCursor;
                if (this.IsMouseCaptured)
                {
                    this.ReleaseMouseCapture();
                }
                this.moveStartPoint = null;
                e.Handled = true;
            }

            if (tools[(int)Tool] == null)
            {
                return;
            }


            if (e.ChangedButton == MouseButton.Left)
            {
                tools[(int)Tool].OnMouseUp(this, e);

                //UpdateState();
            }
        }

        /// <summary>
        /// 鼠标滚轮的事件
        /// </summary>
        void DrawingCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (zoombox != null)
                {
                    if (e.Delta > 0)
                    {
                        zoombox.ZoomIn();
                    }
                    else
                    {
                        zoombox.ZoomOut();
                    }
                }
            }
        }

        #endregion

        #region 其他事件
        /// <summary>
        /// 载入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DrawingCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focusable = true;
        }

        /// <summary>
        /// 鼠标丢失
        /// </summary>
        void DrawingCanvas_LostMouseCapture(object sender, MouseEventArgs e)
        {
            //if (this.IsMouseCaptured)
            //{
            //    CancelCurrentOperation();
            //}
        }


        public void DrawingCanvasKey(KeyEventArgs e)
        {
            DrawingCanvas_KeyDown(this, e);
        }

        /// <summary>
        /// 键盘事件  自己不调用 通过上层触发
        /// </summary>
        void DrawingCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            // Esc键
            if (e.Key == Key.Escape)
            {
                switch (DrawParas.getInstance().CURD)
                {
                    case EnumCURD.Update:
                    case EnumCURD.Create:
                    case EnumCURD.Read:
                        tools[(int)Tool].Operate(DrawParas.getInstance().CURD, DrawStatusType.Cancel, this, null);
                        break;
                }
            }
            //←键
            if (e.Key == Key.Left)
            {
                ScrollViewer.LineLeft();
            }
            //→键
            if (e.Key == Key.Right)
            {
                ScrollViewer.LineRight();
            }
            //↑键
            if (e.Key == Key.Up)
            {
                ScrollViewer.LineUp();
            }
            //↓键
            if (e.Key == Key.Down)
            {
                ScrollViewer.LineDown();
            }
        }


        /// <summary>
        /// 所有操作取消 2015-09-14 ludc
        /// </summary>
        public void AllCancel()
        {
            tools[(int)Tool].Operate(DrawParas.getInstance().CURD, DrawStatusType.Cancel, this, null);
        }



        ///// <summary>
        ///// 取消当前操作
        ///// </summary>
        //public void CancelCurrentOperation()
        //{
        //    if (Tool == PublicEnum.ToolType.Pointer)
        //    {
        //        if (graphicsList.Count > 0)
        //        {
        //            //if (graphicsList[graphicsList.Count - 1] is GraphicsSelectionRectangle)
        //            //{
        //            //    // Delete selection rectangle if it exists
        //            //    graphicsList.RemoveAt(graphicsList.Count - 1);
        //            //}
        //            //else
        //            //{
        //            //    // Pointer tool moved or resized graphics object.
        //            //    // Add this action to the history
        //            //    toolPointer.AddChangeToHistory(this);
        //            //}
        //        }
        //    }
        //    else
        //    {
        //        //删除数据
        //        //if (graphicsList.Count > 0)
        //        //{
        //        //    graphicsList.RemoveAt(graphicsList.Count - 1);
        //        //}
        //    }

        //    tools[(int)Tool].Cancel(this);

        //    Tool = PublicEnum.ToolType.Pointer;

        //    this.ReleaseMouseCapture();
        //    this.Cursor = HelperFunctions.DefaultCursor;
        //}


        /// <summary>
        /// 设置图像剪辑
        /// </summary>
        //public void RefreshClip()
        //{
        //    foreach (GraphicsBase b in graphicsList)
        //    {
        //        b.Clip = new RectangleGeometry(new Rect(0, 0, this.ActualWidth, this.ActualHeight));
        //    }
        //}

        /// <summary>
        /// 画布上定位点
        /// </summary>
        /// <param name="point">定位点坐标</param>
        public void CanvasLocation(Point point)
        {
            ScrollViewer.ScrollToHorizontalOffset(point.X * Global.m_Pvb.m_ZoomScale - ScrollViewer.ViewportWidth / 2);
            ScrollViewer.ScrollToVerticalOffset(point.Y * Global.m_Pvb.m_ZoomScale - ScrollViewer.ActualHeight / 2);
        }
        #endregion


        #region"新建程序时 全部清空  2015-08-03 ludc"
        /// <summary>
        /// 新建程序时 全部清空 
        /// </summary>
        public void clearData()
        {
            this.graphicsList.Clear();
        }


        public void Addgraph(GraphicsBase g)
        {
            GraphicsList.Add(g);
        }
        #endregion

        #region 阵列框选尺寸元素
        /// <summary>
        /// 尺寸 选择 通知
        /// </summary>
        public event EventHandler labelMeasureChooseEventHandler;
        /// <summary>
        /// 阵列 界面 尺寸 选择 通知
        /// </summary>
        public void OnLabelMeasureChoose()
        {
            if (drawElementEventHandler != null)
            {
                //阵列
                labelMeasureChooseEventHandler(this.tools[(int)PublicEnum.ToolType.ArrayPointer], null);
            }
        }

        #endregion


        #region 阵列框选基准元素
        /// <summary>
        /// 尺寸 选择 通知
        /// </summary>
        public event EventHandler arrayBaseChooseEventHandler;
        /// <summary>
        /// 阵列 界面 尺寸 选择 通知
        /// </summary>
        public void OnArrayBaseChoose()
        {
            if (drawElementEventHandler != null)
            {
                //阵列
                arrayBaseChooseEventHandler(this.tools[(int)PublicEnum.ToolType.ArrayBasePointer], null);
            }
        }

        #endregion
    }
}
