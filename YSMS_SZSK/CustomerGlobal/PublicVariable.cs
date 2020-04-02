using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YSMS_SZSK.Basic.PublicClass;
using YSMS_SZSK.ImageDrawing;
using YSMS_SZSK.Lib.CustomerCamera;
using YSMS_SZSK.MessagePrompt;

namespace YSMS_SZSK.CustomerGlobal
{
    public class PublicVariable
    {
        public Camera m_camera = null;

        /// <summary>
        /// 相机参数
        /// </summary>
        public CameraParas m_cameraParas = new CameraParas();

        public double m_ZoomScale { set; get; }
    }

    
}
