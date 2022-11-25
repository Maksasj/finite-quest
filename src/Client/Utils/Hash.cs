using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Client.Utils
{
    public static class Hash
    {
        public static string hash256(string inputString)
        {
            byte[] plainHash = (new SHA256Managed()).ComputeHash(Encoding.UTF8.GetBytes(inputString));

            string hashValue = BitConverter.ToString(plainHash);

            return hashValue.Replace("-", String.Empty).ToLower();
        }
    }
}
