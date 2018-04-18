using System;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NumberTransfer.Transactions;
using Types;

namespace NumberTransfer.TransactionHandlers
{
    public class TransactionHandlerRouter
    {
        private readonly TransactionHandlerFactory _transactionHandlerFactory;
        private readonly TransactionSerializerSettings _transactionSerializerSettings;
        private readonly BlockHandler _blockHandler;
        private readonly ILogger<TransactionHandlerRouter> _logger;

        public TransactionHandlerRouter(TransactionHandlerFactory transactionHandlerFactory,
            TransactionSerializerSettings transactionSerializerSettings,
            BlockHandler blockHandler,
            ILogger<TransactionHandlerRouter> logger)
        {
            _transactionHandlerFactory = transactionHandlerFactory;
            _transactionSerializerSettings = transactionSerializerSettings;
            _blockHandler = blockHandler;
            _logger = logger;
        }

        public Task<ResponseCheckTx> RouteCheckTx(RequestCheckTx request, ServerCallContext context)
        {
            var resolved = ResolveTransactionHandler(() => request.Tx);
            return Handle(resolved.Handler, resolved.Payload,
                (handler, payload) => handler.CheckTx(resolved.TransactionToken, payload, request, context));
        }

        public Task<ResponseDeliverTx> RouteDeliverTx(RequestDeliverTx request, ServerCallContext context)
        {
            var resolved = ResolveTransactionHandler(() => request.Tx);
            return Handle(resolved.Handler, resolved.Payload,
                (handler, payload) => handler.DeliverTx(resolved.TransactionToken, payload, request, context));
        }

        private (ITransactionHandler Handler, TransactionToken TransactionToken, BaseTransaction Payload) ResolveTransactionHandler(Func<ByteString> byteStringAccessor)
        {
            var byteString = byteStringAccessor();
            var transactionToken = TransactionToken.FromByteString(byteString);

            var payload = JsonConvert.DeserializeObject<BaseTransaction>(Encoding.UTF8.GetString(transactionToken.Data), _transactionSerializerSettings);
            return (_transactionHandlerFactory.CreateHandlerFor(payload), transactionToken, payload);
        }

        private Task<T> Handle<T>(ITransactionHandler handler, BaseTransaction payload, Func<ITransactionHandler, BaseTransaction, Task<T>> handlerAction)
            where T : class, new()
        {
            if (handler == null)
            {
                _logger.LogWarning($"No handler found");
                return Task.FromResult(new T());
            }

            _logger.LogInformation($"Handling {payload.GetType()} with handler {handler.GetType()}");
            return handlerAction(handler, payload);
        }
    }
}
