using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Common
{
    public class CertBuilder
    {
        public static string CertPW = "yolo";
        public static string ServerASubject = "CN=NetCoreServerTestServerA";
        public static string ServerBSubject = "CN=NetCoreServerTestServerB";

        public static X509Certificate2 GenerateSelfSignedCertificate(string subjectName)
        {
            using (RSA rsa = RSA.Create(2048))
            {
                var certRequest = new CertificateRequest(subjectName, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                var cert = certRequest.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddDays(1));

                return new X509Certificate2(cert.Export(X509ContentType.Pfx, CertPW), CertPW, X509KeyStorageFlags.Exportable);
            }
        }
    }
}
