using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.Threading;
using System.Windows;


namespace YSMS.DataManage
{
    /// <summary>
    /// 光源串口控制
    /// </summary>
    public class LightSerialControl
    {
        //串口注册信息
        private SerialPort serialPort = new SerialPort();

        /// <summary>
        /// 窗口打开
        /// </summary>
        private bool openSuceess = false;

        /// <summary>
        /// 接收成功
        /// </summary>
        //private bool ReceivedSuccess = false;

        /// <summary>
        /// 串口注册
        /// </summary>
        public int Register(string portName = "COM1", int baudRate = 9600, Parity parity = Parity.None, int dataBits = 8, StopBits stopBits = StopBits.One)
        {
            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
            serialPort.Parity = parity;
            serialPort.DataBits = dataBits;
            serialPort.StopBits = stopBits;

            ////注册事件
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);

            return 0;

       
        }

        /// <summary>
        /// 数据接收 事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string str= serialPort.ReadExisting();
                if (str != "!")
                {
                    //MessageBox.Show("光源控制失败！","系统提示",MessageBoxButton.OKCancel,MessageBoxImage.Question );
                
                }
                //int len = serialPort.BytesToRead;                    //获取输入缓冲区数组长度
                //byte[] RxData = new byte[len];
                //serialPort.Read(RxData, 0, len);                     //将数据读入缓存
                
                //if (RxData[0] == 38)
                //{
                //   // 控制器接收命令失败，则返回&
                //    ReceivedSuccess = false;
                //}
                //else
                //{
                //    //当命令字为1，2，3时，如控制器接收命令成功，则返回特征字$  
                //    //当命令字为4时，如控制器接收命令成功，则返回对应通道的亮度设置参数（返回格式跟发送格式相同）
                //    ReceivedSuccess = true;
                //}

            }
            catch (Exception ex)
            {
                SoftwareInfo.getInstance().WriteLog("serialPort_DataReceived:\n"+ex .ToString ()); 
            }

        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <returns>[-1异常，0成功，1已打开]</returns>
        public int Open()
        {
            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.Open();
                    openSuceess = true;
                    return 0;
                }
                catch(Exception ex)
                {
                    SoftwareInfo.getInstance().WriteLog("Open:\n"+ex.ToString ());
                    openSuceess = false;
                    return -1;
                }
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <returns>[-1异常，0成功，1已关闭]</returns>
        public int Close()
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Close();
                    return 0;
                }
                catch(Exception ex)
                {
                    SoftwareInfo.getInstance().WriteLog("Close:\n"+ex.ToString ());
                    return -1;
                }
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// 通道-亮度
        /// </summary>
        /// <param name="channel">通道</param>
        /// <param name="brightness">亮度</param>
        /// <returns>[-1异常，0成功，1无串口]</returns>
        public int ChannelLight(string channel, int brightness)
        {
            string str = "#3";
            str += channel.Trim();
            str += brightness.ToString("X3");
           return   Write2Device(str);
        }

        /// <summary>
        /// fg通道-亮度
        /// </summary>
        /// <param name="channel">通道</param>
        /// <param name="brightness">亮度</param>
        /// <returns>[-1异常，0成功，1无串口]</returns>
        public int ChannelLight(List<int> strList)
        {            
            string str = "S";
            foreach (int s in strList)
            {
                string lightStr = s.ToString("000");
                str += lightStr + "T";
            }
            str += "C#";
            return Write2Device(str);
        }


        /// <summary>
        /// 通道-打开
        /// </summary>
        /// <param name="channel">通道</param>
        ///<returns>[-1异常，0成功，1无串口]</returns>
        public int ChannelON(string channel)
        {
            string str = "#1";
            str += channel.ToString();
            str += "000";
           return Write2Device(str);
        }

        /// <summary>
        /// 通道-关闭
        /// </summary>
        /// <param name="channel">通道</param>
        /// <returns>[-1异常，0成功，1无串口]</returns>
        public int ChannelOFF(string channel)
        {
            string str = "#2";
            str += channel.ToString();
            str += "000";
            return Write2Device(str);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns>[-1异常，0成功，1无串口]</returns>
        private int Write2Device(string str)
        {
            if (openSuceess)
            {
                try
                {
                    //ReceivedSuccess = false;

                    //数据 +异或和
                    //string sendStr = str + XOR_XLen(str, 2);
                    byte[] sendData = System.Text.ASCIIEncoding.ASCII.GetBytes(str);
                    int len = sendData.Length;
                  
                    serialPort.Write(sendData, 0, len);                    
                    //string str1= serialPort.ReadExisting();                   
                    System.Threading.Thread.Sleep(30);                    
                  
                    return 0;

                }
                catch(Exception ex)
                {
                    SoftwareInfo.getInstance().WriteLog("Write2Device:\n"+ex.ToString ());
                    return -1;
                }
            }
            else
            {
                return 1;
            }

        }

        #region  异或校验和
        /// <summary>
        /// 异或校验和
        /// </summary>
        /// <param name="checkStr">待校验数据（字符串）</param>
        /// <returns></returns>
        private byte XOR(string checkStr)
        {
            //获取s对应的字节数组
            byte[] b = System.Text.Encoding.ASCII.GetBytes(checkStr);

            // xorResult 存放校验结果。注意：初值去首元素值！
            byte xorResult = b[0];

            // 求xor校验和。注意：XOR运算从第二元素开始
            for (int i = 1; i < b.Length; i++)
            {
                xorResult ^= b[i];
            }
            // 运算后，xorResult就是XOR校验和的结果！
            return xorResult;
        }

        /// <summary>
        /// 异或校验和 16进制
        /// </summary>
        /// <param name="checkStr"></param>
        /// <param name="resultLen">结果位长度</param>
        /// <returns></returns>
        private string XOR_XLen(string checkStr, int resultLen = 0)
        {
            byte xorResult = XOR(checkStr);

            if (resultLen <= 0)
            {
                return xorResult.ToString("X");
            }
            else
            {
                //固定几位
                return xorResult.ToString("X" + resultLen);
            }
        }
        #endregion
    }
}
