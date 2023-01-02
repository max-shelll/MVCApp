using MVCApp.Models.Db;
using System.Threading.Tasks;

namespace MVCApp.Models.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
