using System;
using NumberTransfer.Transactions;

namespace NumberTransfer.TransactionHandlers
{
    public class TransactionHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public TransactionHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ITransactionHandler CreateHandlerFor<T>(T payload)
            where T : BaseTransaction
        {
            var type = typeof(ITransactionHandler<>).MakeGenericType(payload.GetType());
            return _serviceProvider.GetService(type) as ITransactionHandler;
        }
    }
}
