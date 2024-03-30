using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ServerA.Clients;

namespace ServerA.Server
{
    internal sealed class ServerA : SslServer
    {
        public ServerA(SslContext context, IPAddress address, int port, ServerBClient serverBClient) : base(context, address, port) 
        {
            ServerBClient = serverBClient;
        }

        public ServerBClient ServerBClient; 

        protected override SslSession CreateSession() { return new SessionA(this); }

        protected override void OnError(SocketError error)
        {
        }
    }
}
