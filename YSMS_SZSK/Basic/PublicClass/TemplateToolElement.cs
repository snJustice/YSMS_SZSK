using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YSMS_SZSK.CustomerGlobal;

namespace YSMS_SZSK.Basic.PublicClass
{
    public class TemplateToolElement : MeasureElement
    {
        private RectangleD m_canvasRect;
        /// <summary>
        /// 画布矩形
        /// </summary>
        public RectangleD CanvasRect
        {
            get { return m_canvasRect; }
            set
            {
                if (m_canvasRect == null)
                {
                    m_canvasRect = new RectangleD(value);
                }
                else
                {
                    m_canvasRect.RectangleD_Copy(value);
                }
            }
        }

        private RectangleD m_canvasRectBackup;
        /// <summary>
        /// 画布变换矩形（用于模板匹配后对画布矩形的备份）
        /// </summary>
        public RectangleD CanvasRectBackup
        {
            get { return m_canvasRectBackup; }
            set
            {
                if (m_canvasRectBackup == null)
                {
                    m_canvasRectBackup = new RectangleD(value);
                }
                else
                {
                    m_canvasRectBackup.RectangleD_Copy(value);
                }
            }
        }

        private RectangleD m_imageRect;
        /// <summary>
        /// 图像矩形
        /// </summary>
        public RectangleD ImageRect
        {
            get { return m_imageRect; }
            set
            {
                if (m_imageRect == null)
                {
                    m_imageRect = new RectangleD(value);
                }
                else
                {
                    m_imageRect.RectangleD_Copy(value);
                }
            }
        }

        public TemplateToolElement()
        {
            NewPublicFunction1();
        }

        /// <summary>
        /// 构造函数（基于实例）
        /// </summary>
        /// <param name="instance"></param>
        public TemplateToolElement(TemplateToolElement instance)
        {
            NewPublicFunction2(instance);
        }

        /// <summary>
        /// 初始化函数
        /// </summary>
        public void TemplateToolElement_Init()
        {
            NewPublicFunction1();
        }

        /// <summary>
        /// 拷贝函数
        /// </summary>
        /// <param name="instance"></param>
        public void TemplateToolElement_Copy(TemplateToolElement instance)
        {
            NewPublicFunction2(instance);
        }

        /// <summary>
        /// 公共函数1
        /// </summary>
        public void NewPublicFunction1()
        {
            this.PublicFunction1();
            this.IsEditEnable = true;
            if (this.CanvasRect == null)
            {
                this.CanvasRect = new RectangleD();
            }
            else
            {
                this.CanvasRect.RectangleD_Init();
            }

            if (this.ImageRect == null)
            {
                this.ImageRect = new RectangleD();
            }
            else
            {
                this.ImageRect.RectangleD_Init();
            }


            if (this.CanvasRectBackup == null)
            {
                this.CanvasRectBackup = new RectangleD();
            }
            else
            {
                this.CanvasRectBackup.RectangleD_Init();
            }

          
        }

        /// <summary>
        /// 公共函数2
        /// </summary>
        /// <param name="instance"></param>
        public void NewPublicFunction2(TemplateToolElement instance)
        {
            this.PublicFunction2(instance);

            if (this.CanvasRect == null)
            {
                this.CanvasRect = new RectangleD(instance.CanvasRect);
            }
            else
            {
                this.CanvasRect.RectangleD_Copy(instance.CanvasRect);
            }

            if (this.ImageRect == null)
            {
                this.ImageRect = new RectangleD(instance.ImageRect);
            }
            else
            {
                this.ImageRect.RectangleD_Copy(instance.ImageRect);
            }

            if (this.CanvasRectBackup == null)
            {
                this.CanvasRectBackup = new RectangleD(instance.CanvasRectBackup);
            }
            else
            {
                this.CanvasRectBackup.RectangleD_Copy(instance.CanvasRectBackup);
            }

       
        }

        /// <summary>
        /// 其他公共函数
        /// </summary>
        
        }

       

    


    }

