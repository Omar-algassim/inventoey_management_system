using System.Collections.Generic;
using System.Threading.Tasks;
using Inventoey_Management.Models;

namespace Inventoey_Management.Services
{
    public interface IRequestService : IBaseServices<Request>
    {
        Task<List<Request>> GetByStatusAsync(string status);
        Task<List<Request>> GetByClientIdAsync(int clientId);
        Task<List<Request>> GetByTechnicianIdAsync(int technicianId);
        Task<int> UpdateStatusAsync(int requestId, string newStatus);
        Task<List<Request>> GetPendingRequestsAsync();
    }
}