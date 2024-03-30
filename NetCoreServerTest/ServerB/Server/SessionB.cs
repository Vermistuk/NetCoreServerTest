using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerB.Server
{
    internal sealed class SessionB : SslSession
    {
        public SessionB(SslServer server) : base(server) { }

        protected override void OnConnected()
        {
        }

        protected override void OnHandshaked()
        {
        }

        protected override void OnDisconnected()
        {
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            var response = new ReadOnlySpan<byte>(buffer, (int)offset, (int)size);
            var text = Encoding.UTF8.GetString(response);
            Console.WriteLine($"SessionB received: {text}");

            Console.WriteLine("SessionB responding Pong!");
            Send("Pong");
        }

        protected override void OnError(SocketError error)
        {
        }
    }
}
