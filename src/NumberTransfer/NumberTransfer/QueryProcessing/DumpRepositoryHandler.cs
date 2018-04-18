using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Newtonsoft.Json;
using NumberTransfer.Models;
using NumberTransfer.Repositories;
using Types;
using Types.Extensions;

namespace NumberTransfer.QueryProcessing
{
    public class DumpRepositoryHandler : IQueryHandler
    {
        private readonly ICallNumberRepository _callNumberRepository;
        public string Path { get; } = "dump-repository";

        public DumpRepositoryHandler(ICallNumberRepository callNumberRepository)
        {
            _callNumberRepository = callNumberRepository;
        }

        public Task<ResponseQuery> Handle(RequestQuery query, ServerCallContext context)
        {
            var list = new List<CallNumber>(_callNumberRepository.List().OrderBy(p => p.PhoneNumber));
            var resultString = JsonConvert.SerializeObject(list);

            return Task.FromResult(ResponseHelper.Query.Ok(resultString.ToByteString()));
        }
    }
}
