using System.Collections.Generic;
using System.Threading.Tasks;
using Inventoey_Management.Models;

namespace Inventoey_Management.Services
{
    public interface IClientService : IBaseServices<Client>
    {
        Task<List<Client>> GetByBuildingAsync(string buildingName);
        Task<List<Client>> GetByFloorAsync(int floor);
        Task<Client?> GetByOfficeNumberAsync(string officeNumber);
    }
}