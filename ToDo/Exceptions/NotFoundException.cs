using System;
namespace ToDo.Exceptions
{
	public class NotFoundException : ApplicationException
	{
		public NotFoundException(string name, object key) : base($"{name} ({key}) was not found")
		{
		}
	}
}

