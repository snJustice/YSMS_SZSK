using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;

namespace YSMS.DataManage
{
    /// <summary>
    /// 报警信息
    /// </summary>
    public class AlarmInfo
    {

        /// <summary>
        /// 报警编码器值
        /// </summary>
        public double  AlarmCode;

        /// <summary>
        /// 报警延时时间
        /// </summary>
        public int DelayTime;

        /// <summary>
        /// 报警时间
        /// </summary>
        public DateTime AlarmTime;

        /// <summary>
        /// 通道号
        /// </summary>
        public int ChannelNo;

        /// <summary>
        /// 工位号
        /// </summary>
        public int StationNo;

        /// <summary>
        /// 报警类型
        /// </summary>
        public AlarmType AlarmType;

        /// <summary>
        /// 报警图片路径
        /// </summary>
        public string AlarmImagePath;

        
    }
}
