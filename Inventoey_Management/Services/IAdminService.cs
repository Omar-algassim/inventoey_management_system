using System.Threading.Tasks;
using Inventoey_Management.Models;

namespace Inventoey_Management.Services
{
    public interface IAdminServices : IBaseServices<Admin>
    {
        public Task<Admin> UpdateUser(Admin entity);
        Task<Admin> CreateUser(Admin entity);
        Task<Admin?> GetByUsernameAsync(string username);
        Task<bool> ValidateCredentialsAsync(string username, string password);
        Task<List<Admin>> GetByInventoryIdAsync(int inventoryId);
    }
}