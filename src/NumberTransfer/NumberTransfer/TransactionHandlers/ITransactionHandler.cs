using System.Threading.Tasks;
using Grpc.Core;
using NumberTransfer.Transactions;
using Types;

namespace NumberTransfer.TransactionHandlers
{
    public interface ITransactionHandler<in T>
    {
        Task<ResponseCheckTx> CheckTx(TransactionToken transactionToken, T data, RequestCheckTx request, ServerCallContext context);
        Task<ResponseDeliverTx> DeliverTx(TransactionToken transactionToken, T data, RequestDeliverTx request, ServerCallContext context);
    }
}
