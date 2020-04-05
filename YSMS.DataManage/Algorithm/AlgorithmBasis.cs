using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSMS.DataManage
{
    /// <summary>
    /// 算法基类
    /// </summary>
    public class AlgorithmBasis
    {
        public AlgorithmBasis() { }

        /// <summary>
        /// 算法编号
        /// </summary>
        public int m_AlgId { get; set; }
        /// <summary>
        /// 算法名称
        /// </summary>
        public string m_AlgName { get; set; }

        public override string ToString()
        {
            return m_AlgName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;

            return equal((AlgorithmBasis)obj);
        }

        public bool equal(AlgorithmBasis obj)
        {
            return obj.m_AlgId == this.m_AlgId;
        }
        public override int GetHashCode()
        {
            return m_AlgId.GetHashCode();
        }
    }
}
