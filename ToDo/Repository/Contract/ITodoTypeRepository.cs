using System;
using ToDo.Datas;

namespace ToDo.Repository.Contract
{
	public interface ITodoTypeRepository : IRepository<TodoType>
	{
        Task<TodoType> GetWithTodoAsync(int? id);
    }
}

