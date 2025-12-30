using System.Threading.Tasks;
using SQLite;
using Inventoey_Management.Models;
using System.ComponentModel;

namespace Inventoey_Management.Services
{
    public class TechnicianService : BaseServices<Technician>, ITechnicianService
    {
        public TechnicianService(SQLiteAsyncConnection database) : base(database)
        {
        }

        public Task<Technician?> GetByPhoneNumberAsync(string phoneNumber)
        {
            return _database.Table<Technician>()
                           .Where(t => t.PhoneNumber.Contains(phoneNumber))
                           .FirstOrDefaultAsync();
        }

        public async Task<List<Technician>> MatchRecords(List<Technician> Techs)
        {
            List<Technician> MatchList = new List<Technician>();
            foreach (Technician tech in Techs)
            {
                var rec = await GetByIdAsync(tech.Id);
                if (rec != null && rec.PhoneNumber == tech.PhoneNumber)
                {
                    MatchList.Add(rec);
                }
                else
                {
                    rec = await GetByPhoneNumberAsync(tech.PhoneNumber);
                    if (rec != null)
                    {
                        MatchList.Add(rec);
                    }
                }
            }
            return MatchList;
        }
        public async Task<int> ImportData(List<Technician> Techs)
        {
            if (Techs.Count <= 0) return 0;

            int savedRecord = 0;
            foreach(var tech in Techs)
            {
                await SaveAsync(tech);
            }
            return savedRecord;
        }
    }
}