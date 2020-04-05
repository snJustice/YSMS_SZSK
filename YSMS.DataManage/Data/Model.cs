using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace YSMS.DataManage
{
    /// <summary>
    /// 工位单模板类
    /// </summary>
    public class Model
    {

        public Model() { }
        public Model(int No)
        {
            this.ModelNo = No;
        }
        /// <summary>
        /// 定位区域的坐标位置与模板的坐标位置的位置仿射变换关系
        /// </summary>
        public string HomMat2D_LocationHoles2SampleXLD_String { get; set; }
        /// <summary>
        /// 定位区域的坐标位置
        /// </summary>
        public string Array_location_holes_String { get; set; }
        /// <summary>
        /// 冲压电镀产品选择及回填/表面灰度,模板面积
        /// </summary>
        public string hv_Gray_Set_String { get; set; }

        public int ModelNo { get; set; }
        public bool IsEnable { get; set; }
        private string projectPath = String.Empty;
        private string projectFileName = String.Empty;
        //public Dictionary<uint, MeasureSize> MeasureSizeDic = new Dictionary<uint, MeasureSize>();
        public ObservableCollection<MeasureSize> MeasureSizeList = new ObservableCollection<MeasureSize>();
        public ObservableCollection<MeasureDefect> MeasureDefectList = new ObservableCollection<MeasureDefect>();
        //public ObservableCollection<MeasureSpecialRegion> MeasureSpecialRegionList = new ObservableCollection<MeasureSpecialRegion>();

        public ROI detectionArea = new ROI();
        public LocationArea locationArea = new LocationArea();
        public GenerateModelParas generateModeParas = new GenerateModelParas();

        /// <summary>
        /// 像素转尺寸比例
        /// </summary>
        public double PixelToSizeRatio { get; set; }
        /// <summary>
        /// 相机参数
        /// </summary>
        public List<double> CameraParameters = new List<double>();

        /// <summary>
        /// 相机姿态
        /// </summary>
        public List<double> CameraPose = new List<double>();

        #region  算法需要的数据
        //ROI框的参数
        [XmlIgnore]
        public HTuple hv_Rect_ROI = new HTuple();

        //模板创建参数
        [XmlIgnore]
        public HTuple hv_Create_Range_Tuple = new HTuple();

        //用户框选的检测单元ROI
        [XmlIgnore]
        public HTuple Region_Array_Unit = new HTuple();
        //用户框选的定位区域ROI
        [XmlIgnore]
        public HTuple Region_Array_LHoles = new HTuple();

        //定位区域的坐标位置
        [XmlIgnore]
        public HTuple Array_location_holes = new HTuple();

        //定位区域的坐标位置与模板的坐标位置的位置仿射变换关系
        [XmlIgnore]
        public HTuple HomMat2D_LocationHoles2SampleXLD = new HTuple();

        //缺陷参数数组
        [XmlIgnore]
        public HTuple Defect_SetArray = new HTuple();

        //高级参数
        [XmlIgnore]
        public HTuple Defect_Assistant_Array = new HTuple();

        //缺陷框列表
        [XmlIgnore]
        public HTuple Defect_RectArray = new HTuple();

        //缺陷框转换后的图像数据列表
        [XmlIgnore]
        public HObject Defect_xldArray = null;

        //轮廓
        [XmlIgnore]
        public HObject Contour = null;

        //特殊区域参数数组
        [XmlIgnore]
        public HTuple SpecialRegion_SetArray = new HTuple();

        //特殊区域框列表
        [XmlIgnore]
        public HTuple SpecialRegion_RectArray = new HTuple();

        //尺寸类型列表
        [XmlIgnore]
        public HTuple Size_Type_Array = new HTuple();
        //公称值列表
        [XmlIgnore]
        public HTuple Size_NominalValue_Array = new HTuple();
        //上下公差列表
        [XmlIgnore]
        public HTuple Size_UpDownTolerance_Array = new HTuple();
        //补偿值列表
        [XmlIgnore]
        public HTuple Size_Compensation_Array = new HTuple();
        //测量个数列表
        [XmlIgnore]
        public HTuple Size_MeasureNums_Array = new HTuple();
        //尺寸是否显示列表
        [XmlIgnore]
        public HTuple Size_IsShow_Array = new HTuple();
        //框数据列表
        [XmlIgnore]
        public HTuple Size_Rects_Array = new HTuple();
        //灰度值
        [XmlIgnore]
        public HTuple Gray_Set = new HTuple();

        //尺寸参数
        [XmlIgnore]
        public HTuple Size_Algorithm_SetArray = new HTuple();

        //3.标定参数
        [XmlIgnore]
        public HTuple Calib_Tuple = new HTuple();

        public int GenerateHalconParas(int AlgorithmNormalParasNum, int AlgorithmSeniorParasNum, Station station)
        {
            int ret = 0;
            try
            {
                //用户框选的检测单元ROI
                List<double> Region_Array_UnitList = new List<double>();
                Region_Array_UnitList.Add(detectionArea.HRectList[0].Row);
                Region_Array_UnitList.Add(detectionArea.HRectList[0].Column);
                Region_Array_UnitList.Add(detectionArea.HRectList[0].Phi);
                Region_Array_UnitList.Add(detectionArea.HRectList[0].Length1);
                Region_Array_UnitList.Add(detectionArea.HRectList[0].Length2);

                //用户框选的定位区域ROI
                List<double> Region_Array_LHolesList = new List<double>();
                foreach (var item in locationArea.HRectList)
                {
                    Region_Array_LHolesList.Add(item.Row);
                    Region_Array_LHolesList.Add(item.Column);
                    Region_Array_LHolesList.Add(item.Phi);
                    Region_Array_LHolesList.Add(item.Length1);
                    Region_Array_LHolesList.Add(item.Length2);
                }
                Region_Array_Unit = Region_Array_UnitList.ToArray();
                Region_Array_LHoles = Region_Array_LHolesList.ToArray();

                //定位区域的坐标位置
                List<double> Array_location_holes_List = new List<double>();
                foreach (var v in Array_location_holes_String.Split(';'))
                {
                    Array_location_holes_List.Add(Convert.ToDouble(v));
                }
                Array_location_holes = Array_location_holes_List.ToArray();

                //定位区域的坐标位置与模板的坐标位置的位置仿射变换关系
                List<double> HomMat2D_LocationHoles2SampleXLD_List = new List<double>();
                foreach (var v in HomMat2D_LocationHoles2SampleXLD_String.Split(';'))
                {
                    HomMat2D_LocationHoles2SampleXLD_List.Add(Convert.ToDouble(v));
                }
                HomMat2D_LocationHoles2SampleXLD = HomMat2D_LocationHoles2SampleXLD_List.ToArray();


                //普通参数列表
                List<double> parasTypeList = new List<double>();
                List<double> DefectList = new List<double>();
                //高级参数列表
                List<double> AssistList = new List<double>();
                //框个数列表
                List<double> defectRectNumList = new List<double>();
                //框数据列表
                List<double> defectRectList = new List<double>();
                //框转换图像数据列表
                //List<HObject > defectxldList = new List<HObject>();
                //HObject Defect_xldArray_Temp = null;
                HObject ContOut = null;
                ////框数据列表
                //List<double> defectRectList = new List<double>();
                //框图形数据
                HObject defect_xldArray = null;
                HObject defect_xldArray_Temp = null;
                HObject ContourTemp = null;

                parasTypeList.Add(MeasureDefectList.Count);
                defectRectNumList.Add(MeasureDefectList.Count);
                foreach (var defect in MeasureDefectList)
                {
                    parasTypeList.Add(defect.DefectAlgorithm.m_AlgId);
                    defectRectNumList.Add(defect.HRectList.Count + defect.HCircleList.Count + defect.HPolygonList.Count);

                    //普通参数个数
                    int NormalParasNum = 0;
                    //1、连续出现几次报警
                    DefectList.Add(defect.DefectAlgorithm.TimesToAlarm);
                    NormalParasNum++;
                    //2、精度等级
                    DefectList.Add(defect.DefectAlgorithm.PrecisionLevel);
                    NormalParasNum++;
                    //3、是否连续报警
                    DefectList.Add(Convert .ToInt32( defect.DefectAlgorithm.IsContinuousAlarm ));
                    NormalParasNum++;
                    //4、单元总数量
                    DefectList.Add(Convert.ToInt32(defect.DefectAlgorithm.GroupNumAlarm));
                    NormalParasNum++;

                    //高级参数个数
                    int SeniorParasNum = 0;

                    //第一个参数作为报警计数不计入计算参数
                    for (int i = 0; i < defect.DefectAlgorithm.GenericAlgorithmParasList.Count; i++)
                    {
                        AlgorithmParas paras = defect.DefectAlgorithm.GenericAlgorithmParasList[i];

                        if (paras.IsSenior)
                        {
                            AssistList.Add(Convert.ToDouble(paras.Value));
                            SeniorParasNum++;
                        }
                    }

                    //foreach (var paras in defect.DefectAlgorithm.GenericAlgorithmParasList)
                    //{
                    //    if (!paras.IsSenior)
                    //    {
                    //        DefectList.Add(Convert.ToDouble(paras.Value));
                    //        NormalParasNum++;
                    //    }
                    //    else
                    //    {
                    //        AssistList.Add(Convert.ToDouble(paras.Value));
                    //        SeniorParasNum++;
                    //    }
                    //}
                    for (int i = NormalParasNum; i < AlgorithmNormalParasNum; i++)
                    {
                        DefectList.Add(0);
                    }
                    for (int i = SeniorParasNum; i < AlgorithmSeniorParasNum; i++)
                    {
                        AssistList.Add(0);
                    }

                    foreach (var rect in defect.HRectList)
                    {
                        HOperatorSet.GenRectangle2ContourXld(out ContOut, rect.Row, rect.Column, rect.Phi, rect.Length1, rect.Length2);
                        rect.Rect_xld = ContOut;
                        defectRectList.Add(1);
                        if (defect_xldArray == null)
                        {
                            defect_xldArray = rect.Rect_xld;
                        }
                        else
                        {
                            //defect_xldArray.ConcatObj(rect.Rect_xld);
                            defect_xldArray_Temp = defect_xldArray;
                            HOperatorSet.ConcatObj(defect_xldArray_Temp, rect.Rect_xld, out defect_xldArray);
                        }
                    }
                    foreach (var circle in defect.HCircleList)
                    {
                        HOperatorSet.GenCircleContourXld(out ContOut, circle.Row, circle.Column, circle.Radius, 0, 6.28318, "positive", 1);
                        circle.Circle_xld = ContOut;                        
                        defectRectList.Add(0);
                        if (defect_xldArray == null)
                        {
                            defect_xldArray = circle.Circle_xld;
                        }
                        else
                        {
                            defect_xldArray_Temp = defect_xldArray;
                            HOperatorSet.ConcatObj(defect_xldArray_Temp, circle.Circle_xld, out defect_xldArray);
                        }
                    }
                    foreach (var polygon in defect.HPolygonList)
                    {
                        HOperatorSet.GenContourPolygonXld(out ContOut, polygon.Row.ToArray(), polygon.Column.ToArray());
                        polygon.Polygon_xld = ContOut;
                        defectRectList.Add(2);
                        if (defect_xldArray == null)
                        {
                            defect_xldArray = polygon.Polygon_xld;
                        }
                        else
                        {
                            defect_xldArray_Temp = defect_xldArray;
                            HOperatorSet.ConcatObj(defect_xldArray_Temp, polygon.Polygon_xld, out defect_xldArray);
                        }
                    }
                    ContourTemp = defect.Hcontour;


                }
                //缺陷参数数组
                List<double> Defect_SetArray_List = new List<double>();
                Defect_SetArray_List.AddRange(parasTypeList);
                Defect_SetArray_List.AddRange(DefectList);
                Defect_SetArray = Defect_SetArray_List.ToArray();

                //高级参数
                List<double> Assistant_Array_List = new List<double>();
                Assistant_Array_List.AddRange(parasTypeList);
                Assistant_Array_List.AddRange(AssistList);
                Defect_Assistant_Array = Assistant_Array_List.ToArray();

                //缺陷框列表
                List<double> Defect_RectArray_List = new List<double>();
                Defect_RectArray_List.AddRange(defectRectNumList);
                Defect_RectArray_List.AddRange(defectRectList);
                Defect_RectArray = Defect_RectArray_List.ToArray();
                Defect_xldArray = defect_xldArray;
                Contour = ContourTemp;
                //Defect_xldArray = defectxldList.ToArray();
                ////特殊区域类型列表
                //List<double> specialParasTypeList = new List<double>();
                ////特殊区域参数列表
                //List<double> specialParasList = new List<double>();

                ////特殊区域框个数列表
                //List<double> specialRectNumList = new List<double>();
                ////特殊区域框数据列表
                //List<double> specialRectList = new List<double>();

                //specialParasTypeList.Add(MeasureSpecialRegionList.Count);
                //specialRectNumList.Add(MeasureSpecialRegionList.Count);
                //foreach (var special in MeasureSpecialRegionList)
                //{
                //    specialParasList.Add(special.SpecialRegionAlgorithm.m_AlgId);
                //    specialRectNumList.Add(special.HRectList.Count);

                //    //普通参数个数
                //    int NormalParasNum = 0;
                //    foreach (var paras in special.SpecialRegionAlgorithm.GenericAlgorithmParasList)
                //    {
                //        if (!paras.IsSenior)
                //        {
                //            specialParasList.Add(Convert.ToDouble(paras.Value));
                //            NormalParasNum++;
                //        }
                //        else
                //        {
                //        }
                //    }
                //    for (int i = NormalParasNum; i < AlgorithmNormalParasNum; i++)
                //    {
                //        specialParasList.Add(0);
                //    }

                //    foreach (var rect in special.HRectList)
                //    {
                //        specialRectList.Add(rect.Row);
                //        specialRectList.Add(rect.Column);
                //        specialRectList.Add(rect.Phi);
                //        specialRectList.Add(rect.Length1);
                //        specialRectList.Add(rect.Length2);
                //    }

                //}
                ////特殊区域参数数组
                //List<double> SpecialRegion_SetArray_List = new List<double>();
                //SpecialRegion_SetArray_List.AddRange(specialParasTypeList);
                //SpecialRegion_SetArray_List.AddRange(specialParasList);
                //SpecialRegion_SetArray = SpecialRegion_SetArray_List.ToArray();


                ////特殊区域框列表
                //List<double> SpecialRegion_RectArray_List = new List<double>();
                //SpecialRegion_RectArray_List.AddRange(specialRectNumList);
                //SpecialRegion_RectArray_List.AddRange(specialRectList);
                //SpecialRegion_RectArray = SpecialRegion_RectArray_List.ToArray();


                List<double> CreateParaList = new List<double>();
                CreateParaList.Add(generateModeParas.LightOrDark);
                CreateParaList.Add(station.ImageChannel);
                CreateParaList.Add(generateModeParas.RangeProduct);
                CreateParaList.Add(generateModeParas.Angle_Modle);
                CreateParaList.Add(generateModeParas.Select_MD);
                CreateParaList.Add(generateModeParas.IsClosedZone);
                CreateParaList.Add(generateModeParas.MinScore);
                CreateParaList.Add(generateModeParas.RangeLocation);
                CreateParaList.Add(generateModeParas.ModelPriority);
                CreateParaList.Add(generateModeParas.DetectionOver);
                CreateParaList.Add(generateModeParas.LocationType);
                CreateParaList.Add(generateModeParas.DirectionY);
                CreateParaList.Add(generateModeParas.DirectionX);
                CreateParaList.Add(generateModeParas.StretchY);
                CreateParaList.Add(generateModeParas.StretchX);

                hv_Create_Range_Tuple = CreateParaList.ToArray();


                List<double> ROIParaList = new List<double>();
                ROIParaList.Add(detectionArea.OffCenters_X / PixelToSizeRatio);
                ROIParaList.Add(detectionArea.OffCenters_Y / PixelToSizeRatio);
                ROIParaList.Add(detectionArea.Height / PixelToSizeRatio);
                ROIParaList.Add(detectionArea.Width / PixelToSizeRatio);
                hv_Rect_ROI = ROIParaList.ToArray();

                //灰度值
                List<double> Gray_Set_List = new List<double>();
                foreach (var v in hv_Gray_Set_String.Split(';'))
                {
                    Gray_Set_List.Add(Convert.ToDouble(v));
                }
                Gray_Set = Gray_Set_List.ToArray();

                //标定值
                List<double> CalibList = new List<double>();
                CalibList.AddRange(CameraParameters);
                CalibList.AddRange(CameraPose);
                CalibList.Add(PixelToSizeRatio);
                Calib_Tuple = CalibList.ToArray();

                //尺寸类型列表
                List<int> Size_Type_List = new List<int>();
                //公称值列表
                List<double> Size_NominalValue_List = new List<double>();
                //上下公差列表
                List<double> Size_UpDownTolerance_List = new List<double>();
                //补偿值列表
                List<double> Size_Compensation_List = new List<double>();
                //测量个数列表
                List<int> Size_MeasureNums_List = new List<int>();
                //尺寸是否显示列表
                List<int> Size_IsShow_List = new List<int>();
                //框个数列表
                List<double> SizeRectNumList = new List<double>();
                //框数据列表
                List<double> SizeRectList = new List<double>();
                //尺寸参数列表
                List<double> SizeParaList = new List<double>();


                foreach (var size in MeasureSizeList)
                {

                    Size_Type_List.Add(size.SizeAlgorithm.m_AlgId);
                    Size_NominalValue_List.Add(size.SizeAlgorithm.Std);
                    Size_UpDownTolerance_List.Add(size.SizeAlgorithm.Up);
                    Size_UpDownTolerance_List.Add(size.SizeAlgorithm.Down);
                    Size_Compensation_List.Add(size.SizeAlgorithm.Compensate);
                    Size_MeasureNums_List.Add(size.SizeAlgorithm.SizeNum);
                    Size_IsShow_List.Add(size.SizeAlgorithm.IsShow);

                    SizeRectNumList.Add(size.HRectList.Count);
                    foreach (var rect in size.HRectList)
                    {
                        SizeRectList.Add(rect.Row);
                        SizeRectList.Add(rect.Column);
                        SizeRectList.Add(rect.Phi);
                        SizeRectList.Add(rect.Length1);
                        SizeRectList.Add(rect.Length2);
                    }


                    int SizeParaNum = 0;
                    foreach (var paras in size.SizeAlgorithm.GenericAlgorithmParasList)
                    {
                        SizeParaList.Add(Convert.ToDouble(paras.Value));
                        SizeParaNum++;
                    }
                    for (int i = SizeParaNum; i < SoftwareInfo.getInstance().AlgorithmSizeParasNum; i++)
                    {
                        SizeParaList.Add(0);
                    }
                }

                Size_Type_Array = Size_Type_List.ToArray();
                Size_NominalValue_Array = Size_NominalValue_List.ToArray();
                Size_UpDownTolerance_Array = Size_UpDownTolerance_List.ToArray();
                Size_Compensation_Array = Size_Compensation_List.ToArray();
                Size_MeasureNums_Array = Size_MeasureNums_List.ToArray();
                Size_IsShow_Array = Size_IsShow_List.ToArray();


                List<double> Size_Rects_Array_List = new List<double>();
                Size_Rects_Array_List.AddRange(SizeRectNumList);
                Size_Rects_Array_List.AddRange(SizeRectList);
                Size_Rects_Array = Size_Rects_Array_List.ToArray();



                Size_Algorithm_SetArray = SizeParaList.ToArray();
            }
            catch (Exception ex)
            {
                SoftwareInfo.getInstance().WriteLog("GenerateHalconParas:\n" + ex.ToString());
                ret = 1;
            }
            return ret;
        }

        public void Copy(Model measureModel)
        {

            this.HomMat2D_LocationHoles2SampleXLD_String = measureModel.HomMat2D_LocationHoles2SampleXLD_String;
            this.Array_location_holes_String = measureModel.Array_location_holes_String;
            this.hv_Gray_Set_String = measureModel.hv_Gray_Set_String;
            this.IsEnable = measureModel.IsEnable;
            //??
            this.projectPath = measureModel.projectPath;
            this.projectFileName = measureModel.projectFileName;

            this.MeasureDefectList.Clear();
            for (int i = 0; i < measureModel.MeasureDefectList.Count; i++)
            {
                this.MeasureDefectList.Add(new MeasureDefect());
                this.MeasureDefectList[i].Copy(measureModel.MeasureDefectList[i]);

            }


            this.detectionArea.Copy(measureModel.detectionArea);
            this.locationArea.Copy(measureModel.locationArea);
            this.generateModeParas.Copy(measureModel.generateModeParas);
            this.PixelToSizeRatio = measureModel.PixelToSizeRatio;
            this.CameraParameters.Clear();
            this.CameraParameters.AddRange(measureModel.CameraParameters);
            this.CameraPose.Clear();
            this.CameraPose.AddRange(measureModel.CameraPose);
            this.hv_Rect_ROI = measureModel.hv_Rect_ROI;
            this.hv_Create_Range_Tuple = measureModel.hv_Create_Range_Tuple;
            this.Region_Array_Unit = measureModel.Region_Array_Unit;
            this.Region_Array_LHoles = measureModel.Region_Array_LHoles;
            this.Array_location_holes = measureModel.Array_location_holes;
            this.HomMat2D_LocationHoles2SampleXLD = measureModel.HomMat2D_LocationHoles2SampleXLD;
            this.Defect_SetArray = measureModel.Defect_SetArray;
            this.Defect_Assistant_Array = measureModel.Defect_Assistant_Array;
            this.Defect_RectArray = measureModel.Defect_RectArray;
            this.Defect_xldArray = measureModel.Defect_xldArray;
            this.Contour = measureModel.Contour ;
            //由于xld不能存储，加载时根据参数重新生成
            HObject ContOut = null;
            foreach (var defect in this.MeasureDefectList)
            {
                foreach (var rect in defect.HRectList)
                {
                    HOperatorSet.GenRectangle2ContourXld(out ContOut, rect.Row, rect.Column, rect.Phi, rect.Length1, rect.Length2);
                    rect.Rect_xld = ContOut;
                }
                foreach (var circle in defect.HCircleList)
                {
                    HOperatorSet.GenCircleContourXld(out ContOut, circle.Row, circle.Column, circle.Radius, 0, 6.28318, "positive", 1);
                    circle.Circle_xld = ContOut;
                }
                foreach (var polygon in defect.HPolygonList)
                {
                    HOperatorSet.GenContourPolygonXld(out ContOut, polygon.Row.ToArray(), polygon.Column.ToArray());
                    polygon.Polygon_xld = ContOut;
                }

            }
            this.SpecialRegion_SetArray = measureModel.SpecialRegion_SetArray;
            this.SpecialRegion_RectArray = measureModel.SpecialRegion_RectArray;
            this.Size_Type_Array = measureModel.Size_Type_Array;
            this.Size_NominalValue_Array = measureModel.Size_NominalValue_Array;
            this.Size_UpDownTolerance_Array = measureModel.Size_UpDownTolerance_Array;
            this.Size_Compensation_Array = measureModel.Size_Compensation_Array;
            this.Size_MeasureNums_Array = measureModel.Size_MeasureNums_Array;
            this.Size_IsShow_Array = measureModel.Size_IsShow_Array;
            this.Size_Rects_Array = measureModel.Size_Rects_Array;
            this.Gray_Set = measureModel.Gray_Set;
            this.Size_Algorithm_SetArray = measureModel.Size_Algorithm_SetArray;
            this.Calib_Tuple = measureModel.Calib_Tuple;
        }
        //public void Clear(Model measureModel)
        //{
        //}
        #endregion
    }
}
