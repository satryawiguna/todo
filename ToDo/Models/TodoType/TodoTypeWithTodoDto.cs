using System;
using ToDo.Models.Todo;

namespace ToDo.Models.TodoType
{
	public class TodoTypeWithTodoDto
	{
        public int Id { get; set; }

        public string Title { get; set; }

        public List<TodoDto> Todos { get; set; }
    }
}

