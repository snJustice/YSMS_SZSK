using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;
using HalconDotNet;

namespace YSMS.DataManage
{

    //public class DataManager
    //{
    //    public Product product;
    //    public DataManager() { }
    //    public DataManager(int StationNum)
    //    {
    //        product = new Product(StationNum);
    //    }
    //    public bool Save()
    //    {
    //        bool ret = true;

    //        using (Stream fStream = new FileStream(@"d:\proc.xml", FileMode.Create, FileAccess.Write, FileShare.None))
    //        {
    //            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(Product));
    //            xmlSerializer.Serialize(fStream, product);
    //        }
    //        return ret;
    //    }


    //    public bool Load()
    //    {

    //        bool ret = true;
    //        if (File.Exists(@"d:\proc.xml"))
    //        {
    //            using (Stream fStream = File.OpenRead(@"d:\proc.xml"))
    //            {
    //                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Product));
    //                product = serializer.Deserialize(fStream) as Product;
    //            }
    //        }
    //        return ret;
    //    }
    //public bool Save()
    //{
    //    bool ret = true;
    //    XElement root = new XElement("Root");
    //    //尺寸
    //    XElement MeasureSizes = new XElement("MeasureSizeS");
    //    root.Add(MeasureSizes);
    //    foreach (var v in MeasureSizeList)
    //    {
    //        MeasureSizes.Add(XmlSerializer.Serialize(v));
    //    }
    //    //缺陷
    //    XElement MeasureDefect = new XElement("MeasureDefectS");
    //    root.Add(MeasureDefect);
    //    foreach (var v in MeasureDefectList)
    //    {
    //        MeasureDefect.Add(XmlSerializer.Serialize(v));
    //    }
    //    //特殊区域
    //    XElement MeasureSpecialRegion = new XElement("MeasureSpecialRegionS");
    //    root.Add(MeasureSpecialRegion);
    //    foreach (var v in MeasureSpecialRegionList)
    //    {
    //        MeasureSpecialRegion.Add(XmlSerializer.Serialize(v));
    //    }
    //    //检测区域
    //    root.Add(XmlSerializer.Serialize(detectionArea));
    //    //定位区域
    //    root.Add(XmlSerializer.Serialize(locationArea));
    //    //模板生成
    //    root.Add(XmlSerializer.Serialize(generateModeParas));

    //    root.Save(@"d:\prod.xml");
    //    return ret;
    //}

    //public bool LoadSize()
    //{
    //    bool ret = true;
    //    System.Xml.Linq.XDocument xDoc = System.Xml.Linq.XDocument.Load(@"d:\prod.xml");
    //    XElement root = xDoc.Root;
    //    //尺寸
    //    XElement MeasureSizes = root.Element("MeasureSizeS");
    //    MeasureSizeList.Clear();
    //    foreach (var v in MeasureSizes.Elements())
    //    {
    //        MeasureSizeList.Add(XmlSerializer.Deserialize(v, typeof(MeasureSize)) as MeasureSize);
    //    }
    //    //缺陷
    //    XElement MeasureDefect = root.Element("MeasureDefectS");
    //    MeasureDefectList.Clear();
    //    foreach (var v in MeasureDefect.Elements())
    //    {
    //        MeasureDefectList.Add(XmlSerializer.Deserialize(v, typeof(MeasureDefect)) as MeasureDefect);
    //    }
    //    //特殊区域
    //    XElement MeasureSpecialRegion = root.Element("MeasureSpecialRegionS");
    //    MeasureSpecialRegionList.Clear();
    //    foreach (var v in MeasureSpecialRegion.Elements())
    //    {
    //        MeasureSpecialRegionList.Add(XmlSerializer.Deserialize(v, typeof(MeasureSpecialRegion)) as MeasureSpecialRegion);
    //    }

    //    XElement DetectionArea = root.Element("DetectionArea");
    //    detectionArea.Copy(XmlSerializer.Deserialize(DetectionArea, typeof(DetectionArea)) as DetectionArea);

    //    XElement LocationArea = root.Element("LocationArea");
    //    locationArea.Copy(XmlSerializer.Deserialize(LocationArea, typeof(LocationArea)) as LocationArea);

    //    XElement GenerateModeParas = root.Element("GenerateModeParas");
    //    generateModeParas.Copy(XmlSerializer.Deserialize(GenerateModeParas, typeof(GenerateModeParas)) as GenerateModeParas);
    //    return ret;

    //}
    //}
   

  

  
}
