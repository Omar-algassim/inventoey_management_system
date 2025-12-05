using Inventoey_Management.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventoey_Management.Services
{
    public interface IBaseServices<T> where T : Base , new()
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> SaveAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<int> DeleteByID(int id);
        Task<T> UpdateAsync(int id,T data);

    }
}
