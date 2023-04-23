using System;
using ToDo.Datas;
using ToDo.Models;

namespace ToDo.Repository.Contract
{
	public interface ITodoRepository: IRepository<Todo>
	{
        Task<List<Todo>> GetAllWithTodoTypeAsync();

        Task<PagedResult<TResult>> GetAllWithTodoTypeAsync<TResult>(QueryParameter queryParameter);

        Task<Todo> GetWithTodoTypeAsync(int? id);
    }
}

