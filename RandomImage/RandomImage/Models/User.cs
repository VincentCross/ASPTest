using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Models
{
	public class User
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters")]
		public string Username { get; set; }
	}
}
}
