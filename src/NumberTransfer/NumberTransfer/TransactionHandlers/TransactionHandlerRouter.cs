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
        private readonly ILogger<TransactionHandlerRouter> _logger;

        public TransactionHandlerRouter(TransactionHandlerFactory transactionHandlerFactory,
            TransactionSerializerSettings transactionSerializerSettings,
            ILogger<TransactionHandlerRouter> logger)
        {
            _transactionHandlerFactory = transactionHandlerFactory;
            _transactionSerializerSettings = transactionSerializerSettings;
            _logger = logger;
        }


        public Task<ResponseCheckTx> RouteCheckTx(RequestCheckTx request, ServerCallContext context)
        {
            var data = ResolveRequestTx(request.Tx);
            var handler = _transactionHandlerFactory.CreateHandlerFor(data.Payload);
            _logger.LogInformation($"Handling CheckTx {data.Payload.GetType()} with handler {handler.GetType()}");
            return handler.CheckTx(data.TransactionToken, data.Payload, request, context);
        }

        public Task<ResponseDeliverTx> RouteDeliverTx(RequestDeliverTx request, ServerCallContext context)
        {
            var data = ResolveRequestTx(request.Tx);
            var handler = _transactionHandlerFactory.CreateHandlerFor(data.Payload);
            _logger.LogInformation($"Handling DeliverTx {data.Payload.GetType()} with handler {handler.GetType()}");
            return handler.DeliverTx(data.TransactionToken, data.Payload, request, context);
        }

        private (TransactionToken TransactionToken, dynamic Payload) ResolveRequestTx(ByteString byteString)
        {
            var transactionToken = TransactionToken.FromByteString(byteString);

            var baseTransaction = JsonConvert.DeserializeObject<BaseTransaction>(Encoding.UTF8.GetString(transactionToken.Data), _transactionSerializerSettings);
            dynamic payload = Convert.ChangeType(baseTransaction, baseTransaction.GetType());
            return (transactionToken, payload);
        }

    }
}
