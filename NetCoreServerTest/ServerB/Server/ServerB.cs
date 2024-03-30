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
    internal sealed class ServerB : TcpServer
    {
        public ServerB(IPAddress address, int port) : base(address, port) { }

        protected override TcpSession CreateSession() { return new SessionB(this); }

        protected override void OnError(SocketError error)
        {
        }
    }
}
