using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDo.Datas.Configuration
{
    public class TodoTypeConfiguration : IEntityTypeConfiguration<TodoType>
    {
        public void Configure(EntityTypeBuilder<TodoType> builder)
        {
            builder.HasData(
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
        }
    }
}

