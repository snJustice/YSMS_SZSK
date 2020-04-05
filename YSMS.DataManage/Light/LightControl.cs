using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSMS.DataManage
{
    /// <summary>
    /// 光源控制
    /// </summary>
    class LightControl
    {
        /// <summary>
        /// 控制器编号
        /// </summary>
        public string ControlNo { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 控制器串口参数信息
        /// </summary>
        public SerialPortPara SerialPortPara { get; set; }
        /// <summary>
        /// 控制器通道
        /// </summary>
        public Dictionary<string, Channel> DicChannel = new Dictionary<string, Channel>();

        /// <summary>
        /// 串口控制器
        /// </summary>
        private LightSerialControl serialPort = new LightSerialControl();


        /// <summary>
        /// 打开串口
        /// </summary>
        /// <returns></returns>
        public int OpenSerialPort()
        {
            if (IsEnabled)
            {
                serialPort.Register(SerialPortPara.PortName, SerialPortPara.BaudRate, SerialPortPara.Parity, SerialPortPara.DataBits, SerialPortPara.StopBits);

                return serialPort.Open();
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <returns></returns>
        public int CloseSerialPort()
        {
            return serialPort.Close();
        }

        public int ChannelLight(string channelNo, int brightness)
        {
            return serialPort.ChannelLight(channelNo, brightness);
        }

        /// <summary>
        /// FG
        /// </summary>
        /// <param name="strList"></param>
        /// <returns></returns>
        public int ChannelLight(List<int> strList)
        {
            return serialPort.ChannelLight(strList);
        }

        public int ChannelON(string channelNo)
        {
            return serialPort.ChannelON(channelNo);
        }

        public int ChannelOFF(string channelNo)
        {
            return serialPort.ChannelOFF(channelNo);
        }
    }
}
