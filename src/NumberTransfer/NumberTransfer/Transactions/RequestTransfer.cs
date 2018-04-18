using System;
using Newtonsoft.Json;

namespace NumberTransfer.Transactions
{
    public class RequestTransfer : BaseTransaction
    {
        [JsonProperty("pn")]
        public string PhoneNumber { get; set; }

        [JsonProperty("co")]
        public string CurrentOwner { get; set; }

        [JsonProperty("no")]
        public string NewOwner { get; set; }

        [JsonProperty("s")]
        public DateTime TransferStarted { get; set; }
    }
}
