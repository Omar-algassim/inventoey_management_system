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

        public Task<Client?> GetByOfficeNumberAsync(string officeNumber)
        {
            return _database.Table<Client>()
                           .Where(c => c.OfficeNumber == officeNumber)
                           .FirstOrDefaultAsync();
        }
        public async Task<List<Client>> MatchRecords(List<Client> records)
        {
            List<Client> MatchRecords = default!;

            foreach (Client re in records)
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