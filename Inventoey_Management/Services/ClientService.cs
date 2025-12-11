using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Inventoey_Management.Models;
using SQLiteNetExtensionsAsync.Extensions;

namespace Inventoey_Management.Services
{
    public class ClientService : BaseServices<Client>, IClientService
    {
        public ClientService(SQLiteAsyncConnection database) : base(database)
        {
        }

        public Task<List<Client>> GetByBuildingAsync(string buildingName)
        {
            return QueryAsync(c => c.BuildingName.Contains(buildingName));
        }

        public Task<List<Client>> GetByFloorAsync(int floor)
        {
            return QueryAsync(c => c.Floor == floor);
        }

        public Task<Client?> GetByOfficeNumberAsync(string officeNumber)
        {
            return _database.Table<Client>()
                           .Where(c => c.OfficeNumber == officeNumber)
                           .FirstOrDefaultAsync();
        }
    }
}