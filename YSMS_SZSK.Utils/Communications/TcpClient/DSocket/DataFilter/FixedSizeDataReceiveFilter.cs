using SuperSocket.ProtoBase;
using System;
using System.Text;

namespace YSMS_SZSK.Utils.Communication.TCP_Client.DSocket.DataFilter

{
    class FixedSizeDataReceiveFilter : FixedSizeReceiveFilter<DataPackageInfo>
    {
        private readonly DataReceiveFilter _switchFilter;
        public FixedSizeDataReceiveFilter(DataReceiveFilter filter,int size) :base(size)
        {
            _switchFilter = filter;
        }

        public override DataPackageInfo ResolvePackage(IBufferStream bufferStream)
        {
            var length = Convert.ToInt32(bufferStream.Length);
            var code = bufferStream.ReadString(length, Encoding.ASCII);
            var responseInfo = new DataPackageInfo(code);
            NextReceiveFilter = _switchFilter;
            return responseInfo;
        }
    }
}
