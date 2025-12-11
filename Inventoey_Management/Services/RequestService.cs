using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Inventoey_Management.Models;
using Inventoey_Management.Services;

namespace Inventoey_Management.Services
{
    public class RequestService : BaseServices<Request>, IRequestService
    {
        public RequestService(SQLiteAsyncConnection database) : base(database)
        {
        }

        public Task<List<Request>> GetByStatusAsync(string status)
        {
            return QueryAsync(r => r.Status == status);
        }

        public Task<List<Request>> GetByClientIdAsync(int clientId)
        {
            return QueryAsync(r => r.ClientId == clientId);
        }

        public Task<List<Request>> GetByTechnicianIdAsync(int technicianId)
        {
            return QueryAsync(r => r.TechnicianId == technicianId);
        }

        public async Task<int> UpdateStatusAsync(int requestId, string newStatus)
        {
            var request = await GetByIdAsync(requestId);
            if (request == null) return 0;

            request.Status = newStatus;
            return await SaveAsync(request);
        }

        public Task<List<Request>> GetPendingRequestsAsync()
        {
            return GetByStatusAsync("Pending");
        }
    }
}