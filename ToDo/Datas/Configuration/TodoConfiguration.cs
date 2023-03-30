using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDo.Datas.Configuration
{
	public class TodoConfiguration : IEntityTypeConfiguration<Todo>
	{
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasData(
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

