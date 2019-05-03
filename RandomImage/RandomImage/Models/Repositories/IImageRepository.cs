using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Models
{
	public interface IImageRepository
	{
		Image GetImage(int Id);
		Image GetRandomImage();
		IEnumerable<Image> GetAllImages();
		Image Add(Image image);
		//Image Update(Image imageChanges);
		//Image Delete(int Id);
	}
}
