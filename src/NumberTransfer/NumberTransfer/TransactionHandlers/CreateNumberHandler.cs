using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using NumberTransfer.Models;
using NumberTransfer.Repositories;
using NumberTransfer.Services;
using NumberTransfer.Transactions;
using Types;

namespace NumberTransfer.TransactionHandlers
{
    public class CreateNumberHandler : TransactionHandlerBase<CreateNumber>
    {
        private readonly TransactionTokenValidationService _transactionTokenValidationService;
        private readonly ICallNumberRepository _callNumberRepository;
        private readonly ILogger<CreateNumberHandler> _logger;

        public CreateNumberHandler(TransactionTokenValidationService transactionTokenValidationService,
            ICallNumberRepository callNumberRepository,
            ILogger<CreateNumberHandler> logger)
        {
            _transactionTokenValidationService = transactionTokenValidationService;
            _callNumberRepository = callNumberRepository;
            _logger = logger;
        }

        private bool IsVerifiedCaller(TransactionToken token)
        {
            _transactionTokenValidationService.Validate(token, "Regulator");

            return token.IsValid;
        }

        protected override async Task<ResponseCheckTx> CheckTx(TransactionToken transactionToken, CreateNumber payload, RequestCheckTx request,
            ServerCallContext context)
        {
            if (!IsVerifiedCaller(transactionToken))
            {
                return ResponseHelper.Check.Unauthorized();
            }
            
            _logger.LogInformation("Received valid CheckTx request");

            var result = await _callNumberRepository.Get(payload.PhoneNumber);

            _logger.LogInformation($"CheckTx Result: {result == null}");
            return ResponseHelper.Check.Create(result == null ? CodeType.Ok : CodeType.PhoneNumberAlreadyExists, result == null ? "" : "Phonenumber already exists.");
        }

        protected override async Task<ResponseDeliverTx> DeliverTx(TransactionToken transactionToken, CreateNumber payload, RequestDeliverTx request,
            ServerCallContext context)
        {
            if (!IsVerifiedCaller(transactionToken))
            {
                return ResponseHelper.Deliver.Unauthorized();
            }
            
            _logger.LogInformation("Received valid DeliverTx request");

            await _callNumberRepository.Add(new CallNumber()
            {
                Owner = payload.Owner,
                PhoneNumber = payload.PhoneNumber
            });

            _logger.LogInformation("DeliverTx Result: ok");
            return ResponseHelper.Deliver.Ok();
        }
    }
}
