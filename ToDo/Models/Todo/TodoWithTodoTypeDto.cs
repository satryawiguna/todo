using System;
using ToDo.Models.TodoType;

namespace ToDo.Models.Todo
{
	public class TodoWithTodoTypeDto
	{
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public TodoTypeDto TodoType { get; set; }
    }
}

