using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO.Ports;
using System.Windows.Forms;
using System.Xml;

namespace YSMS.DataManage
{
    public class LightControls
    {

        #region 错误编号
        /// <summary>
        /// 无XML文件
        /// </summary>
        private const int ERR_NoXML = 100;
        /// <summary>
        /// 已加载过XML文件
        /// </summary>
        private const int ERR_HaveLoadedXML = 101;
        /// <summary>
        ///解析XML文档异常
        /// </summary>
        private const int ERR_ReadXML = 102;
        /// <summary>
        /// 串口打开失败
        /// </summary>
        private const int ERR_OpenSerialPort = 200;
        /// <summary>
        /// 光源通道已存在
        /// </summary>
        private const int ERR_EXT_ChannelNo = 300;


        /// <summary>
        /// 无光源控制器编号
        /// </summary>
        private const int ERR_NoControlNo = 400;

        /// <summary>
        /// 发送数据失败
        /// </summary>
        private const int ERR_SendData = 401;

        #endregion

        private static LightControls instance = null;

        private static bool haveLoadXml = false;

        private LightControls()
        {

        }
        /// <summary>
        /// 获取单例
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static LightControls CreateInstance()
        {
            if (instance == null)
            {
                lock (typeof(LightControls))
                {
                    if (instance == null)
                    {
                        instance = new LightControls();
                    }
                }
            }
            return instance;

        }

        public void SaveLightValToXml(string filePath)
        {
            if (dicChannelBrightness.Count == 0)
            {
                return;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);            
            //XmlNode memberlist = xmlDoc.SelectSingleNode("//LightControls//LightControl");
            XmlNode memberlist = xmlDoc.SelectSingleNode("//LightControls//LightControl");
            XmlNodeList nodelist = memberlist.ChildNodes;
            List <int > brightList=new List<int> (){};
            int count = 0;
            XmlNodeList nodelistChannels = null;
            XmlNodeList nodelistDefaultValue = null;
            // XmlNodeList nodelist=xmlDoc.GetElementsByTagName("MEMBER");
            foreach (var para in dicChannelBrightness.Keys)
            {
                
                brightList.Add(para.Brightness);
            }
            
            foreach (XmlNode node in nodelist)
            {
                if (node.Name == "Channels")
                {
                    nodelistChannels = node.ChildNodes;
                    foreach (XmlNode nodeChannels in nodelistChannels)
                    {

                        if (nodeChannels.Name == "Channel")
                        {
                            nodelistDefaultValue = nodeChannels.ChildNodes;
                            foreach (XmlNode noded in nodelistDefaultValue)
                            {
                                if (noded.Name == "DefaultValue")
                                {
                                    noded.ChildNodes[0].InnerText = brightList.ToArray()[count].ToString();
                                    count++;
                                }
                            }
                        }
                    }

                }              
            
            }
            
            xmlDoc.Save(filePath);
        
        }

