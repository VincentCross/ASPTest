using Microsoft.AspNetCore.Mvc;
using RandomImage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Controllers
{
	public class HomeController : Controller
	{
		private readonly IUserRepository _userRepository;
		private readonly IImageRepository _imageRepository;
		private readonly IUserPreferenceRepository _userPreferanceRepository;

		public HomeController(IUserRepository userRepository, IImageRepository imageRepository, IUserPreferenceRepository userPreferenceRepository)
		{
			userRepository = _userRepository;
			imageRepository = _imageRepository;
			userPreferenceRepository = _userPreferanceRepository;
		}

		public ViewResult Index()
		{
			return View("~/Views/Home/Index.cshtml");
		}
	}
}
