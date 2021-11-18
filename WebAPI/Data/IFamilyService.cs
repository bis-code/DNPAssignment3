using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Models;

namespace WebClient.Data
{
    public interface IFamilyService
    {
        Task<IList<Family>> GetAllFamiliesAsync();
        Task<Family> GetFamilyAsync(int id);

        Task<Family> AddFamilyAsync(Family family);

        Task RemoveFamilyAsync(int id);

        Task<Family> UpdateAsync(Family family);
        
        
        // Task<IList<Family>> GetFamiliesAsync();
        // Task<Family> GetFamilyAsync(int IdFamily);
        // Task<Adult> GetAdultAsync(int IdFamily, int IdAdult);
        // Task<Child> GetChildAsync(int IdFamily, int IdChild);
        // Task<Pet> GetPetAsync(int IdFamily, int IdPet);
        //
        // Task AddAdultToFamilyAsync(Family family, Adult _newAdult);
        // Task AddChildToFamilyAsync(Family family, Child _newChild);
        // Task AddFamilyAsync(Family family);
        // Task AddInterestAsync(int IdFamily, Child child, Interest interest);
        // Task AddPetForFamilyAsync(Family family, Child? child, Pet pet);
        //
        // Task UpdateFamilyAsync(Family family);
        // Task UpdateAdultAsync(int familyId, Adult adult);
        // Task UpdateChildAsync(int familyId, Child child);
        // Task UpdatePetAsync(int familyId, Pet pet);
        //
        // Task RemoveFamilyAsync(Family family);
        // Task RemoveAdultAsync(int IdFamily, Adult adult);
        // Task RemoveChildAsync(int IdFamily, Child child);
        // Task RemovePetAsync(int IdFamily, Pet pet);
    }
}