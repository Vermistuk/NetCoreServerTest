using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerA.Clients
{
    internal sealed class ServerBClient : SslClient
    {
        public ServerBClient(SslContext context, string address, int port) : base(context, address, port) { }

        public void DisconnectAndStop()
        {
            DisconnectAsync();
            while (IsConnected)
                Thread.Yield();
        }

        protected override void OnConnecting()
        {
        }

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

            Console.WriteLine($"ServerBClient received {text}");

            Console.WriteLine("ServerBClient forwarding through SessionA");
            
        }

        protected override void OnError(SocketError error)
        {
        }
    }
}
