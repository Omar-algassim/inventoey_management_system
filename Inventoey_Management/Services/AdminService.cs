using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using SQLite;
using Inventoey_Management.Models;
using System.Text;

namespace Inventoey_Management.Services
{
    public class AdminService : BaseServices<Admin>, IAdminServices
    {
        public AdminService(SQLiteAsyncConnection database) : base(database)
        {
        }

        public Task<Admin> CreateUser(Admin entity)
        {
            entity.PasswordHash = HashPassword(entity.PasswordHash ?? string.Empty);
            _database.InsertAsync(entity);
            return Task.FromResult(entity);
        }
        public Task<Admin?> GetByUsernameAsync(string username)
        {
            return _database.Table<Admin>()
                           .Where(a => a.Username == username)
                           .FirstOrDefaultAsync();
        }

        public async Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            var admin = await GetByUsernameAsync(username);
            if (admin == null) return false;


            return admin.PasswordHash == HashPassword(password);
        }

        public Task<List<Admin>> GetByInventoryIdAsync(int inventoryId)
        {
            return QueryAsync(a => a.InventoryId == inventoryId);
        }
        private static string HashPassword(string password)
        {
            byte[] passByte = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = SHA256.HashData(passByte);
            return Convert.ToHexString(hashBytes);
        }
        public async Task<Admin> UpdateUser(Admin entity)
        {
            if (!string.IsNullOrEmpty(entity.PasswordHash))
            {
                entity.PasswordHash = HashPassword(entity.PasswordHash);
            }
            await _database.UpdateAsync(entity);
            return entity;
        }
        public async Task<List<Admin>> MatchRecords(List<Admin> records)
        {
            List<Admin> MatchRecords = default!;

            foreach (Admin re in records)
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