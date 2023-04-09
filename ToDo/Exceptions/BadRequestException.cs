using System;
namespace ToDo.Exceptions
{
	public class BadRequestException : ApplicationException
	{
		public BadRequestException(string name, object key) : base($"{name} ({key}) bad request")
		{

		}
	}
}

