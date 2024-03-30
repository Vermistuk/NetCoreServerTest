using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServerB.Server
{
    internal sealed class ServerB : SslServer
    {
        public ServerB(SslContext context, IPAddress address, int port) : base(context, address, port) { }

        protected override SslSession CreateSession() { return new SessionB(this); }

        protected override void OnError(SocketError error)
        {
        }
    }
}
