using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace WebAPI.Data
{
    public interface IChildServices
    {
        Task<IList<Child>> GetAllChildrenAsync(int familyId);
        Task<Child> GetChildAsync(int id);
        Task<Child> AddChildAsync(Child child);
        Task<Child> RemoveChildAsync(int id);
        Task<Child> UpdateChildAsync(Child child); 
    }
}