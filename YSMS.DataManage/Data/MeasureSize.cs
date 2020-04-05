using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace YSMS.DataManage
{
    /// <summary>
    /// 测量尺寸
    /// </summary>
    [Serializable]
    public class MeasureSize : INotifyPropertyChanged, IChangeShowName
    {

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


        public MeasureSize() { }

        private SizeAlgorithm m_SizeAlgorithm;
        /// <summary>
        /// 算法
        /// </summary>
        public SizeAlgorithm SizeAlgorithm
        {
            get
            {
                if (m_SizeAlgorithm == null)
                {
                    m_SizeAlgorithm = new SizeAlgorithm();
                }
                return m_SizeAlgorithm;
            }
            set
            {
                m_SizeAlgorithm = value;
                OnPropertyChanged("SizeAlgorithm");
            }
        }

        private string m_Id;
        /// <summary>
        /// 尺寸编号
        /// </summary>
        public string Id
        {
            get
            {
                return m_Id;
            }
            set
            {
                m_Id = value;
                OnPropertyChanged("Id");
            }
        }

        private string m_SizeName;
        /// <summary>
        /// 尺寸名称
        /// </summary>
        public string SizeName
        {
            get
            {
                return m_SizeName;
            }
            set
            {
                m_SizeName = value;
                OnPropertyChanged("SizeName");
            }
        }



        /// <summary>
        /// 矩形框列表
        /// </summary>
        public ObservableCollection<HRect> HRectList = new ObservableCollection<HRect>();


        public override string ToString()
        {
            return this.SizeName;
        }

        public void ChangeName(string showName)
        {
            this.SizeName = showName;
        }



        public void Copy(MeasureSize measureSize)
        {
            this.SizeAlgorithm = measureSize.SizeAlgorithm;
            this.HRectList.Clear();
            foreach (var item in measureSize.HRectList)
            {
                HRect hRect = new HRect();
                hRect.Copy(item);
                this.HRectList.Add(hRect);
            }
        }

        public void Init()
        {
            m_SizeAlgorithm = new SizeAlgorithm();
            Id = "";
            SizeName = "";
            HRectList = new ObservableCollection<HRect>();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MeasureSizes
    {


        //public static List<MeasureSize> GetMeasureSize(string xmlPath)
        //{
        //    System.Xml.Linq.XDocument xDoc = System.Xml.Linq.XDocument.Load("d:\\MeasureSizeS.xml");
        //    var measureSizeS = (from size in xDoc.Element("SizeS").Descendants("Size")
        //                        select new YSMS.DataManage.MeasureSize
        //                        {
        //                            AlgId = size.Attribute("AlgId").Value,
        //                            Id = size.Attribute("Id").Value,
        //                            Name = size.Attribute("Name").Value,
        //                            SizeNum = Convert.ToInt32(size.Attribute("SizeNum").Value),
        //                            Std = Convert.ToDouble(size.Attribute("Std").Value),
        //                            Up = Convert.ToDouble(size.Attribute("Up").Value),
        //                            Down = Convert.ToDouble(size.Attribute("Down").Value),
        //                            Compensate = Convert.ToDouble(size.Attribute("Compensate").Value),

        //                            HRectList = (
        //                                          from rect in size.Descendants("rect")
        //                                          select new YSMS.DataManage.HRect
        //                                          {
        //                                              Id = rect.Attribute("Id").Value,
        //                                              Row = Convert.ToDouble(rect.Attribute("Row").Value),
        //                                              Column = Convert.ToDouble(rect.Attribute("Column").Value),
        //                                              Phi = Convert.ToDouble(rect.Attribute("Phi").Value),
        //                                              Lenght1 = Convert.ToDouble(rect.Attribute("Lenght1").Value),
        //                                              Lenght2 = Convert.ToDouble(rect.Attribute("Lenght2").Value)

        //                                          }
        //                                        ).ToList()
        //                        }
        //                        ).ToList();

        //    return measureSizeS;
        //}

        public void GetHTupleSizes()
        {
            //HalconDotNet.HTuple ht_sizeS = new HalconDotNet.HTuple();
            //HalconDotNet.HTuple ht_sizeSNum = new HalconDotNet.HTuple();
            //foreach (var size in measureSizeS)
            //{
            //    //尺寸信息
            //    ht_sizeS = ht_sizeS.TupleConcat(size.AlgId, size.Id, size.Name, size.SizeNum, size.Std, size.Up, size.Down, size.Compensate);
            //    //矩形框信息            
            //    foreach (var rect in size.HRectList)
            //    {
            //        ht_sizeS = ht_sizeS.TupleConcat(rect.Id, rect.Row, rect.Column, rect.Phi, rect.Lenght1, rect.Lenght2);
            //    }
            //    ht_sizeS = ht_sizeS.TupleConcat("|");
            //    //个数
            //    ht_sizeSNum = ht_sizeSNum.TupleConcat(8 + size.HRectList.Count * 6 + 1);

            //}         
        }

        //XElement rootElment = new XElement("SizeS");

        //for(int i=1;i<10;i++)
        //{
        //    XElement chiCun = new XElement("Size", 
        //                                new XAttribute("AlgId","algId"+i),
        //                                new XAttribute("Id", i.ToString("000")),
        //                                new XAttribute("Name","名称"+i),
        //                                new XAttribute("Std",i*10),
        //                                new XAttribute("Up",0.05),
        //                                new XAttribute("Down",-0.05),
        //                                new XAttribute("Compensate", 0),
        //                                new XAttribute("SizeNum",1)
        //                                );




        //  chiCun.Add(new XElement("rect",
        //                           new XAttribute("Id", "R1" + i.ToString("000")),
        //                           new XAttribute("Row",100),
        //                           new XAttribute("Column",50),
        //                           new XAttribute("Phi",0.6),
        //                           new XAttribute("Lenght1",80),
        //                           new XAttribute("Lenght2",60)
        //                           ));

        //  chiCun.Add(new XElement("rect",
        //                       new XAttribute("Id", "R2" + i.ToString("000")),
        //                       new XAttribute("Row", 100),
        //                       new XAttribute("Column", 50),
        //                       new XAttribute("Phi", 0.6),
        //                       new XAttribute("Lenght1", 80),
        //                       new XAttribute("Lenght2", 60)
        //                       ));

        //  rootElment.Add(chiCun);
        //}

        //XDocument xDoc = new XDocument();

        //xDoc.Add(rootElment);

        //xDoc.Save("d:\\MeasureSizeS.xml");
    }
}
