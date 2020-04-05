using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;

namespace YSMS.DataManage
{
    /// <summary>
    /// 
    /// </summary>
   public  class Para4HTuple
    {
        /// <summary>
        /// 参数编号 01 02 03
        /// </summary>
        public string ParaNo { get; set; }
        /// <summary>
        /// 参数名称 ExposureTimeRaw TriggerMode
        /// </summary>
        public string ParaName { get; set; }
        /// <summary>
        /// 参数类型 [int,double,string]
        /// </summary>
        public string ParaType { get; set; }
        /// <summary>
        /// 参数值  500  25.5   Off
        /// </summary>
        public string ParaValue { get; set; }

       /// <summary>
       /// 获取HTuple 值
       /// </summary>
        public HTuple GetHTuple
        {
            get
            {
                return Comm.GetHTuple(ParaType,ParaValue);             
            }
        }
    }

    /// <summary>
   /// Para4HTuple+显示名称、备注说明、默认值、操作等级
    /// </summary>
   public class Para7HTuple
   {
       /// <summary>
       /// 参数编号
       /// </summary>
       public string ParaNo { get; set; }
       /// <summary>
       /// ExposureTimeRaw TriggerMode
       /// </summary>
       public string ParaName { get; set; }
       /// <summary>
       /// 参数类型 [int,double,string]
       /// </summary>
       public string ParaType { get; set; }
       /// <summary>
       /// 参数值 
       /// </summary>
       public string ParaValue { get; set; }


       /// <summary>
       /// 曝光时间   触发模式
       /// </summary>
       public string ShowName { get; set; }
       /// <summary>
       /// 默认值 
       /// </summary>
       public string DefaultValue { get; set; }

       /// <summary>
       /// 备注说明
       /// </summary>
       public string Des { get; set; }


       /// <summary>
       /// 操作等级 1普通 2管理员 3超级管理员
       /// </summary>
       public int Level { get; set; }


       /// <summary>
       /// 获取HTuple 值
       /// </summary>
       public HTuple GetHTuple
       {
           get
           {
               return Comm.GetHTuple(ParaType, ParaValue);
           }
       }
   }
}
