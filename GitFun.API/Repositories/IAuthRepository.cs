using System.Threading.Tasks;
using GitFun.API.Models;

namespace GitFun.API.Repositories
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
        Task<User> GetUser(string username);
    }
}