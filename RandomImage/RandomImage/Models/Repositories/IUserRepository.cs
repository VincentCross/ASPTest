﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Models
{
	public interface IUserRepository
	{
		User GetUser(int id);
		User GetUser(string username);
		IEnumerable<User> GetAllUsers();
		User Add(User user);
		//User Update(User userChanges);
		//User Delete(int Id);
	}
}
