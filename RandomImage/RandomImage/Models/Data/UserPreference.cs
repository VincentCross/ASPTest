using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Models
{
	public class UserPreference
	{
		[Required]
		public User user { get; set; }
		[Required]
		public Image image { get; set; }
		[Required]
		public Preference preference { get; set; }
	}	
}
