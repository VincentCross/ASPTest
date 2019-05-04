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

		[HttpGet]
		public ViewResult Likes()
		{
			User currentUser = new User() { Id = 1, Username = "Bob" }; // TODO implement user recognition

			// Get all likes for user
			IEnumerable<UserPreference> userPreferenceList = _userPreferenceRepository.GetLikesForUser(currentUser);

			return View("~/Views/Home/Likes.cshtml", PrepareModel(userPreferenceList, currentUser));
		}

		[HttpPost]
		public IActionResult Likes(HomeLikesDislikesViewModel model)
		{
			UserPreference userPreferenceToDelete = _userPreferenceRepository.GetPreference(model.user.Id, model.removeImage.Id);
			_userPreferenceRepository.Delete(userPreferenceToDelete);

			return RedirectToAction("Likes");
		}

		[HttpGet]
		public ViewResult Dislikes()
		{
			User currentUser = new User() { Id = 1, Username = "Bob" }; // TODO implement user recognition

			// Get all dislikes for user
			IEnumerable<UserPreference> userPreferenceList = _userPreferenceRepository.GetDislikesForUser(currentUser);

			return View("~/Views/Home/Dislikes.cshtml", PrepareModel(userPreferenceList, currentUser));
		}

		[HttpPost]
		public IActionResult Dislikes(HomeLikesDislikesViewModel model)
		{
			UserPreference userPreferenceToDelete = _userPreferenceRepository.GetPreference(model.user.Id, model.removeImage.Id);
			_userPreferenceRepository.Delete(userPreferenceToDelete);

			return RedirectToAction("Dislikes");
		}

		// Helper function to prepare the HomeLikesDislikesViewModel for the likes and dislikes pages
		private HomeLikesDislikesViewModel PrepareModel(IEnumerable<UserPreference> userPreferenceList, User currentUser)
		{
			// Prepare model
			HomeLikesDislikesViewModel model = new HomeLikesDislikesViewModel() { user = currentUser };
			List<Image> imageList = new List<Image>();

			// Add images to model based on preference list
			foreach (UserPreference userPreference in userPreferenceList)
			{
				imageList.Add(_imageRepository.GetImage(userPreference.imageId));
			}

			model.images = imageList;

			return model;
		}
	}
}
