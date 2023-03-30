using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

			modelBuilder.Entity<TodoType>().HasData(
				new TodoType
				{
					Id = 1,
					Title = "School activity"
				},
				new TodoType
				{
					Id = 2,
					Title = "Work activity"
				},
				new TodoType
				{
					Id = 3,
					Title = "Home activity"
				}
			);

            modelBuilder.Entity<Todo>().HasData(
                new Todo
                {
                    Id = 1,
                    Title = "Activity one",
                    Description = "Description of activity one",
					TodoTypeId = 1
                },
                new Todo
                {
                    Id = 2,
                    Title = "Activity two",
                    Description = "Description of activity two",
                    TodoTypeId = 1
                },
                new Todo
                {
                    Id = 3,
                    Title = "Activity three",
                    Description = "Description of activity three",
                    TodoTypeId = 2
                },
                new Todo
                {
                    Id = 4,
                    Title = "Activity four",
                    Description = "Description of activity four",
                    TodoTypeId = 2
                },
                new Todo
                {
                    Id = 5,
                    Title = "Activity five",
                    Description = "Description of activity five",
                    TodoTypeId = 3
                },
                new Todo
                {
                    Id = 6,
                    Title = "Activity six",
                    Description = "Description of activity six",
                    TodoTypeId = 3
                }
            );
        }
    }
}

