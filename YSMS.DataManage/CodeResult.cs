using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSMS.DataManage
{
    public class CodeResult
    {
        public double  ImageCode = 0;

        public bool result = false;
        // 20200327
        //public bool result = true;

        public int StationCount = 0;

        public List<int> NGStationList = new List<int>(); 

        public CodeResult copy()
        {
            CodeResult cr = new CodeResult();
            cr.ImageCode = this.ImageCode;
            cr.result = this.result;
            cr.StationCount = this.StationCount;
            cr.NGStationList = new List<int>();
            foreach (var v in this.NGStationList)
            {
                cr.NGStationList.Add(v);
            }
            return cr;
        }
    }
}
