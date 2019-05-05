using RandomImage.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Models.Repositories
{
	public class SQLImageRepository : IImageRepository
	{
		private readonly AppDbContext context;

		public SQLImageRepository(AppDbContext context)
		{
			this.context = context;
		}

		public Image Add(Image image)
		{
			context.Images.Add(image);
			context.SaveChanges();
			return image;
		}

		public IEnumerable<Image> GetAllImages()
		{
			return context.Images;
		}

		public Image GetImage(int Id)
		{
			return context.Images.Find(Id);
		}

		public Image GetRandomImage()
		{
			List<Image> imageList = GetAllImages().ToList();
			return imageList[new Random().Next(imageList.Count())];
		}
	}
}
