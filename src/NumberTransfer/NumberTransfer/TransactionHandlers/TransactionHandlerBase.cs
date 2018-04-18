using System.Threading.Tasks;
using Grpc.Core;
using NumberTransfer.Transactions;
using Types;

namespace NumberTransfer.TransactionHandlers
{
    public abstract class TransactionHandlerBase<T> : ITransactionHandler<T>
        where T : BaseTransaction
    {
        public async Task<ResponseCheckTx> CheckTx(TransactionToken transactionToken, BaseTransaction data,
            RequestCheckTx request, ServerCallContext context)
        {
            if (!(data is T payload))
            {
                return ResponseHelper.Check.NoPayload();
            }

            return await CheckTx(transactionToken, payload, request, context).ConfigureAwait(false);
        }

        public async Task<ResponseDeliverTx> DeliverTx(TransactionToken transactionToken, BaseTransaction data,
            RequestDeliverTx request, ServerCallContext context)
        {
            if (!(data is T payload))
            {
                return ResponseHelper.Deliver.NoPayload();
            }

            return await DeliverTx(transactionToken, payload, request, context).ConfigureAwait(false);
        }

        protected abstract Task<ResponseCheckTx> CheckTx(TransactionToken transactionToken, T payload,
            RequestCheckTx request,
            ServerCallContext context);

        protected abstract Task<ResponseDeliverTx> DeliverTx(TransactionToken transactionToken, T payload,
            RequestDeliverTx request, ServerCallContext context);
    }
}
