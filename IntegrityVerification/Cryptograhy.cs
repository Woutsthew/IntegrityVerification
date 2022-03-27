using System.Security.Cryptography;
using System.Text;

namespace IntegrityVerification
{
    public static class Cryptograhy
    {
        static public string Sha256(byte[] rString)
        {
            var managed = new SHA256Managed();
            var hash = new StringBuilder();

            byte[] crypto = managed.ComputeHash(rString);

            foreach (byte theByte in crypto)
                hash.Append(theByte.ToString("x2"));

            return hash.ToString();
        }
    }
}
