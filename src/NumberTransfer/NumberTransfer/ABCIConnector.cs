using System;
using System.Threading.Tasks;
using Grpc.Core;
using NumberTransfer.QueryProcessing;
using NumberTransfer.TransactionHandlers;
using Types;

namespace NumberTransfer
{
    public class ABCIConnector : ABCIApplication.ABCIApplicationBase
    {
        private readonly TransactionHandlerRouter _transactionHandlerRouter;
        private readonly QueryProcessor _queryProcessor;
        private readonly BlockHandler _blockHandler;

        public ABCIConnector(TransactionHandlerRouter transactionHandlerRouter, QueryProcessor queryProcessor, BlockHandler blockHandler)
        {
            _transactionHandlerRouter = transactionHandlerRouter;
            _queryProcessor = queryProcessor;
            _blockHandler = blockHandler;
        }

        public override Task<ResponseCheckTx> CheckTx(RequestCheckTx request, ServerCallContext context)
        {
            Console.WriteLine("CheckTx has been called.");
            return _transactionHandlerRouter.RouteCheckTx(request, context);
        }

        public override Task<ResponseBeginBlock> BeginBlock(RequestBeginBlock request, ServerCallContext context)
        {
            Console.WriteLine("BeginBlock has been called.");
            return _blockHandler.BeginBlock(request, context);
        }

        public override Task<ResponseCommit> Commit(RequestCommit request, ServerCallContext context)
        {
            Console.WriteLine("Commit has been called.");
            return _blockHandler.Commit(request, context);
        }

        public override Task<ResponseDeliverTx> DeliverTx(RequestDeliverTx request, ServerCallContext context)
        {
            Console.WriteLine("DeliverTx has been called.");
            return _transactionHandlerRouter.RouteDeliverTx(request, context);
        }

        public override Task<ResponseEcho> Echo(RequestEcho request, ServerCallContext context)
        {
            Console.WriteLine("Echo has been called.");
            return Task.FromResult(new ResponseEcho());
        }

        public override Task<ResponseEndBlock> EndBlock(RequestEndBlock request, ServerCallContext context)
        {
            Console.WriteLine("EndBlock has been called.");
            return _blockHandler.EndBlock(request, context);
        }

        public override Task<ResponseFlush> Flush(RequestFlush request, ServerCallContext context)
        {
            Console.WriteLine("RequestFlush has been called.");
            return Task.FromResult(new ResponseFlush());
        }

        public override Task<ResponseInfo> Info(RequestInfo request, ServerCallContext context)
        {
            Console.WriteLine("RequestInfo has been called.");
            return _blockHandler.Info(request, context);
        }

        public override Task<ResponseInitChain> InitChain(RequestInitChain request, ServerCallContext context)
        {
            Console.WriteLine("InitChain has been called.");
            return Task.FromResult(new ResponseInitChain());
        }

        public override Task<ResponseQuery> Query(RequestQuery request, ServerCallContext context)
        {
            Console.WriteLine("Query has been called.");
            return _queryProcessor.Process(request, context);
        }

        public override Task<ResponseSetOption> SetOption(RequestSetOption request, ServerCallContext context)
        {
            Console.WriteLine("SetOption has been called.");
            return Task.FromResult(new ResponseSetOption());
        }
    }
}
