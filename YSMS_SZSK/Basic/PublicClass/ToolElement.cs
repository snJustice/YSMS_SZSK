using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YSMS_SZSK.CustomerGlobal;

namespace YSMS_SZSK.Basic.PublicClass
{
    public class ToolElement : Element
    {
        private PublicEnum.ToolElementType m_toolType;
        /// <summary>
        /// 工具元素类型
        /// </summary>
        public PublicEnum.ToolElementType ToolType
        {
            get { return m_toolType; }
            set { m_toolType = value; }
        }

        private PublicEnum.ToolElementApplication m_toolApplication;
        /// <summary>
        /// 工具元素用途
        /// </summary>
        public PublicEnum.ToolElementApplication ToolApplication
        {
            get { return m_toolApplication; }
            set { m_toolApplication = value; }
        }

        /// <summary>
        /// 构造函数（无参数）
        /// </summary>
        public ToolElement()
        {
            this.PublicFunction1();
        }

        /// <summary>
        /// 构造函数（基于实例）
        /// </summary>
        /// <param name="instance"></param>
        public ToolElement(ToolElement instance)
        {
            this.PublicFunction2(instance);
        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        public void ToolElement_Init()
        {
            this.PublicFunction1();
        }

        /// <summary>
        /// 克隆函数
        /// </summary>
        /// <returns></returns>
        public virtual ToolElement Clone()
        {
            ToolElement toolElement = new ToolElement();
            return toolElement;
        }


        /// <summary>
        /// 拷贝函数
        /// </summary>
        /// <param name="instance"></param>
        public void ToolElement_Copy(ToolElement instance)
        {
            this.PublicFunction2(instance);
        }

        /// <summary>
        /// 公共函数1
        /// </summary>
        public void PublicFunction1()
        {
            this.BasePublicFunction1();
            this.ElementType = PublicEnum.ElementType.ToolElement;
            this.ToolType = PublicEnum.ToolElementType.None;
            this.ToolApplication = PublicEnum.ToolElementApplication.None;
            this.IsEditEnable = true;
        }

        /// <summary>
        /// 公共函数2
        /// </summary>
        /// <param name="instance"></param>
        public void PublicFunction2(ToolElement instance)
        {
            this.ToolType = instance.ToolType;
            this.ToolApplication = instance.ToolApplication;
            this.BasePublicFunction2(instance);
        }

        public override void Copy(Element instance)
        {
            if (instance.GetType() == typeof(ToolElement))
            {
                ToolElement_Copy((ToolElement)instance);
            }
        }

        public virtual void BackUp()
        {

        }

    }
}
