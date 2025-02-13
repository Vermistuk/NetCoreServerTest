﻿using Common;
using NetCoreServer;
using ServerA.Clients;
using System.Net;
using System.Security.Authentication;

namespace ServerA
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await StartServer();
        }

        public static async Task StartServer()
        {
            var serverBClient = MakeServerBClient();

            var dummyCert = CertBuilder.GenerateSelfSignedCertificate(CertBuilder.ServerASubject);
            var sslContext = new SslContext(SslProtocols.Tls12, dummyCert, (sender, certificate, chain, sslPolicyErrors) => true);

            var ip = "127.0.0.1";
            var port = 13001;

            var serverA = new Server.ServerA(sslContext, IPAddress.Any, port, serverBClient);
            serverA.Start();

            while (true)
            {
                await Task.Delay(1000);
            }
        }

        public static ServerBClient MakeServerBClient()
        {
            var dummyCert = CertBuilder.GenerateSelfSignedCertificate(CertBuilder.ServerBSubject);
            var sslContext = new SslContext(SslProtocols.Tls12, dummyCert, (sender, certificate, chain, sslPolicyErrors) => true);

            var client = new ServerBClient(sslContext, "127.0.0.1", 13037);

            client.Connect();
            return client;
        }
    }
}
