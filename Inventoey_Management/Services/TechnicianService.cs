using System.Threading.Tasks;
using SQLite;
using Inventoey_Management.Models;

namespace Inventoey_Management.Services
{
    public class TechnicianService : BaseServices<Technician>, ITechnicianService
    {
        public TechnicianService(SQLiteAsyncConnection database) : base(database)
        {
        }

        public Task<Technician?> GetByPhoneNumberAsync(int phoneNumber)
        {
            return _database.Table<Technician>()
                           .Where(t => t.PhoneNumber == phoneNumber)
                           .FirstOrDefaultAsync();
        }
    }
}