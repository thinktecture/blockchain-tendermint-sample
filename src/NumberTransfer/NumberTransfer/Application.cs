using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NumberTransfer.Settings;
using Types;

namespace NumberTransfer
{
    public class Application
    {
        private readonly ILogger _logger;
        private readonly ABCIConnector _abciConnector;
        private readonly ApplicationSettings _settings;

        public Application(ILogger<Application> logger, ABCIConnector abciConnector, IOptions<ApplicationSettings> settings)
        {
            _logger = logger;
            _abciConnector = abciConnector;
            _settings = settings.Value;

            ReadCertificates();
        }

        public void Run()
        {
            _logger.LogInformation($"Starting ABCI Application");

            var server = new Server()
            {
                Ports = { new ServerPort(_settings.BindSettings.Url, _settings.BindSettings.Port, ServerCredentials.Insecure) },
                Services = { ABCIApplication.BindService(_abciConnector) },
            };

            server.Start();

            _logger.LogInformation($"Server is up & running ({_settings.BindSettings.Url}:{_settings.BindSettings.Port})");

            ShutdownAwaiter();

            _logger.LogInformation("Shutting down...");
            server.ShutdownAsync().Wait();
        }

        private void ReadCertificates()
        {
            _logger.LogInformation($"Reading {_settings.SecuritySettings.PublicKeys.Length} public keys");

            _settings.SecuritySettings.PublicCertificates = new List<X509Certificate2>();

            foreach (var item in _settings.SecuritySettings.PublicKeys)
            {
                _logger.LogInformation($"Reading PublicKey of {item.Name}");
                _settings.SecuritySettings.PublicCertificates.Add(new X509Certificate2(Convert.FromBase64String(item.PublicKey)));
            }
        }

        private void ShutdownAwaiter()
        {
            var waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);

            Console.CancelKeyPress += (s, e) =>
            {
                e.Cancel = true;
                waitHandle.Set();
            };

            waitHandle.WaitOne();
        }
    }
}
