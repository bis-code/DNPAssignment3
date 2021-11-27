using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace WebClient.Data
{
    public interface IChildServices
    {
        Task<IList<Child>> GetAllChildrenAsync(int familyId);
            Task<Child> GetChildAsync(int id);
            Task AddChildAsync(Child child);
            Task<Child> RemoveChildAsync(int id);
            Task UpdateChildAsync(Child child);
            
    }
}