using RandomImage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.ViewModels
{
	public class RandomIndexViewModel
	{
		public User user { get; set; }
		public Image image { get; set; }
		public UserPreference existingPreference { get; set; }
	}
}
