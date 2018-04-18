using System.Security.Cryptography;
using Types.Extensions;

namespace NumberTransfer.Services
{
    public class SimpleHashCalculation : IHashCalculation
    {
        public string Calculate(byte[] data)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(data).ByteArrayToString();
            }
        }
    }
}
