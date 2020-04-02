﻿
using SuperSocket.ProtoBase;

namespace YSMS_SZSK.Utils.Communication.TCP_Client.DSocket.DataFilter
{
    class DataReceiveFilter : IReceiveFilter<DataPackageInfo>
    {
        //three filter
        private  IReceiveFilter<DataPackageInfo> _fixedHeaderReceiveFilter;
        private  IReceiveFilter<DataPackageInfo> _fixedSizeReceiveFilter;
        private  IReceiveFilter<DataPackageInfo> _terminatorReceiveFilter;

        public DataReceiveFilter()
        {   
            _fixedHeaderReceiveFilter = new FixedHeaderDataReceiveFilter(this);
            _terminatorReceiveFilter = new TerminatorDataReceiveFilter(this);
        }

        public DataPackageInfo Filter(BufferList data, out int rest)
        {
            
            rest = data.Total;
            //according to the Setting,choose  specified filter
            if (false)
            {
                //fixed length filter
                _fixedSizeReceiveFilter = new FixedSizeDataReceiveFilter(this, rest);
                NextReceiveFilter = _fixedSizeReceiveFilter;
            }

            else 
            {
                //Terminator Filter
                NextReceiveFilter = _terminatorReceiveFilter;
            }
                


            return null;
        }

        public void Reset()
        {
            
        }

        public FilterState State { get; }
        public IReceiveFilter<DataPackageInfo> NextReceiveFilter { get; private set; }
    }
}
