using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Models
{
	public class Image
	{
		public int Id { get; set; }
		[Required]
		[MaxLength(50, ErrorMessage = "Image name cannot exceed 50 characters")]
		public string Name { get; set; }
		[Required]
		public string Path { get; set; }
	}
}
}
