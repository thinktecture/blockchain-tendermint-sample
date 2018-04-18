using Newtonsoft.Json;

namespace NumberTransfer.Transactions
{
    public class TransactionSerializerSettings : JsonSerializerSettings
    {
        public TransactionSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All;
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple;
        }
    }
}
