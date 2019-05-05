using Microsoft.AspNetCore.Mvc;
using RandomImage.Models;
using RandomImage.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Controllers
{
	public class RandomController : Controller
	{
		private readonly IUserRepository _userRepository;
		private readonly IImageRepository _imageRepository;
		private readonly IUserPreferenceRepository _userPreferenceRepository;

		public RandomController(IUserRepository userRepository, IImageRepository imageRepository, IUserPreferenceRepository userPreferenceRepository)
		{
			_userRepository = userRepository;
			_imageRepository = imageRepository;
			_userPreferenceRepository = userPreferenceRepository;
		}

		// Produces a random image when the page loads.
		public IActionResult Index()
		{
			User currentUser = _userRepository.GetUser(Request.Cookies["Username"]);
			if (currentUser != null)
			{
				Image randomImage = _imageRepository.GetRandomImage();

				// Sets an existing preference if there is one
				UserPreference existingPreference = _userPreferenceRepository.GetPreference(currentUser.Id, randomImage.Id);
				
				RandomIndexViewModel randomIndexViewModel = new RandomIndexViewModel()
				{
					user = _userRepository.GetUser(Request.Cookies["Username"]),
					image = randomImage,
					existingPreference = existingPreference
				};

				return View("Index", randomIndexViewModel);
			}

			return RedirectToAction("Index", "Account");
		}

		// Creates a record in the UserPreferenceRepository linking the user to the image they liked
		[HttpPost]
		public RedirectToActionResult Like(RandomIndexViewModel randomIndexViewModel)
		{
			UserPreference userPreference = new UserPreference()
			{
				userId = randomIndexViewModel.user.Id,
				imageId = randomIndexViewModel.image.Id,
				preference = Preference.Like
			};

			_userPreferenceRepository.Add(userPreference);

			return RedirectToAction("Index");
		}

		// Creates a record in the UserPreferenceRepository linking the user to the image they disliked
		[HttpPost]
		public RedirectToActionResult Dislike(RandomIndexViewModel randomIndexViewModel)
		{
			UserPreference userPreference = new UserPreference()
			{
				userId = randomIndexViewModel.user.Id,
				imageId = randomIndexViewModel.image.Id,
				preference = Preference.Dislike
			};

			_userPreferenceRepository.Add(userPreference);

			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult RemovePreference(RandomIndexViewModel randomIndexViewModel)
		{
			DeletePreference(randomIndexViewModel.user.Id, randomIndexViewModel.image.Id);

			return RedirectToAction("Index");
		}

		private void DeletePreference(int userId, int imageId)
		{
			UserPreference userPreferenceToDelete = _userPreferenceRepository.GetPreference(userId, imageId);
			_userPreferenceRepository.Delete(userPreferenceToDelete);
		}
	}
}
