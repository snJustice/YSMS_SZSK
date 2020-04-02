using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using YSMS_SZSK.CustomerGlobal;
using YSMS_SZSK.LibCustomerDataManager;
using YSMS_SZSK.MessagePrompt;

namespace YSMS_SZSK.Lib.CustomerCamera
{
    /// <summary>
    /// 
    /// </summary>
    public class CameraParas
    {

        ///// <summary>
        ///// 相机打开参数
        ///// </summary>
        //public Dictionary<string, GrabberParaHTuple> OpenFramegrabber = null;
        ///// <summary>
        ///// 相机初始化参数
        ///// </summary>
        //public Dictionary<string, GrabberParaHTuple> SetFramegrabberParam = null;

        public List<GrabberParaHTuple> OpenFramegrabber = null;

        public List<GrabberParaHTuple> SetFramegrabberParam = null;

        //相机标定参数
        public string CameraParameters { get; private set; }

        public string CameraPose { get; private set; }


        /// <summary>
        /// 默认 像素宽度 2452
        /// </summary>
        public int PixWidth = 640;
        /// <summary>
        /// 默认像素高度 2056 
        /// </summary>
        public int PixHeight = 480;


        /// <summary>
        /// 定义测量 halcon 控件 宽度
        /// </summary>
        public int m_deHalconWidth = 640;
        /// <summary>
        /// 定义测量 halcon 控件 高度
        /// </summary>
        public int m_deHalconHeight = 480;

        /// <summary>
        /// 测量界面 halcon 控件宽度 763
        /// </summary>
        public int MeHalconWidth = 640;
        /// <summary>
        /// 测量界面 halcon 控件高度 640
        /// </summary>
        public int MeHalconHeight = 480;





        public CameraParas()
        {

            //OpenFramegrabber = new Dictionary<string, GrabberParaHTuple>();
            //SetFramegrabberParam = new Dictionary<string, GrabberParaHTuple>();

            OpenFramegrabber = new List<GrabberParaHTuple>();
            SetFramegrabberParam = new List<GrabberParaHTuple>();


            //相机打开参数 
            string filePath = CfgInfo.getInstance().CameraParaXmlPath;

            System.Xml.Linq.XElement root = null;
            try
            {
                root = XDocument.Load(filePath).Root;
            }
            catch (Exception e)
            {
                MyMessageBox.GetInstance().tipsInfo = "相机打开参数：\n" + e.Message;
                MyMessageBox.GetInstance().ShowWindow(PublicEnum.MessageType.Tips);
                return;
            }

            //相机打开参数
            System.Xml.Linq.XElement xmlOpenFramegrabber = root.Element("OpenFramegrabber");
            foreach (var v in xmlOpenFramegrabber.Elements())
            {
                GrabberParaHTuple para = XmlSerializer.Deserialize(v, typeof(GrabberParaHTuple)) as GrabberParaHTuple;
                //判断字典中是否存在
                if (!OpenFramegrabber.Contains(para))
                {
                    OpenFramegrabber.Add(para);
                }
            }

            //相机初始化参数
            System.Xml.Linq.XElement xmlSetFramegrabberParam = root.Element("SetFramegrabberParam");
            foreach (var v in xmlSetFramegrabberParam.Elements())
            {
                GrabberParaHTuple para = XmlSerializer.Deserialize(v, typeof(GrabberParaHTuple)) as GrabberParaHTuple;
                //判断字典中是否存在
                if (!SetFramegrabberParam.Contains(para))
                {
                    SetFramegrabberParam.Add(para);
                }
            }


            //相机标定参数
            XElement xeCameraParameters = root.Element("CameraParameters");
            if (xeCameraParameters != null) CameraParameters = xeCameraParameters.Value.Trim().Trim('[').Trim(']');
            XElement xeCameraPose = root.Element("CameraPose");
            if (xeCameraPose != null) CameraPose = xeCameraPose.Value.Trim().Trim('[').Trim(']');


            //图像 + 定义控件+测量控件(Width,Height)

            XElement xePixControlParas = root.Element("PixControlParas");
            if (xePixControlParas != null)
            {
                string[] arrPixControlParas = xePixControlParas.Value.Trim().Split(',');
                if (arrPixControlParas != null && arrPixControlParas.Length == 6)
                {

                    PixWidth = Convert.ToInt32(arrPixControlParas[0]);
                    PixHeight = Convert.ToInt32(arrPixControlParas[1]);

                    m_deHalconWidth = Convert.ToInt32(arrPixControlParas[2]);
                    m_deHalconHeight = Convert.ToInt32(arrPixControlParas[3]);

                    MeHalconWidth = Convert.ToInt32(arrPixControlParas[4]);
                    MeHalconHeight = Convert.ToInt32(arrPixControlParas[5]);
                }

            }

        }




    }

    /// <summary>
    /// 参数信息
    /// </summary>
    public class GrabberParaHTuple
    {
        /// <summary>
        /// ExposureTime, CDSGain
        /// </summary>
        public string ParaKey { get; set; }
        /// <summary>
        /// double ,int ,string
        /// </summary>
        public string ParaType { get; set; }

        /// <summary>
        /// 3.5,100, "High"
        /// </summary>
        public string ValueString { get; set; }

        /// <summary>
        /// 参数名称
        /// </summary>
        public string ParaName { get; set; }

        /// <summary>
        /// 参数描述
        /// </summary>
        public string ParaDesc { get; set; }


        public HalconDotNet.HTuple GetHTupleValue()
        {
            //根据字符串 返回
            HalconDotNet.HTuple hTupleValue = new HalconDotNet.HTuple();
            switch (ParaType)
            {
                case "string":
                    hTupleValue = ValueString;
                    break;
                case "int":

                    try
                    {
                        hTupleValue = Convert.ToInt32(ValueString);
                    }
                    catch
                    {
                        hTupleValue = 0;
                    }
                    break;
                case "double":
                    try
                    {
                        hTupleValue = Convert.ToDouble(ValueString);
                    }
                    catch
                    {
                        hTupleValue = 0;
                    }
                    break;
            }

            return hTupleValue;
        }

        public override string ToString()
        {
            return GetHTupleValue().ToString();
        }
    }
}
