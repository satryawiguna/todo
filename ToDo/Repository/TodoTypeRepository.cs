using System;
using Microsoft.EntityFrameworkCore;
using ToDo.Datas;
using ToDo.Repository.Contract;

namespace ToDo.Repository
{
    public class TodoTypeRepository : BaseRepository<TodoType>, ITodoTypeRepository
    {
        private readonly TodoDbContext _context;

        public TodoTypeRepository(TodoDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<TodoType> GetWithTodoAsync(int? id)
        {
            if (id == null)
                return null;

            return await this._context.TodoTypes.Include(q => q.Todos).FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}

