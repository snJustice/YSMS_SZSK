using SuperSocket.ClientEngine;
using System;
using System.Net;
//using MiscUtil.Conversion;
using System.Text;
using System.Threading.Tasks;
using YSMS_SZSK.Utils.Communication.TCP_Client.DSocket.DataFilter;

namespace YSMS_SZSK.Utils.Communication.TCP_Client.DSocket
{
    public class TCPCommunication 
    {

        public event EventHandler Connected;

        private readonly EasyClient _tcpClient = new EasyClient();
        //private readonly EndianBitConverter _endianBitConverter;

        
        public string EndPoint { get; set; }
        public int Port { get; set; } = 51236;
        public bool IsConnected { get { return _tcpClient.IsConnected; } }

        public TCPCommunication(string ip,Action<DataPackageInfo> handler=null)
        {
            EndPoint = ip;
            
            //_endianBitConverter = new BigEndianBitConverter();

            _tcpClient.Connected += _tcpClient_Connected;

            _tcpClient.Initialize(new DataReceiveFilter(), response =>
            {
                
                if (response != null )
                {
                    handler(response);
                }
            });
        }

        private void _tcpClient_Connected(object sender, EventArgs e)
        {
            Connected?.Invoke(this, e);
        }

        public async Task<bool> ConnectAsync()
        {
              //_tcpClient.ConnectAsync(new IPEndPoint(IPAddress.Parse(EndPoint), Port));
            return await _tcpClient.ConnectAsync(new IPEndPoint(IPAddress.Parse(EndPoint), Port));
        }

        public void Close()
        {
            if (_tcpClient.IsConnected) _tcpClient.Close();
        }

        public void Send(string _message)
        {

            

            if (_tcpClient.IsConnected)
            {

                var messageByte = System.Text.ASCIIEncoding.ASCII.GetBytes(_message);
                int lengthMessage = messageByte.Length;
                byte[] sendMessageByte = new byte[lengthMessage + 2];
                sendMessageByte[0] = 02;

                for (int i = 1; i <= lengthMessage; i++)
                {
                    sendMessageByte[i] = messageByte[i - 1];
                }
                sendMessageByte[lengthMessage + 1] = 03;


               
                _tcpClient.Send(sendMessageByte);
                
            }
        }
    }
}
