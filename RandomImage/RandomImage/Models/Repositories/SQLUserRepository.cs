using RandomImage.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Models.Repositories
{
	public class SQLUserRepository : IUserRepository
	{
		private readonly AppDbContext context;

		public SQLUserRepository(AppDbContext context)
		{
			this.context = context;
		}

		public User Add(User user)
		{
			context.Users.Add(user);
			context.SaveChanges();
			return user;
		}

		public IEnumerable<User> GetAllUsers()
		{
			return context.Users;
		}

		public User GetUser(int id)
		{
			return context.Users.Find(id);
		}

		public User GetUser(string username)
		{
			return context.Users.FirstOrDefault(us => us.Username == username);
		}
	}
}
