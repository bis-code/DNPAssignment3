using System.Threading.Tasks;
using Models;

namespace WebClient.Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string username, string password);
    }
}