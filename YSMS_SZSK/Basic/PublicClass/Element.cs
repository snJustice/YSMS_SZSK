using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using YSMS_SZSK.CustomerGlobal;

namespace YSMS_SZSK.Basic.PublicClass
{
    public class Element
    {
        private int m_iD;
        /// <summary>
        /// 元素ID
        /// </summary>
        public int ID
        {
            get { return m_iD; }
            set { m_iD = value; }
        }

        private string m_defaultName;
        /// <summary>
        /// 元素默认名称
        /// </summary>
        public string DefaultName
        {
            get { return m_defaultName; }
            set { m_defaultName = value; }
        }

        private PublicEnum.ElementType m_elementType;
        /// <summary>
        /// 元素类型（用以区分是测量元素or工具元素）
        /// </summary>
        public PublicEnum.ElementType ElementType
        {
            get { return m_elementType; }
            set { m_elementType = value; }
        }

        private bool m_isEditEnable;
        /// <summary>
        /// 是否可编辑使能
        /// </summary>
        public bool IsEditEnable
        {
            get { return m_isEditEnable; }
            set { m_isEditEnable = value; }
        }

        private bool m_isChooseEnable;
        /// <summary>
        /// 是否选中使能
        /// </summary>
        public bool IsChooseEnable
        {
            get { return m_isChooseEnable; }
            set { m_isChooseEnable = value; }
        }

        private bool m_isChoosed;
        /// <summary>
        /// 是否选中
        /// 最好更改图形的属性，直接改变此属性需要再调用图形的RefreshDrawing，以改变图形状态
        /// </summary>
        public bool IsChoosed
        {
            get { return m_isChoosed; }
            set { m_isChoosed = value; }
        }


        private PublicEnum.ArraySetBanZu m_banZu;
        /// <summary>
        /// 元素的版 /组	
        /// </summary>
        public PublicEnum.ArraySetBanZu BanZu
        {
            get { return m_banZu; }
            set { m_banZu = value; }
        }

        private bool m_isHide;
        /// <summary>
        /// 是否隐藏
        /// 最好更改图形的属性，直接改变此属性需要再调用图形的RefreshDrawing，以改变图形状态
        /// </summary>
        public bool IsHide
        {
            get { return m_isHide; }
            set { m_isHide = value; }
        }

        private bool m_isGroup;
        /// <summary>
        /// 是否为多元素捆绑
        /// </summary>
        public bool IsGroup
        {
            get { return m_isGroup; }
            set { m_isGroup = value; }
        }

        private Color m_dispColor;
        /// <summary>
        /// 元素显示颜色
        /// </summary>
        public Color DispColor
        {
            get { return m_dispColor; }
            set { m_dispColor = value; }
        }

        private Color m_choosedColor;
        /// <summary>
        /// 元素选中颜色
        /// </summary>
        public Color ChoosedColor
        {
            get { return m_choosedColor; }
            set { m_choosedColor = value; }
        }

        private PointD m_gratingPos;
        /// <summary>
        /// 光栅位置（XYZ方向）
        /// </summary>
        public PointD GratingPos
        {
            get { return m_gratingPos; }
            set
            {
                if (m_gratingPos == null)
                {
                    m_gratingPos = new PointD(value);
                }
                else
                {
                    m_gratingPos.PointD_Copy(value);
                }
            }
        }

        /// <summary>
        /// 构造函数（无参数）
        /// </summary>
        public Element()
        {
            BasePublicFunction1();
        }

        /// <summary>
        /// 构造函数（基于实例）
        /// </summary>
        /// <param name="instance"></param>
        public Element(Element instance)
        {
            BasePublicFunction2(instance);
        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        public void Element_Init()
        {
            BasePublicFunction1();
        }

        /// <summary>
        /// 拷贝函数
        /// </summary>
        /// <param name="instance"></param>
        public void Element_Copy(Element instance)
        {
            BasePublicFunction2(instance);
        }

        /// <summary>
        /// 公共函数1
        /// </summary>
        public void BasePublicFunction1()
        {
            this.ID = 0;
            this.DefaultName = "";
            this.ElementType = PublicEnum.ElementType.None;
            this.IsEditEnable = false;
            this.IsChooseEnable = true;
            this.IsChoosed = false;
            this.IsHide = false;
            this.IsGroup = false;

            this.BanZu = PublicEnum.ArraySetBanZu.None;

            if (this.DispColor == null)
            {
                this.DispColor = new Color();
            }
            this.DispColor = Colors.Red;

            if (this.ChoosedColor == null)
            {
                this.ChoosedColor = new Color();
            }
            this.ChoosedColor = Colors.Blue;

            if (this.GratingPos == null)
            {
                this.GratingPos = new PointD();
            }
            else
            {
                this.GratingPos.PointD_Init();
            }
        }

        /// <summary>
        /// 公共函数2
        /// </summary>
        /// <param name="instance"></param>
        public void BasePublicFunction2(Element instance)
        {
            this.ID = instance.ID;
            this.DefaultName = instance.DefaultName;
            this.ElementType = instance.ElementType;
            this.IsEditEnable = instance.IsEditEnable;
            this.IsChooseEnable = instance.IsChooseEnable;
            this.IsChoosed = instance.IsChoosed;
            this.IsHide = instance.IsHide;
            this.IsGroup = instance.IsGroup;

            if (this.DispColor == null)
            {
                this.DispColor = new Color();
            }
            this.DispColor = instance.DispColor;

            if (this.ChoosedColor == null)
            {
                this.ChoosedColor = new Color();
            }
            this.ChoosedColor = instance.ChoosedColor;

            if (this.GratingPos == null)
            {
                this.GratingPos = new PointD(instance.GratingPos);
            }
            else
            {
                this.GratingPos.PointD_Copy(instance.GratingPos);
            }

            this.BanZu = instance.BanZu;
        }

        public virtual void Copy(Element instance)
        {
            Element_Copy(instance);
        }
    }
}
