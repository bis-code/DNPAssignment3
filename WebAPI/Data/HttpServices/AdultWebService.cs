using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WebAPI.Data.HttpServices
{
    public class AdultWebService : IAdultServices
    {
        private DatabaseContext _databaseContext;

        public AdultWebService()
        {
            _databaseContext = new DatabaseContext();
        }

        public async Task<IList<Adult>> GetAllAdultsAsync(int familyId)
        {
            return await _databaseContext.Adults.Where(a => a.FamilyId == familyId).ToListAsync();
        }

        public async Task<Adult> GetAdultAsync(int id)
        {
            return await _databaseContext.Adults.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            await _databaseContext.Adults.AddAsync(adult);
            await _databaseContext.SaveChangesAsync();
            return adult;
        }

        public async Task<Adult> RemoveAdultAsync(int id)
        {
            Adult adult = await _databaseContext.Adults.FirstAsync(a => a.Id == id);
            _databaseContext.Adults.Remove(adult);
            await _databaseContext.SaveChangesAsync();
            return adult;
        }

        public async Task<Adult> UpdateAdultAsync(Adult adult)
        {
            _databaseContext.Adults.Update(adult);
            await _databaseContext.SaveChangesAsync();
            return adult;
        }
    }
}