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

		public AccountController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult WriteUserCookie(string username)
		{
			CookieOptions options = new CookieOptions();
			options.Expires = DateTime.Now.AddMinutes(5);

			Response.Cookies.Append("Username", username, options);

			User activeUser = _userRepository.GetUser(username);
			
			return View("LoggedIn", activeUser);
		}

		public string ReadUserCookie()
		{
			return Request.Cookies["Username"];
		}
	}
}
