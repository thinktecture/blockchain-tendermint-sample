using System.Threading.Tasks;
using Grpc.Core;
using Types;

namespace NumberTransfer.QueryProcessing
{
    public interface IQueryHandler
    {
        string Path { get; }

        Task<ResponseQuery> Handle(RequestQuery query, ServerCallContext context);
    }
}
