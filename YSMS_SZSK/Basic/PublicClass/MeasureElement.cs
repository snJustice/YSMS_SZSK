using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YSMS_SZSK.CustomerGlobal;

namespace YSMS_SZSK.Basic.PublicClass
{
    public class MeasureElement : Element
    {
        private int m_operateStepNum;
        /// <summary>
        /// 操作步骤
        /// </summary>
        public int OperateStepNum
        {
            get { return m_operateStepNum; }
            set { m_operateStepNum = value; }
        }

        private string m_customerName;
        /// <summary>
        /// 元素自定义名称
        /// </summary>
        public string CustomerName
        {
            get { return m_customerName; }
            set { m_customerName = value; }
        }

        private PublicEnum.MeasureElementMainType m_elementMainType;
        /// <summary>
        /// 元素主类型
        /// </summary>
        public PublicEnum.MeasureElementMainType ElementMainType
        {
            get { return m_elementMainType; }
            set { m_elementMainType = value; }
        }

        private PublicEnum.MeasureElementSubType m_elementSubType;
        /// <summary>
        /// 元素子类型
        /// </summary>
        public PublicEnum.MeasureElementSubType ElementSubType
        {
            get { return m_elementSubType; }
            set { m_elementSubType = value; }
        }

        private int m_bindCRDID;
        /// <summary>
        /// 绑定坐标系ID
        /// </summary>
        public int BindCRDID
        {
            get { return m_bindCRDID; }
            set { m_bindCRDID = value; }
        }

        PublicEnum.ToolType toolEnum;
        /// <summary>
        /// 绘图工具
        /// </summary>
        public PublicEnum.ToolType ToolEnum
        {
            get { return toolEnum; }
            set { toolEnum = value; }
        }


        private List<int> m_bindToolIDs;
        /// <summary>
        /// 绑定工具ID集合
        /// </summary>
        public List<int> BindToolIDs
        {
            get { return m_bindToolIDs; }
            set
            {
                if (m_bindToolIDs == null)
                {
                    m_bindToolIDs = new List<int>();
                }

                m_bindToolIDs.Clear();
                foreach (var temp in value)
                {
                    m_bindToolIDs.Add(temp);
                }
            }
        }

        private List<int> m_bindElementIDs;
        /// <summary>
        /// 绑定元素ID集合
        /// </summary>
        public List<int> BindElementIDs
        {
            get { return m_bindElementIDs; }
            set
            {
                if (m_bindElementIDs == null)
                {
                    m_bindElementIDs = new List<int>();
                }

                m_bindElementIDs.Clear();
                foreach (var temp in value)
                {
                    m_bindElementIDs.Add(temp);
                }
            }
        }

        private PublicEnum.MeasureElementAlgType m_algType;
        /// <summary>
        /// 算法类型
        /// </summary>
        public PublicEnum.MeasureElementAlgType AlgType
        {
            get { return m_algType; }
            set { m_algType = value; }
        }
        private AlgParas m_algParas;
        /// <summary>
        /// 算法参数
        /// </summary>
        public AlgParas AlgParas
        {
            get { return m_algParas; }
            set { m_algParas = value; }
        }


        private PublicEnum.AllModuleType m_allModuleTp;
        /// <summary>
        /// all 枚举
        /// </summary>
        public PublicEnum.AllModuleType AllModuleType
        {
            get { return m_allModuleTp; }
            set { m_allModuleTp = value; }
        }


        /// <summary>
        /// 设置 AllModuleType相关联枚举，ToolEnum，AlgType，ElementMainType，ElementSubType
        /// </summary>
        /// <param name="_allModuleType"></param>
        public void setAllModeleEnums(PublicEnum.AllModuleType _allModuleType)
        {

            this.AllModuleType = _allModuleType;

            AllModuleEnumValues allEnum = AllModuleValue.getInstance().getValues(_allModuleType);

            this.AlgType = allEnum.AlgEnum;
            this.ToolEnum = allEnum.ToolEnum;
            this.ElementMainType = allEnum.MainEnum;
            this.ElementSubType = allEnum.SubEnum;
            this.ElementType = PublicEnum.ElementType.MeasureElement;

        }


        private PublicEnum.LabelAsJudgeType m_isJudgeState;
        /// <summary>
        /// 判据启用状态（用以是否选择作为判据的判定）
        /// </summary>
        public PublicEnum.LabelAsJudgeType IsJudgeState
        {
            get { return m_isJudgeState; }
            set { m_isJudgeState = value; }
        }


        private bool m_shuJuShuChu;
        /// <summary>
        /// 是否作为报表输出
        /// </summary>
        public bool ShuJuShuChu
        {
            get { return m_shuJuShuChu; }
            set { m_shuJuShuChu = value; }
        }

