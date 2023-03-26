using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models.TodoType
{
	public class CreateTodoTypeDto
	{
		[Required]
		public string Title	{ get; set; }
	}
}

