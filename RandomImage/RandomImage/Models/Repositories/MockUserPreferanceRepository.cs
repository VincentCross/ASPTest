using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Models.Repositories
{
	public class MockUserPreferanceRepository : IUserPreferenceRepository
	{
		private List<UserPreferance> _userPreferancesList;

		public MockUserPreferanceRepository()
		{
			_userPreferancesList = new List<UserPreferance>();
		}

		public UserPreferance Add(UserPreferance userPreferance)
		{
			_userPreferancesList.Add(userPreferance);
			return userPreferance;
		}

		public UserPreferance Delete(User user, Image image)
		{
			UserPreferance userPreferanceToDelete = GetPreferance(user, image);
			_userPreferancesList.Remove(userPreferanceToDelete);
			return userPreferanceToDelete;
		}

		public IEnumerable<UserPreferance> GetAllUserPreferances()
		{
			return _userPreferancesList;
		}

		public UserPreferance GetPreferance(User user, Image image)
		{
			return _userPreferancesList.FirstOrDefault(usp => usp.user == user && usp.image == image);
		}

		public UserPreferance Update(UserPreferance userPreferanceChanges)
		{
			UserPreferance userPreferanceToUpdate = GetPreferance(userPreferanceChanges.user, userPreferanceChanges.image);

			if (userPreferanceToUpdate != null)
			{
				userPreferanceToUpdate.preference = userPreferanceChanges.preference;
			}

			return userPreferanceToUpdate;
		}
	}
}
