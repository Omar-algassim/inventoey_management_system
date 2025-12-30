using CsvHelper;
using Inventoey_Management.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
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
           return await _database.Table<T>().OrderByDescending(i => i.UpdatedAt).ToListAsync();
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
        public Task<List<T>> GetAllWithChildern()
        {
            return _database.GetAllWithChildrenAsync<T>();
        }
        public Task<T> GetByIdWithChilderen(string id)
        {
            return _database.GetWithChildrenAsync<T>(id);
        }
        public async Task<T> SaveWithChilderenAsync(T entity)
        {
            await _database.InsertWithChildrenAsync(entity, recursive: true);
            return entity;
        }
        public async Task<T> UpdateWithChilderenAsync(T entity)
        {
            await _database.UpdateWithChildrenAsync(entity);
            return entity;
        }
        protected Task<List<T>> QueryAsync(Expression<Func<T, bool>> predicate)
        {
            return _database.Table<T>().Where(predicate).ToListAsync();
        }

        public IEnumerable<T> ImportDataFromCsv(string csvFile)
        {
            using (var reader = new StreamReader(csvFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<T>();
            }
        }
        public async Task<int> ImportData(List<T> Records)
        {
            if (Records.Count <= 0) return 0;

            int savedRecord = 0;
            foreach (var rec in Records)
            {
                await SaveAsync(rec);
                savedRecord += 1;
            }
            return savedRecord;
        }

    }
}
