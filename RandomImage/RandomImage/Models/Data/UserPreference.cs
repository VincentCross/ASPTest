using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Models
{
	public class UserPreference
	{
		public int Id { get; set; }
		[Required]
		public int userId { get; set; }
		[Required]
		public int imageId { get; set; }
		[Required]
		public Preference preference { get; set; }
	}	
}
