using System.Threading.Tasks;
using Grpc.Core;
using NumberTransfer.Transactions;
using Types;

namespace NumberTransfer.TransactionHandlers
{
    public interface ITransactionHandler
    {
        Task<ResponseCheckTx> CheckTx(TransactionToken transactionToken, BaseTransaction data, RequestCheckTx request, ServerCallContext context);
        Task<ResponseDeliverTx> DeliverTx(TransactionToken transactionToken, BaseTransaction data, RequestDeliverTx request, ServerCallContext context);
    }

    public interface ITransactionHandler<T> : ITransactionHandler
        where T: BaseTransaction 
    {
        // Marker interface
    }
}
