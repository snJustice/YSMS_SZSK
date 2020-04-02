using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YSMS_SZSK.Basic.PublicClass
{
    public class FoucsImage
    {
        /// <summary>
        /// 图
        /// </summary>
        public HalconDotNet.HObject Image { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// 获取图片轴位置
        /// </summary>
        public int GetPosition { get; set; }





        HObject ho_EdgeAmplitude;

        // Local control variables 

        //HTuple hv_Pointer, hv_Type, hv_Width, hv_Height;
        HTuple hv_FocusGardient, hv_Mean;
        /// <summary>
        /// 分数计算
        /// </summary>
        public void Cal(HalconDotNet.HTuple rectValue)
        {




            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_EdgeAmplitude);

            //*实时显示**
            //HOperatorSet.GetImagePointer1(Image, out hv_Pointer, out hv_Type, out hv_Width,
            //out hv_Height);
            //*计算边缘梯度

            if (rectValue.Length != 4)
            {
                MessageBox.Show("对焦框存在问题！");
                return;
            }

            HObject ho_Rectangle;
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            HOperatorSet.GenRectangle1(out ho_Rectangle, rectValue[0], rectValue[1], rectValue[2],
                 rectValue[3]);

            HObject ho_ImageReduced;
            HOperatorSet.GenEmptyObj(out ho_ImageReduced);
            HOperatorSet.ReduceDomain(Image, ho_Rectangle, out ho_ImageReduced);

            ho_EdgeAmplitude.Dispose();
            HOperatorSet.SobelAmp(ho_ImageReduced, out ho_EdgeAmplitude, "sum_abs", 3);
            HOperatorSet.Intensity(ho_EdgeAmplitude, ho_EdgeAmplitude, out hv_Mean,
                out hv_FocusGardient);

            Score = hv_FocusGardient.D;
            ho_EdgeAmplitude.Dispose();
        }
    }
}
