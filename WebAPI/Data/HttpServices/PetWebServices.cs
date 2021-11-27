using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WebAPI.Data.HttpServices
{
    public class PetWebServices : IPetsServices
    {
        private DatabaseContext _databaseContext;

        public PetWebServices()
        {
            _databaseContext = new DatabaseContext();
        }
        
        public async Task<IList<Pet>> GetAllPetsAsync(int childId)
        {
            return await _databaseContext.Pets.Where(p => p.ChildId == childId).ToListAsync();
        }

        public async Task<Pet> GetPetAsync(int id)
        {
            return await _databaseContext.Pets.FirstAsync(p => p.Id == id);
        }

        public async Task<Pet> AddPetAsync(Pet pet)
        {
            await _databaseContext.Pets.AddAsync(pet);
            await _databaseContext.SaveChangesAsync();
            return pet;
        }

        public async Task<Pet> RemovePetAsync(int id)
        {
            Pet petRemoved = await _databaseContext.Pets.FirstAsync(p => p.Id == id);
            _databaseContext.Pets.Remove(petRemoved);
            await _databaseContext.SaveChangesAsync();
            return petRemoved;
        }

        public async Task<Pet> UpdatePetAsync(Pet pet)
        {
            _databaseContext.Pets.Update(pet);
            await _databaseContext.SaveChangesAsync();
            return pet;
        }
    }
}