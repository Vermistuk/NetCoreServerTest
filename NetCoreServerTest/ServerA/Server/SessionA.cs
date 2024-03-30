using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerA.Server
{
    internal sealed class SessionA : TcpSession
    {
        public SessionA(TcpServer server) : base(server) { }

        protected override void OnConnected()
        {
        }

        protected override void OnDisconnected()
        {
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            var response = new ReadOnlySpan<byte>(buffer, (int)offset, (int)size);
            var text = Encoding.UTF8.GetString(response);
            Console.WriteLine($"SessionA received: {text}");
        }

        protected override void OnError(SocketError error)
        {
        }
    }
}
