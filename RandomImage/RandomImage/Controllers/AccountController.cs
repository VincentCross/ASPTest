using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomImage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RandomImage.Controllers
{
	public class AccountController : Controller
	{
		private readonly IUserRepository _userRepository;
		private readonly int _TOKENLIFEMINS = 60;

		public AccountController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public IActionResult Index()
		{
			if(Request.Cookies["Username"] != null)
			{
				return RedirectToAction("Index", "Home");
			}

			return View();
		}

		[HttpPost]
		public ViewResult Login(string username)
		{
			if (username != null)
			{
				LogInUser(username);

				return View("_LoggedIn");
			}

			ViewBag.Required = "Please enter a username to log in.";
			return View("Index");
		}

		public IActionResult Logout()
		{
			Response.Cookies.Delete("Username");

			return View("_LoggedOut");
		}

		[HttpGet]
		public ViewResult Register()
		{
			return View("Register");
		}

		[HttpPost]
		public ViewResult Register(string username)
		{
			if (username != null)
			{
				_userRepository.Add(new User()
				{
					Username = username
				});

				LogInUser(username);
				return View("_Registered");
			}

			ViewBag.Required = "Please enter a username to register.";
			return View();
		}

		private User LogInUser(string username)
		{
			CookieOptions options = new CookieOptions();
			options.Expires = DateTime.Now.AddMinutes(_TOKENLIFEMINS);

			Response.Cookies.Append("Username", username, options);

			return _userRepository.GetUser(username);
		}
	}
}
