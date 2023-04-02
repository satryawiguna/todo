using System;
using Microsoft.EntityFrameworkCore;
using ToDo.Datas;
using ToDo.Repository.Contract;

namespace ToDo.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly TodoDbContext _context;

        public BaseRepository(TodoDbContext context)
        {
            this._context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this._context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id == null)
                return null;

            return await this._context.Set<T>().FindAsync(id);
        }

        public async Task<bool> IsExists(int id)
        {
            var entity = await GetAsync(id);

            return entity != null;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await this._context.AddAsync(entity);

            await this._context.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            this._context.Update(entity);

            await this._context.SaveChangesAsync();
            
        }

        public async Task DeleteAsync(int id)
        {   
            var entity = await GetAsync(id);

            this._context.Set<T>().Remove(entity);

            await this._context.SaveChangesAsync();
        }
    }
}