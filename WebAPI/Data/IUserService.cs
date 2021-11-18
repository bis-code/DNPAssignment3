using System.Threading.Tasks;
using Models;

namespace WebClient.Authentication
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string username, string password);
    }
}