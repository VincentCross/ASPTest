using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Models.Repositories
{
	public class MockImageRepository : IImageRepository
	{
		private List<Image> _imageList;

		public MockImageRepository()
		{
			_imageList = new List<Image>()
			{
				new Image() { Id = 1, Name = "Image1", Filename = "alberto-gasco-1397222-unsplash"},
				new Image() { Id = 4, Name = "Image2", Filename = "andrea-reiman-1387147-unsplash.jpg"},
				new Image() { Id = 8, Name = "Image3", Filename = "aviv-ben-or-1494731-unsplash.jpg"},
				new Image() { Id = 9, Name = "Image4", Filename = "christian-neuheuser-1487789-unsplash.jpg"},
				new Image() { Id = 16, Name = "Image5", Filename = "david-billings-1467594-unsplash.jpg"},
				new Image() { Id = 24, Name = "Image6", Filename = "fabrizio-conti-1453997-unsplash.jpg"},
				new Image() { Id = 53, Name = "Image7", Filename = "hanan-1399891-unsplash.jpg"}
			};
		}

		public Image Add(Image image)
		{
			image.Id = _imageList.Max(img => img.Id) + 1;
			_imageList.Add(image);
			return image;
		}

		public IEnumerable<Image> GetAllImages()
		{
			return _imageList;
		}

		public Image GetImage(int Id)
		{
			return _imageList.FirstOrDefault(img => img.Id == Id);
		}

		public Image GetRandomImage()
		{
			return _imageList[new Random().Next(_imageList.Count())];
		}
	}
}