        /// <summary>
        /// 加载XML 文档并 注册串口
        /// </summary>
        /// <param name="filePath"></param>
        public int GetControlsByLoadXML(string filePath, ref string exMessage)
        {
            if (haveLoadXml)
                return ERR_HaveLoadedXML;

            int resultFlag = 0;

            //if(File.Ex

            if (System.IO.File.Exists(filePath))
            {
                //读取XML 文件并解析
                List<LightControl> listLC = new List<LightControl>();


                try
                {
                    XDocument doc = XDocument.Load(filePath);

                    instance.dicLightControl =
                        (
                            from LC in doc.Descendants("LightControl")
                            select new LightControl
                            {
                                //控制器编号
                                ControlNo = LC.Element("ControlNo").Value.Trim(),
                                IsEnabled = LC.Element("IsEnabled").Value == "0" ? false : true,
                                //窗口参数
                                SerialPortPara = new SerialPortPara
                                {
                                    PortName = LC.Element("SerialPortPara").Element("PortName").Value.Trim(),

                                    BaudRate = Convert.ToInt32(LC.Element("SerialPortPara").Element("BaudRate").Value),

                                    DataBits = Convert.ToInt32(LC.Element("SerialPortPara").Element("DataBits").Value),

                                    StopBits = (StopBits)Enum.Parse(typeof(StopBits), LC.Element("SerialPortPara").Element("StopBits").Value, true),

                                    Parity = (Parity)Enum.Parse(typeof(StopBits), LC.Element("SerialPortPara").Element("Parity").Value, true),

                                },
                                //通道列表
                                DicChannel = (
                                                from channel in LC.Element("Channels").Descendants("Channel")
                                                select new Channel
                                                {
                                                    ChannelNo = channel.Element("ChannelNo").Value,
                                                    Name = channel.Element("Name").Value,
                                                    DefaultValue = Convert.ToInt32(channel.Element("DefaultValue").Value),
                                                    NewDefaultValue = Convert.ToInt32(channel.Element("NewDefaultValue").Value),
                                                    Des = channel.Element("Des").Value

                                                }
                                            ).ToDictionary(v => v.ChannelNo)

                            }
                       ).ToDictionary(v => v.ControlNo);
                }
                catch (Exception ex)
                {
                    SoftwareInfo.getInstance().WriteLog("GetControlsByLoadXML:\n"+ex.ToString ());
                    resultFlag = ERR_ReadXML;

                    exMessage = "光源配置文件错误:" + ex.Message;
                }


                if (resultFlag == 0 && instance.dicLightControl.Count > 0)
                {
                    foreach (var lc in instance.dicLightControl.Values)
                    {
                        //打开串口
                        if (0 != lc.OpenSerialPort())
                        {
                            resultFlag = ERR_OpenSerialPort;
                            exMessage = "打开串口异常:" + lc.SerialPortPara.PortName;
                            break;
                        }

                        foreach (var ch in lc.DicChannel.Values)
                        {
                            ChannelBrightness controlChannelNo = new ChannelBrightness { ControlNo = lc.ControlNo, ChannelNo = ch.ChannelNo, Brightness = -1 };

                            if (!instance.dicChannelBrightness.ContainsKey(controlChannelNo))
                            {
                                instance.dicChannelBrightness.Add(controlChannelNo, ch);
                            }
                            else
                            {
                                resultFlag = ERR_EXT_ChannelNo;
                                exMessage = "光源通道已存在" + controlChannelNo.ControlNo + "->" + controlChannelNo.ChannelNo;
                                break;
                            }
                        }

                        //if (System.IO.File.Exists(brightPath))
                        //{

                        //    ReadAndSetLightParas(brightPath);

                        //}


                        if (resultFlag != 0)
                            break;

                    }
                }

            }
            else
            {
                exMessage = "无XML文件:" + filePath;
                //无XML 文件
                resultFlag = ERR_NoXML;
            }

            return resultFlag;
        }

        /// <summary>
        /// 从文件中 获取 光源通道参数
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <param name="exMessage"></param>
        /// <returns></returns>
        public List<int> ReadAndSetLightParas(string xmlPath)
        {

            List<int> brightList = new List<int>() { };
            //InfoPath .getInstance ().ChannelBrightness
            string xmlFileName = xmlPath;

            //if (!System.IO.File.Exists(xmlFileName))
            //{
            //    return "不存在文件=" + xmlFileName;              
            //}

            string resultOK = "OK";

            try
            {
                XDocument xDoc = XDocument.Load(xmlFileName);

                var listChannelBrightness = from para in xDoc.Descendants("Channel")
                                            select new ChannelBrightness
                                            {
                                                ControlNo = para.Attribute("ControlNo").Value,
                                                ChannelNo = para.Attribute("ChannelNo").Value,
                                                Brightness = Convert.ToInt32(para.Attribute("Brightness").Value)
                                            };

                KeyValuePair<ChannelBrightness, Channel> keyvalue;
                ChannelBrightness cb = null;

                foreach (var para in listChannelBrightness)
                {
                    //try
                    //{
                    //修改 光源亮度值
                    keyvalue = dicChannelBrightness.First(v => { return (v.Key.ChannelNo == para.ChannelNo) && (v.Key.ControlNo == para.ControlNo); });

                    keyvalue.Key.Brightness = para.Brightness;

                    if (!instance.dicChannelBrightness.ContainsKey(keyvalue.Key))
                    {
                        Channel channel = keyvalue.Value;
                        channel.NewDefaultValue = keyvalue.Key.Brightness;
                        instance.dicChannelBrightness.Add(keyvalue.Key, channel);
                    }
                    //else
                    //{
                    //    resultFlag = ERR_EXT_ChannelNo;
                    //    exMessage = "光源通道已存在" + controlChannelNo.ControlNo + "->" + controlChannelNo.ChannelNo;
                    //    break;
                    //}

                    brightList.Add(keyvalue.Key.Brightness);
                    cb = keyvalue.Key;
                    //设置光源亮度

                    //}
                    //catch
                    //{
                    //}

                }
                SendBrightness(brightList, cb);

            }
            catch (Exception ex)
            {
                SoftwareInfo.getInstance().WriteLog("ReadAndSetLightParas:\n"+ex.ToString ());
                SaveChannelBrightness(xmlPath);
                //MessageBox.Show("请检查当前程序ChannelBrightness文件配置是否正确！","系统提示",MessageBoxButtons.YesNo);
                resultOK = ex.Message;
            }

            return brightList;
        }

