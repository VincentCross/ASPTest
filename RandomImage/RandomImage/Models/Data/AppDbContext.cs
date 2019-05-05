using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomImage.Models.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
		{

		}

		public DbSet<User> Users { get; set; }
		public DbSet<Image> Images { get; set; }
		public DbSet<UserPreference> UserPreferences { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Image>().HasData(
					new Image() { Id = 1, Name = "Image1", Filename = "alberto-gasco-1397222-unsplash.jpg" },
					new Image() { Id = 4, Name = "Image2", Filename = "andrea-reiman-1387147-unsplash.jpg" },
					new Image() { Id = 8, Name = "Image3", Filename = "aviv-ben-or-1494731-unsplash.jpg" },
					new Image() { Id = 9, Name = "Image4", Filename = "christian-neuheuser-1487789-unsplash.jpg" },
					new Image() { Id = 16, Name = "Image5", Filename = "david-billings-1467594-unsplash.jpg" },
					new Image() { Id = 24, Name = "Image6", Filename = "fabrizio-conti-1453997-unsplash.jpg" },
					new Image() { Id = 53, Name = "Image7", Filename = "hanan-1399891-unsplash.jpg" },
					new Image() { Id = 54, Name = "Image8", Filename = "ian-keefe-1505288-unsplash.jpg" },
					new Image() { Id = 55, Name = "Image9", Filename = "james-eades-1384261-unsplash.jpg" },
					new Image() { Id = 56, Name = "Image10", Filename = "josh-gordon-1475759-unsplash.jpg" }
				);
		}
	}
}
