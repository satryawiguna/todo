using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo.Datas
{
	public class Todo
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		[ForeignKey(nameof(TodoTypeId))]
		public int TodoTypeId { get; set; }

		public TodoType TodoType { get; set; }
	}
}

