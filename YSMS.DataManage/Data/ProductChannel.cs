using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace YSMS.DataManage
{
    /// <summary>
    /// 通道
    /// </summary>
    public class ProductChannel
    {
        /// <summary>
        /// 通道编号
        /// </summary>
        public uint ChannelNo { set; get; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable = false;

        /// <summary>
        /// 通道名称
        /// </summary>
        public string ChannelName = string.Empty;


        /// <summary>
        /// 产品管理
        /// </summary>
        public Product ProductData = new Product();
    }
}
