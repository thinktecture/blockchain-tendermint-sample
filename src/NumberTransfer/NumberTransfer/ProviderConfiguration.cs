using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NumberTransfer.Models;
using NumberTransfer.QueryProcessing;
using NumberTransfer.Repositories;
using NumberTransfer.Services;
using NumberTransfer.Settings;
using NumberTransfer.TransactionHandlers;
using NumberTransfer.Transactions;

namespace NumberTransfer
{
    public static class ProviderConfiguration
    {
        public static ServiceProvider Provide(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<Application>();
            serviceCollection.AddTransient<ABCIConnector>();
            serviceCollection.AddTransient<TransactionSerializerSettings>();

            ConfigureLogging(serviceCollection);
            ConfigureSettings(serviceCollection, args);
            ConfigureServices(serviceCollection);

            return serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ICallNumberRepository, InMemoryCallNumberRepository>();
            serviceCollection.AddTransient<TransactionTokenValidationService>();
            serviceCollection.AddTransient<IHashCalculation, SimpleHashCalculation>();

            ConfigureTransactionHandlers(serviceCollection);
            ConfigureQueryProcessing(serviceCollection);
        }

        private static void ConfigureQueryProcessing(ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<QueryProcessor>();
            serviceCollection.AddTransient<IQueryHandler, DumpRepositoryHandler>();
            serviceCollection.AddTransient<IQueryHandler, OpenTransfersHandler>();
        }

        private static void ConfigureTransactionHandlers(ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<TransactionHandlerFactory>();
            serviceCollection.AddTransient<ITransactionHandler<CreateNumber>, CreateNumberHandler>();
            serviceCollection.AddTransient<ITransactionHandler<ConfirmTransferRequest>, ConfirmTransferRequestHandler>();
            serviceCollection.AddTransient<ITransactionHandler<DenyTransferRequest>, DenyTransferRequestHandler>();
            serviceCollection.AddTransient<ITransactionHandler<RequestTransfer>, RequestTransferHandler>();
            serviceCollection.AddSingleton<TransactionHandlerRouter>();

            serviceCollection.AddTransient<BlockHandler>();
            serviceCollection.AddSingleton<BlockchainMetadata>();
        }

        private static void ConfigureSettings(ServiceCollection serviceCollection, string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddEnvironmentVariables()
                .AddJsonFile("app-settings.json")
                .AddCommandLine(args)
                .Build();

            serviceCollection.AddOptions();
            serviceCollection.Configure<ApplicationSettings>(configuration);
        }

        private static void ConfigureLogging(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(new LoggerFactory()
                .AddDebug()
                .AddConsole()
            );
            serviceCollection.AddLogging();
        }
    }
}
