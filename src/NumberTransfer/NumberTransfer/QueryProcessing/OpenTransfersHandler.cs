using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Newtonsoft.Json;
using NumberTransfer.Repositories;
using Types;
using Types.Extensions;

namespace NumberTransfer.QueryProcessing
{
    public class OpenTransfersHandler : IQueryHandler
    {
        private readonly ICallNumberRepository _callNumberRepository;
        public string Path { get; } = "open-transfers";

        public OpenTransfersHandler(ICallNumberRepository callNumberRepository)
        {
            _callNumberRepository = callNumberRepository;
        }

        public async Task<ResponseQuery> Handle(RequestQuery query, ServerCallContext context)
        {
            var party = query.Data.ToStringUtf8();

            if (string.IsNullOrWhiteSpace(party))
            {
                return new ResponseQuery();
            }

            var openRequests = _callNumberRepository.List().Where(number => number.Owner == party && number.TransferRequestStarted.HasValue).OrderBy(p => p.PhoneNumber);
            var jsonString = JsonConvert.SerializeObject(openRequests);

            return ResponseHelper.Query.Ok(jsonString.ToByteString());
        }
    }
}
