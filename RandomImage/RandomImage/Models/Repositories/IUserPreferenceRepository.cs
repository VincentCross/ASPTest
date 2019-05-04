using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Models
{
	public interface IUserPreferenceRepository
	{
		UserPreference GetPreference(int userId, int imageId);
		IEnumerable<UserPreference> GetAllUserPreferences();
		IEnumerable<UserPreference> GetAllLikes();
		IEnumerable<UserPreference> GetAllDislikes();
		IEnumerable<UserPreference> GetLikesForUser(User user);
		IEnumerable<UserPreference> GetDislikesForUser(User user);
		UserPreference Add(UserPreference userPreference);
		UserPreference Update(UserPreference userPreferenceChanges);
		UserPreference Delete(UserPreference userPreference);
	}
}
