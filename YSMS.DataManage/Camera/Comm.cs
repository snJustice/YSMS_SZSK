using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;

namespace YSMS.DataManage
{
    /// <summary>
    /// 通用类
    /// </summary>
   public static class Comm
    {

        /// <summary>
        /// 获取 HTuple 值
        /// </summary>
        /// <param name="type">string      int    double</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static HTuple GetHTuple(string type,string value)
        {           
                HTuple ht_value;
                switch (type.ToLower())
                {
                    case "int":
                        ht_value = Convert.ToInt32(value);
                        break;
                    case "double":
                        ht_value = Convert.ToDouble(value);
                        break;
                    default:
                        ht_value = value;
                        break;
                }
                return ht_value;           
        }
    }
}
