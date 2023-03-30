using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDo.Datas.Configuration;

namespace ToDo.Datas
{
	public class TodoDbContext : IdentityDbContext<User>
	{
		public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
		{
		}

		public DbSet<Todo> Todos { get; set; }
		public DbSet<TodoType> TodoTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new TodoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TodoConfiguration());
        }
    }
}

