using System;
namespace ToDo.Repository.Contract
{
	public interface IRepository<T> where T : class
	{
		Task<List<T>> GetAllAsync();

		Task<T> GetAsync(int? id);

		Task<T> CreateAsync(T entity);

		Task UpdateAsync(T entity);

		Task DeleteAsync(int id);

		Task<bool> IsExists(int id);
	}
}

