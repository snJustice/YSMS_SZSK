using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YSMS_SZSK.CustomerGlobal
{
    public class AllModuleValue
    {
        #region 单例对象
        private static AllModuleValue instance;

        private AllModuleEnumValues iniAllModule;
        private static SortedDictionary<PublicEnum.AllModuleType, AllModuleEnumValues> m_allModuleValues = new SortedDictionary<PublicEnum.AllModuleType, AllModuleEnumValues>();

        private AllModuleValue()
        {

            iniAllModule = new AllModuleEnumValues(
                 PublicEnum.ToolType.Pointer, PublicEnum.MeasureElementAlgType.None,
                 PublicEnum.UC_ModuleType.None, PublicEnum.MeasureElementSubType.None,
                 PublicEnum.MeasureElementMainType.None, PublicEnum.UC_OperateType.None);


            //模板
            m_allModuleValues.Add(PublicEnum.AllModuleType.TemplateSetting_ROI, new AllModuleEnumValues(
                PublicEnum.ToolType.TemplateTool, PublicEnum.MeasureElementAlgType.TemplateTool,
                 PublicEnum.UC_ModuleType.TemplateSetting_Creat, PublicEnum.MeasureElementSubType.TemplateTool,
                  PublicEnum.MeasureElementMainType.Template, PublicEnum.UC_OperateType.None));

            m_allModuleValues.Add(PublicEnum.AllModuleType.TemplateSetting_ROI_Circle, new AllModuleEnumValues(
               PublicEnum.ToolType.TemplateTool_Circle, PublicEnum.MeasureElementAlgType.TemplateTool_Circle,
                PublicEnum.UC_ModuleType.TemplateSetting_Creat, PublicEnum.MeasureElementSubType.TemplateTool,
                 PublicEnum.MeasureElementMainType.Template, PublicEnum.UC_OperateType.None));

            m_allModuleValues.Add(PublicEnum.AllModuleType.TemplateSetting_Creat, new AllModuleEnumValues(
        PublicEnum.ToolType.Pointer, PublicEnum.MeasureElementAlgType.TemplateCreate,
         PublicEnum.UC_ModuleType.TemplateSetting_Creat, PublicEnum.MeasureElementSubType.TemplateElement,
          PublicEnum.MeasureElementMainType.Template, PublicEnum.UC_OperateType.None));


            //全部枚举字典
            // 坐标系
            m_allModuleValues.Add(PublicEnum.AllModuleType.CRD_MainCRD_Alg_2Circle, new AllModuleEnumValues(
                            PublicEnum.ToolType.TwoCircleToCRD, PublicEnum.MeasureElementAlgType.CRD_Alg_2Circle,
                            PublicEnum.UC_ModuleType.CRD_MainCRD, PublicEnum.MeasureElementSubType.CRDElement_Main,
                            PublicEnum.MeasureElementMainType.CRDElement, PublicEnum.UC_OperateType.Element_Para));
            m_allModuleValues.Add(PublicEnum.AllModuleType.CRD_MainCRD_Alg_2Point, new AllModuleEnumValues(
                          PublicEnum.ToolType.TwoPointToCRD, PublicEnum.MeasureElementAlgType.CRD_Alg_2Point,
                          PublicEnum.UC_ModuleType.CRD_MainCRD, PublicEnum.MeasureElementSubType.CRDElement_Main,
                          PublicEnum.MeasureElementMainType.CRDElement, PublicEnum.UC_OperateType.Element_Para));

            m_allModuleValues.Add(PublicEnum.AllModuleType.CRD_SubCRD_Alg_Point, new AllModuleEnumValues(
                            PublicEnum.ToolType.PointToSubCRD, PublicEnum.MeasureElementAlgType.CRD_SubCRD_Alg_Point,
                            PublicEnum.UC_ModuleType.CRD_SubCRD, PublicEnum.MeasureElementSubType.CRDElement_Sub,
                            PublicEnum.MeasureElementMainType.CRDElement, PublicEnum.UC_OperateType.Element_Para));

            m_allModuleValues.Add(PublicEnum.AllModuleType.CRD_MainCRD_Alg_line, new AllModuleEnumValues(PublicEnum.ToolType.LineToCRD, PublicEnum.MeasureElementAlgType.CRD_Alg_Line,
                          PublicEnum.UC_ModuleType.CRD_MainCRD, PublicEnum.MeasureElementSubType.CRDElement_Main,
                          PublicEnum.MeasureElementMainType.CRDElement, PublicEnum.UC_OperateType.Element_Para));



            #region 基本元素-点 [点选圆心、点选基岛中心 、点选双边槽孔、点选单边槽孔 、划线取点 、屏幕取点、框选弧心、线-框-边界点、框选管脚中心点]
            //基本点-点选圆心       
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementPoint_Alg_Circle, new AllModuleEnumValues(
                          PublicEnum.ToolType.CrossToPoint, PublicEnum.MeasureElementAlgType.BaseElementPoint_Alg_Circle,
                          PublicEnum.UC_ModuleType.BaseElement_Point, PublicEnum.MeasureElementSubType.BaseElement_Point,
                          PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));

            //基本点-点选基岛中心       
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementPoint_Alg_JiDao, new AllModuleEnumValues(
                        PublicEnum.ToolType.CrossToJiDaoPoint, PublicEnum.MeasureElementAlgType.BaseElementPoint_Alg_JiDao,
                        PublicEnum.UC_ModuleType.BaseElement_Point, PublicEnum.MeasureElementSubType.BaseElement_Point,
                        PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));

            //基本点-点选双边槽孔 
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementPoint_Alg_CaoKong, new AllModuleEnumValues(
                        PublicEnum.ToolType.CrossToCaoKong, PublicEnum.MeasureElementAlgType.BaseElementPoint_Alg_CaoKong,
                        PublicEnum.UC_ModuleType.BaseElement_Point, PublicEnum.MeasureElementSubType.BaseElement_Point,
                        PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));

            //基本点-点选单边槽孔     
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementPoint_Alg_SingleCaoKong, new AllModuleEnumValues(
                     PublicEnum.ToolType.CrossToSingleCaoKong, PublicEnum.MeasureElementAlgType.BaseElementPoint_Alg_SingleCaoKong,
                     PublicEnum.UC_ModuleType.BaseElement_Point, PublicEnum.MeasureElementSubType.BaseElement_Point,
                     PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));

            //基本点-划线取点     
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementPoint_Alg_Line, new AllModuleEnumValues(
                        PublicEnum.ToolType.ToolLineToPoint, PublicEnum.MeasureElementAlgType.BaseElementPoint_Alg_Line,
                        PublicEnum.UC_ModuleType.BaseElement_Point, PublicEnum.MeasureElementSubType.BaseElement_Point,
                        PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));

            //基本点-屏幕取点     
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementPoint_Alg_Screen, new AllModuleEnumValues(
                        PublicEnum.ToolType.CrossToScreenPoint, PublicEnum.MeasureElementAlgType.BaseElementPoint_Alg_Screen,
                        PublicEnum.UC_ModuleType.BaseElement_Point, PublicEnum.MeasureElementSubType.BaseElement_Point,
                        PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));

            //基本点-框选弧心   
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementPoint_Alg_SimeCircle, new AllModuleEnumValues(
                         PublicEnum.ToolType.RectangleToSemiCircleCenterPoint, PublicEnum.MeasureElementAlgType.BaseElementPoint_Alg_SimeCircle,
                         PublicEnum.UC_ModuleType.BaseElement_Point, PublicEnum.MeasureElementSubType.BaseElement_Point,
                         PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));

            //基本点-线-框-边界点  
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementPoint_Alg_LineRect, new AllModuleEnumValues(
                        PublicEnum.ToolType.ToolLineRectangleToPoint, PublicEnum.MeasureElementAlgType.BaseElementPoint_Alg_LineRect,
                        PublicEnum.UC_ModuleType.BaseElement_Point, PublicEnum.MeasureElementSubType.BaseElement_Point,
                        PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));

            //基本点-框选管脚中心点  
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementPoint_Alg_RectPinCenterPoint, new AllModuleEnumValues(
                         PublicEnum.ToolType.ToolRectPinCenterPoint, PublicEnum.MeasureElementAlgType.BaseElementPoint_Alg_RectPinCenterPoint,
                         PublicEnum.UC_ModuleType.BaseElement_Point, PublicEnum.MeasureElementSubType.BaseElement_Point,
                         PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));

            //基本点-框选区域极值点 
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementPoint_Alg_RectExtremumPoint, new AllModuleEnumValues(
                         PublicEnum.ToolType.ToolRectExtremumPoint, PublicEnum.MeasureElementAlgType.BaseElementPoint_Alg_RectExtremumPoint,
                         PublicEnum.UC_ModuleType.BaseElement_Point, PublicEnum.MeasureElementSubType.BaseElement_Point,
                         PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));



            #endregion


            ////基本线
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementLine_Alg_Line, new AllModuleEnumValues(
                    PublicEnum.ToolType.RectangleToLine, PublicEnum.MeasureElementAlgType.BaseElementLine_Alg_Line,
                    PublicEnum.UC_ModuleType.BaseElement_Line, PublicEnum.MeasureElementSubType.BaseElement_Line,
                    PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));


            //多框选线 2019-10-08 ludc
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementLine_Alg_RectList, new AllModuleEnumValues(
                  PublicEnum.ToolType.RectangleListToLine, PublicEnum.MeasureElementAlgType.BaseElementLine_Alg_RectList,
                  PublicEnum.UC_ModuleType.BaseElement_Line, PublicEnum.MeasureElementSubType.BaseElement_Line,
                  PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));

            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementLine_Alg_ShortLine, new AllModuleEnumValues(
                 PublicEnum.ToolType.RectangleToShortLine, PublicEnum.MeasureElementAlgType.BaseElementLine_Alg_ShortLine,
                 PublicEnum.UC_ModuleType.BaseElement_Line, PublicEnum.MeasureElementSubType.BaseElement_Line,
                 PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));

            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementLine_Alg_MidLine, new AllModuleEnumValues(
                    PublicEnum.ToolType.RectangleToMidLine, PublicEnum.MeasureElementAlgType.BaseElementLine_Alg_MidLine,
                    PublicEnum.UC_ModuleType.BaseElement_Line, PublicEnum.MeasureElementSubType.BaseElement_Line,
                    PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));

            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementLine_Alg_MultiLines, new AllModuleEnumValues(
                    PublicEnum.ToolType.RectangleToMultiLines, PublicEnum.MeasureElementAlgType.BaseElementLine_Alg_MultiLines,
                    PublicEnum.UC_ModuleType.BaseElement_Line, PublicEnum.MeasureElementSubType.BaseElement_Line,
                    PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));

            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementLine_Alg_MultiMidLines, new AllModuleEnumValues(
                    PublicEnum.ToolType.RectangleToMultiMidLines, PublicEnum.MeasureElementAlgType.BaseElementLine_Alg_MultiMidLines,
                    PublicEnum.UC_ModuleType.BaseElement_Line, PublicEnum.MeasureElementSubType.BaseElement_Line,
                    PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));


            ////基本圆
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementCircle_Alg_Point, new AllModuleEnumValues(
                 PublicEnum.ToolType.CrossToCircle, PublicEnum.MeasureElementAlgType.BaseElementCircle_Alg_Point,
                 PublicEnum.UC_ModuleType.BaseElement_Circle, PublicEnum.MeasureElementSubType.BaseElement_Circle,
                 PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));

            ////圆出圆
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementCircle_Alg_Circle, new AllModuleEnumValues(
                 PublicEnum.ToolType.CircleToCircle, PublicEnum.MeasureElementAlgType.BaseElementCircle_Alg_Circle,
                 PublicEnum.UC_ModuleType.BaseElement_Circle, PublicEnum.MeasureElementSubType.BaseElement_Circle,
                 PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));

            //框选圆
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementCircle_Alg_Rect, new AllModuleEnumValues(
               PublicEnum.ToolType.RectToCircle, PublicEnum.MeasureElementAlgType.BaseElementCircle_Alg_Rect,
               PublicEnum.UC_ModuleType.BaseElement_Circle, PublicEnum.MeasureElementSubType.BaseElement_Circle,
               PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));


            //框选弧
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementArc_Alg_Rect, new AllModuleEnumValues(
               PublicEnum.ToolType.RectToArc, PublicEnum.MeasureElementAlgType.BaseElementArc_Alg_Rect,
               PublicEnum.UC_ModuleType.BaseElement_Arc, PublicEnum.MeasureElementSubType.BaseElement_Arc,
               PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));


            //多框选弧 2019-09-29 ludc
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementArc_Alg_RectList, new AllModuleEnumValues(
               PublicEnum.ToolType.RectListToArc, PublicEnum.MeasureElementAlgType.BaseElementArc_Alg_RectList,
               PublicEnum.UC_ModuleType.BaseElement_Arc, PublicEnum.MeasureElementSubType.BaseElement_Arc,
               PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));





            //框选圆弧
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementCircleArc_Alg_Rect, new AllModuleEnumValues(
               PublicEnum.ToolType.RectToCircleArc, PublicEnum.MeasureElementAlgType.BaseElementCircleArc_Alg_Rect,
               PublicEnum.UC_ModuleType.BaseElement_Arc, PublicEnum.MeasureElementSubType.BaseElement_Arc,
               PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));

            ////尺寸 点点距离
            m_allModuleValues.Add(PublicEnum.AllModuleType.SizeElementDIST_PP_Alg_2Point, new AllModuleEnumValues(
                PublicEnum.ToolType.LabelTwoPointDistance, PublicEnum.MeasureElementAlgType.SizeElementDIST_PP_Alg_2Point,
                PublicEnum.UC_ModuleType.SizeElement_DIST_PP, PublicEnum.MeasureElementSubType.SizeElement_DIST_PP,
                PublicEnum.MeasureElementMainType.SizeElement, PublicEnum.UC_OperateType.Element_Para));

            m_allModuleValues.Add(PublicEnum.AllModuleType.SizeElementDIST_PP_Alg_2Circle, new AllModuleEnumValues(
                PublicEnum.ToolType.LabelTwoCircleDistance, PublicEnum.MeasureElementAlgType.SizeElementDIST_PP_Alg_2Circle,
                PublicEnum.UC_ModuleType.SizeElement_DIST_PP, PublicEnum.MeasureElementSubType.SizeElement_DIST_PP,
                PublicEnum.MeasureElementMainType.SizeElement, PublicEnum.UC_OperateType.Element_Para));

            m_allModuleValues.Add(PublicEnum.AllModuleType.SizeElementDIST_PP_Alg_2CircleIntiligent, new AllModuleEnumValues(
                PublicEnum.ToolType.LabelSmartTwoCircleDistance, PublicEnum.MeasureElementAlgType.SizeElementDIST_PP_Alg_2CircleIntiligent,
                PublicEnum.UC_ModuleType.SizeElement_DIST_PP, PublicEnum.MeasureElementSubType.SizeElement_DIST_PP,
                PublicEnum.MeasureElementMainType.SizeElement, PublicEnum.UC_OperateType.Element_Para));


            ////尺寸 线线距离
            m_allModuleValues.Add(PublicEnum.AllModuleType.SizeElementDIST_LL_Alg_2Line, new AllModuleEnumValues(
                 PublicEnum.ToolType.LabelTwoLineDistance, PublicEnum.MeasureElementAlgType.SizeElementDIST_LL_Alg_2Line,
                 PublicEnum.UC_ModuleType.SizeElement_DIST_LL, PublicEnum.MeasureElementSubType.SizeElement_DIST_LL,
                 PublicEnum.MeasureElementMainType.SizeElement, PublicEnum.UC_OperateType.Element_Para));

            ////尺寸 框选线线距离
            m_allModuleValues.Add(PublicEnum.AllModuleType.SizeElementDIST_LL_Alg_Rect, new AllModuleEnumValues(
                 PublicEnum.ToolType.LabelRectangleToLineDistance, PublicEnum.MeasureElementAlgType.SizeElementDIST_LL_Alg_Rect,
                 PublicEnum.UC_ModuleType.SizeElement_DIST_LL, PublicEnum.MeasureElementSubType.SizeElement_DISTs_LLs,
                 PublicEnum.MeasureElementMainType.SizeElement, PublicEnum.UC_OperateType.Element_Para));

            //尺寸 点线距离
            m_allModuleValues.Add(PublicEnum.AllModuleType.SizeElementDIST_PL_Alg_Point, new AllModuleEnumValues(
                 PublicEnum.ToolType.LabelPointLineDistance, PublicEnum.MeasureElementAlgType.SizeElementDIST_PL_Alg_Point,
                 PublicEnum.UC_ModuleType.SizeElement_DIST_PL, PublicEnum.MeasureElementSubType.SizeElement_DIST_PL,
                 PublicEnum.MeasureElementMainType.SizeElement, PublicEnum.UC_OperateType.Element_Para));


            ////尺寸  直径/半径  
            m_allModuleValues.Add(PublicEnum.AllModuleType.SizeElementRID_DIA_CA_Alg_Radius, new AllModuleEnumValues(
                  PublicEnum.ToolType.LabelCircleToRadius, PublicEnum.MeasureElementAlgType.SizeElementRID_DIA_CA_Alg_Radius,
                  PublicEnum.UC_ModuleType.SizeElement_RID_DIA_CA, PublicEnum.MeasureElementSubType.SizeElement_RID_CA,
                  PublicEnum.MeasureElementMainType.SizeElement, PublicEnum.UC_OperateType.Element_Para));

            m_allModuleValues.Add(PublicEnum.AllModuleType.SizeElementRID_DIA_CA_Alg_Diameter, new AllModuleEnumValues(
                  PublicEnum.ToolType.LabelCircleToDiameter, PublicEnum.MeasureElementAlgType.SizeElementRID_DIA_CA_Alg_Diameter,
                  PublicEnum.UC_ModuleType.SizeElement_RID_DIA_CA, PublicEnum.MeasureElementSubType.SizeElement_DIA_CA,
                  PublicEnum.MeasureElementMainType.SizeElement, PublicEnum.UC_OperateType.Element_Para));

            m_allModuleValues.Add(PublicEnum.AllModuleType.SizeElementRID_DIA_CA_Alg_Point_R, new AllModuleEnumValues(
                  PublicEnum.ToolType.LabelSmartCircleToRadius, PublicEnum.MeasureElementAlgType.SizeElementRID_DIA_CA_Alg_Point_R,
                  PublicEnum.UC_ModuleType.SizeElement_RID_DIA_CA, PublicEnum.MeasureElementSubType.SizeElement_RID_CA,
                  PublicEnum.MeasureElementMainType.SizeElement, PublicEnum.UC_OperateType.Element_Para));

            m_allModuleValues.Add(PublicEnum.AllModuleType.SizeElementRID_DIA_CA_Alg_Point_D, new AllModuleEnumValues(
                  PublicEnum.ToolType.LabelSmartCircleToDiameter, PublicEnum.MeasureElementAlgType.SizeElementRID_DIA_CA_Alg_Point_D,
                  PublicEnum.UC_ModuleType.SizeElement_RID_DIA_CA, PublicEnum.MeasureElementSubType.SizeElement_DIA_CA,
                  PublicEnum.MeasureElementMainType.SizeElement, PublicEnum.UC_OperateType.Element_Para));



            //点选弧半径
            m_allModuleValues.Add(PublicEnum.AllModuleType.SizeElementRID_DIA_CA_Alg_Arc_R, new AllModuleEnumValues(
                  PublicEnum.ToolType.LabelArcToRadius, PublicEnum.MeasureElementAlgType.SizeElementRID_ARC_Alg_Point,
                  PublicEnum.UC_ModuleType.SizeElement_RID_DIA_CA, PublicEnum.MeasureElementSubType.SizeElement_RID_CA,
                  PublicEnum.MeasureElementMainType.SizeElement, PublicEnum.UC_OperateType.Element_Para));



            //点选弧长
            m_allModuleValues.Add(PublicEnum.AllModuleType.SizeElementLenth_ARC_Alg_Point, new AllModuleEnumValues(
                  PublicEnum.ToolType.LabelArcLenth, PublicEnum.MeasureElementAlgType.SizeElementLenth_ARC_Alg_Point,
                  PublicEnum.UC_ModuleType.SizeElement_RID_DIA_CA, PublicEnum.MeasureElementSubType.SizeElement_Lenth_Arc,
                  PublicEnum.MeasureElementMainType.SizeElement, PublicEnum.UC_OperateType.Element_Para));


            //点坐标
            m_allModuleValues.Add(PublicEnum.AllModuleType.CoordinateElementPoint_Alg_Point, new AllModuleEnumValues(
                 PublicEnum.ToolType.LabelPointToCRD, PublicEnum.MeasureElementAlgType.CoordinateElementPoint_Alg_Point,
                 PublicEnum.UC_ModuleType.CoordinateElement_Point, PublicEnum.MeasureElementSubType.CoordinateElement_Point,
                 PublicEnum.MeasureElementMainType.CoordinateElement, PublicEnum.UC_OperateType.Element_Para));

            m_allModuleValues.Add(PublicEnum.AllModuleType.CoordinateElementPoint_Alg_Circle, new AllModuleEnumValues(
                PublicEnum.ToolType.LabelSmartCircleCenterToCRD, PublicEnum.MeasureElementAlgType.CoordinateElementPoint_Alg_Circle,
                PublicEnum.UC_ModuleType.CoordinateElement_Point, PublicEnum.MeasureElementSubType.CoordinateElement_Point,
                PublicEnum.MeasureElementMainType.CoordinateElement, PublicEnum.UC_OperateType.Element_Para));

            m_allModuleValues.Add(PublicEnum.AllModuleType.CoordinateElementPoint_Alg_SingleCaoKong, new AllModuleEnumValues(
                PublicEnum.ToolType.LabelSmartSingleCaoKongToCRD, PublicEnum.MeasureElementAlgType.CoordinateElementPoint_Alg_SingleCaoKong,
                PublicEnum.UC_ModuleType.CoordinateElement_Point, PublicEnum.MeasureElementSubType.CoordinateElement_Point,
                PublicEnum.MeasureElementMainType.CoordinateElement, PublicEnum.UC_OperateType.Element_Para));

            m_allModuleValues.Add(PublicEnum.AllModuleType.CoordinateElementPoint_Alg_JiDao, new AllModuleEnumValues(
                PublicEnum.ToolType.LabelSmartJiDaoCenterToCRD, PublicEnum.MeasureElementAlgType.CoordinateElementPoint_Alg_JiDao,
                PublicEnum.UC_ModuleType.CoordinateElement_Point, PublicEnum.MeasureElementSubType.CoordinateElement_Point,
                PublicEnum.MeasureElementMainType.CoordinateElement, PublicEnum.UC_OperateType.Element_Para));

            //弧心点坐标
            m_allModuleValues.Add(PublicEnum.AllModuleType.CoordinateElementPoint_Alg_ArcCenterPoint, new AllModuleEnumValues(
             PublicEnum.ToolType.LabelArcPointCenterToCRD, PublicEnum.MeasureElementAlgType.CoordinateElementPoint_Alg_ArcCenterPoint,
             PublicEnum.UC_ModuleType.CoordinateElement_Point, PublicEnum.MeasureElementSubType.CoordinateElement_Point,
             PublicEnum.MeasureElementMainType.CoordinateElement, PublicEnum.UC_OperateType.Element_Para));

            //直线坐标
            m_allModuleValues.Add(PublicEnum.AllModuleType.CoordinateElementLine_Alg_Line, new AllModuleEnumValues(
                 PublicEnum.ToolType.LabelLineToCRD, PublicEnum.MeasureElementAlgType.CoordinateElementLine_Alg_Line,
                 PublicEnum.UC_ModuleType.CoordinateElement_Line, PublicEnum.MeasureElementSubType.CoordinateElement_Line,
                 PublicEnum.MeasureElementMainType.CoordinateElement, PublicEnum.UC_OperateType.Element_Para));


            #region 辅助元素-点 [四边拟合矩形中心、两线交点、两点中点、多点拟合圆心点 ]
            ////辅助元素-点-四边拟合矩形中心        
            m_allModuleValues.Add(PublicEnum.AllModuleType.AssistElementPoint_Alg_4Line, new AllModuleEnumValues(
                          PublicEnum.ToolType.FourLineToPoint, PublicEnum.MeasureElementAlgType.AssistElementPoint_Alg_4Line,
                          PublicEnum.UC_ModuleType.AssistElement_Point, PublicEnum.MeasureElementSubType.AssistElement_Point,
                          PublicEnum.MeasureElementMainType.AssistElement, PublicEnum.UC_OperateType.Element_Para));

            ////辅助元素-点-两线交点         
            m_allModuleValues.Add(PublicEnum.AllModuleType.AssistElementPoint_Alg_2Line, new AllModuleEnumValues(
                          PublicEnum.ToolType.TwoLineToPoint, PublicEnum.MeasureElementAlgType.AssistElementPoint_Alg_2Line,
                          PublicEnum.UC_ModuleType.AssistElement_Point, PublicEnum.MeasureElementSubType.AssistElement_Point,
                          PublicEnum.MeasureElementMainType.AssistElement, PublicEnum.UC_OperateType.Element_Para));


            ////辅助元素-点-两点中点     
            m_allModuleValues.Add(PublicEnum.AllModuleType.AssistElementPoint_Alg_2Point, new AllModuleEnumValues(
                          PublicEnum.ToolType.TwoPointToPoint, PublicEnum.MeasureElementAlgType.AssistElementPoint_Alg_2Point,
                          PublicEnum.UC_ModuleType.AssistElement_Point, PublicEnum.MeasureElementSubType.AssistElement_Point,
                          PublicEnum.MeasureElementMainType.AssistElement, PublicEnum.UC_OperateType.Element_Para));

            ////辅助元素-点-多点拟合圆心点  
            m_allModuleValues.Add(PublicEnum.AllModuleType.AssistElementPoint_Alg_PointsFitToCircleCenterPoint, new AllModuleEnumValues(
                          PublicEnum.ToolType.PointsFitToCircleCenterPoint, PublicEnum.MeasureElementAlgType.AssistElementPoint_Alg_PointsFitToCircleCenterPoint,
                          PublicEnum.UC_ModuleType.AssistElement_Point, PublicEnum.MeasureElementSubType.AssistElement_Point,
                          PublicEnum.MeasureElementMainType.AssistElement, PublicEnum.UC_OperateType.Element_Para));

            ////辅助元素-点-弧线交点         
            m_allModuleValues.Add(PublicEnum.AllModuleType.AssistElementPoint_Alg_ArcLine, new AllModuleEnumValues(
                          PublicEnum.ToolType.ArcLineToPoint, PublicEnum.MeasureElementAlgType.AssistElementPoint_Alg_ArcLine,
                          PublicEnum.UC_ModuleType.AssistElement_Point, PublicEnum.MeasureElementSubType.AssistElement_Point,
                          PublicEnum.MeasureElementMainType.AssistElement, PublicEnum.UC_OperateType.Element_Para));


            ////辅助元素-点-弧线切点        2019-10-17 ludc  
            m_allModuleValues.Add(PublicEnum.AllModuleType.AssistElementPoint_Alg_ArcLine_Tangent, new AllModuleEnumValues(
                          PublicEnum.ToolType.ArcLineToPoint_Tangent, PublicEnum.MeasureElementAlgType.AssistElementPoint_Alg_ArcLine_Tangent,
                          PublicEnum.UC_ModuleType.AssistElement_Point, PublicEnum.MeasureElementSubType.AssistElement_Point,
                          PublicEnum.MeasureElementMainType.AssistElement, PublicEnum.UC_OperateType.Element_Para));


            ////辅助元素-点-线的起点和终点     
            m_allModuleValues.Add(PublicEnum.AllModuleType.AssistElement_Alg_LineStartingPointEndPoint, new AllModuleEnumValues(
                          PublicEnum.ToolType.LineStartingPointEndPoint, PublicEnum.MeasureElementAlgType.AssistElement_Alg_LineStartingPointEndPoint,
                          PublicEnum.UC_ModuleType.AssistElement_Point, PublicEnum.MeasureElementSubType.AssistElement_Point,
                          PublicEnum.MeasureElementMainType.AssistElement, PublicEnum.UC_OperateType.Element_Para));


            ////辅助元素-点-线中点     
            m_allModuleValues.Add(PublicEnum.AllModuleType.AssistElement_Alg_LineMidpoint, new AllModuleEnumValues(
                          PublicEnum.ToolType.LineMidpoint, PublicEnum.MeasureElementAlgType.AssistElement_Alg_LineMidpoint,
                          PublicEnum.UC_ModuleType.AssistElement_Point, PublicEnum.MeasureElementSubType.AssistElement_Point,
                          PublicEnum.MeasureElementMainType.AssistElement, PublicEnum.UC_OperateType.Element_Para));

            #endregion


            ////辅助元素-线-两点连线        
            m_allModuleValues.Add(PublicEnum.AllModuleType.AssistElementLine_Alg_2Point, new AllModuleEnumValues(
                          PublicEnum.ToolType.TwoPointToLine, PublicEnum.MeasureElementAlgType.AssistElementLine_Alg_2Point,
                          PublicEnum.UC_ModuleType.AssistElement_Line, PublicEnum.MeasureElementSubType.AssistElement_Line,
                          PublicEnum.MeasureElementMainType.AssistElement, PublicEnum.UC_OperateType.Element_Para));


            ////辅助元素-线-线线拟合    
            m_allModuleValues.Add(PublicEnum.AllModuleType.AssistElementLine_Alg_Lines, new AllModuleEnumValues(
                          PublicEnum.ToolType.LinesToLine, PublicEnum.MeasureElementAlgType.AssistElementLine_Alg_Lines,
                          PublicEnum.UC_ModuleType.AssistElement_Line, PublicEnum.MeasureElementSubType.AssistElement_Line,
                          PublicEnum.MeasureElementMainType.AssistElement, PublicEnum.UC_OperateType.Element_Para));


            ////辅助元素-弧-弧弧拟合    
            m_allModuleValues.Add(PublicEnum.AllModuleType.AssistElementArc_Alg_Arcs, new AllModuleEnumValues(
                          PublicEnum.ToolType.ArcsToArc, PublicEnum.MeasureElementAlgType.AssistElementArc_Alg_Arcs,
                          PublicEnum.UC_ModuleType.AssistElement_Arc, PublicEnum.MeasureElementSubType.AssistElement_Arc,
                          PublicEnum.MeasureElementMainType.AssistElement, PublicEnum.UC_OperateType.Element_Para));

            m_allModuleValues.Add(PublicEnum.AllModuleType.AssistElementLine_Alg_2Line, new AllModuleEnumValues(
                          PublicEnum.ToolType.TwoLineToLine, PublicEnum.MeasureElementAlgType.AssistElementLine_Alg_2Line,
                          PublicEnum.UC_ModuleType.AssistElement_Line, PublicEnum.MeasureElementSubType.AssistElement_Line,
                          PublicEnum.MeasureElementMainType.AssistElement, PublicEnum.UC_OperateType.Element_Para));
            //框选轮廓直线
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementLine_Alg_OutLine, new AllModuleEnumValues(
                          PublicEnum.ToolType.RectangleToOutLine, PublicEnum.MeasureElementAlgType.BaseElementLine_Alg_OutLine,
                          PublicEnum.UC_ModuleType.BaseElement_Line, PublicEnum.MeasureElementSubType.BaseElement_Line,
                          PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));



            //获取灰度值
            m_allModuleValues.Add(PublicEnum.AllModuleType.Rectangle2GrayVal, new AllModuleEnumValues(
                        PublicEnum.ToolType.Rectangle2GrayVal, PublicEnum.MeasureElementAlgType.None,
                        PublicEnum.UC_ModuleType.ImageGrab_Grab, PublicEnum.MeasureElementSubType.None,
                        PublicEnum.MeasureElementMainType.None, PublicEnum.UC_OperateType.None));




            #region 形位公差
            //圆度
            m_allModuleValues.Add(PublicEnum.AllModuleType.ToleranceForm_Circularity_Alg_Circle, new AllModuleEnumValues(
                        PublicEnum.ToolType.LabelCircularity, PublicEnum.MeasureElementAlgType.ToleranceForm_Circularity_Alg_Circle,
                        PublicEnum.UC_ModuleType.ToleranceForm, PublicEnum.MeasureElementSubType.ToleranceForm_Circularity,
                        PublicEnum.MeasureElementMainType.ToleranceForm, PublicEnum.UC_OperateType.Element_Para));

            //直线度
            m_allModuleValues.Add(PublicEnum.AllModuleType.ToleranceForm_Straightness_Alg_Line, new AllModuleEnumValues(
                      PublicEnum.ToolType.LabelStraightness, PublicEnum.MeasureElementAlgType.ToleranceForm_Straightness_Alg_Line,
                      PublicEnum.UC_ModuleType.ToleranceForm, PublicEnum.MeasureElementSubType.ToleranceForm_Straightness,
                      PublicEnum.MeasureElementMainType.ToleranceForm, PublicEnum.UC_OperateType.Element_Para));


            //平行度
            m_allModuleValues.Add(PublicEnum.AllModuleType.TolerancePosition_Parallelism_Alg, new AllModuleEnumValues(
                      PublicEnum.ToolType.LabelParallelism, PublicEnum.MeasureElementAlgType.TolerancePosition_Parallelism_Alg,
                      PublicEnum.UC_ModuleType.TolerancePosition, PublicEnum.MeasureElementSubType.TolerancePosition_Parallelism,
                      PublicEnum.MeasureElementMainType.TolerancePosition, PublicEnum.UC_OperateType.Element_Para));

            //垂直度
            m_allModuleValues.Add(PublicEnum.AllModuleType.TolerancePostion_Perpendicularity_Alg, new AllModuleEnumValues(
                      PublicEnum.ToolType.LabelPerpendicularity, PublicEnum.MeasureElementAlgType.TolerancePosition_Perpendicularity_Alg,
                      PublicEnum.UC_ModuleType.TolerancePosition, PublicEnum.MeasureElementSubType.TolerancePosition_Perpendicularity,
                      PublicEnum.MeasureElementMainType.TolerancePosition, PublicEnum.UC_OperateType.Element_Para));


            // 倾斜度
            m_allModuleValues.Add(PublicEnum.AllModuleType.TolerancePostion_Gradient_Alg, new AllModuleEnumValues(
                      PublicEnum.ToolType.LabelGradient, PublicEnum.MeasureElementAlgType.TolerancePosition_Gradient_Alg,
                      PublicEnum.UC_ModuleType.TolerancePosition, PublicEnum.MeasureElementSubType.TolerancePosition_Gradient,
                      PublicEnum.MeasureElementMainType.TolerancePosition, PublicEnum.UC_OperateType.Element_Para));

            //同心度
            m_allModuleValues.Add(PublicEnum.AllModuleType.TolerancePosition_ConCentricity_Alg, new AllModuleEnumValues(
                   PublicEnum.ToolType.LabelConcentricity, PublicEnum.MeasureElementAlgType.TolerancePosition_ConCentricity_Alg,
                   PublicEnum.UC_ModuleType.TolerancePosition, PublicEnum.MeasureElementSubType.TolerancePosition_Concentricity,
                   PublicEnum.MeasureElementMainType.TolerancePosition, PublicEnum.UC_OperateType.Element_Para));


            #endregion


            ////尺寸 线线夹角
            m_allModuleValues.Add(PublicEnum.AllModuleType.SizeElementANG_LL_Alg_2Line, new AllModuleEnumValues(
                 PublicEnum.ToolType.Label2LineAngle, PublicEnum.MeasureElementAlgType.SizeElementANG_LL_Alg_2Line,
                 PublicEnum.UC_ModuleType.SizeElement_ANG_LL, PublicEnum.MeasureElementSubType.SizeElement_ANG_LL,
                 PublicEnum.MeasureElementMainType.SizeElement, PublicEnum.UC_OperateType.Element_Para));


            #region 众威
            ////尺寸 框选2线距离  2017/2/4 czf
            m_allModuleValues.Add(PublicEnum.AllModuleType.SizeElementDIST_2L_Alg_4Rect, new AllModuleEnumValues(PublicEnum.ToolType.Label4RectangleTo2LineDistance, PublicEnum.MeasureElementAlgType.SizeElementDIST_2L_Alg_4Rect,
                 PublicEnum.UC_ModuleType.SizeElement_DIST_LL, PublicEnum.MeasureElementSubType.SizeElement_DISTs_2L,
                 PublicEnum.MeasureElementMainType.SizeElement, PublicEnum.UC_OperateType.Element_Para));

            //框出直径 2017/2/4 czf
            m_allModuleValues.Add(PublicEnum.AllModuleType.SizeElementRID_DIA_Alg_Rect_D, new AllModuleEnumValues(
                  PublicEnum.ToolType.LabelRectangleToDiameter, PublicEnum.MeasureElementAlgType.SizeElementRID_DIA_Alg_Rect,
                  PublicEnum.UC_ModuleType.SizeElement_DIST_LL, PublicEnum.MeasureElementSubType.SizeElement_DISTs_2L,
                  PublicEnum.MeasureElementMainType.SizeElement, PublicEnum.UC_OperateType.Element_Para));

            //两框出基准线
            m_allModuleValues.Add(PublicEnum.AllModuleType.TwoRectangleToBaseLine, new AllModuleEnumValues(
                        PublicEnum.ToolType.TwoRectangleToBaseLine, PublicEnum.MeasureElementAlgType.TwoRectangleToBaseLine,
                        PublicEnum.UC_ModuleType.BaseElement_Line, PublicEnum.MeasureElementSubType.BaseElement_Line,
                        PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));
            #endregion


            ////尺寸 圆弧夹角
            m_allModuleValues.Add(PublicEnum.AllModuleType.SizeElementANG_Arc_Alg_Point, new AllModuleEnumValues(
                 PublicEnum.ToolType.Label2ArcAngle, PublicEnum.MeasureElementAlgType.SizeElementANG_Arc_Alg_Point,
                 PublicEnum.UC_ModuleType.SizeElement_ANG_LL, PublicEnum.MeasureElementSubType.SizeElement_ANG_Arc,
                 PublicEnum.MeasureElementMainType.SizeElement, PublicEnum.UC_OperateType.Element_Para));


            ////基本圆- 点选两圆（圆环）
            m_allModuleValues.Add(PublicEnum.AllModuleType.BaseElementCircle_Alg_Ring, new AllModuleEnumValues(
                 PublicEnum.ToolType.PointToRing, PublicEnum.MeasureElementAlgType.BaseElementCircle_Alg_Ring,
                 PublicEnum.UC_ModuleType.BaseElement_Circle, PublicEnum.MeasureElementSubType.BaseElement_Circle,
                 PublicEnum.MeasureElementMainType.BaseElement, PublicEnum.UC_OperateType.Element_Para));


            ////点点距- 4框出点点距
            m_allModuleValues.Add(PublicEnum.AllModuleType.SizeElementDIST_PP_Alg_2Point_4Rect, new AllModuleEnumValues(
                 PublicEnum.ToolType.Label4RectangleTo2PointDistance, PublicEnum.MeasureElementAlgType.SizeElementDIST_PP_Alg_2Point_4Rect,
                 PublicEnum.UC_ModuleType.SizeElement_DIST_PP, PublicEnum.MeasureElementSubType.SizeElement_DIST_PP,
                 PublicEnum.MeasureElementMainType.SizeElement, PublicEnum.UC_OperateType.Element_Para));

        }
        /// <summary>
        /// 获取 单例实例对象
        /// </summary>
        /// <returns></returns>
        public static AllModuleValue getInstance()
        {
            if (instance == null)
            {
                lock (typeof(DrawParas))
                {
                    if (instance == null)
                    {
                        instance = new AllModuleValue();
                    }
                }
            }
            return instance;
        }
        #endregion

        public AllModuleEnumValues getValues(PublicEnum.AllModuleType allModule)
        {
            if (m_allModuleValues.ContainsKey(allModule))
                return m_allModuleValues[allModule];
            else
                return iniAllModule;
        }

    }

    public class AllModuleEnumValues
    {
        #region 元素
        /// <summary>
        /// 工具
        /// </summary>
        public PublicEnum.ToolType ToolEnum { get; set; }

        /// <summary>
        /// 算法参数类型
        /// </summary>
        public PublicEnum.MeasureElementAlgType AlgEnum { get; set; }

        /// <summary>
        /// 子类型
        /// </summary>
        public PublicEnum.MeasureElementSubType SubEnum { get; set; }

        /// <summary>
        /// 主类型
        /// </summary>
        public PublicEnum.MeasureElementMainType MainEnum { get; set; }

        #endregion
        /// <summary>
        /// UC界面
        /// </summary>
        public PublicEnum.UC_ModuleType UcModuleEnum { get; set; }

        /// <summary>
        /// 操作树类型
        /// </summary>
        public PublicEnum.UC_OperateType UcOperateEnum { get; set; }


        public AllModuleEnumValues(PublicEnum.ToolType _toolEnum, PublicEnum.MeasureElementAlgType _algEnum, PublicEnum.UC_ModuleType _ucModuleEnum, PublicEnum.MeasureElementSubType _subEnum, PublicEnum.MeasureElementMainType _mainEnum, PublicEnum.UC_OperateType _ucOperateEnum)
        {
            this.AlgEnum = _algEnum;
            this.MainEnum = _mainEnum;
            this.SubEnum = _subEnum;
            this.UcModuleEnum = _ucModuleEnum;
            this.UcOperateEnum = _ucOperateEnum;
            this.ToolEnum = _toolEnum;
        }


    }
}
