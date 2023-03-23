using System;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Datas
{
	public class TodoDbContext : DbContext
	{
		public TodoDbContext(DbContextOptions options) : base(options)
		{

		}
	}
}

