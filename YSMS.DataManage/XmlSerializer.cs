using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Text;


namespace YSMS.DataManage
{
    public class XmlSerializer
    {
        private static System.Xml.Serialization.XmlSerializerNamespaces xmlns = new System.Xml.Serialization.XmlSerializerNamespaces();

        static XmlSerializer()
        {
            xmlns.Add(string.Empty, string.Empty);
        }

        public static XElement Serialize(object obj)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
            StringBuilder buffer = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(buffer);
            serializer.Serialize(writer, obj, xmlns);
            return XElement.Parse(buffer.ToString());
        }

        public static object Deserialize(XElement element, Type type)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(type);
            StringReader buffer = new StringReader(element.ToString());
            return serializer.Deserialize(buffer);
        }

        //public static string StringListToString(List<string> source)
        //{
        //    string result = String.Empty;
        //    foreach (var v in source)
        //    {
        //        result += v + ",";
        //    }
        //    return result.TrimEnd(',');
        //}

        //public static List<string> StringToStringList(string source)
        //{
        //    string[] result = source.Split(',');
        //    return result.ToList();
        //}
    }
}
