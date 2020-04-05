using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSMS.DataManage
{
    /// <summary>
    /// 通道亮度
    /// </summary>
    public class ChannelBrightness : IComparable
    {
        /// <summary>
        /// 控制器编号
        /// </summary>
        public string ControlNo { get; set; }

        /// <summary>
        /// 通道编号 [1,2]
        /// </summary>
        public string ChannelNo { get; set; }

        /// <summary>
        /// 亮度
        /// </summary>
        public int Brightness { get; set; }

        /// <summary>
        /// 上一次的亮度
        /// </summary>
        public int LastBrightness { get; set; }


        public override int GetHashCode()
        {
            return (ControlNo + ChannelNo).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            return Equals((ChannelBrightness)obj);
        }

        public bool Equals(ChannelBrightness obj)
        {
            return (this.ControlNo == obj.ControlNo + obj.ChannelNo) && (this.ChannelNo == obj.ChannelNo);
        }

        /// <summary>
        /// 比较
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(ChannelBrightness x, ChannelBrightness y)
        {
            int flag = x.ControlNo.CompareTo(y.ControlNo);

            if (flag == 0)
            {
                flag = x.ChannelNo.CompareTo(y.ChannelNo);
            }

            return flag;

        }

        public int CompareTo(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return -1;

            ChannelBrightness test = obj as ChannelBrightness;
            int flag = this.ControlNo.CompareTo(test.ControlNo);
            if (flag == 0)
            {
                flag = this.ChannelNo.CompareTo(test.ChannelNo);
            }
            return flag;
        }
    }
}
