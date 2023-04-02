using System;
using ToDo.Datas;

namespace ToDo.Repository.Contract
{
	public interface ITodoTypeRepository : IRepository<TodoType>
	{
        Task<List<TodoType>> GetAllWithTodoAsync();

        Task<TodoType> GetWithTodoAsync(int? id);
    }
}

