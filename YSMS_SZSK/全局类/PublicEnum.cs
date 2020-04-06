using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSMS_130Standard
{
    public class PublicEnum
    {
        /// <summary>
        /// 批量测量状态
        /// </summary>
        public enum BatchMeasureState
        {
            /// <summary>
            /// 未准备状态
            /// </summary>
            NotReady,

            /// <summary>
            /// 准备状态
            /// </summary>
            Ready,

            /// <summary>
            /// 运行状态
            /// </summary>
            Running,

            /// <summary>
            /// 报警
            /// </summary>
            Alarm
        }

        /// <summary>
        /// 工位状态
        /// </summary>
        public enum StationState
        {
            /// <summary>
            /// 不启用
            /// </summary>
            Close,

            /// <summary>
            /// 黑屏
            /// </summary>
            Black,

            /// <summary>
            /// 保持
            /// </summary>
            Stay,

            /// <summary>
            /// 实时显示
            /// </summary>
            Show,

            /// <summary>
            /// 运行检测
            /// </summary>
            Measure,

            /// <summary>
            /// 模板校正
            /// </summary>
            Ajust
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

      


        
    }

}
