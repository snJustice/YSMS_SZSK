using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using YSMS_SZSK.CustomerGlobal;

namespace YSMS_SZSK.Basic.PublicClass
{


        //[XmlInclude(typeof(AssistElementArc_Alg_Arcs_Paras))]

        public class AlgParas
        {
            PublicEnum.MeasureElementAlgType algType;
            /// <summary>
            /// 算法类型
            /// </summary>
            public PublicEnum.MeasureElementAlgType AlgType
            {
                get { return algType; }
                set { algType = value; }
            }
            /// <summary>
            /// 构造函数（无参数）
            /// </summary>
            public AlgParas()
            {
                PublicFunction1();
            }

            /// <summary>
            /// 构造函数（基于实例）
            /// </summary>
            /// <param name="instance"></param>
            public AlgParas(AlgParas instance)
            {
                PublicFunction2(instance);
            }

            /// <summary>
            /// 初始化函数
            /// </summary>
            public void AlgParas_Init()
            {
                PublicFunction1();
            }

            /// <summary>
            /// 拷贝函数
            /// </summary>
            /// <param name="instance"></param>
            public void AlgParas_Copy(AlgParas instance)
            {
                PublicFunction2(instance);
            }

            /// <summary>
            /// 公共函数1
            /// </summary>
            public void PublicFunction1()
            {
                algType = PublicEnum.MeasureElementAlgType.None;


            }

            /// <summary>
            /// 公共函数2
            /// </summary>
            /// <param name="instance"></param>
            public void PublicFunction2(AlgParas instance)
            {

            }

            #region "获取实例对象"


            /// <summary>
            /// 拷贝方法
            /// </summary>
            /// <param name="alg"></param>
            public virtual void Copy(AlgParas alg)
            {
                this.AlgType = alg.AlgType;



            }

            #endregion
        }
    }

