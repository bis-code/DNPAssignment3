using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using Microsoft.EntityFrameworkCore;
using Models;

namespace WebAPI.Data.HttpServices
{
    public class ChildWebServices : IChildServices
    {
        private DatabaseContext _databaseContext;

        public ChildWebServices()
        {
            _databaseContext = new DatabaseContext();
        }
        
        public async Task<IList<Child>> GetAllChildrenAsync(int familyId)
        {
            return await _databaseContext.Children.Where(c => c.FamilyId == familyId).ToListAsync();
        }

        public async Task<Child> GetChildAsync(int id)
        {
            return await _databaseContext.Children.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Child> AddChildAsync(Child child)
        {
            await _databaseContext.Children.AddAsync(child);
            await _databaseContext.SaveChangesAsync();
            return child;
        }

        public async Task<Child> RemoveChildAsync(int id)
        {
            Child child = await _databaseContext.Children.FirstAsync(c => c.Id == id);
            _databaseContext.Children.Remove(child);
            await _databaseContext.SaveChangesAsync();
            return child;
        }

        public async Task<Child> UpdateChildAsync(Child child)
        {
            _databaseContext.Children.Update(child);
            await _databaseContext.SaveChangesAsync();
            return child;
        }
    }
}