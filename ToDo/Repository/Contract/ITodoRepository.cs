using System;
using ToDo.Datas;

namespace ToDo.Repository.Contract
{
	public interface ITodoRepository: IRepository<Todo>
	{
        Task<List<Todo>> GetAllWithTodoTypeAsync();

        Task<Todo> GetWithTodoTypeAsync(int? id);
    }
}

