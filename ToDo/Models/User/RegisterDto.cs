using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models.User
{
	public class RegisterDto : LoginDto
	{
		[Required]
		public string FullName { get; set; }

        [Required]
        public string NickName { get; set; }

        [DataType(DataType.PhoneNumber)]
		public string Phone { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(15, ErrorMessage = "Your password limited {2} to {1} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}

