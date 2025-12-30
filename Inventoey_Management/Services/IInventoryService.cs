using System.Collections.Generic;
using System.Threading.Tasks;
using Inventoey_Management.Models;

namespace Inventoey_Management.Services
{
    public interface IInventoryService : IBaseServices<Inventory>
    {
        Task<List<Request>> MatchRecords(List<Request> records);
        Task<List<Inventory>> GetByLocationAsync(string location);
    }
}