using SuperSocket.ProtoBase;

namespace YSMS_SZSK.Utils.Communication.TCP_Client.DSocket
{
    public class DataPackageInfo : IPackageInfo
    {
        public string Massage { get; set; }

        public DataPackageInfo(string _codeData)
        {
            Massage = _codeData;
        }
        


    }
}
