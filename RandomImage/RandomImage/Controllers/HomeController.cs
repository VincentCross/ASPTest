using Microsoft.AspNetCore.Mvc;
using RandomImage.Models;
using RandomImage.ViewModels;
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

		public IActionResult Random()
		{
			return RedirectToAction("index", "random");
		}

		public ViewResult Likes()
		{
			User currentUser = new User() { Id = 1, Username = "Bob" }; // TODO implement user recognition

			// Get all likes
			IEnumerable<UserPreference> userPreferenceList = _userPreferenceRepository.GetLikesForUser(currentUser);

			// Prepare model
			HomeLikesDislikesViewModel model = new HomeLikesDislikesViewModel() { user = currentUser };
			List<Image> imageList = new List<Image>();

			// Add images to model based on preference list
			foreach(UserPreference userPreference in userPreferenceList)
			{
				imageList.Add(_imageRepository.GetImage(userPreference.imageId));
			}

			model.images = imageList;

			return View("~/Views/Home/Likes.cshtml", model);
		}

		public ViewResult Dislikes()
		{
			var model = _userPreferenceRepository.GetAllDislikes();

			return View("~/Views/Home/Dislikes.cshtml", model);
		}
	}
}
