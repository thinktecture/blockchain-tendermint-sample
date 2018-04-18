using Newtonsoft.Json;

namespace NumberTransfer.Transactions
{
    public class CreateNumber : BaseTransaction
    {
        [JsonProperty("pn")]
        public string PhoneNumber { get; set; }

        [JsonProperty("o")]
        public string Owner { get; set; }
    }
}
