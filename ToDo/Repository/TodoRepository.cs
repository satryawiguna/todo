using System;
using Microsoft.EntityFrameworkCore;
using ToDo.Datas;
using ToDo.Repository.Contract;

namespace ToDo.Repository
{
	public class TodoRepository : BaseRepository<Todo>, ITodoRepository
	{
        private readonly TodoDbContext _context;

        public TodoRepository(TodoDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Todo> GetWithTodoTypeAsync(int? id)
        {
            if (id == null)
                return null;

            return await this._context.Todos.Include(q => q.TodoType).FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}

