using System;

namespace NumberTransfer.TransactionHandlers
{
    public class TransactionHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public TransactionHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ITransactionHandler<T> CreateHandlerFor<T>(T payload)
        {
            var handler = _serviceProvider
                .GetService(typeof(ITransactionHandler<T>))
                as ITransactionHandler<T>;
            return handler;
        }

    }
}
