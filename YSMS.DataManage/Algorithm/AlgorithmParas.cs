using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSMS.DataManage
{
    /// <summary>
    /// 算法参数类
    /// </summary>
    public class AlgorithmParas
    {
        /// <summary>
        /// 参数名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 参数值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 标注
        /// </summary>
        public string Tip { get; set; }
        /// <summary>
        /// 是否高级参数
        /// </summary>
        public bool IsSenior { get; set; }

        public AlgorithmParas()
        {
        }

    }
}
