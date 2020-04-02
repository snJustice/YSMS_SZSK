using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YSMS_SZSK.CustomerGlobal;

namespace YSMS_SZSK.Basic.PublicClass
{
    public class OperateInfo
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

        private string m_operateName;
        /// <summary>
        /// 操作名称
        /// </summary>
        public string OperateName
        {
            get { return m_operateName; }
            set { m_operateName = value; }
        }

        private PublicEnum.UC_ModuleType m_moduleType;
        /// <summary>
        /// 自定义控件类型
        /// </summary>
        public PublicEnum.UC_ModuleType ModuleType
        {
            get { return m_moduleType; }
            set { m_moduleType = value; }
        }

        private PublicEnum.UC_OperateType m_paraType;
        /// <summary>
        /// 自定义控件参数类型
        /// </summary>
        public PublicEnum.UC_OperateType ParaType
        {
            get { return m_paraType; }
            set { m_paraType = value; }
        }

        private PublicEnum.AllModuleType m_allModuleType;
        /// <summary>
        /// 测量算法类型（用以确定采用哪个方法产生，用作查找操作名称记录用）
        /// </summary>
        public PublicEnum.AllModuleType AllModuleType
        {
            get { return m_allModuleType; }
            set { m_allModuleType = value; }
        }

        private List<int> m_elementIDArray;
        /// <summary>
        /// 元素ID集合
        /// </summary>
        public List<int> ElementIDArray
        {
            get { return m_elementIDArray; }
            set
            {
                if (m_elementIDArray == null)
                {
                    m_elementIDArray = new List<int>();
                }
                m_elementIDArray.Clear();

                foreach (var temp in value)
                {
                    m_elementIDArray.Add(temp);
                }
            }
        }

        /// <summary>
        /// 构造函数（无参数）
        /// </summary>
        public OperateInfo()
        {
            PublicFunction1();
        }

        /// <summary>
        /// 构造函数（有参数）
        /// </summary>
        /// <param name="operateStepNum"></param>
        /// <param name="operateName"></param>
        public OperateInfo(int operateStepNum, string operateName, PublicEnum.UC_ModuleType moduleType, PublicEnum.UC_OperateType paraType)
        {
            this.OperateStepNum = operateStepNum;
            this.OperateName = operateName;
            this.ModuleType = moduleType;
            this.ParaType = paraType;
            this.AllModuleType = PublicEnum.AllModuleType.None;
        }

        /// <summary>
        /// 构造函数（有参数）
        /// </summary>
        /// <param name="operateStepNum"></param>
        /// <param name="operateName"></param>
        public OperateInfo(int operateStepNum, string operateName, PublicEnum.UC_ModuleType moduleType, PublicEnum.UC_OperateType paraType, PublicEnum.AllModuleType measureAlgType)
        {
            this.OperateStepNum = operateStepNum;
            this.OperateName = operateName;
            this.ModuleType = moduleType;
            this.ParaType = paraType;
            this.AllModuleType = measureAlgType;
        }

        /// <summary>
        /// 构造函数（有参数）
        /// </summary>
        /// <param name="operateStepNum"></param>
        /// <param name="operateName"></param>
        /// <param name="elementIDArray"></param>
        public OperateInfo(int operateStepNum, string operateName, PublicEnum.UC_ModuleType moduleType, PublicEnum.UC_OperateType paraType, PublicEnum.AllModuleType measureAlgType, List<int> elementIDArray)
        {
            this.OperateStepNum = operateStepNum;
            this.OperateName = operateName;
            this.ModuleType = moduleType;
            this.ParaType = paraType;
            this.AllModuleType = measureAlgType;
            if (this.ElementIDArray == null)
            {
                this.ElementIDArray = new List<int>();
            }
            this.ElementIDArray.Clear();
            foreach (var temp in elementIDArray)
            {
                this.ElementIDArray.Add(temp);
            }
        }

        /// <summary>
        /// 构造函数（基于实例）
        /// </summary>
        /// <param name="instance"></param>
        public OperateInfo(OperateInfo instance)
        {
            PublicFunction2(instance);
        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        public void OperateInfo_Init()
        {
            PublicFunction1();
        }

        /// <summary>
        /// 拷贝函数
        /// </summary>
        /// <param name="instance"></param>
        public void OperateInfo_Copy(OperateInfo instance)
        {
            PublicFunction2(instance);
        }

        /// <summary>
        /// 公共函数1
        /// </summary>
        public void PublicFunction1()
        {
            this.OperateStepNum = 0;
            this.OperateName = "";
            this.ModuleType = PublicEnum.UC_ModuleType.None;
            this.ParaType = PublicEnum.UC_OperateType.None;
            this.AllModuleType = PublicEnum.AllModuleType.None;
            if (this.ElementIDArray == null)
            {
                this.ElementIDArray = new List<int>();
            }
            else
            {
                this.ElementIDArray.Clear();
            }
        }

        /// <summary>
        /// 公共函数2
        /// </summary>
        /// <param name="instance"></param>
        public void PublicFunction2(OperateInfo instance)
        {
            this.OperateStepNum = instance.OperateStepNum;
            this.OperateName = instance.OperateName;
            this.ModuleType = instance.ModuleType;
            this.ParaType = instance.ParaType;
            this.AllModuleType = instance.AllModuleType;
            if (this.ElementIDArray == null)
            {
                this.ElementIDArray = new List<int>();
            }
            this.ElementIDArray.Clear();
            foreach (var temp in instance.ElementIDArray)
            {
                this.ElementIDArray.Add(temp);
            }
        }



        public override string ToString()
        {
            return "";//nameof(this.OperateFullName());
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!obj.GetType().Equals(this.GetType()))
                return false;
            return equals((OperateInfo)obj);
        }

        private bool equals(OperateInfo obj)
        {
            return this.m_operateStepNum == obj.m_operateStepNum;
        }
        public override int GetHashCode()
        {
            return m_operateStepNum;
        }

        /*
        public string OperateFullName()
        {
            string bz = this.m_operateStepNum.ToString();
            string dz = Global.m_AllModuleType[this.AllModuleType];

            string obj = string.Empty;
            List<int> ids = this.ElementIDArray;
            foreach (var item in ids)
            {
                if (Global.m_Pvb.m_MeasureElementArray.ContainsKey(item))
                    obj += Global.m_Pvb.m_MeasureElementArray[item].DefaultName + ",";
            }
            obj = obj.TrimEnd(',');

            //判断是否有 计算不合理的测量元素
            IEnumerable<MeasureElement> ieMe = from item in Global.m_Pvb.m_MeasureElementArray.Values
                                               where ids.Contains(item.ID) && item.CalculateFlag == false
                                               select item;
            if (ieMe == null || ieMe.Count() == 0)
            {
                return string.Format("（{0}）{1}：{2}", bz, dz, obj);
            }
            else
            {

                return string.Format("x （{0}）{1}：{2}", bz, dz, obj);
            }


        }
        */
    }
}
