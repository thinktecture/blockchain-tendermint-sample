using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Google.Protobuf;
using Types.Extensions;

namespace NumberTransfer.Transactions
{
    public class TransactionToken
    {
        private bool _isValid;
        private byte[] _signature;
        private byte[] _data;

        public bool IsValid => _isValid;
        public byte[] Data => _data;

        public TransactionToken(byte[] data)
        {
            _data = data;
        }

        private TransactionToken()
        {
        }

        public static TransactionToken FromByteString(ByteString value)
        {
            var utf8String = value.ToStringUtf8();
            var tokenParts = utf8String.Split('.');

            var tokenResult = new TransactionToken();

            if (tokenParts.Length != 2)
            {
                return tokenResult;
            }

            tokenResult._data = Convert.FromBase64String(tokenParts[0]);
            tokenResult._signature = tokenParts[1].StringToByteArray();

            return tokenResult;
        }
        
        public void Validate(X509Certificate2 certificate)
        {
            var rsa = certificate.GetRSAPublicKey();
            _isValid = rsa.VerifyData(_data, _signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }

        public void Sign(X509Certificate2 certificate)
        {
            var rsa = certificate.GetRSAPrivateKey();
            _signature = rsa.SignData(_data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }

        public string ToTokenString()
        {
            if (_signature.Length == 0)
            {
                throw new Exception("Can't create a token string from an unsigned token");
            }

            var data = Convert.ToBase64String(_data);
            var signature = _signature.ByteArrayToString();

            return $"{data}.{signature}";
        }

        
    }
}
