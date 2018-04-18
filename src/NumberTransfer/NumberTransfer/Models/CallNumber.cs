using System;

namespace NumberTransfer.Models
{
    public class CallNumber
    {
        public string PhoneNumber { get; set; }
        public string Owner { get; set; }
        public DateTime? TransferRequestStarted { get; set; }
        public string TransferRequestedTo { get; set; }
    }
}
