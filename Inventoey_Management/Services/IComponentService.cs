using System.Collections.Generic;
using System.Threading.Tasks;
using Inventoey_Management.Models;

namespace Inventoey_Management.Services
{
    public interface IComponentService : IBaseServices<Component>
    {
        Task<List<Component>> GetAvailable();
        Task<List<Component>> GetLowStockAsync(int threshold);
        Task<int> UpdateStockAsync(int componentId, int amount);
        Task<List<Component>> SearchByDescriptionAsync(string description);
    }
}