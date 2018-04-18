using Google.Protobuf;

namespace NumberTransfer.Models
{
    public class BlockchainMetadata
    {
        public ByteString Hash { get; set; }
        public long Height { get; set; }
    }
}
