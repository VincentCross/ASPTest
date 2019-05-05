using RandomImage.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Models.Repositories
{
	public class SQLUserPreferenceRepository : IUserPreferenceRepository
	{
		private readonly AppDbContext context;

		public SQLUserPreferenceRepository(AppDbContext context)
		{
			this.context = context;
		}

		public UserPreference Add(UserPreference userPreference)
		{
			context.UserPreferences.Add(userPreference);
			context.SaveChanges();
			return userPreference;
		}

		public UserPreference Delete(UserPreference userPreference)
		{
			context.Remove(userPreference);
			context.SaveChanges();
			return userPreference;
		}

		public IEnumerable<UserPreference> GetAllDislikes()
		{
			List<UserPreference> userPreferencesList = context.UserPreferences.ToList();
			return userPreferencesList.FindAll(usp => usp.preference == Preference.Dislike);
		}

		public IEnumerable<UserPreference> GetAllLikes()
		{
			List<UserPreference> userPreferencesList = context.UserPreferences.ToList();
			return userPreferencesList.FindAll(usp => usp.preference == Preference.Like);
		}

		public IEnumerable<UserPreference> GetAllUserPreferences()
		{
			return context.UserPreferences;
		}

		public IEnumerable<UserPreference> GetDislikesForUser(User user)
		{
			List<UserPreference> dislikesList = GetAllDislikes().ToList();
			return dislikesList.FindAll(dis => dis.userId == user.Id);
		}

		public IEnumerable<UserPreference> GetLikesForUser(User user)
		{
			List<UserPreference> likesList = GetAllLikes().ToList();
			return likesList.FindAll(dis => dis.userId == user.Id);
		}

		public UserPreference GetPreference(int userId, int imageId)
		{
			return context.UserPreferences.First(usp => usp.userId == userId && usp.imageId == imageId);
		}

		public UserPreference Update(UserPreference userPreferenceChanges)
		{
			var userPreference = context.UserPreferences.Attach(userPreferenceChanges);
			userPreference.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			context.SaveChanges();
			return userPreference.Entity;
		}
	}
}
