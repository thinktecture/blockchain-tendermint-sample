using Microsoft.Extensions.DependencyInjection;

namespace NumberTransfer
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ProviderConfiguration.Provide(args);

            var app = serviceProvider.GetService<Application>();
            app.Run();
        }
    }
}
