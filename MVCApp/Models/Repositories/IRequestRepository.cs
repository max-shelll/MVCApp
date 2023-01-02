using MVCApp.Models.Db;
using System.Threading.Tasks;

namespace MVCApp.Models.Repositories
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);
        Task<Request[]> GetRequests();
    }
}
