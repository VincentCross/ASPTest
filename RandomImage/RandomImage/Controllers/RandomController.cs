﻿using Microsoft.AspNetCore.Mvc;
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
		public ViewResult Index()
		{
			RandomIndexViewModel randomIndexViewModel = new RandomIndexViewModel()
			{
				user = _userRepository.GetUser(1), // TODO implement user recognition
				image = _imageRepository.GetRandomImage()
			};

			return View("Index", randomIndexViewModel);
		}

		// Creates a record in the UserPreferenceRepository linking the user to the image they liked
		[HttpPost]
		public RedirectToActionResult Like(RandomIndexViewModel randomIndexViewModel)
		{
			UserPreference userPreference = new UserPreference()
			{
				user = randomIndexViewModel.user,
				image = randomIndexViewModel.image,
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
				user = randomIndexViewModel.user,
				image = randomIndexViewModel.image,
				preference = Preference.Dislike
			};

			_userPreferenceRepository.Add(userPreference);

			return RedirectToAction("Index");
		}
	}
}