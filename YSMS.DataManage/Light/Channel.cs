using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSMS.DataManage
{
    /// <summary>
    /// 光源通道
    /// </summary>
    public class Channel
    {
        /// <summary>
        /// 通道序号  1、2
        /// </summary>
        public string ChannelNo { get; set; }
        /// <summary>
        /// 通道名称 显示界面时使用 如【A、B】
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 默认亮度
        /// </summary>
        public int DefaultValue { get; set; }

        /// <summary>
        /// 软件初始的亮度
        /// </summary>
        public int NewDefaultValue { get; set; }

        /// <summary>
        /// 用途说明 如 【相机1，相机2】
        /// </summary>
        public string Des { get; set; }
    }
}
