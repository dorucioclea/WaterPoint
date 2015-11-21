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
        public class HashTypes
        {
            public const string RowVersion = "fCZxDpLN";
        }

        public static string ToHashedString(this byte[] bytes, string type, object obj)
        {
            //var secondaryHashCode = obj.GetHashCode();

            //using (var sha1 = new SHA1CryptoServiceProvider())
            //{
            //    //versionbytes to hash
            //    var hashs = Convert.ToBase64String(sha1.ComputeHash(bytes));

            //    //type to version
            //    var typebytes = Encoding.UTF8.GetBytes(type);

            //    var segment1 = sha1.ComputeHash(typebytes)
            //}

            //return Convert.ToBase64String(hashBytes);
            //string hash;
            //using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
            //{
            //    hash = Convert.ToBase64String(sha1.ComputeHash(byteArray));
            //}

            throw new NotImplementedException();
        }
    }
}
