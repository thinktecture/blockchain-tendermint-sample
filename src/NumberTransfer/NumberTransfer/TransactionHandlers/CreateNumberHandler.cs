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
    public class CreateNumberHandler : ITransactionHandler, ITransactionHandler<CreateNumber>
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

        public async Task<ResponseCheckTx> CheckTx(TransactionToken transactionToken, object data, RequestCheckTx request, ServerCallContext context)
        {
            if (!IsVerifiedCaller(transactionToken))
            {
                return ResponseHelper.Check.Unauthorized();
            }

            if (!(data is CreateNumber payload))
            {
                return ResponseHelper.Check.NoPayload();
            }

            _logger.LogInformation("Received valid CheckTx request");

            var result = await _callNumberRepository.Get(payload.PhoneNumber);

            _logger.LogInformation($"CheckTx Result: {result == null}");
            return ResponseHelper.Check.Create(result == null ? CodeType.Ok : CodeType.PhoneNumberAlreadyExists, result == null ? "" : "Phonenumber already exists.");
        }

        public async Task<ResponseDeliverTx> DeliverTx(TransactionToken transactionToken, object data, RequestDeliverTx request, ServerCallContext context)
        {
            if (!IsVerifiedCaller(transactionToken))
            {
                return ResponseHelper.Deliver.Unauthorized();
            }

            if (!(data is CreateNumber payload))
            {
                return ResponseHelper.Deliver.NoPayload();
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