        /// <summary>
        /// 光源控制器 字典
        /// </summary>
        private Dictionary<string, LightControl> dicLightControl = null;

        /// <summary>
        /// 存储控制器编号，通道编号  
        /// </summary>
        private SortedDictionary<ChannelBrightness, Channel> dicChannelBrightness = new SortedDictionary<ChannelBrightness, Channel>();

        /// <summary>
        /// 光源通道
        /// </summary>
        public SortedDictionary<ChannelBrightness, Channel> DicChannelBrightness
        {
            get { return dicChannelBrightness; }
        }


        

        /// <summary>
        /// FG设置光源亮度
        /// </summary>
        /// <param name="controlNo"></param>
        /// <param name="channelNo"></param>
        /// <param name="brightness"></param>  
        //LightControl lc1 = new LightControl();
        public int SendBrightness(List<int> strList, ChannelBrightness channelBrightness)
        {
            LightControl lc = null;
            dicLightControl.TryGetValue(channelBrightness.ControlNo, out lc);

            if (0 != lc.ChannelLight(strList))
            {
                return ERR_SendData;
            }

            return 0;

        }


        public int TurnOn(ChannelBrightness channelBrightness)
        {
            if (channelBrightness == null)
                return -1;

            LightControl lc = null;
            dicLightControl.TryGetValue(channelBrightness.ControlNo, out lc);

            if (lc == null)
                return ERR_NoControlNo;


            if (0 != lc.ChannelON(channelBrightness.ChannelNo))
            {
                return ERR_SendData;
            }

            return 0;

        }

        public int TurnOFF(ChannelBrightness channelBrightness)
        {
            if (channelBrightness == null)
                return -1;

            LightControl lc = null;
            dicLightControl.TryGetValue(channelBrightness.ControlNo, out lc);

            if (lc == null)
                return ERR_NoControlNo;


            if (0 != lc.ChannelOFF(channelBrightness.ChannelNo))
            {
                return ERR_SendData;
            }

            return 0;

        }

        /// <summary>
        /// 关闭所有 光源控制器串口
        /// </summary>
        public void ClosAllSerialPort()
        {
            if (dicLightControl == null)
                return;
            try
            {

                for (int i = 0; i < dicLightControl.Count; i++)
                {
                    dicLightControl.ElementAt(i).Value.CloseSerialPort();
                }
            }
            catch(Exception ex)
            {
                SoftwareInfo.getInstance().WriteLog("ClosAllSerialPort:\n"+ex.ToString ());
            }

        }


        string exMessage = "";
        string ChannelBrightness = "";
        /// <summary>
        /// 保存通道亮度
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <returns></returns>
        public List<int> SaveChannelBrightness(string xmlPath)
        {
            ChannelBrightness = xmlPath;
            ChannelBrightness = ChannelBrightness.Replace("\\\\", "\\");

            int resultFlag = 0;
            List<int> brightList = new List<int>() { };

            brightList = SaveChannelBrightnessParas(ChannelBrightness, ref exMessage);

            if (resultFlag != 0)
            {
                MessageBox.Show(exMessage);
            }
            return brightList;
        }


        /// <summary>
        /// 保存通道亮度
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <param name="exMessage"></param>
        /// <returns></returns>
        public List<int> SaveChannelBrightnessParas(string xmlPath, ref string exMessage)
        {
            //int resultFLag = 0;
            List<int> brightList = new List<int>() { };
            try
            {

                XElement rootNode = new XElement("Channels");

                foreach (var para in dicChannelBrightness.Keys)
                {
                    //定义一个新节点 Channel
                    XElement newNode = new XElement("Channel",
                                                        new XAttribute("ControlNo", para.ControlNo),
                                                        new XAttribute("ChannelNo", para.ChannelNo),
                                                        new XAttribute("Brightness", para.Brightness)
                                                    );
                    rootNode.Add(newNode);
                    brightList.Add(para.Brightness);
                }



                XDocument parasXDoc = new XDocument();
                parasXDoc.Add(rootNode);

                parasXDoc.Save(xmlPath);
                exMessage = "保存成功！";
            }
            catch (Exception ex)
            {
                SoftwareInfo.getInstance().WriteLog("SaveChannelBrightnessParas:\n"+ex.ToString ());
                //resultFLag = -1;
                exMessage = ex.Message;
            }

            return brightList;
        }


    }

}
