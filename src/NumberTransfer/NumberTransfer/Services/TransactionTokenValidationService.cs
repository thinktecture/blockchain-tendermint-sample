using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Options;
using NumberTransfer.Settings;
using NumberTransfer.Transactions;

namespace NumberTransfer.Services
{
    public class TransactionTokenValidationService
    {
        private readonly ApplicationSettings _settings;

        public TransactionTokenValidationService(IOptions<ApplicationSettings> settings)
        {
            _settings = settings.Value;
        }

        public void Validate(TransactionToken token, string issuer)
        {
            var certificate = _settings.SecuritySettings.PublicCertificates.SingleOrDefault(i =>
                i.GetNameInfo(X509NameType.SimpleName, false).Equals(issuer, StringComparison.OrdinalIgnoreCase));

            if (certificate == null)
            {
                return;
            }

            token.Validate(certificate);
        }
    }
}
