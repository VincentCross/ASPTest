﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RandomImage.Models.Data;

namespace RandomImage.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190505044114_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RandomImage.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Filename")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Filename = "alberto-gasco-1397222-unsplash.jpg",
                            Name = "Image1"
                        },
                        new
                        {
                            Id = 4,
                            Filename = "andrea-reiman-1387147-unsplash.jpg",
                            Name = "Image2"
                        },
                        new
                        {
                            Id = 8,
                            Filename = "aviv-ben-or-1494731-unsplash.jpg",
                            Name = "Image3"
                        },
                        new
                        {
                            Id = 9,
                            Filename = "christian-neuheuser-1487789-unsplash.jpg",
                            Name = "Image4"
                        },
                        new
                        {
                            Id = 16,
                            Filename = "david-billings-1467594-unsplash.jpg",
                            Name = "Image5"
                        },
                        new
                        {
                            Id = 24,
                            Filename = "fabrizio-conti-1453997-unsplash.jpg",
                            Name = "Image6"
                        },
                        new
                        {
                            Id = 53,
                            Filename = "hanan-1399891-unsplash.jpg",
                            Name = "Image7"
                        },
                        new
                        {
                            Id = 54,
                            Filename = "ian-keefe-1505288-unsplash.jpg",
                            Name = "Image8"
                        },
                        new
                        {
                            Id = 55,
                            Filename = "james-eades-1384261-unsplash.jpg",
                            Name = "Image9"
                        },
                        new
                        {
                            Id = 56,
                            Filename = "josh-gordon-1475759-unsplash.jpg",
                            Name = "Image10"
                        });
                });

            modelBuilder.Entity("RandomImage.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RandomImage.Models.UserPreference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("imageId");

                    b.Property<int>("preference");

                    b.Property<int>("userId");

                    b.HasKey("Id");

                    b.ToTable("UserPreferences");
                });
#pragma warning restore 612, 618
        }
    }
}
