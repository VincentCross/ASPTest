using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Models
{
	public interface IUserPreferenceRepository
	{
		UserPreferance GetPreferance(User user, Image image);
		IEnumerable<UserPreferance> GetAllUserPreferances();
		UserPreferance Add(UserPreferance userPreferance);
		UserPreferance Update(UserPreferance userPreferanceChanges);
		UserPreferance Delete(User user, Image image);
	}
}
