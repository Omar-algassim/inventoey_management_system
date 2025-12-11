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
    }
}