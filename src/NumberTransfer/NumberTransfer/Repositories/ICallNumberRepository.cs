using System.Linq;
using System.Threading.Tasks;
using NumberTransfer.Models;

namespace NumberTransfer.Repositories
{
    public interface ICallNumberRepository
    {
        Task<CallNumber> Get(string callNumber);
        Task<CallNumber> Add(CallNumber callNumber);
        Task<bool> Delete(string callNumber);
        Task<CallNumber> Update(CallNumber callNumber);
        IQueryable<CallNumber> List();
    }
}
