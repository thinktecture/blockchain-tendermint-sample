using System.Threading.Tasks;
using Grpc.Core;
using NumberTransfer.Repositories;
using NumberTransfer.Services;
using NumberTransfer.Transactions;
using Types;

namespace NumberTransfer.TransactionHandlers
{
    public class DenyTransferRequestHandler : ITransactionHandler<DenyTransferRequest>
    {
        private readonly TransactionTokenValidationService _transactionTokenValidationService;
        private readonly ICallNumberRepository _callNumberRepository;

        public DenyTransferRequestHandler(TransactionTokenValidationService transactionTokenValidationService,
            ICallNumberRepository callNumberRepository)
        {
            _transactionTokenValidationService = transactionTokenValidationService;
            _callNumberRepository = callNumberRepository;
        }

        public async Task<ResponseCheckTx> CheckTx(TransactionToken transactionToken, DenyTransferRequest payload, RequestCheckTx request, ServerCallContext context)
        {
            var callNumber = await _callNumberRepository.Get(payload.PhoneNumber);

            if (callNumber == null)
            {
                return ResponseHelper.Check.Create(CodeType.UnknownCallNumber, "Unknown call number.");
            }

            if (!IsVerifiedCaller(transactionToken, callNumber.Owner))
            {
                return ResponseHelper.Check.Unauthorized();
            }

            if (callNumber.TransferRequestedTo != payload.NewOwner)
            {
                return ResponseHelper.Check.Create(CodeType.UnknownNewOwner, "Unknown new owner.");
            }

            if (!callNumber.TransferRequestStarted.HasValue)
            {
                return ResponseHelper.Check.Create(CodeType.NoTransferInitiated, "Transfer was not initiated.");
            }

            return ResponseHelper.Check.Ok();
        }

        private bool IsVerifiedCaller(TransactionToken token, string owner)
        {
            _transactionTokenValidationService.Validate(token, owner);

            return token.IsValid;
        }

        public async Task<ResponseDeliverTx> DeliverTx(TransactionToken transactionToken, DenyTransferRequest payload, RequestDeliverTx request, ServerCallContext context)
        {
            var callNumber = await _callNumberRepository.Get(payload.PhoneNumber);

            if (callNumber == null)
            {
                return ResponseHelper.Deliver.Create(CodeType.UnknownCallNumber, "Unknown call number.");
            }

            if (!IsVerifiedCaller(transactionToken, callNumber.Owner))
            {
                return ResponseHelper.Deliver.Unauthorized();
            }

            callNumber.TransferRequestedTo = null;
            callNumber.TransferRequestStarted = null;

            await _callNumberRepository.Update(callNumber);

            return ResponseHelper.Deliver.Ok();
        }
    }
}
