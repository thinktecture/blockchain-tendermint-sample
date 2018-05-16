using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NumberTransfer.Models;
using NumberTransfer.Repositories;
using NumberTransfer.Services;
using Types;
using Types.Extensions;

namespace NumberTransfer.TransactionHandlers
{
    public class BlockHandler
    {
        private readonly IHashCalculation _hashCalculation;
        private readonly ICallNumberRepository _callNumberRepository;
        private readonly ILogger<BlockHandler> _logger;
        private readonly BlockchainMetadata _blockchainMetadata;

        public BlockHandler(IHashCalculation hashCalculation, ICallNumberRepository callNumberRepository, ILogger<BlockHandler> logger,
            BlockchainMetadata blockchainMetadata)
        {
            _hashCalculation = hashCalculation;
            _callNumberRepository = callNumberRepository;
            _logger = logger;
            _blockchainMetadata = blockchainMetadata;
        }

        public async Task<ResponseCommit> Commit(RequestCommit commit, ServerCallContext context)
        {
            if (!_callNumberRepository.List().Any())
            {
                return new ResponseCommit() { Log = "Zero tx. Hash is empty." };
            }

            var allData = _callNumberRepository.List().OrderBy(p => p.PhoneNumber).ToList();
            var serializedData = JsonConvert.SerializeObject(allData);
            var byteData = Encoding.UTF8.GetBytes(serializedData);
            var hashBytes = _hashCalculation.Calculate(byteData);
            var hashByteString = hashBytes.ToByteString();

            _logger.LogInformation($"Calculated hash: {hashByteString.ToStringUtf8()}");

            _blockchainMetadata.Hash = hashByteString;
            _blockchainMetadata.Height++;

            return await Task.FromResult(new ResponseCommit { Data = hashByteString });
        }

        public async Task<ResponseInfo> Info(RequestInfo request, ServerCallContext context) => await Task.FromResult(new ResponseInfo()
        {
            LastBlockAppHash = _blockchainMetadata.Hash ?? ByteString.Empty,
            LastBlockHeight = _blockchainMetadata.Height
        });

        public async Task<ResponseEndBlock> EndBlock(RequestEndBlock request, ServerCallContext context) => await Task.FromResult(new ResponseEndBlock());

        public async Task<ResponseBeginBlock> BeginBlock(RequestBeginBlock request, ServerCallContext context) => await Task.FromResult(new ResponseBeginBlock());
    }
}
