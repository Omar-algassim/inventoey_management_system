using System.Threading.Tasks;
using Inventoey_Management.Models;

namespace Inventoey_Management.Services
{
    public interface ITechnicianService : IBaseServices<Technician>
    {
        Task<Technician?> GetByPhoneNumberAsync(int phoneNumber);
    }
}