using System.Threading.Tasks;
using Models;

namespace WebClient.Authentication
{
    public interface IUserService
    {
        Task<User> ValidateUser(string username, string password);
    }
}