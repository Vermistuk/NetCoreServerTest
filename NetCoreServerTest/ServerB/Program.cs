using System.Net;

namespace ServerB
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await StartServer();
        }

        public static async Task StartServer()
        {
            var ip = "127.0.0.1";
            var port = 13037;

            var loginServer = new Server.ServerB(IPAddress.Any, port);
            loginServer.Start();

            while (true)
            {
                await Task.Delay(1000);
            }
        }
    }
}
