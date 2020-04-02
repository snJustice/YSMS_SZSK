using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YSMS_SZSK.Basic.PublicClass;
using YSMS_SZSK.ImageDrawing;

namespace YSMS_SZSK.CustomerGlobal
{
    public class DrawParas
    {
        #region 单例对象
        private static DrawParas instance;
        private DrawParas()
        {
            prefixName = "";//名称前缀
            currentCrdId = 0;//当前坐标系Id
            toolEnum = PublicEnum.ToolType.Pointer;

            algType = PublicEnum.MeasureElementAlgType.None;
            if (algParasIns == null)
            {
                algParasIns = new AlgParas();
            }
        }

        /// <summary>
        /// 获取 单例实例对象
        /// </summary>
        /// <returns></returns>
        public static DrawParas getInstance()
        {
            if (instance == null)
            {
                lock (typeof(DrawParas))
                {
                    if (instance == null)
                    {
                        instance = new DrawParas();
                    }
                }
            }
            return instance;
        }
        #endregion

        string prefixName;
        /// <summary>
        /// 前缀名称 (默认)
        /// </summary>
        public string PrefixName
        {
            get { return prefixName; }
            set { prefixName = value; }
        }

        private int currentCrdId;
        /// <summary>
        /// 当前坐标系 Id
        /// </summary> 
        public int CurrentCrdId
        {
            get { return currentCrdId; }
            set { currentCrdId = value; }
        }


        PublicEnum.UC_ModuleType ucType;
        /// <summary>
        /// 右边界面枚举
        /// </summary>
        public PublicEnum.UC_ModuleType UcType
        {
            get { return ucType; }
            set { ucType = value; }
        }


        PublicEnum.UC_OperateType operType;

        public PublicEnum.UC_OperateType OperType
        {
            get { return operType; }
            set { operType = value; }
        }


        private EnumCURD cURD;
        /// <summary>
        /// 模式
        /// </summary>
        public EnumCURD CURD
        {
            get { return cURD; }
            set { cURD = value; }
        }

        DrawStatusType drawStatusEnum;
        /// <summary>
        /// 绘图状态
        /// </summary>
        public DrawStatusType DrawStatusEnum
        {
            get { return drawStatusEnum; }
            set { drawStatusEnum = value; }
        }


        PublicEnum.ToolType toolEnum;
        /// <summary>
        /// 工具枚举
        /// </summary>
        public PublicEnum.ToolType ToolEnum
        {
            get { return toolEnum; }
            set
            {
                if (toolEnum == PublicEnum.ToolType.Pointer && value != PublicEnum.ToolType.Pointer)
                {
                    // Pointer 工具=》 其他工具
                    if (drawCanvas != null)
                    {
                        HelperFunctions.UnselectAll(drawCanvas);
                    }
                }

                toolEnum = value;
            }
        }


        PublicEnum.AllModuleType allModuleType;
        /// <summary>
        /// 类型
        /// </summary>
        public PublicEnum.AllModuleType AllModuleType
        {
            get { return allModuleType; }
            set { allModuleType = value; }
        }



        PublicEnum.MeasureElementAlgType algType;
        /// <summary>
        /// 算法类型
        /// </summary>
        public PublicEnum.MeasureElementAlgType AlgType
        {
            get { return algType; }
            set { algType = value; }
        }


        AlgParas algParasIns;
        /// <summary>
        /// 算法参数
        /// </summary>
        public AlgParas AlgParaIns
        {
            get { return algParasIns; }
            set { algParasIns = value; }
        }


        DrawingCanvas drawCanvas;
        /// <summary>
        /// 画布
        /// </summary>
        public DrawingCanvas DrawCanvas
        {
            get { return drawCanvas; }
            set { drawCanvas = value; }
        }

        /// <summary>
        /// 全局单例 初始化
        /// </summary>
        public void init()
        {
            this.allModuleType = PublicEnum.AllModuleType.None;
            this.algParasIns = null;
            this.cURD = EnumCURD.Read;
            this.currentCrdId = 0;
            this.drawCanvas = null;
            this.drawStatusEnum = DrawStatusType.None;
            this.operType = PublicEnum.UC_OperateType.None;
            this.prefixName = "";
            this.toolEnum = PublicEnum.ToolType.Pointer;

        }

    }
}
