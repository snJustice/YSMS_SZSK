using YSMS_SZSK.Basic.PublicClass;

namespace YSMS_SZSK.ImageDrawing
{
    public abstract class GraphicsMeasureBase : GraphicsBase
    {
        public MeasureElement measureElement
        {
            get
            {
                return element as MeasureElement;
            }
            set
            {
                element = value;
            }
        }
    }
}