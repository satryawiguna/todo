using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models.Todo
{
	public class UpdateTodoDto
	{
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}

