using Common;
using NetCoreServer;
using System.Net;
using System.Security.Authentication;

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
            var dummyCert = CertBuilder.GenerateSelfSignedCertificate(CertBuilder.ServerBSubject);
            var sslContext = new SslContext(SslProtocols.Tls12, dummyCert, (sender, certificate, chain, sslPolicyErrors) => true);

            var ip = "127.0.0.1";
            var port = 13037;

            var loginServer = new Server.ServerB(sslContext, IPAddress.Any, port);
            loginServer.Start();

            while (true)
            {
                await Task.Delay(1000);
            }
        }
    }
}
