using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Google.Protobuf;
using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NumberTransfer.Settings;
using NumberTransfer.TransactionHandlers;
using NumberTransfer.Transactions;
using Types;

namespace NumberTransfer.Test
{
    [TestClass]
    public class TransactionHandlerFactoryTests
    {
        private ServiceProvider _serviceProvider;
        private TransactionHandlerFactory _factory;

        [TestInitialize]
        public void Initialize()
        {
            _serviceProvider = ProviderConfiguration.Provide(new string[0]);
            _factory = new TransactionHandlerFactory(_serviceProvider);
        }

        [TestMethod]
        public void ShouldGetHandlerForCreateNumber()
        {
            var payload = new CreateNumber();
            var handler = _factory.CreateHandlerFor(payload);
            Assert.IsNotNull(handler);
        }

        [TestMethod]
        public void ShouldGetHandlerForCreateNumberFromBaseTransaction()
        {
            var baseTransaction = new CreateNumber() as BaseTransaction;
            dynamic payload = Convert.ChangeType(baseTransaction, baseTransaction.GetType());
            var handler = _factory.CreateHandlerFor(payload);
            Assert.IsNotNull(handler);
        }

        [TestMethod]
        public void ShouldGetTransactionHandlerRouter()
        {
            var transactionHandlerRouter =_serviceProvider.GetService(typeof(TransactionHandlerRouter)) as TransactionHandlerRouter;
            Assert.IsNotNull(transactionHandlerRouter);
        }

        [TestMethod]
        public void ShouldRouteTransaction()
        {
            var transactionHandlerRouter = _serviceProvider.GetService(typeof(TransactionHandlerRouter)) as TransactionHandlerRouter;

            // initialize certificates list
            if (_serviceProvider.GetService(typeof(IOptions<ApplicationSettings>)) is IOptions<ApplicationSettings> applicationSettings)
                applicationSettings.Value.SecuritySettings.PublicCertificates = new List<X509Certificate2>();

            var transaction = new CreateNumber {Owner = "A", PhoneNumber = "1", TransactionTime = DateTime.Now};
            var json = JsonConvert.SerializeObject(transaction, new TransactionSerializerSettings());
            var token = new TransactionToken(Encoding.UTF8.GetBytes(json));
            // fake signing
            var signatureField = typeof(TransactionToken).GetField("_signature", BindingFlags.NonPublic | BindingFlags.Instance);
            signatureField.SetValue(token, Encoding.UTF8.GetBytes("1234"));

            var request = new RequestCheckTx {  Tx = ByteString.CopyFromUtf8(token.ToTokenString()) };

            // fake context
            var ctor = typeof(ServerCallContext).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).First();
            var context = (ServerCallContext)ctor.Invoke(new object[] { null, "TX", "localhost", DateTime.Now, new Metadata(), CancellationToken.None, null, null });

            var expected = ResponseHelper.Check.Unauthorized();
            var responseCheckTx = transactionHandlerRouter?.RouteCheckTx(request, context).Result;
            Assert.AreEqual(expected, responseCheckTx);
        }


    }
}
