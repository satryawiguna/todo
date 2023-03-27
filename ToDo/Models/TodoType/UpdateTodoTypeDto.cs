using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models.TodoType
{
	public class UpdateTodoTypeDto
	{
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}

