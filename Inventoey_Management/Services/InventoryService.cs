using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Inventoey_Management.Models;

namespace Inventoey_Management.Services
{
    public class InventoryService : BaseServices<Inventory>, IInventoryService
    {
        public InventoryService(SQLiteAsyncConnection database) : base(database)
        {
        }

        public Task<List<Inventory>> GetByLocationAsync(string location)
        {
            return QueryAsync(i => i.Location.Contains(location));
        }
        public async Task<List<Request>> MatchRecords(List<Request> records)
        {
            List<Request> MatchRecords = default!;

            foreach (Request re in records)
            {
                var data = await GetByIdAsync(re.Id);
                if (data != null && data.Id == re.Id)
                {
                    MatchRecords.Add(re);
                }
            }
            return MatchRecords;
        }
    }
}