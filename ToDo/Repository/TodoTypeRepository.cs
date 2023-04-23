using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDo.Datas;
using ToDo.Repository.Contract;

namespace ToDo.Repository
{
    public class TodoTypeRepository : BaseRepository<TodoType>, ITodoTypeRepository
    {
        private readonly TodoDbContext _context;

        public TodoTypeRepository(TodoDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<TodoType>> GetAllWithTodoAsync()
        {
            var result = await _context.TodoTypes.Include(q => q.Todos).ToListAsync();

            return result;
        }

        public async Task<TodoType> GetWithTodoAsync(int? id)
        {
            if (id == null)
                return null;

            var result = await this._context.TodoTypes.Include(q => q.Todos).FirstOrDefaultAsync(q => q.Id == id); await this._context.TodoTypes.Include(q => q.Todos).FirstOrDefaultAsync(q => q.Id == id);

            return result;
        }
    }
}

