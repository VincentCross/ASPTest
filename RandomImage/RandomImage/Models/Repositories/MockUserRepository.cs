using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Models.Repositories
{
	public class MockUserRepository : IUserRepository
	{
		private List<User> _userList;

		public MockUserRepository()
		{
			_userList = new List<User>()
			{
				new User() { Id = 1, Username = "User1" },
				new User() { Id = 4, Username = "User2" },
				new User() { Id = 9, Username = "User3" }
			};
		}

		public User Add(User user)
		{
			user.Id = _userList.Max(us => us.Id) + 1;
			_userList.Add(user);
			return user;
		}

		public IEnumerable<User> GetAllUsers()
		{
			return _userList;
		}

		public User GetUser(int Id)
		{
			return _userList.FirstOrDefault(us => us.Id == Id);
		}
	}
}
