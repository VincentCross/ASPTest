using RandomImage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.ViewModels
{
	public class DebugViewModel
	{
		public IEnumerable<User> users { get; set; }
		public IEnumerable<Image> images { get; set; }
		public IEnumerable<UserPreference> userPreferences { get; set; }
	}
}
