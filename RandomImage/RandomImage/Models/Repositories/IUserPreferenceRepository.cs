using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Models
{
	public interface IUserPreferenceRepository
	{
		UserPreference GetPreference(User user, Image image);
		IEnumerable<UserPreference> GetAllUserPreferences();
		IEnumerable<UserPreference> GetAllLikes();
		IEnumerable<UserPreference> GetAllDislikes();
		UserPreference Add(UserPreference userPreference);
		UserPreference Update(UserPreference userPreferenceChanges);
		UserPreference Delete(User user, Image image);
	}
}
