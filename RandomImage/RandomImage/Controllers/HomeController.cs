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
		private readonly IUserPreferenceRepository _userPreferenceRepository;

		public HomeController(IUserRepository userRepository, IImageRepository imageRepository, IUserPreferenceRepository userPreferenceRepository)
		{
			_userRepository = userRepository;
			_imageRepository = imageRepository;
			_userPreferenceRepository = userPreferenceRepository;
		}

		public ViewResult Index()
		{
			var model = _userRepository.GetAllUsers();

			return View("~/Views/Home/Index.cshtml", model);
		}

		public ViewResult Random()
		{
			Image randomImage = _imageRepository.GetRandomImage();

			return View("~/Views/Home/Random.cshtml", randomImage);
		}

		public ViewResult Likes()
		{
			return View("~/Views/Home/Likes.cshtml");
		}

		public ViewResult Dislikes()
		{
			return View("~/Views/Home/Dislikes.cshtml");
		}
	}
}
