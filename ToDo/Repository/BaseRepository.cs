using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ToDo.Datas;
using ToDo.Models;
using ToDo.Repository.Contract;

namespace ToDo.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly TodoDbContext _context;
        protected readonly IMapper _mapper;

        public BaseRepository(TodoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameter queryParameter)
        {
            var totalSize = await _context.Set<T>().CountAsync();
            var items = await _context.Set<T>()
                .Skip(queryParameter.StartIndex)
                .Take(queryParameter.PageSize)
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedResult<TResult>
            {
                Items = items,
                PageNumber = queryParameter.PageNumber,
                RecordNumber = queryParameter.PageSize,
                TotalCount = totalSize
            };
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