﻿using ServerA.Clients;
using System.Net;

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

            var ip = "127.0.0.1";
            var port = 13001;

            var serverA = new Server.ServerA(IPAddress.Any, port, serverBClient);
            serverA.Start();

            Console.WriteLine("ServerA Sending Ping!");
            serverBClient.Send("Ping");

            while (true)
            {
                await Task.Delay(1000);
            }
        }

        public static ServerBClient MakeServerBClient()
        {
            var client = new ServerBClient("127.0.0.1", 13037);

            client.Connect();
            return client;
        }
    }
}
