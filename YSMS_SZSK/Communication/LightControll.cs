using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YSMS_SZSK.CustomerGlobal;
using YSMS_SZSK.LibCustomerDataManager;
using YSMS_SZSK.MessagePrompt;

namespace YSMS_SZSK.Communication
{
    [Serializable]
    public class LightContolParas
    {

        public string portName { get; set; }

        public int baudRate { get; set; }

        public Parity parity { get; set; }

        public int dataBits { get; set; }

        public StopBits stopBits { get; set; }

        public LightContolParas()
        {

        }
    }

    public class LightControl
    {
        /// <summary>
        /// 获取一个值，表示串口是否打开
        /// </summary>
        public bool OpenSuceess { get; private set; }
        /// <summary>
        /// 获取一个值，表示串口是否接受成功
        /// </summary>
        public bool ReceivedSuccess { get; private set; }
        SerialPort serialPort = null;

        public LightContolParas lightContolParas = null;


        public LightControl()
        {
            serialPort = new SerialPort();
            lightContolParas = new LightContolParas();
        }

        public int Register()
        {
            if (serialPort != null && !serialPort.IsOpen)
            {
                serialPort.PortName = lightContolParas.portName;
                serialPort.BaudRate = lightContolParas.baudRate;
                serialPort.Parity = lightContolParas.parity;
                serialPort.DataBits = lightContolParas.dataBits;
                serialPort.StopBits = lightContolParas.stopBits;

                serialPort.DataReceived += delegate
                {
                    try
                    {
                        int len = serialPort.BytesToRead;                    //获取输入缓冲区数组长度
                        byte[] RxData = new byte[len];
                        serialPort.Read(RxData, 0, len);                     //将数据读入缓存

                        if (RxData[0] == 38)
                        {
                            // 控制器接收命令失败，则返回&
                            ReceivedSuccess = false;
                        }
                        else
                        {
                            //当命令字为1，2，3时，如控制器接收命令成功，则返回特征字$  
                            //当命令字为4时，如控制器接收命令成功，则返回对应通道的亮度设置参数（返回格式跟发送格式相同）
                            ReceivedSuccess = true;
                        }

                    }
                    catch (Exception ex)
                    {
                    }
                };

            }
            return 0;


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
                    OpenSuceess = true;
                    return 0;
                }
                catch
                {
                    OpenSuceess = false;
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
                catch
                {
                    return -1;
                }
            }
            else
            {
                return 1;
            }
        }


        public int ChannelON(int L1, int L2, int L3, int L4)
        {
            string str = "S" + ChangeNum(L1) + "T" + ChangeNum(L2) + "T" + ChangeNum(L3) + "T" + ChangeNum(L4) + "TC#";
            return Write2Device(str);
        }
        public int ChannelOFF()
        {
            string str = "S039F039F039F039FC#";
            return Write2Device(str);
        }
        /// <summary>
        /// 通道-打开
        /// </summary>
        /// <param name="channel">通道</param>
        ///<returns>[-1异常，0成功，1无串口]</returns>
        public int ChannelON()
        {

            string str = "S039T039T039T039TC#";

            return Write2Device(str);

        }




        /// <summary>
        /// 通道-关闭
        /// </summary>
        /// <param name="channel">通道</param>
        /// <returns>[-1异常，0成功，1无串口]</returns>
        public int ChannelOFF(string channel)
        {
            //string str = "$2";
            //str += channel.ToString();
            //str += "000";
            string str = "S039F039F039F039FC#";
            return Write2Device(str);
        }

        private string ChangeNum(int num)
        {
            if (num < 10)
            {
                return "00" + num.ToString();
            }
            else if (num >= 10 && num < 100)
            {
                return "0" + num.ToString();
            }
            else
            {
                return num.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns>[-1异常，0成功，1无串口]</returns>
        private int Write2Device(string str)
        {
            if (OpenSuceess)
            {
                try
                {
                    ReceivedSuccess = false;

                    //数据 +异或和
                    string sendStr = str + XOR_XLen(str, 2);
                    //sendStr = str + XOR(str);
                    byte[] sendData = System.Text.ASCIIEncoding.ASCII.GetBytes(sendStr);
                    int len = sendData.Length;
                    //string str2 = Convert.ToBase64String(sendData);
                    //serialPort.WriteLine(str2);
                    serialPort.Write(sendData, 0, len);
                    System.Threading.Thread.Sleep(30);


                    return 0;

                }
                catch
                {
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

    public class LightControlConfig
    {
        public List<LightControl> lightControlList = null;


        public LightControlConfig()
        {
            lightControlList = new List<LightControl>();

            string lightcontrolpath = CfgInfo.getInstance().LightControXmlPath;

            System.Xml.Linq.XElement root = null;

            try
            {
                root = System.Xml.Linq.XDocument.Load(lightcontrolpath).Root;
            }
            catch (Exception e)
            {

                MyMessageBox.GetInstance().tipsInfo = "光源控制器：\n" + e.Message;
                MyMessageBox.GetInstance().ShowWindow(PublicEnum.MessageType.Tips);
                return;
            }

            System.Xml.Linq.XElement controls = root.Element("LightControls");

            foreach (var item in controls.Elements())
            {
                LightControl lc = new LightControl() { lightContolParas = XmlSerializer.Deserialize(item, typeof(LightContolParas)) as LightContolParas };
                if (!lightControlList.Contains(lc))
                {
                    lightControlList.Add(lc);
                }

            }
        }
    }
}
