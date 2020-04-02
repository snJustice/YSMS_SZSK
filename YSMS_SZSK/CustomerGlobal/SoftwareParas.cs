using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace YSMS_SZSK.CustomerGlobal
{
    public class SoftwareParas
    {
        private string m_decimalNum;
        /// <summary>
        /// 小数点位数
        /// </summary>
        public string DecimalNum
        {
            get { return m_decimalNum; }
            set { m_decimalNum = value; }
        }

        #region 数值
        /// <summary>
        /// 命中判定的宽度
        /// </summary>
        private double m_hitTestWidth;
        public double HitTestWidth
        {
            get { return m_hitTestWidth; }
            set { m_hitTestWidth = value; }
        }

        /// <summary>
        /// 控制点的长宽大小
        /// </summary>
        private double m_handleSize;
        public double HandleSize
        {
            get { return m_handleSize; }
            set { m_handleSize = value; }
        }

        //基础未选中时的线宽
        public double BasicUnchoosedLineWidth;
        //基础选中时的线宽
        public double BasicChoosedLineWidth;
        //工具元素未选中时的线宽
        public double ToolUnchoosedLineWidth;
        //工具元素选中时的线宽
        public double ToolChoosedLineWidth;
        //测量元素元素未选中时的线宽
        public double MeasureUnchoosedLineWidth;
        //测量元素选中时的线宽
        public double MeasureChoosedLineWidth;
        //标注元素元素未选中时的线宽
        public double LabelUnchoosedLineWidth;
        //标注元素选中时的线宽
        public double LabelChoosedLineWidth;
        //标注元素需要向上偏移的距离
        public double LabelUpDistance;
        //标注元素标注的长度
        public double LabelLength;


        // 工具元素十字架的长度
        public double CrossLineLength;
        //测量元素点的十字架长度
        public double PointLineLength;
        //矩形工具最小半长
        public double MinRectHalfLength;
        //矩形工具箭头棒的长度
        public double ArrowStickLength;


        //坐标系X轴默认长度
        public double CRDXLength;
        //坐标系Y轴默认长度
        public double CRDYLength;
        //箭头长度
        public double ArrowLength;



        //标注字号大小 LableEmSize
        public double LableEmSize;

        #endregion

        #region 颜色
        private Color m_handleOutSideColor;
        /// <summary>
        /// 控制点外圈颜色
        /// </summary>
        public Color HandleOutSideColor
        {
            get { return m_handleOutSideColor; }
            set { m_handleOutSideColor = value; }
        }

        private Color m_handleMidSideColor;
        /// <summary>
        /// 控制点中圈颜色
        /// </summary>
        public Color HandleMidSideColor
        {
            get { return m_handleMidSideColor; }
            set { m_handleMidSideColor = value; }
        }

        private Color m_handleInSideColor;
        /// <summary>
        /// 控制点内圈颜色
        /// </summary>
        public Color HandleInSideColor
        {
            get { return m_handleInSideColor; }
            set { m_handleInSideColor = value; }
        }

        private Color m_basicElementChoosedColor;
        /// <summary>
        /// 基本元素选中颜色
        /// </summary>
        public Color BasicElementChoosedColor
        {
            get { return m_basicElementChoosedColor; }
            set { m_basicElementChoosedColor = value; }
        }

        private Color m_basicElementUnchoosedColor;
        /// <summary>
        /// 基本元素未选中颜色
        /// </summary>
        public Color BasicElementUnchoosedColor
        {
            get { return m_basicElementUnchoosedColor; }
            set { m_basicElementUnchoosedColor = value; }
        }

        private Color m_toolChoosedColor;
        /// <summary>
        /// 工具元素选中颜色
        /// </summary>
        public Color ToolElementChoosedColor
        {
            get { return m_toolChoosedColor; }
            set { m_toolChoosedColor = value; }
        }

        private Color m_toolElementUnchoosedColor;
        /// <summary>
        /// 工具元素未选中颜色
        /// </summary>
        public Color ToolElementUnchoosedColor
        {
            get { return m_toolElementUnchoosedColor; }
            set { m_toolElementUnchoosedColor = value; }
        }

        private Color m_measureChoosedColor;
        /// <summary>
        /// 测量元素选中颜色
        /// </summary>
        public Color MeasureElementChoosedColor
        {
            get { return m_measureChoosedColor; }
            set { m_measureChoosedColor = value; }
        }

        private Color m_measureElementUnchoosedColor;
        /// <summary>
        /// 测量元素未选中颜色
        /// </summary>
        public Color MeasureElementUnchoosedColor
        {
            get { return m_measureElementUnchoosedColor; }
            set { m_measureElementUnchoosedColor = value; }
        }

        private Color m_labelChoosedColor;
        /// <summary>
        /// 标注选中颜色
        /// </summary>
        public Color LabelChoosedColor
        {
            get { return m_labelChoosedColor; }
            set { m_labelChoosedColor = value; }
        }

        private Color m_lableUnchoosedColor;
        /// <summary>
        /// 标注未选中颜色
        /// </summary>
        public Color LabelUnchoosedColor
        {
            get { return m_lableUnchoosedColor; }
            set { m_lableUnchoosedColor = value; }
        }




        #endregion

        public SoftwareParas()
        {
            this.DecimalNum = "F4";

            this.HitTestWidth = 8.0;
            this.HandleSize = 10.0;
            this.BasicUnchoosedLineWidth = 2.0;
            this.BasicChoosedLineWidth = 3.0;
            this.ToolUnchoosedLineWidth = 1.0;
            this.ToolChoosedLineWidth = 1.0;
            this.MeasureUnchoosedLineWidth = 2.0;
            this.MeasureChoosedLineWidth = 3.0;
            this.LabelUnchoosedLineWidth = 1.0;
            this.LabelChoosedLineWidth = 2.0;

            this.LabelUpDistance = 15.0;
            this.LabelLength = 20.0;

            this.CrossLineLength = 8.0;
            this.PointLineLength = 4.0;

            this.MinRectHalfLength = 1.0;
            this.ArrowStickLength = 20.0;

            this.CRDXLength = 60.0;
            this.CRDYLength = 60.0;
            this.ArrowLength = 8.0;

            this.LableEmSize = 12;


            this.HandleOutSideColor = Color.FromArgb(255, 0, 0, 0);
            this.HandleMidSideColor = Color.FromArgb(255, 255, 255, 255);
            this.HandleInSideColor = Color.FromArgb(255, 0, 0, 255);

            this.BasicElementUnchoosedColor = Colors.Red;
            this.BasicElementChoosedColor = Colors.LightSkyBlue;

            this.ToolElementUnchoosedColor = Colors.LightSteelBlue;
            this.ToolElementChoosedColor = Colors.LightSkyBlue;

            this.MeasureElementUnchoosedColor = Colors.Red;
            this.MeasureElementChoosedColor = Colors.LightSkyBlue;

            this.LabelUnchoosedColor = Colors.LimeGreen;
            this.LabelChoosedColor = Colors.LightSkyBlue;

        }




    }
}
