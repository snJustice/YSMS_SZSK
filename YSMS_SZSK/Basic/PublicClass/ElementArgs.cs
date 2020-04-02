using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YSMS_SZSK.Basic.PublicClass
{


    public enum MessageSource
    {
        /// <summary>
        /// 右侧功能按钮选择传递
        /// </summary>
        FromFuncChoose,

        /// <summary>
        /// 操作数传递
        /// </summary>
        FromOperate
    }

    /// <summary>
    /// 操作动作 [创建、更新、读取、删除]
    /// </summary>
    public enum EnumCURD
    {
        /// <summary>
        /// 创建C
        /// </summary>
        Create,
        /// <summary>
        /// 更新U
        /// </summary>
        Update,
        /// <summary>
        /// 读取R
        /// </summary>
        Read,

        /// <summary>
        /// 删除D
        /// </summary>
        Delete,

        /// <summary>
        /// 刷新
        /// </summary>
        Refresh

    }

    /// <summary>
    /// 绘图状态
    /// </summary>
    public enum DrawStatusType
    {
        None,
        /// <summary>
        /// 开始
        /// </summary>
        Start,
        /// <summary>
        /// 取消
        /// </summary>
        Cancel,
        /// <summary>
        /// 结束
        /// </summary>
        Finished
    }

    /// <summary>
    /// 绘图结果
    /// </summary>
    public enum DrawResultType
    {
        None,
        /// <summary>
        /// 成功
        /// </summary>
        Suceess,
        /// <summary>
        /// 失败
        /// </summary>
        Fail

    }


    /// <summary>
    ///  绘图委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="ela"></param>
    public delegate void DrawElementEventHandler(ElementArgs e);


    /// <summary>
    ///  绘图出 多元素
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="ela"></param>
    public delegate void DrawElementListEventHandler(ElementListArgs e);

    /// <summary>
    /// 元素列表属性
    /// </summary>
    public class ElementListArgs : EventArgs
    {
        public ElementListArgs()
        {
            this.CRUD = EnumCURD.Create;
            this.DrawStatusEnum = DrawStatusType.Finished;
            this.DrawResultEnum = DrawResultType.Suceess;
            this.MeasureElementList = new List<MeasureElement>();

        }
        public ElementListArgs(EnumCURD CRUD, List<MeasureElement> _measureElementList)
        {
            this.CRUD = CRUD;
            this.MeasureElementList = _measureElementList;
        }
        /// 创建 读取 更新 删除
        /// </summary>
        public EnumCURD CRUD { get; set; }

        /// <summary>
        /// 绘图状态
        /// </summary>
        public DrawStatusType DrawStatusEnum { get; set; }

        /// <summary>
        /// 绘图结果
        /// </summary>
        public DrawResultType DrawResultEnum { get; set; }

        /// <summary>
        /// 测量元素
        /// </summary>
        public List<MeasureElement> MeasureElementList { get; set; }

    }


    /// <summary>
    /// 自定义控件委托
    /// </summary>
    /// <param name="e"></param>
    public delegate void EleMyUserControlEventHandler(ElementArgs e);
    public delegate void UelMyUserControlEventHandler(UnElementArgs e);

    /// <summary>
    /// 操作树委托
    /// </summary>
    /// <param name="e"></param>
    public delegate void UcOperateStepEventHandler(OperateArgs e);


    /// <summary>
    /// 元素属性
    /// </summary>
    public class ElementArgs : EventArgs
    {
        public ElementArgs()
        {
        }
        public ElementArgs(EnumCURD CRUD, MeasureElement MeasureElement)
        {
            this.CRUD = CRUD;
            this.MeasureElement = MeasureElement;
        }
        /// 创建 读取 更新 删除
        /// </summary>
        public EnumCURD CRUD { get; set; }

        /// <summary>
        /// 绘图状态
        /// </summary>
        public DrawStatusType DrawStatusEnum { get; set; }

        /// <summary>
        /// 绘图结果
        /// </summary>
        public DrawResultType DrawResultEnum { get; set; }

        /// <summary>
        /// 测量元素
        /// </summary>
        public MeasureElement MeasureElement { get; set; }

    }

    /// <summary>
    /// 操作步骤属性
    /// </summary>
    public class OperateArgs : EventArgs
    {
        public OperateArgs(OperateInfo OperateInfo)
        {
            //this.CRUD = EnumCURD;
            this.OperateInfo = OperateInfo;
        }
        /// <summary>
        /// 创建 读取 更新 删除
        /// </summary>
        public EnumCURD CRUD { get; set; }
        /// <summary>
        /// 操作对象
        /// </summary>
        public OperateInfo OperateInfo { get; set; }
    }
    /// <summary>
    /// 非元素属性(光源设置)
    /// </summary>
    public class UnElementArgs : EventArgs
    {
        public UnElementArgs(EnumCURD EnumCURD, object setOject)
        {
            this.CRUD = EnumCURD;
            this.setOject = setOject;
        }
        public EnumCURD CRUD { get; set; }
        public object setOject { get; set; }

    }
}
