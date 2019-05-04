using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Models.Repositories
{
	public class MockUserPreferenceRepository : IUserPreferenceRepository
	{
		private List<UserPreference> _userPreferencesList;

		public MockUserPreferenceRepository()
		{
			_userPreferencesList = new List<UserPreference>();
		}

		public UserPreference Add(UserPreference userPreference)
		{
			_userPreferencesList.Add(userPreference);
			return userPreference;
		}

		public UserPreference Delete(UserPreference userPreference)
		{
			_userPreferencesList.Remove(userPreference);
			return userPreference;
		}

		public IEnumerable<UserPreference> GetAllDislikes()
		{
			IEnumerable<UserPreference> fullPreferenceList = GetAllUserPreferences();
			List<UserPreference> dislikePreferenceList = new List<UserPreference>();

			foreach(UserPreference userPreference in fullPreferenceList)
			{
				if (userPreference.preference == Preference.Dislike)
					dislikePreferenceList.Add(userPreference);
			}

			return dislikePreferenceList;
		}

		public IEnumerable<UserPreference> GetAllLikes()
		{
			IEnumerable<UserPreference> fullPreferenceList = GetAllUserPreferences();
			List<UserPreference> likePreferenceList = new List<UserPreference>();

			foreach (UserPreference userPreference in fullPreferenceList)
			{
				if (userPreference.preference == Preference.Like)
					likePreferenceList.Add(userPreference);
			}

			return likePreferenceList;
		}

		public IEnumerable<UserPreference> GetAllUserPreferences()
		{
			return _userPreferencesList;
		}

		public IEnumerable<UserPreference> GetDislikesForUser(User user)
		{
			return _userPreferencesList.FindAll(usp => usp.userId == user.Id && usp.preference == Preference.Dislike);
		}

		public IEnumerable<UserPreference> GetLikesForUser(User user)
		{
			return _userPreferencesList.FindAll(usp => usp.userId == user.Id && usp.preference == Preference.Like);
		}

		public UserPreference GetPreference(int userId, int imageId)
		{
			return _userPreferencesList.FirstOrDefault(usp => usp.userId == userId && usp.imageId == imageId);
		}

		public UserPreference Update(UserPreference userPreferenceChanges)
		{
			UserPreference userPreferenceToUpdate = GetPreference(userPreferenceChanges.userId, userPreferenceChanges.imageId);

			if (userPreferenceToUpdate != null)
			{
				userPreferenceToUpdate.preference = userPreferenceChanges.preference;
			}

			return userPreferenceToUpdate;
		}
	}
}
