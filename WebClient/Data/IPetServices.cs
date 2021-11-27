using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace WebClient.Data
{
    public interface IPetServices
    {
        Task<IList<Pet>> GetAllPetsAsync(int childId);
        Task<Pet> GetPetAsync(int id);
        Task AddPetAsync(Pet pet);
        Task<Pet> RemovePetAsync(int id);
        Task UpdatePetAsync(Pet pet);
    }
}