        private bool m_calculateFlag;
        /// <summary>
        /// 计算是否正常标志位 true：正常 false：失败
        /// </summary>
        public bool CalculateFlag
        {
            get { return m_calculateFlag; }
            set { m_calculateFlag = value; }
        }


        /// <summary>
        /// 构造函数（无参数）
        /// </summary>
        public MeasureElement()
        {
            this.PublicFunction1();
        }

        /// <summary>
        /// 构造函数（基于实例）
        /// </summary>
        /// <param name="instance"></param>
        public MeasureElement(MeasureElement instance)
        {
            this.PublicFunction2(instance);
        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        public void MeasureElement_Init()
        {
            this.PublicFunction1();
        }

        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
        public virtual MeasureElement Clone()
        {
            MeasureElement measureElement = new MeasureElement();
            return measureElement;
        }


        /// <summary>
        /// 拷贝函数
        /// </summary>
        /// <param name="instance"></param>
        public void MeasureElement_Copy(MeasureElement instance)
        {
            this.PublicFunction2(instance);
        }

        /// <summary>
        /// 公共函数1
        /// </summary>
        public void PublicFunction1()
        {
            this.BasePublicFunction1();
            this.ElementType = PublicEnum.ElementType.MeasureElement;

            this.OperateStepNum = 0;
            this.m_customerName = "";
            this.ElementMainType = PublicEnum.MeasureElementMainType.None;
            this.ElementSubType = PublicEnum.MeasureElementSubType.None;
            this.BindCRDID = 0;

            if (this.BindToolIDs == null)
            {
                this.BindToolIDs = new List<int>();
            }
            else
            {
                this.BindToolIDs.Clear();
            }

            if (this.BindElementIDs == null)
            {
                this.BindElementIDs = new List<int>();
            }
            else
            {
                this.BindElementIDs.Clear();
            }

            this.AlgType = PublicEnum.MeasureElementAlgType.None;
            this.AllModuleType = PublicEnum.AllModuleType.None;
            //this.AlgParas = null;
            if (this.AlgParas == null)
            {
                this.AlgParas = new AlgParas();
            }
            this.IsJudgeState = PublicEnum.LabelAsJudgeType.None;

            this.ShuJuShuChu = false;
            this.CalculateFlag = true;
        }

        /// <summary>
        /// 公共函数2
        /// </summary>
        /// <param name="instance"></param>
        public void PublicFunction2(MeasureElement instance)
        {
            this.OperateStepNum = instance.OperateStepNum;
            this.m_customerName = instance.CustomerName;
            this.ElementMainType = instance.ElementMainType;
            this.ElementSubType = instance.ElementSubType;
            this.BindCRDID = instance.BindCRDID;

            if (this.BindToolIDs == null)
            {
                this.BindToolIDs = new List<int>();
            }

            this.BindToolIDs.Clear();
            foreach (var temp in instance.BindToolIDs)
            {
                this.BindToolIDs.Add(temp);
            }

            if (this.BindElementIDs == null)
            {
                this.BindElementIDs = new List<int>();
            }

            this.BindElementIDs.Clear();
            foreach (var temp in instance.BindElementIDs)
            {
                this.BindElementIDs.Add(temp);
            }
            this.AllModuleType = instance.AllModuleType;
            this.AlgType = instance.AlgType;
            this.AllModuleType = instance.AllModuleType;
            this.AlgParas = instance.AlgParas;
            this.IsJudgeState = instance.IsJudgeState;

            this.ShuJuShuChu = instance.ShuJuShuChu;

            //注意工具 拷贝  否则 删除问出问题
            this.ToolEnum = instance.ToolEnum;

            this.BasePublicFunction2(instance);
            this.CalculateFlag = instance.CalculateFlag;
        }


        public override void Copy(Element instance)
        {
            if (instance.GetType() == typeof(MeasureElement))
            {
                MeasureElement_Copy((MeasureElement)instance);
            }
        }

        public virtual void ClearValues()
        {

        }

        #region "重写 ToString"
        public override string ToString()
        {
            return DefaultName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!obj.GetType().Equals(this.GetType()))
                return false;
            return equals((MeasureElement)obj);
        }

        private bool equals(MeasureElement obj)
        {
            return this.ID == obj.ID;
        }

        public override int GetHashCode()
        {
            return this.ID;
        }
        #endregion

        public virtual DataTable MeaseureElementDetailInfo()
        {
            DataTable dt = new DataTable();

            return dt;
        }

        #region 阵列 使用
        public virtual void addOffXY(double pixelOffX, double pixelOffY, double canvasOffX, double canvasOffY, System.Collections.Generic.Dictionary<int, int> dicMeONID, System.Collections.Generic.Dictionary<int, int> dicToolONID, string prefixName)
        {


        }
        #endregion
    }
}
