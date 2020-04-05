using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSMS.DataManage
{
    /// <summary>
    /// 软件类型
    /// </summary>
    public enum SoftwareTypeEnum
    {
        /// <summary>
        /// 普通
        /// </summary>
        Normal,

        /// <summary>
        /// 片式
        /// </summary>
        Pieces,

        /// <summary>
        /// 连续型 + UDP 通讯
        /// </summary>
        ContinueUDP
    }
   

    /// <summary>
    /// 结果类型
    /// </summary>
    public enum ResultType
    {
        None,
        DefectOK,
        DefectError,
        WPP,
        SizeOK,
        SizeError,
        ImageError,
        NoProduct
    }
}
