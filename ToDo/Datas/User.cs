using System;
using Microsoft.AspNetCore.Identity;

namespace ToDo.Datas
{
	public class User : IdentityUser
	{
		public string FullName { get; set; }

		public string NickName { get; set; }
	}
}

