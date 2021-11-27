using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace WebAPI.Data
{
    public interface IAdultServices
    {
        Task<IList<Adult>> GetAllAdultsAsync(int familyId);
        Task<Adult> GetAdultAsync(int id);
        Task<Adult> AddAdultAsync(Adult adult);
        Task<Adult> RemoveAdultAsync(int id);
        Task<Adult> UpdateAdultAsync(Adult adult);

    }
}