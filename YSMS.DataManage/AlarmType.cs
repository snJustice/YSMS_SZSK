using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSMS.DataManage
{
    public enum AlarmType
    {
        /// <summary>
        /// 连续未匹配
        /// </summary>
        WPP,

        /// <summary>
        /// 其中一个模板连续未匹配
        /// </summary>
        ModelWPP,

        /// <summary>
        /// 检测报警
        /// </summary>
        Measure,

        /// <summary>
        /// 堵料报警
        /// </summary>
        Block,

        /// <summary>
        /// 无产品报警
        /// </summary>
        NoProduct,

        /// <summary>
        /// 未开启检测报警
        /// </summary>
        NoCheck,
    }
}
