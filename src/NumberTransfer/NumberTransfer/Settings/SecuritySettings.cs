using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace NumberTransfer.Settings
{
    public class SecuritySettings
    {
        public SecuritySettingsItem[] PublicKeys { get; set; }

        public IList<X509Certificate2> PublicCertificates { get; set; }
    }

    public class SecuritySettingsItem
    {
        public string Name { get; set; }
        public string PublicKey { get; set; }
    }
}
