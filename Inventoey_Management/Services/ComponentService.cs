using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Inventoey_Management.Models;

namespace Inventoey_Management.Services
{
    public class ComponentService : BaseServices<Component>, IComponentService
    {
        public ComponentService(SQLiteAsyncConnection database) : base(database)
        {
        }

        public Task<List<Component>> GetLowStockAsync(int threshold)
        {
            return QueryAsync(c => c.Amount <= threshold);
        }

        public async Task<Component> UpdateStockAsync(int componentId, int amount)
        {
            var component = await GetByIdAsync(componentId);
            component.Amount -= amount;
            return await UpdateAsync(componentId, component);
        }

        public Task<List<Component>> SearchByDescriptionAsync(string description)
        {
            return _database.Table<Component>()
                           .Where(c => c.Description.Contains(description))
                           .ToListAsync();
        }

        public Task<List<Component>> GetAvailable()
        {
            return QueryAsync(c => c.Amount > 0);
        }
        public Task<Component> GetMinComponentAmount()
        {
                       return _database.Table<Component>()
                            .OrderBy(c => c.Amount)
                            .FirstOrDefaultAsync();
        }
        public async Task<List<Component>> MatchRecords(List<Component> records)
        {
            List<Component> MatchRecords = default!;

            foreach (Component re in records)
            {
                var data = await GetByIdAsync(re.Id);
                if (data != null && (data.Id == re.Id || data.Code == re.Code))
                {
                    MatchRecords.Add(re);
                }
            }
            return MatchRecords;
        }
    }
}