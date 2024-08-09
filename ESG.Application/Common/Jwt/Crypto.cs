using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ESG.Application.Common.Jwt
{
    public static class Crypto
    {
        public static byte[] GenerateHash(string input, string salt)
        {
            var saltBytes = Encoding.UTF8.GetBytes(salt);
            return new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(input), saltBytes, 10000).GetBytes(saltBytes.Length + 24);
        }

        public static byte[] GenerateHash(string input, Guid salt)
        {
            return GenerateHash(input, salt.ToString());
        }

        public static (byte[] Hash, Guid Salt) GenerateHash(string input)
        {
            var salt = Guid.NewGuid();
            return (GenerateHash(input, salt.ToString()), salt);
        }

        public static bool Equals(string input, Guid salt, byte[] compare)
        {
            var compareThis = GenerateHash(input, salt.ToString());

            if (compare.Length == compareThis.Length)
            {
                var sLength = Encoding.UTF8.GetBytes(salt.ToString()).Length;
                compare = compare.Skip(sLength).ToArray();
                compareThis = compareThis.Skip(sLength).ToArray();

                for (int i = 0; i < compare.Length; i++)
                {
                    if (compare[i] != compareThis[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
