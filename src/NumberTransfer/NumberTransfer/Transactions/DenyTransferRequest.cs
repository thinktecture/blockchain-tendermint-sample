using Newtonsoft.Json;

namespace NumberTransfer.Transactions
{
    public class DenyTransferRequest : BaseTransaction
    {
        [JsonProperty("pn")]
        public string PhoneNumber { get; set; }

        [JsonProperty("no")]
        public string NewOwner { get; set; }
    }
}
