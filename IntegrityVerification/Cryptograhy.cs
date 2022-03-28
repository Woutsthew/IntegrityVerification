using System.Security.Cryptography;
using System.Text;

namespace IntegrityVerification
{
    static class Cryptograhy
    {
        public static string Sha256(byte[] rString)
        {
            var managed = new SHA256Managed();
            var hash = new StringBuilder();

            byte[] crypto = managed.ComputeHash(rString);

            foreach (byte theByte in crypto)
                hash.Append(theByte.ToString("x2"));

            return hash.ToString();
        }

        public static string Sha256(string rString)
        {
            return Sha256(Encoding.UTF8.GetBytes(rString));
        }
    }
}
