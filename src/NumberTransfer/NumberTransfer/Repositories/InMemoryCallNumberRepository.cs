using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NumberTransfer.Models;

namespace NumberTransfer.Repositories
{
    public class InMemoryCallNumberRepository : ICallNumberRepository
    {
        private readonly IDictionary<string, CallNumber> _callNumbers = new ConcurrentDictionary<string, CallNumber>();

        public Task<CallNumber> Get(string callNumber) => Task.Run(() => _callNumbers.ContainsKey(callNumber) ? CloneCallNumber(_callNumbers[callNumber]) : null);

        public Task<CallNumber> Add(CallNumber callNumber) => Task.Run(() =>
        {
            _callNumbers.Add(callNumber.PhoneNumber, callNumber);
            return callNumber;
        });

        public Task<bool> Delete(string callNumber) => Task.Run(() => _callNumbers.Remove(callNumber));

        public Task<CallNumber> Update(CallNumber callNumber)
        {
            _callNumbers.Remove(callNumber.PhoneNumber);
            _callNumbers.Add(callNumber.PhoneNumber, callNumber);
            return Task.Run(() => callNumber);
        }

        public IQueryable<CallNumber> List() => _callNumbers.Select(pair => pair.Value).AsQueryable();

        // "Simulates" that the data comes from the DB, having no connection to the data store
        private CallNumber CloneCallNumber(CallNumber source) => new CallNumber()
        {
            Owner = source.Owner,
            PhoneNumber = source.PhoneNumber,
            TransferRequestedTo = source.TransferRequestedTo,
            TransferRequestStarted = source.TransferRequestStarted
        };
    }
}
