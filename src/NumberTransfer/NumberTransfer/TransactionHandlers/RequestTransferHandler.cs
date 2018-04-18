using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using NumberTransfer.Repositories;
using NumberTransfer.Services;
using NumberTransfer.Transactions;
using Types;

namespace NumberTransfer.TransactionHandlers
{
    // TODO: Do we need to check currentOwner somehow?
    public class RequestTransferHandler : TransactionHandlerBase<RequestTransfer>
    {
        private readonly TransactionTokenValidationService _transactionTokenValidationService;
        private readonly ICallNumberRepository _callNumberRepository;
        private readonly ILogger<RequestTransferHandler> _logger;

        public RequestTransferHandler(TransactionTokenValidationService transactionTokenValidationService,
            ICallNumberRepository callNumberRepository,
            ILogger<RequestTransferHandler> logger)
        {
            _transactionTokenValidationService = transactionTokenValidationService;
            _callNumberRepository = callNumberRepository;
            _logger = logger;
        }

        protected override async Task<ResponseCheckTx> CheckTx(TransactionToken transactionToken, RequestTransfer payload, RequestCheckTx request,
            ServerCallContext context)
        {
            if (!IsVerifiedCaller(transactionToken, payload.NewOwner))
            {
                return ResponseHelper.Check.Unauthorized();
            }

            _logger.LogInformation("Received valid CheckTx request");

            var callNumber = await _callNumberRepository.Get(payload.PhoneNumber);

            if (callNumber == null)
            {
                return ResponseHelper.Check.Create(CodeType.UnknownCallNumber, "Unknown call number.");
            }

            if (callNumber.TransferRequestStarted.HasValue)
            {
                return ResponseHelper.Check.Create(CodeType.TransferAlreadyStarted, "Transfer has already been started.");
            }

            _logger.LogInformation("CheckTx Result: ok");

            return ResponseHelper.Check.Ok();
        }

        private bool IsVerifiedCaller(TransactionToken token, string owner)
        {
            _transactionTokenValidationService.Validate(token, owner);

            return token.IsValid;
        }

        protected override async Task<ResponseDeliverTx> DeliverTx(TransactionToken transactionToken, RequestTransfer payload, RequestDeliverTx request,
            ServerCallContext context)
        {
            if (!IsVerifiedCaller(transactionToken, payload.NewOwner))
            {
                return ResponseHelper.Deliver.Unauthorized();
            }

            _logger.LogInformation("Received valid CheckTx request");

            var callNumber = await _callNumberRepository.Get(payload.PhoneNumber);
            callNumber.TransferRequestStarted = payload.TransferStarted;
            callNumber.TransferRequestedTo = payload.NewOwner;

            await _callNumberRepository.Update(callNumber);

            _logger.LogInformation($"DeliverTx Result: ok, transfer started: {callNumber.TransferRequestStarted}, to: {callNumber.TransferRequestedTo}");
            return ResponseHelper.Deliver.Ok();
        }
    }
}
