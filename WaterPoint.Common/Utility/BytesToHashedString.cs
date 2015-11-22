using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class ByteExtensions
    {
        public static string ToSha1(this byte[] bytes, string uniqueIdentifier)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                var typebytes = Encoding.UTF8.GetBytes(uniqueIdentifier);

                var bytesToUse = typebytes.Concat(bytes).ToArray();

                var sha1CryptedBytes = sha1.ComputeHash(bytesToUse);

                return Convert.ToBase64String(sha1CryptedBytes);
            }
        }
    }
}
