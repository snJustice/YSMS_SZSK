using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSMS.DataManage
{
    class SerialPortPara
    {
        /// <summary>
        /// 端口号
        /// </summary>
        public string PortName { get; set; }
        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate { get; set; }

        /// <summary>
        /// 数据位
        /// </summary>
        public int DataBits { get; set; }

        /// <summary>
        /// 校验位
        /// </summary>
        public System.IO.Ports.Parity Parity { get; set; }

        /// <summary>
        /// 停止位
        /// </summary>
        public System.IO.Ports.StopBits StopBits { get; set; }

    }
}
