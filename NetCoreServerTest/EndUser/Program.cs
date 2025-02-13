﻿using Common;
using EndUser.Clients;
using NetCoreServer;
using System.Security.Authentication;

namespace EndUser
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("EndUser connecting");

            var dummyCert = CertBuilder.GenerateSelfSignedCertificate(CertBuilder.ServerASubject);
            var sslContext = new SslContext(SslProtocols.Tls12, dummyCert, (sender, certificate, chain, sslPolicyErrors) => true);

            var client = new ServerAClient(sslContext, "127.0.0.1", 13001);

            client.Connect();


            Console.WriteLine("EndUser connected");


            Console.WriteLine("EndUser sending Ping!");
            client.Send("Ping");

            while (true)
            {
                await Task.Delay(1000);
            }

        }
    }
}
