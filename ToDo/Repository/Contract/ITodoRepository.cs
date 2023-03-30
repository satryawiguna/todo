using System;
using ToDo.Datas;

namespace ToDo.Repository.Contract
{
	public interface ITodoRepository: IRepository<Todo>
	{
        Task<Todo> GetWithTodoTypeAsync(int? id);
    }
}

