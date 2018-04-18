using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using NumberTransfer.Models;
using Types;

namespace NumberTransfer.QueryProcessing
{
    public class QueryProcessor
    {
        private readonly IEnumerable<IQueryHandler> _queryHandlers;
        private readonly BlockchainMetadata _blockchainMetadata;

        public QueryProcessor(IEnumerable<IQueryHandler> queryHandlers, BlockchainMetadata blockchainMetadata)
        {
            _queryHandlers = queryHandlers;
            _blockchainMetadata = blockchainMetadata;
        }

        public async Task<ResponseQuery> Process(RequestQuery query, ServerCallContext context)
        {
            var possibleHandler = _queryHandlers.SingleOrDefault(handler => handler.Path == query.Path);

            if (possibleHandler != null)
            {
                var result = await possibleHandler.Handle(query, context);
                result.Height = _blockchainMetadata.Height;
                return result;
            }

            return new ResponseQuery()
            {
                Code = (uint) CodeType.Ok,
                Log = $"No handler found for {query.Path}"
            };
        }
    }
}
