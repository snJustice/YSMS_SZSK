using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSMS.DataManage
{
    /// <summary>
    /// 图形类型
    /// </summary>
    public enum GraphType
    {
        none,
        /// <summary>
        /// 缺陷框
        /// </summary>
        Defect,
        /// <summary>
        /// 尺寸框
        /// </summary>
        Size,
        /// <summary>
        /// RiO区域
        /// </summary>
        Roi,
        /// <summary>
        /// 检测区
        /// </summary>
        DetectionArea,
        /// <summary>
        /// 屏蔽区
        /// </summary>
        ShieldingArea,
        /// <summary>
        /// 定位区
        /// </summary>
        LocationArea
    }
}
