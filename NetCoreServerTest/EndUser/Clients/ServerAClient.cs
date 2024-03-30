using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EndUser.Clients
{
    internal sealed class ServerAClient : SslClient
    {
        public ServerAClient(SslContext context, string address, int port) : base(context, address, port) { }

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
        }

        protected override void OnError(SocketError error)
        {
        }
    }
}
