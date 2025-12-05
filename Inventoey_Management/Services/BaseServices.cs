using Inventoey_Management.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventoey_Management.Services
{
    public class BaseServices<T> : IBaseServices<T> where T : Base, new()
    {
        protected readonly SQLiteAsyncConnection _database;

        public BaseServices(SQLiteAsyncConnection database)
        {
            _database = database;
        }
        public async Task<List<T>> GetAllAsync()
        {
           return await _database.Table<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _database.Table<T>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveAsync(T entity)
        {
            await _database.InsertAsync(entity);
            return await Task.FromResult(entity.Id);
        }

        public async Task<int> DeleteAsync(T entity)
        {
            return await _database.DeleteAsync(entity);
        }

        public async Task<int> DeleteByID(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                return await _database.DeleteAsync(entity);
            }
            return 0;
        }

        public async Task<T> UpdateAsync(int id, T data)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                data.Id = entity.Id;
                await _database.UpdateAsync(data);
                return data;
            }
            return entity;
        }
    }
}
