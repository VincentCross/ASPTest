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

		public UserPreference Delete(User user, Image image)
		{
			UserPreference userPreferenceToDelete = GetPreference(user, image);
			_userPreferencesList.Remove(userPreferenceToDelete);
			return userPreferenceToDelete;
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

		public UserPreference GetPreference(User user, Image image)
		{
			return _userPreferencesList.FirstOrDefault(usp => usp.user == user && usp.image == image);
		}

		public UserPreference Update(UserPreference userPreferenceChanges)
		{
			UserPreference userPreferenceToUpdate = GetPreference(userPreferenceChanges.user, userPreferenceChanges.image);

			if (userPreferenceToUpdate != null)
			{
				userPreferenceToUpdate.preference = userPreferenceChanges.preference;
			}

			return userPreferenceToUpdate;
		}
	}
}
