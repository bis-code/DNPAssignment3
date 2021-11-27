using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace WebAPI.Data
{
    public interface IPetsServices
    {
        Task<IList<Pet>> GetAllPetsAsync(int familyId);
        Task<Pet> GetPetAsync(int id);
        Task<Pet> AddPetAsync(Pet pet);
        Task<Pet> RemovePetAsync(int id);
        Task<Pet> UpdatePetAsync(Pet pet); 
    }
}