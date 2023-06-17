using System.Security.Cryptography;
using System.Text;

namespace FQ.Server
{
    [Serializable]
    public class PrivateKeyType
    {
        public string value { get; set; }

        public PrivateKeyType(string value)
        {
            this.value = value;
        }

        public static PrivateKeyType GenerateFromString(string rawKey)
        {
            StringBuilder hashedKey = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(rawKey));

                foreach (Byte b in result)
                    hashedKey.Append(b.ToString("x2"));
            }

            return new PrivateKeyType(hashedKey.ToString());
        }
    }
}
