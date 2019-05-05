using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Models
{
	public class UserPreference
	{
		public int Id { get; set; }
		[ForeignKey("User")]
		public int userId { get; set; }
		[ForeignKey("Image")]
		public int imageId { get; set; }
		[Required]
		public Preference preference { get; set; }
	}	
}
