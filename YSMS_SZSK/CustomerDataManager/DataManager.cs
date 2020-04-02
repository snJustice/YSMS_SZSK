using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using YSMS_SZSK.Basic.PublicClass;
using YSMS_SZSK.CustomerGlobal;
using YSMS_SZSK.LibCustomerDataManager;
using YSMS_SZSK.MessagePrompt;

namespace YSMS_SZSK.CustomerDataManager
{
    public class DataManager
    {
        public bool New()
        {
            bool result = true;
           
            return result;
        }

        public bool Save(string filePath)
        {
            bool result = true;

            FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);


            try
            {

                XElement root = new XElement("Root");
                string time = DateTime.Now.ToString();
                root.SetAttributeValue("CreateTime", time);
                //root.SetAttributeValue("ImagePath", Global.m_Pvb.m_MeasureImagePath);

                


                
                root.Save(stream);
            }
            catch (Exception e)
            {
                MyMessageBox.GetInstance().tipsInfo = "保存发生未知错误: \n" + e.Message;
                MyMessageBox.GetInstance().ShowWindow(PublicEnum.MessageType.Tips);

                result = false;
            }
            finally
            {
                stream.Close();
            }

            return result;
        }

        public bool Load(string filePath)
        {
            bool result = true;

            XElement root = null;
            try
            {
                root = XElement.Load(filePath);
            }
            catch (Exception e)
            {
                MyMessageBox.GetInstance().tipsInfo = "工程文件加载出错：\n" + e.Message;
                MyMessageBox.GetInstance().ShowWindow(PublicEnum.MessageType.Tips);

                result = false;
            }

           

           

            


            XElement LightsControl = root.Element("LightsControl");
            try
            {

                Global.lights = XmlSerializer.Deserialize(LightsControl.Elements().First(), typeof(Lights)) as Lights;
            }
            catch
            {

                Global.lights.Init();
            }

            return result;
        }
    }
}
