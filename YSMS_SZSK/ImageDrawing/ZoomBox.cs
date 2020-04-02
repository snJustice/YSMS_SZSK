using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using YSMS_SZSK.CustomerGlobal;

namespace YSMS_SZSK.ImageDrawing
{
    public class ZoomBox : Control
    {
        private Thumb zoomThumb;
        private Canvas zoomCanvas;
        public Slider zoomSlider;
        private ScaleTransform scaleTransform;
        private List<Canvas> designerCanvasList;

        public ScrollViewer ScrollViewer
        {
            get { return (ScrollViewer)GetValue(ScrollViewerProperty); }
            set { SetValue(ScrollViewerProperty, value); }
        }

        public static readonly DependencyProperty ScrollViewerProperty =
            DependencyProperty.Register("ScrollViewer", typeof(ScrollViewer), typeof(ZoomBox));

        public List<Canvas> DesignerCanvasList { get; set; }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this.ScrollViewer == null)
                return;

            this.designerCanvasList = DesignerCanvasList;
            if (this.designerCanvasList == null || this.designerCanvasList.Count == 0)
                throw new Exception("DesignerCanvas must not be null!");

            this.zoomThumb = Template.FindName("PART_ZoomThumb", this) as Thumb;
            if (this.zoomThumb == null)
                throw new Exception("PART_ZoomThumb template is missing!");

            this.zoomCanvas = Template.FindName("PART_ZoomCanvas", this) as Canvas;
            if (this.zoomCanvas == null)
                throw new Exception("PART_ZoomCanvas template is missing!");

            this.zoomSlider = Template.FindName("PART_ZoomSlider", this) as Slider;
            if (this.zoomSlider == null)
                throw new Exception("PART_ZoomSlider template is missing!");
            foreach (var v in designerCanvasList)
            {
                v.LayoutUpdated += new EventHandler(this.DesignerCanvas_LayoutUpdated);
            }
            //this.designerCanvas.LayoutUpdated += new EventHandler(this.DesignerCanvas_LayoutUpdated);

            this.zoomThumb.DragDelta += new DragDeltaEventHandler(this.Thumb_DragDelta);

            this.zoomSlider.ValueChanged += new RoutedPropertyChangedEventHandler<double>(this.ZoomSlider_ValueChanged);

            this.scaleTransform = new ScaleTransform();
            foreach (var v in designerCanvasList)
            {
                v.LayoutTransform = this.scaleTransform;
            }
            //this.designerCanvas.LayoutTransform = this.scaleTransform;
        }


        /// <summary>
        /// 放大
        /// </summary>
        public void ZoomIn()
        {
            double newValue = 0.0;
            foreach (var v in zoomSlider.Ticks)
            {
                if (v > zoomSlider.Value)
                {
                    if (newValue == 0.0)
                    {
                        newValue = v;
                    }
                    else if (v < newValue)
                    {
                        newValue = v;
                    }
                }
            }
            if (newValue != 0.0)
            {
                zoomSlider.Value = newValue;
            }
        }

        /// <summary>
        /// 缩小
        /// </summary>
        public void ZoomOut()
        {
            double newValue = 0.0;
            foreach (var v in zoomSlider.Ticks)
            {
                if (v < zoomSlider.Value)
                {
                    if (newValue == 0.0)
                    {
                        newValue = v;
                    }
                    else if (v > newValue)
                    {
                        newValue = v;
                    }
                }
            }
            if (newValue != 0.0)
            {
                zoomSlider.Value = newValue;
            }
        }

        private void ZoomSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Global.m_Pvb.m_ZoomScale = e.NewValue / 100.0;
            HelperFunctions.RefreshDrawingALL(designerCanvasList[1] as DrawingCanvas);

            double scale = e.NewValue / e.OldValue;

            double halfViewportHeight = this.ScrollViewer.ViewportHeight / 2;
            double newVerticalOffset = ((this.ScrollViewer.VerticalOffset + halfViewportHeight) * scale - halfViewportHeight);

            double halfViewportWidth = this.ScrollViewer.ViewportWidth / 2;
            double newHorizontalOffset = ((this.ScrollViewer.HorizontalOffset + halfViewportWidth) * scale - halfViewportWidth);

            this.scaleTransform.ScaleX *= scale;
            this.scaleTransform.ScaleY *= scale;

            this.ScrollViewer.ScrollToHorizontalOffset(newHorizontalOffset);
            this.ScrollViewer.ScrollToVerticalOffset(newVerticalOffset);
        }

        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            double scale, xOffset, yOffset;
            this.InvalidateScale(out scale, out xOffset, out yOffset);

            this.ScrollViewer.ScrollToHorizontalOffset(this.ScrollViewer.HorizontalOffset + e.HorizontalChange / scale);
            this.ScrollViewer.ScrollToVerticalOffset(this.ScrollViewer.VerticalOffset + e.VerticalChange / scale);
        }


        private void DesignerCanvas_LayoutUpdated(object sender, EventArgs e)
        {
            double scale, xOffset, yOffset;
            this.InvalidateScale(out scale, out xOffset, out yOffset);


            this.zoomThumb.Width = this.ScrollViewer.ViewportWidth * scale;
            this.zoomThumb.Height = this.ScrollViewer.ViewportHeight * scale;

            if (this.zoomThumb.Width > this.zoomCanvas.ActualWidth ||
                this.zoomThumb.Height > this.zoomCanvas.ActualHeight)
            {
                this.zoomThumb.Visibility = Visibility.Hidden;
            }
            else
            {
                this.zoomThumb.Visibility = Visibility.Visible;
            }

            Canvas.SetLeft(this.zoomThumb, xOffset + this.ScrollViewer.HorizontalOffset * scale);
            Canvas.SetTop(this.zoomThumb, yOffset + this.ScrollViewer.VerticalOffset * scale);
        }

        private void InvalidateScale(out double scale, out double xOffset, out double yOffset)
        {
            // designer canvas size
            double w = Math.Max(designerCanvasList[0].ActualWidth, designerCanvasList[1].ActualWidth) * this.scaleTransform.ScaleX;
            double h = Math.Max(designerCanvasList[0].ActualHeight, designerCanvasList[1].ActualHeight) * this.scaleTransform.ScaleY;

            // zoom canvas size
            double x = this.zoomCanvas.ActualWidth;
            double y = this.zoomCanvas.ActualHeight;

            double scaleX = x / w;
            double scaleY = y / h;

            scale = (scaleX < scaleY) ? scaleX : scaleY;

            xOffset = (x - scale * w) / 2;
            yOffset = (y - scale * h) / 2;
        }
    }
}
