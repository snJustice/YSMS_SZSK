using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace YSMS.DataManage
{
    /// <summary>
    /// 产品类
    /// </summary>
    public class Product
    {
        private int m_StationNum = 6;

        public string ProductName = string.Empty;


        public string  BatchRatio = "1";
        //单元长度
        public string BatchUnitLen = "1";

        /// <summary>
        ///隔多少个单元，一个异型模板  Qiyi Li 20200307
        /// </summary>
        public int IntervalV = 0;

        /// <summary>
        ///外部触发多少次拍照  Qiyi Li 20200311
        /// </summary>
        public int TriggerInterval = 5;

        //触发模式 软件触发0 硬件触发1
        public int CameraPhotoType = 0;


        //通讯信息
        //合格满料数
        public int OKFullNum = 50;
        //不合格满料数
        public int NGFullNum = 50;

        //不合格几次报警
        public int NGAlarmNumber = 10;


        //增加料盒选择功能
        public int BoxType = 0;
        
        /// <summary>
        /// 工位列表
        /// </summary>
        public ObservableCollection<Station> StationList = new ObservableCollection<Station>();


        List<bool> StationBolenList = new List<bool>();



        //public Product(List<bool> StationOpenList)
        //{
        //    StationList = new ObservableCollection<Station>();
        //    for (int i = 0; i < m_StationNum; i++)
        //    {
        //        StationList.Add(new Station(i + 1, StationOpenList[i]));
        //        //_StationBoolenDictionary.Add(i, StationOpenList[i]);
        //    }
        //}

        public Product(int ChannelNo, int StationNum)
        {
            StationList = new ObservableCollection<Station>();
            for (int i = 0; i < m_StationNum; i++)
            {
                bool StationEnable = false;
                if (i < StationNum)
                {
                    StationEnable = true;
                }
                StationList.Add(new Station(ChannelNo, i + 1, StationEnable));
                //_StationBoolenDictionary.Add(i, StationOpenList[i]);
            }
        }

        public Product()
        { }

        public List<bool> GetList()
        {
            StationBolenList.Clear();
            foreach (var item in this.StationList)
            {
                this.StationBolenList.Add(item.IsEnable);
            }
            return this.StationBolenList;
        }
    }
}
