using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YSMS_SZSK.CustomerGlobal
{
    public class PublicEnum
    {



        /// <summary>
        /// 打开定义程序界面 -分类
        /// </summary>
        public enum OpenDefineMeasureType
        {
            /// <summary>
            /// 正常打开
            /// </summary>
            Nomal = 0,

            /// <summary>
            /// 程序修复 时 临时打开
            /// </summary>
            ProgrameRepair,
        }
        public enum ArrayDirection
        {
            /// <summary>
            /// X轴
            /// </summary>
            AxisX,

            /// <summary>
            /// Y轴
            /// </summary>
            AxisY
        }

        public enum Diatance2CirclesType
        {
            /// <summary>
            /// 两圆心距离
            /// </summary>
            Centers,

            /// <summary>
            /// 最小距离
            /// </summary>
            Min,

            /// <summary>
            /// 最大距离
            /// </summary>
            Max
        }

        /// <summary>
        /// 作为判据状态
        /// </summary>
        public enum LabelAsJudgeType
        {
            /// <summary>
            /// 不作为判据
            /// </summary>
            None = 0,

            /// <summary>
            /// 判据启用
            /// </summary>
            Enable,

            /// <summary>
            /// 判据禁用
            /// </summary>
            UnEnable
        }

        /// <summary>
        /// 标注类型（绘图用） 标注类型 与 图形化测量元素  命名需要符合特定规则  GraphicsMeasureElement_Label{LabelType.ToString()}
        /// </summary>
        public enum LabelType
        {
            None = 0,

            LabelCircleToDiameter,

            LabelCircleToRadius,

            LabelCircularity,

            LabelPointToCRD,

            LabelLineToCRD,

            LabelTwoPointDistance,

            LabelTwoCircleDistance,

            LabelTwoLineDistance,

            LabelPointLineDistance,

            //用于框选多线距离
            LabelList,
            //用于框选多线距离
            LabelList_2p,
            /// <summary>
            /// 点选弧半径
            /// </summary>
            LabelArcToRadius,

            /// <summary>
            /// 直线度
            /// </summary>
            LabelStraightness,

            /// <summary>
            /// 平行度
            /// </summary>
            LabelTwoLineParallelism,

            /// <summary>
            /// 垂直度
            /// </summary>
            LabelTwoLinePerpendicularity,
            /// <summary>
            /// 垂直度
            /// </summary>
            LabelTwoLineGradient,

            /// <summary>
            /// 同心度
            /// </summary>
            LabelPositionConcentricity,

            /// <summary>
            /// 线线夹角
            /// </summary>
            LabelTwoLineAngle,


            /// <summary>
            /// 点选弧心坐标
            /// </summary>
            LabelArcCentetPointToCRD,

            /// <summary>
            /// 点选弧夹角
            /// </summary>
            LabelArcToAngle,

            /// <summary>
            /// 点选弧长
            /// </summary>
            LabelArcToLenth,
        }

        /// <summary>
        /// 标注类元素标注基准轴
        /// </summary>
        public enum ReferenceAxisType
        {
            None = 0,

            /// <summary>
            /// X轴
            /// </summary>
            AxisX,

            /// <summary>
            /// Y轴
            /// </summary>
            AxisY,

            /// <summary>
            /// 绝对
            /// </summary>
            Absolute,

            /// <summary>
            /// XY轴
            /// </summary>
            AxisXY
        }

        /// <summary>
        /// 自定义控件参数类型
        /// </summary>
        public enum UC_OperateType
        {
            None = 0,

            /// <summary>
            /// 图像获取-运动控制参数
            /// </summary>
            ImageGrab_Move_Para,

            /// <summary>
            /// 图像获取-光源控制参数
            /// </summary>
            ImageGrab_Light_Para,

            /// <summary>
            /// 图像获取-相机控制参数
            /// </summary>
            ImageGrab_Camera_Para,

            /// <summary>
            /// 图像获取-图像采集参数
            /// </summary>
            ImageGrab_Grab_Para,

            /// <summary>
            /// 模板设定-检测区域参数
            /// </summary>
            TemplateSetting_ROI_Para,

            /// <summary>
            /// 模板设定-模板设置参数
            /// </summary>
            TemplateSetting_Creat_Para,

            /// <summary>
            /// 元素参数
            /// </summary>
            Element_Para

        }

        /// <summary>
        /// 自定义控件类型
        /// </summary>
        public enum UC_ModuleType
        {
            None = 0,

            /// <summary>
            /// 欢迎界面
            /// </summary>
            Welcome,

            /// <summary>
            /// 图像获取-运动参数
            /// </summary>
            ImageGrab_Move,

            /// <summary>
            /// 图像获取-光源参数
            /// </summary>
            ImageGrab_Light,

            /// <summary>
            /// 图像获取-相机参数
            /// </summary>
            ImageGrab_Camera,

            /// <summary>
            /// 图像获取-图像采集
            /// </summary>
            ImageGrab_Grab,

            /// <summary>
            /// 模板设定-检测区域
            /// </summary>
            TemplateSetting_ROI,

            /// <summary>
            /// 模板设定-模板设置
            /// </summary>
            TemplateSetting_Creat,

            /// <summary>
            /// 坐标系-主坐标系
            /// </summary>
            CRD_MainCRD,

            /// <summary>
            /// 坐标系-子坐标系
            /// </summary>
            CRD_SubCRD,

            /// <summary>
            /// 基本元素-点
            /// </summary>
            BaseElement_Point,

            /// <summary>
            /// 基本元素-线
            /// </summary>
            BaseElement_Line,

            /// <summary>
            /// 基本元素-圆
            /// </summary>
            BaseElement_Circle,

            /// <summary>
            /// 基本元素-弧
            /// </summary>
            BaseElement_Arc,

            /// <summary>
            /// 辅助元素-点
            /// </summary>
            AssistElement_Point,

            /// <summary>
            /// 辅助元素-线
            /// </summary>
            AssistElement_Line,

            /// <summary>
            /// 辅助元素-圆
            /// </summary>
            AssistElement_Circle,


            /// <summary>
            /// 辅助元素-弧
            /// </summary>
            AssistElement_Arc,
            /// <summary>
            /// 尺寸测量-点点距离
            /// </summary>
            SizeElement_DIST_PP,

            /// <summary>
            /// 尺寸测量-多点距离
            /// </summary>
            SizeElement_DISTs_PPs,

            /// <summary>
            /// 尺寸测量-点线距离
            /// </summary>
            SizeElement_DIST_PL,

            /// <summary>
            /// 尺寸测量-线线距离
            /// </summary>
            SizeElement_DIST_LL,

            /// <summary>
            /// 尺寸测量-多线距离
            /// </summary>
            SizeElement_DISTs_LLs,

            /// <summary>
            /// 尺寸测量-线线角度
            /// </summary>
            SizeElement_ANG_LL,

            /// <summary>
            /// 尺寸测量-多线角度
            /// </summary>
            SizeElement_ANGs_LLs,

            /// <summary>
            /// 尺寸测量-直径/半径
            /// </summary>
            SizeElement_RID_DIA_CA,
            /// <summary>
            /// 尺寸测量-弧长
            /// </summary>
            SizeElement_Lenth_ARC_Point,

            /// <summary>
            /// 坐标测量-点坐标
            /// </summary>
            CoordinateElement_Point,

            /// <summary>
            /// 坐标测量-线坐标
            /// </summary>
            CoordinateElement_Line,

            /// <summary>
            /// 其他-尺寸阵列
            /// </summary>
            Array_Size,

            /// <summary>
            /// 其他-尺寸阵列2
            /// </summary>
            Array_Size2,

            /// <summary>
            /// 其他-判据设定
            /// </summary>
            JudgesSetting,

            /// <summary>
            /// 其他-报表设定
            /// </summary>
            ReportsSetting,

            /// <summary>
            /// 其他-测量校准
            /// </summary>
            MeasureCorrect,

            /// <summary>
            /// 其他-测试运行
            /// </summary>
            TestRun,


            /// <summary>
            /// 设置元素 版/组
            /// </summary>
            SetBanZu,

            /// <summary>
            /// 设置元素 显示 与隐藏
            /// </summary>
            SetElementHidden,

            /// <summary>
            ///  形状公差
            /// </summary>
            ToleranceForm,

            /// <summary>
            /// 位置公差
            /// </summary>
            TolerancePosition,


        }

        /// <summary>
        /// 元素主类型
        /// </summary>
        public enum ElementType
        {
            None = 0,

            /// <summary>
            /// 工具元素
            /// </summary>
            ToolElement,

            /// <summary>
            /// 测量元素
            /// </summary>
            MeasureElement,

            /// <summary>
            /// 模板工具元素
            /// </summary>
            TemplateToolElement,

            /// <summary>
            /// 模板元素
            /// </summary>
            TemplateElement
        }

        /// <summary>
        /// 工具元素类型
        /// </summary>
        public enum ToolElementType
        {
            None = 0,

            /// <summary>
            /// 点
            /// </summary>
            Point,

            /// <summary>
            /// 线
            /// </summary>
            Line,

            /// <summary>
            /// 矩形
            /// </summary>
            Rect,

            /// <summary>
            /// 圆
            /// </summary>
            Circle
        }

        /// <summary>
        /// 工具用途（针对绑定多个工具情况）
        /// </summary>
        public enum ToolElementApplication
        {
            None = 0,

            /// <summary>
            /// 坐标系原点
            /// </summary>
            CRD_OriginalPoint,

            /// <summary>
            /// 坐标系X轴点
            /// </summary>
            CRD_X_DirectionPoint

        }

        /// <summary>
        /// 元素绘制类型
        /// </summary>
        public enum MeasureDrawType
        {
            None = 0,

            /// <summary>
            /// 十字点
            /// </summary>
            Cross,

            /// <summary>
            /// 圆形点
            /// </summary>
            Point
        }

        /// <summary>
        /// 测量元素主类型
        /// </summary>
        public enum MeasureElementMainType
        {
            None = 0,

            /// <summary>
            /// 基本元素
            /// </summary>
            BaseElement,

            /// <summary>
            /// 辅助元素
            /// </summary>
            AssistElement,

            /// <summary>
            /// 几何公差元素
            /// </summary>
            GeometryElement,

            /// <summary>
            /// 尺寸测量元素
            /// </summary>
            SizeElement,

            /// <summary>
            /// 坐标元素
            /// </summary>
            CoordinateElement,

            /// <summary>
            /// 坐标系元素
            /// </summary>
            CRDElement,

            /// <summary>
            /// 模板类型元素（包含模板和模板工具）
            /// </summary>
            Template,

            ToleranceForm,
            TolerancePosition
        }

        /// <summary>
        /// 测量元素子类型
        /// </summary>
        public enum MeasureElementSubType
        {
            None = 0,

            /// <summary>
            /// 基本元素-点
            /// </summary>
            BaseElement_Point,

            /// <summary>
            /// 基本元素-线
            /// </summary>
            BaseElement_Line,

            /// <summary>
            /// 基本元素-圆
            /// </summary>
            BaseElement_Circle,

            /// <summary>
            /// 基本元素-弧
            /// </summary>
            BaseElement_Arc,

            /// <summary>
            /// 辅助元素-点
            /// </summary>
            AssistElement_Point,

            /// <summary>
            /// 辅助元素-线
            /// </summary>
            AssistElement_Line,
            /// <summary>
            /// 辅助元素-弧
            /// </summary>
            AssistElement_Arc,
            /// <summary>
            /// 辅助元素-圆
            /// </summary>
            AssistElement_Circle,

            /// <summary>
            /// 尺寸测量-点点距离
            /// </summary>
            SizeElement_DIST_PP,

            /// <summary>
            /// 尺寸测量-多点距离
            /// </summary>
            SizeElement_DISTs_PPs,

            /// <summary>
            /// 尺寸测量-点线距离
            /// </summary>
            SizeElement_DIST_PL,

            /// <summary>
            /// 尺寸测量-线线距离
            /// </summary>
            SizeElement_DIST_LL,

            /// <summary>
            /// 尺寸测量-多线距离
            /// </summary>
            SizeElement_DISTs_LLs,

            /// <summary>
            /// 尺寸测量-2线距离
            /// </summary>
            SizeElement_DISTs_2L,

            /// <summary>
            /// 尺寸测量-线线夹角
            /// </summary>
            SizeElement_ANG_LL,

            /// <summary>
            /// 尺寸测量-多线夹角
            /// </summary>
            SizeElement_ANGs_LLs,

            ///// <summary>
            ///// 尺寸测量-圆/弧半径直径
            ///// </summary>
            //SizeElement_RID_DIA_CA,

            /// <summary>
            /// 尺寸测量-圆/弧 半径
            /// </summary>
            SizeElement_RID_CA,

            /// <summary>
            /// 尺寸测量-圆/弧 直径
            /// </summary>
            SizeElement_DIA_CA,
            /// <summary>
            /// 尺寸测量-圆/弧 弧半径
            /// </summary>
            SizeElement_RID_Arc,

            /// <summary>
            /// 坐标测量-点坐标
            /// </summary>
            CoordinateElement_Point,

            /// <summary>
            /// 坐标测量-线坐标
            /// </summary>
            CoordinateElement_Line,

            /// <summary>
            /// 主坐标系元素
            /// </summary>
            CRDElement_Main,

            /// <summary>
            /// 子坐标系元素
            /// </summary>
            CRDElement_Sub,

            /// <summary>
            /// 模板
            /// </summary>
            TemplateElement,

            /// <summary>
            /// 模板区域
            /// </summary>
            TemplateTool,
            /// <summary>
            /// 两线中线
            /// </summary>
            AssistElementLine_Alg_2Line,

            /// <summary>
            ///形状公差- 圆度
            /// </summary>
            ToleranceForm_Circularity,

            /// <summary>
            ///形状公差- 直线度
            /// </summary>
            ToleranceForm_Straightness,


            /// <summary>
            ///位置公差-平行度
            /// </summary>
            TolerancePosition_Parallelism,

            /// <summary>
            ///位置公差-垂直度
            /// </summary>
            TolerancePosition_Perpendicularity,

            /// <summary>
            ///位置公差-倾斜度
            /// </summary>
            TolerancePosition_Gradient,

            /// <summary>
            /// 位置公差-同心度
            /// </summary>
            TolerancePosition_Concentricity,


            /// <summary>
            /// 尺寸测量-圆弧夹角
            /// </summary>
            SizeElement_ANG_Arc,

            /// <summary>
            /// 尺寸测量-圆弧弧长
            /// </summary>
            SizeElement_Lenth_Arc
        }

        /// <summary>
        /// 测量元素算法类型
        /// </summary>
        public enum MeasureElementAlgType
        {
            None = 0,
            /// <summary>
            /// 坐标系-点选两点
            /// </summary>
            CRD_Alg_2Point,
            /// <summary>
            /// 坐标系-点选两圆心
            /// </summary>
            CRD_Alg_2Circle,

            /// <summary>
            /// 坐标系-线选
            /// </summary>
            CRD_Alg_Line,

            /// <summary>
            /// 坐标系-智能点选
            /// </summary>
            CRD_Alg_Point,


            /// <summary>
            /// 子坐标系-点参考
            /// </summary>
            CRD_SubCRD_Alg_Point,


            /// <summary>
            /// 基本元素-点-点选圆心
            /// </summary>
            BaseElementPoint_Alg_Circle,

            /// <summary>
            /// 基本元素-点-点选基岛中心
            /// </summary>
            BaseElementPoint_Alg_JiDao,

            /// <summary>
            /// 基本元素-点-点选双边槽孔
            /// </summary>
            BaseElementPoint_Alg_CaoKong,

            /// <summary>
            /// 基本元素-点-点选但边槽孔
            /// </summary>
            BaseElementPoint_Alg_SingleCaoKong,

            /// <summary>
            /// 基本元素-点-屏幕取点
            /// </summary>
            BaseElementPoint_Alg_Screen,
            /// <summary>
            /// 划线取点
            /// </summary>
            BaseElementPoint_Alg_Line,
            /// <summary>
            /// 基本元素-点-框选半圆圆心
            /// </summary>
            BaseElementPoint_Alg_SimeCircle,

            /// <summary>
            /// 基本元素-线-框选直线
            /// </summary>
            BaseElementLine_Alg_Line,

            /// <summary>
            /// 基本元素-线-框选 2019-10-08
            /// </summary>
            BaseElementLine_Alg_RectList,



            /// <summary>
            /// 基本元素-线-框选短直线
            /// </summary>
            BaseElementLine_Alg_ShortLine,



            /// <summary>
            /// 基本元素-线-框选中线
            /// </summary>
            BaseElementLine_Alg_MidLine,

            /// <summary>
            /// 基本元素-线-框选多直线
            /// </summary>
            BaseElementLine_Alg_MultiLines,

            /// <summary>
            /// 基本元素-线-框选多中线
            /// </summary>
            BaseElementLine_Alg_MultiMidLines,


            /// <summary>
            /// 基本元素-线-框选轮廓直线
            /// </summary>
            BaseElementLine_Alg_OutLine,

            /// <summary>
            /// 基本元素-圆-智能点选圆
            /// </summary>
            BaseElementCircle_Alg_Point,

            /// <summary>
            /// 基本元素-圆-框选选圆
            /// </summary>
            BaseElementCircle_Alg_Rect,

            /// <summary>
            /// 尺寸测量-点点距离-点选两点距离
            /// </summary>
            SizeElementDIST_PP_Alg_2Point,
            /// <summary>
            /// 尺寸测量-点点距离-4框
            /// </summary>
            SizeElementDIST_PP_Alg_2Point_4Rect,
            /// <summary>
            /// 尺寸测量-点点距离-点选两圆距离
            /// </summary>
            SizeElementDIST_PP_Alg_2Circle,

            /// <summary>
            /// 尺寸测量-点点距离-智能点选两圆距离
            /// </summary>
            SizeElementDIST_PP_Alg_2CircleIntiligent,

            /// <summary>
            /// 尺寸测量-多点距离
            /// </summary>
            SizeElementDISTs_PPs_Alg,

            /// <summary>
            /// 尺寸测量-点线距离-点选点线距离
            /// </summary>
            SizeElementDIST_PL_Alg_Point,

            /// <summary>
            /// 尺寸测量-线线距离-点选两线距离
            /// </summary>
            SizeElementDIST_LL_Alg_2Line,

            /// <summary>
            /// 尺寸测量-线线距离-框选线线距离
            /// </summary>
            SizeElementDIST_LL_Alg_Rect,




            /// <summary>
            /// 尺寸测量-多线距离
            /// </summary>
            SizeElementDISTs_LLs_Alg,

            /// <summary>
            /// 尺寸测量-线线角度-点选两线角度
            /// </summary>
            SizeElementANG_LL_Alg_2Line,

            /// <summary>
            /// 尺寸测量-线线角度-框选线线角度
            /// </summary>
            SizeElementANG_LL_Alg_Rect,

            /// <summary>
            /// 尺寸测量-直径/半径-点选圆半径
            /// </summary>
            SizeElementRID_DIA_CA_Alg_Radius,

            /// <summary>
            /// 尺寸测量-直径/半径-点选圆直径
            /// </summary>
            SizeElementRID_DIA_CA_Alg_Diameter,

            /// <summary>
            /// 尺寸测量-直径/半径-智能点选半径
            /// </summary>
            SizeElementRID_DIA_CA_Alg_Point_R,

            /// <summary>
            /// 尺寸测量-直径/半径-智能点选直径
            /// </summary>
            SizeElementRID_DIA_CA_Alg_Point_D,

            /// <summary>
            /// 尺寸测量-半径-点选弧半径
            /// </summary>
            SizeElementRID_ARC_Alg_Point,
            /// <summary>
            /// 尺寸测量-弧长-点选弧长
            /// </summary>
            SizeElementLenth_ARC_Alg_Point,
            /// <summary>
            /// 坐标测量-点坐标-点选点坐标
            /// </summary>
            CoordinateElementPoint_Alg_Point,

            /// <summary>
            /// 坐标测量-点坐标-智能点选圆心坐标
            /// </summary>
            CoordinateElementPoint_Alg_Circle,

            /// <summary>
            /// 坐标测量-点坐标-智能点选基岛中心坐标
            /// </summary>
            CoordinateElementPoint_Alg_JiDao,


            /// <summary>
            /// 坐标测量-点坐标-智能点选单边槽孔坐标
            /// </summary>
            CoordinateElementPoint_Alg_SingleCaoKong,


            /// <summary>
            /// 坐标测量-点坐标-点选弧心坐标
            /// </summary>
            CoordinateElementPoint_Alg_ArcCenterPoint,

            /// <summary>
            /// 坐标测量-直线坐标-点选直线坐标
            /// </summary>
            CoordinateElementLine_Alg_Line,

            /// <summary>
            /// 坐标测量-直线坐标-框选直线坐标
            /// </summary>
            CoordinateElementLine_Alg_Rect,

            /// <summary>
            /// 模板
            /// </summary>
            TemplateElement,

            /// <summary>
            /// 模板区域
            /// </summary>
            TemplateTool,

            TemplateTool_Circle,

            /// <summary>
            /// 模板(创建)
            /// </summary>
            TemplateCreate,

            /// <summary>
            /// 模板(匹配)
            /// </summary>
            TemplateFind,

            /// <summary>
            /// 辅助元素-点-弧线交点
            /// </summary>
            AssistElementPoint_Alg_ArcLine,


            /// <summary>
            /// 辅助元素-点-弧线切点 线弧切点 2019-10-17 ludc
            /// </summary>
            AssistElementPoint_Alg_ArcLine_Tangent,


            /// <summary>
            /// 辅助元素-点-两线交点
            /// </summary>
            AssistElementPoint_Alg_2Line,

            /// <summary>
            /// 辅助元素-点-四边拟合矩形中心
            /// </summary>
            AssistElementPoint_Alg_4Line,


            /// <summary>
            /// 辅助元素-点-多点拟合圆心
            /// </summary>
            AssistElementPoint_Alg_PointsFitToCircleCenterPoint,


            /// <summary>
            /// 辅助元素-点-两点中点
            /// </summary>
            AssistElementPoint_Alg_2Point,

            /// <summary>
            /// 辅助元素 线中点
            /// </summary>
            AssistElement_Alg_LineMidpoint,

            /// <summary>
            /// 辅助元素 线的起点终点
            /// </summary>
            AssistElement_Alg_LineStartingPointEndPoint,

            /// <summary>
            /// 辅助元素-线-两点连线
            /// </summary>
            AssistElementLine_Alg_2Point,

            /// <summary>
            /// 辅助元素-线-线线
            /// </summary>
            AssistElementLine_Alg_Lines,

            /// <summary>
            /// 辅助元素-弧-弧弧
            /// </summary>
            AssistElementArc_Alg_Arcs,
            /// <summary>
            /// 辅助元素-两线中线 czf 20150922
            /// </summary>
            AssistElementLine_Alg_2Line,

            /// <summary>
            /// 获取灰度值
            /// </summary>
            Rectangle2GrayVal,



            /// <summary>
            /// 基本元素-边界点-线-框
            /// </summary>
            BaseElementPoint_Alg_LineRect,

            /// <summary>
            /// 框选-管脚中心点
            /// </summary>
            BaseElementPoint_Alg_RectPinCenterPoint,


            /// <summary>
            /// 框选-区域极值点
            /// </summary>
            BaseElementPoint_Alg_RectExtremumPoint,

            /// <summary>
            /// 形位公差-圆度
            /// </summary>
            ToleranceForm_Circularity_Alg_Circle,

            /// <summary>
            /// 形位公差-直线度
            /// </summary>
            ToleranceForm_Straightness_Alg_Line,



            /// <summary>
            /// 位置公差-平行度
            /// </summary>
            TolerancePosition_Parallelism_Alg,


            /// <summary>
            /// 位置公差-垂直度
            /// </summary>
            TolerancePosition_Perpendicularity_Alg,

            /// <summary>
            /// 位置公差-倾斜度
            /// </summary>
            TolerancePosition_Gradient_Alg,


            /// <summary>
            /// 位置公差-同心度
            /// </summary>
            TolerancePosition_ConCentricity_Alg,


            /// <summary>
            /// 基本元素-弧-框选弧
            /// </summary>
            BaseElementArc_Alg_Rect,


            /// <summary>
            /// 基本元素-弧-框选弧 2019-09-29
            /// </summary>
            BaseElementArc_Alg_RectList,





            /// <summary>
            /// 基本元素-弧-框选圆弧
            /// </summary>
            BaseElementCircleArc_Alg_Rect,
            /// <summary>
            /// 众威 2框选基准线
            /// </summary>
            TwoRectangleToBaseLine,

            /// <summary>
            /// 众威  尺寸测量-线线距离-框选2线距离
            /// </summary>
            SizeElementDIST_2L_Alg_4Rect,


            /// <summary>
            /// 众威  尺寸测量-直径-框出直径
            /// </summary>
            SizeElementRID_DIA_Alg_Rect,

            /// <summary>
            /// 尺寸测量-圆弧角度-点选圆弧夹角
            /// </summary>
            SizeElementANG_Arc_Alg_Point,

            /// <summary>
            /// 基本元素-圆-点选两圆（圆环）
            /// </summary>
            BaseElementCircle_Alg_Ring,
            /// <summary>
            /// 基本元素-圆-圆选圆
            /// </summary>
            BaseElementCircle_Alg_Circle


        }

        /// <summary>
        /// 工具类型
        /// </summary>
        public enum ToolType
        {
            Pointer,

            /// <summary>
            /// 灰度值
            /// </summary>
            Rectangle2GrayVal,


            RectangleToLine,




            /// <summary>
            /// 框选短线
            /// </summary>
            RectangleToShortLine,


            RectangleToMidLine,
            /// <summary>
            /// 框选多直线
            /// </summary>
            RectangleToMultiLines,
            /// <summary>
            /// 框选多中线
            /// </summary>
            RectangleToMultiMidLines,
            /// <summary>
            /// 框选轮廓线
            /// </summary>
            RectangleToOutLine,
            /// <summary>
            /// 框选半圆圆心
            /// </summary>
            RectangleToSemiCircleCenterPoint,



            /// <summary>
            /// 点选圆
            /// </summary>
            CrossToCircle,
            /// <summary>
            /// 框选圆
            /// </summary>
            RectToCircle,
            CrossToPoint,
            /// <summary>
            /// 点选基岛中心
            /// </summary>
            CrossToJiDaoPoint,
            /// <summary>
            /// 点选双边槽孔心
            /// </summary>
            CrossToCaoKong,
            /// <summary>
            /// 点选单边槽孔心
            /// </summary>
            CrossToSingleCaoKong,
            CrossToScreenPoint,
            TwoCircleToCRD,
            TwoPointToCRD,
            /// <summary>
            /// 点选点坐标
            /// </summary>
            LabelPointToCRD,
            /// <summary>
            /// 智能点选圆心坐标
            /// </summary>
            LabelSmartCircleCenterToCRD,
            /// <summary>
            /// 智能点选基岛中心坐标
            /// </summary>
            LabelSmartJiDaoCenterToCRD,
            /// <summary>
            /// 智能点选单边槽孔坐标
            /// </summary>
            LabelSmartSingleCaoKongToCRD,
            /// <summary>
            /// 点选直线坐标
            /// </summary>
            LabelLineToCRD,

            LabelTwoPointDistance,
            LabelTwoCircleDistance,
            /// <summary>
            /// 智能点选两圆圆心
            /// </summary>
            LabelSmartTwoCircleDistance,
            LabelTwoLineDistance,
            //框选多线距离
            LabelRectangleToLineDistance,

            LabelCircleToRadius,
            LabelCircleToDiameter,

            LabelSmartCircleToRadius,
            LabelSmartCircleToDiameter,


            /// <summary>
            /// 标注 点 线距离
            /// </summary>
            LabelPointLineDistance,
            /// <summary>
            /// 弧半径
            /// </summary>
            LabelArcToRadius,
            /// <summary>
            /// 点选弧长
            /// </summary>
            LabelArcLenth,

            /// <summary>
            /// 点参考 子坐标
            /// </summary>
            PointToSubCRD,

            /// <summary>
            /// 模板
            /// </summary>
            Template,

            /// <summary>
            /// 模板区域
            /// </summary>
            TemplateTool,
            /// <summary>
            /// 模板区域（圆）
            /// </summary>
            TemplateTool_Circle,
            /// <summary>
            /// 两线交点
            /// </summary>
            TwoLineToPoint,
            /// <summary>
            /// 弧线交点
            /// </summary>
            ArcLineToPoint,

            /// <summary>
            /// 弧线切点 2019-10-17 ludc
            /// </summary>
            ArcLineToPoint_Tangent,


            /// <summary>
            /// 四边拟合矩形中心
            /// </summary>
            FourLineToPoint,

            /// <summary>
            /// 多点拟合圆心点
            /// </summary>
            PointsFitToCircleCenterPoint,

            /// <summary>
            /// 两点连线
            /// </summary>
            TwoPointToLine,

            /// <summary>
            /// 两点中点
            /// </summary>
            TwoPointToPoint,

            /// <summary>
            /// 线中点
            /// </summary>
            LineMidpoint,

            /// <summary>
            /// 线的起点终点
            /// </summary>
            LineStartingPointEndPoint,

            /// <summary>
            /// 线线 拟合
            /// </summary>
            LinesToLine,
            /// <summary>
            /// 弧弧拟合
            /// </summary>
            ArcsToArc,
            /// <summary>
            /// 两线中线 
            /// </summary>
            TwoLineToLine,

            /// <summary>
            /// 阵列 框选尺寸元素
            /// </summary>
            ArrayPointer,

            /// <summary>
            /// 阵列 框选基准元素
            /// </summary>
            ArrayBasePointer,

            /// <summary>
            /// 阵列 设置元素(版/组)
            /// </summary>
            ArraySetBanZu,


            /// <summary>
            /// 框选-隐藏元素
            /// </summary>
            KuangXuanSetElementHidden,

            /// <summary>
            /// 划线取点
            /// </summary>
            ToolLineToPoint,

            /// <summary>
            /// 线 -框 -边界点
            /// </summary>
            ToolLineRectangleToPoint,

            /// <summary>
            /// 框选 -管脚中心点
            /// </summary>
            ToolRectPinCenterPoint,


            /// <summary>
            /// 框选 -区域极值点
            /// </summary>
            ToolRectExtremumPoint,

            /// <summary>
            /// 形位公差-圆度
            /// </summary>
            LabelCircularity,

            /// <summary>
            /// 形位公差-直线度
            /// </summary>
            LabelStraightness,

            /// <summary>
            /// 平行度
            /// </summary>
            LabelParallelism,


            /// <summary>
            ///垂直度
            /// </summary>
            LabelPerpendicularity,


            /// <summary>
            ///垂直度
            /// </summary>
            LabelGradient,

            /// <summary>
            /// 同心度
            /// </summary>
            LabelConcentricity,


            /// <summary>
            ///线线 夹角
            /// </summary>
            Label2LineAngle,

            /// <summary>
            /// 框选弧
            /// </summary>
            RectToArc,


            /// <summary>
            /// 多框选弧
            /// </summary>
            RectListToArc,


            // RectListToLine,

            /// <summary>
            /// 多框选线
            /// </summary>
            RectangleListToLine,


            /// <summary>
            /// 框选圆弧
            /// </summary>
            RectToCircleArc,



            /// <summary>
            /// 点选弧心坐标
            /// </summary>
            LabelArcPointCenterToCRD,
            /// <summary>
            /// 线选坐标系
            /// </summary>
            LineToCRD,


            /// <summary>
            /// 众威 4框出两线距离
            /// </summary>
            Label4RectangleTo2LineDistance,

            /// <summary>
            /// 众威 框出直径
            /// </summary>
            LabelRectangleToDiameter,

            /// <summary>
            ///众威 2框出基准线
            /// </summary>
            TwoRectangleToBaseLine,

            /// <summary>
            ///圆弧 夹角
            /// </summary>
            Label2ArcAngle,

            /// <summary>
            /// 点选圆环
            /// </summary>
            PointToRing,
            /// <summary>
            /// 圆选圆
            /// </summary>
            CircleToCircle,
            /// <summary>
            /// 4框出2点距离
            /// </summary>
            Label4RectangleTo2PointDistance

        };
        /// <summary>
        /// 所有模块以及子模块类型（用以操作树文字配对）
        /// </summary>
        public enum AllModuleType
        {
            None = 0,

            /// <summary>
            /// 图像获取-运动参数
            /// </summary>
            ImageGrab_Move,

            /// <summary>
            /// 图像获取-光源参数
            /// </summary>
            ImageGrab_Light,

            /// <summary>
            /// 图像获取-相机参数
            /// </summary>
            ImageGrab_Camera,

            /// <summary>
            /// 图像获取-图像采集
            /// </summary>
            ImageGrab_Grab,







            /// <summary>
            /// 模板设定-检测区域
            /// </summary>
            TemplateSetting_ROI,
            TemplateSetting_ROI_Circle,
            /// <summary>
            /// 模板设定-模板设置
            /// </summary>
            TemplateSetting_Creat,






            /// <summary>
            /// 坐标系-点选两圆心
            /// </summary>
            CRD_MainCRD_Alg_2Circle,

            /// <summary>
            /// 坐标系-框选两直线
            /// </summary>
            CRD_MainCRD_Alg_2Line,

            /// <summary>
            /// 坐标系-智能点选
            /// </summary>
            CRD_MainCRD_Alg_Point,
            /// <summary>
            /// 坐标系-点选两点
            /// </summary>
            CRD_MainCRD_Alg_2Point,

            /// <summary>
            /// 主坐标系-线选
            /// </summary>
            CRD_MainCRD_Alg_line,

            /// <summary>
            ///子坐标 点参考法
            /// </summary>
            CRD_SubCRD_Alg_Point,






            /// <summary>
            /// 基本元素-点-点选圆心
            /// </summary>
            BaseElementPoint_Alg_Circle,

            /// <summary>
            /// 基本元素-点-点选基岛中心
            /// </summary>
            BaseElementPoint_Alg_JiDao,

            /// <summary>
            /// 基本元素-点-点选双边槽孔
            /// </summary>
            BaseElementPoint_Alg_CaoKong,

            /// <summary>
            /// 基本元素-点-点选单边槽孔
            /// </summary>
            BaseElementPoint_Alg_SingleCaoKong,

            /// <summary>
            /// 基本元素-点-屏幕取点
            /// </summary>
            BaseElementPoint_Alg_Screen,

            /// <summary>
            /// 基本元素-点-划线取点
            /// </summary>
            BaseElementPoint_Alg_Line,

            /// <summary>
            /// 基本元素-点-框选半圆圆心
            /// </summary>
            BaseElementPoint_Alg_SimeCircle,








            /// <summary>
            /// 基本元素-线-框选直线
            /// </summary>
            BaseElementLine_Alg_Line,


            /// <summary>
            /// 多框选线 2019-10-08 ludc 
            /// </summary>
            BaseElementLine_Alg_RectList,



            /// <summary>
            /// 基本元素-线-框选短线
            /// </summary>
            BaseElementLine_Alg_ShortLine,

            /// <summary>
            /// 基本元素-线-框选中线
            /// </summary>
            BaseElementLine_Alg_MidLine,

            /// <summary>
            /// 基本元素-线-框选多直线
            /// </summary>
            BaseElementLine_Alg_MultiLines,

            /// <summary>
            /// 基本元素-线-框选多中线
            /// </summary>
            BaseElementLine_Alg_MultiMidLines,

            /// <summary>
            /// 基本元素-线-框选轮廓直线
            /// </summary>
            BaseElementLine_Alg_OutLine,

            /// <summary>
            /// 基本元素-圆-点选圆
            /// </summary>
            BaseElementCircle_Alg_Point,

            /// <summary>
            /// 基本元素-圆-框选圆
            /// </summary>
            BaseElementCircle_Alg_Rect,


            /// <summary>
            /// 尺寸测量-点点距离-点选两点距离
            /// </summary>
            SizeElementDIST_PP_Alg_2Point,
            // <summary>
            /// 尺寸测量-点点距离-点选两点距离
            /// </summary>
            SizeElementDIST_PP_Alg_2Point_4Rect,

            /// <summary>
            /// 尺寸测量-点点距离-点选两圆距离
            /// </summary>
            SizeElementDIST_PP_Alg_2Circle,

            /// <summary>
            /// 尺寸测量-点点距离-智能点选两圆距离
            /// </summary>
            SizeElementDIST_PP_Alg_2CircleIntiligent,

            /// <summary>
            /// 尺寸测量-多点距离
            /// </summary>
            SizeElementDISTs_PPs_Alg,

            /// <summary>
            /// 尺寸测量-点线距离-点选点线距离
            /// </summary>
            SizeElementDIST_PL_Alg_Point,

            /// <summary>
            /// 尺寸测量-线线距离-点选两线距离
            /// </summary>
            SizeElementDIST_LL_Alg_2Line,

            /// <summary>
            /// 尺寸测量-线线距离-框选线线距离
            /// </summary>
            SizeElementDIST_LL_Alg_Rect,

            /// <summary>
            /// 尺寸测量-多线距离
            /// </summary>
            SizeElementDISTs_LLs_Alg,

            /// <summary>
            /// 尺寸测量-线线角度-点选两线角度
            /// </summary>
            SizeElementANG_LL_Alg_2Line,

            /// <summary>
            /// 尺寸测量-线线角度-框选线线角度
            /// </summary>
            SizeElementANG_LL_Alg_Rect,

            /// <summary>
            /// 尺寸测量-直径/半径-点选圆半径
            /// </summary>
            SizeElementRID_DIA_CA_Alg_Radius,

            /// <summary>
            /// 尺寸测量-直径/半径-点选圆直径
            /// </summary>
            SizeElementRID_DIA_CA_Alg_Diameter,

            /// <summary>
            /// 尺寸测量-直径/半径-智能点选半径
            /// </summary>
            SizeElementRID_DIA_CA_Alg_Point_R,

            /// <summary>
            /// 尺寸测量-直径/半径-智能点选直径
            /// </summary>
            SizeElementRID_DIA_CA_Alg_Point_D,

            /// <summary>
            /// 尺寸测量-点选弧半径
            /// </summary>
            SizeElementRID_DIA_CA_Alg_Arc_R,



            /// <summary>
            /// 坐标测量-点坐标-点选点坐标
            /// </summary>
            CoordinateElementPoint_Alg_Point,

            /// <summary>
            /// 坐标测量-点坐标-智能点选圆心坐标
            /// </summary>
            CoordinateElementPoint_Alg_Circle,

            /// <summary>
            /// 坐标测量-点坐标-智能点选基岛中心坐标
            /// </summary>
            CoordinateElementPoint_Alg_JiDao,

            /// <summary>
            /// 坐标测量-点坐标-智能点选单边槽孔坐标
            /// </summary>
            CoordinateElementPoint_Alg_SingleCaoKong,

            /// <summary>
            /// 坐标测量-点坐标-弧心坐标
            /// </summary>
            CoordinateElementPoint_Alg_ArcCenterPoint,

            /// <summary>
            /// 坐标测量-直线坐标-点选直线坐标
            /// </summary>
            CoordinateElementLine_Alg_Line,

            /// <summary>
            /// 坐标测量-直线坐标-框选直线坐标
            /// </summary>
            CoordinateElementLine_Alg_Rect,

            /// <summary>
            /// 辅助元素-点-弧线交点
            /// </summary>
            AssistElementPoint_Alg_ArcLine,


            /// <summary>
            /// 辅助元素-点- 线弧切点 2019-10-17 ludc
            /// </summary>
            AssistElementPoint_Alg_ArcLine_Tangent,




            /// <summary>
            /// 辅助元素-点-两线交点
            /// </summary>
            AssistElementPoint_Alg_2Line,

            /// <summary>
            /// 辅助元素-点-四边拟合矩形中心
            /// </summary>
            AssistElementPoint_Alg_4Line,

            /// <summary>
            /// 辅助元素-点-多点拟合圆心
            /// </summary>
            AssistElementPoint_Alg_PointsFitToCircleCenterPoint,


            /// <summary>
            /// 辅助元素-点-两点中点
            /// </summary>
            AssistElementPoint_Alg_2Point,

            /// <summary>
            /// 辅助元素-线-两点连线
            /// </summary>
            AssistElementLine_Alg_2Point,

            /// <summary>
            /// 辅助元素 线中点
            /// </summary>
            AssistElement_Alg_LineMidpoint,

            /// <summary>
            /// 辅助元素 线的起点终点
            /// </summary>
            AssistElement_Alg_LineStartingPointEndPoint,

            /// <summary>
            /// 辅助元素-线-线线
            /// </summary>
            AssistElementLine_Alg_Lines,
            /// <summary>
            /// 辅助元素-弧-弧弧
            /// </summary>
            AssistElementArc_Alg_Arcs,
            /// <summary>
            /// 辅助元素-两线中线
            /// </summary>
            AssistElementLine_Alg_2Line,

            /// <summary>
            /// 获取灰度值
            /// </summary>
            Rectangle2GrayVal,


            /// <summary>
            /// 基本元素-点-线-框边界点
            /// </summary>
            BaseElementPoint_Alg_LineRect,

            /// <summary>
            /// 框选-管脚中心点
            /// </summary>
            BaseElementPoint_Alg_RectPinCenterPoint,

            /// <summary>
            /// 框选-区域极值点
            /// </summary>
            BaseElementPoint_Alg_RectExtremumPoint,

            /// <summary>
            ///形状公差-圆度
            /// </summary>
            ToleranceForm_Circularity_Alg_Circle,

            /// <summary>
            /// 形状公差-直线度
            /// </summary>
            ToleranceForm_Straightness_Alg_Line,


            /// <summary>
            /// 位置公差-平行度
            /// </summary>
            TolerancePosition_Parallelism_Alg,

            /// <summary>
            /// 位置公差-垂直度
            /// </summary>
            TolerancePostion_Perpendicularity_Alg,

            /// <summary>
            /// 位置公差-倾斜度
            /// </summary>
            TolerancePostion_Gradient_Alg,

            /// <summary>
            /// 位置公差-同心度
            /// </summary>
            TolerancePosition_ConCentricity_Alg,

            /// <summary>
            /// 框选弧
            /// </summary>
            BaseElementArc_Alg_Rect,

            /// <summary>
            /// 多框选弧 2019-09-29 ludc 
            /// </summary>
            BaseElementArc_Alg_RectList,



            /// <summary>
            /// 框选圆弧
            /// </summary>
            BaseElementCircleArc_Alg_Rect,
            /// <summary>
            /// 众威 两框出基准线
            /// </summary>
            TwoRectangleToBaseLine,

            /// <summary>
            /// 众威 尺寸测量-框出直径
            /// </summary>
            SizeElementRID_DIA_Alg_Rect_D,

            /// <summary>
            /// 众威 尺寸测量-线线距离-框选2线距离
            /// </summary>
            SizeElementDIST_2L_Alg_4Rect,

            /// <summary>
            /// 尺寸测量-圆弧角度-点选圆弧夹角
            /// </summary>
            SizeElementANG_Arc_Alg_Point,
            /// <summary>
            /// 基本元素-圆-点选两圆（圆环）
            /// </summary>
            BaseElementCircle_Alg_Ring,
            /// <summary>
            /// 尺寸测量-弧长-点选弧长
            /// </summary>
            SizeElementLenth_ARC_Alg_Point,
            /// <summary>
            /// 基本元素-圆-圆选圆
            /// </summary>
            BaseElementCircle_Alg_Circle

        }

        /// <summary>
        /// 消息类型
        /// </summary>
        public enum MessageType
        {
            /// <summary>
            /// 询问
            /// </summary>
            Question,

            /// <summary>
            /// 提示
            /// </summary>
            Tips,

            /// <summary>
            /// 异常
            /// </summary>
            Error
        }

        /// <summary>
        /// 运行类型（操作树上的操作类型）
        /// </summary>
        public enum RunType
        {
            None = 0,

            EditRun,

            ArrayRun,

            TestRun,

            AutoRun
        }


        /// <summary>
        /// 阵列元素  所属 （版：不阵列，组：X方向阵列）
        /// </summary>
        public enum ArraySetBanZu
        {

            None,
            /// <summary>
            /// 整版 (不阵列)
            /// </summary>
            Ban,
            /// <summary>
            /// 单组(X方向阵列)
            /// </summary>
            Zu2X
        }


        public enum ShowImageType
        {
            /// <summary>
            /// 实时图像
            /// </summary>
            Continus,
            /// <summary>
            /// 静态图像
            /// </summary>
            Single
        }
    }
}
