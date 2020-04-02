using SuperSocket.ProtoBase;
using System;
using System.Text;

namespace YSMS_SZSK.Utils.Communication.TCP_Client.DSocket.DataFilter

{
    class FixedHeaderDataReceiveFilter : FixedHeaderReceiveFilter<DataPackageInfo>
    {

        private readonly DataReceiveFilter _switchFilter;
        public FixedHeaderDataReceiveFilter(DataReceiveFilter filter) :base(9)
        {
            _switchFilter = filter;
        }

        public override DataPackageInfo ResolvePackage(IBufferStream bufferStream)
        {
            var length = Convert.ToInt32( bufferStream.Length);
            var code = bufferStream.ReadString(length, Encoding.ASCII);
            var responseInfo = new DataPackageInfo(code);
            return responseInfo;
        }

        protected override int GetBodyLengthFromHeader(IBufferStream bufferStream, int length)
        {
            return bufferStream.Skip(length - 1).ReadByte();
        }
    }
}
