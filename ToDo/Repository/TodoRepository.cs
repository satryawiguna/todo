using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ToDo.Datas;
using ToDo.Models;
using ToDo.Repository.Contract;

namespace ToDo.Repository
{
	public class TodoRepository : BaseRepository<Todo>, ITodoRepository
	{

        public TodoRepository(TodoDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<Todo>> GetAllWithTodoTypeAsync()
        {
            return await _context.Todos.Include(q => q.TodoType).ToListAsync();
        }

        public async Task<PagedResult<TResult>> GetAllWithTodoTypeAsync<TResult>(QueryParameter queryParameter)
        {
            var totalSize = await _context.Set<Todo>().CountAsync();
            var items = await _context.Set<Todo>()
                .Include(q => q.TodoType)
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

        public async Task<Todo> GetWithTodoTypeAsync(int? id)
        {
            if (id == null)
                return null;

            return await _context.Todos.Include(q => q.TodoType).FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}

