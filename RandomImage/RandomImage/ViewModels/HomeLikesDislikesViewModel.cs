﻿using RandomImage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.ViewModels
{
	public class HomeLikesDislikesViewModel
	{
		public User user { get; set; }
		public List<Image> images { get; set; }
		public Image removeImage { get; set; }
	}
}
