using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models.Todo
{
	public class CreateTodoDto
	{
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int TodoTypeId { get; set; }
    }
}

