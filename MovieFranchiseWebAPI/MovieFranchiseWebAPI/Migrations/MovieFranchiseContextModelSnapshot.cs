﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieFranchiseWebAPI.Models;

namespace MovieFranchiseWebAPI.Migrations
{
    [DbContext(typeof(MovieFranchiseContext))]
    partial class MovieFranchiseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieCharacter", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("MovieCharacter");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            CharacterId = 1
                        },
                        new
                        {
                            MovieId = 2,
                            CharacterId = 3
                        },
                        new
                        {
                            MovieId = 2,
                            CharacterId = 4
                        },
                        new
                        {
                            MovieId = 3,
                            CharacterId = 2
                        },
                        new
                        {
                            MovieId = 3,
                            CharacterId = 3
                        },
                        new
                        {
                            MovieId = 3,
                            CharacterId = 4
                        },
                        new
                        {
                            MovieId = 3,
                            CharacterId = 6
                        },
                        new
                        {
                            MovieId = 4,
                            CharacterId = 2
                        },
                        new
                        {
                            MovieId = 4,
                            CharacterId = 3
                        },
                        new
                        {
                            MovieId = 4,
                            CharacterId = 4
                        },
                        new
                        {
                            MovieId = 4,
                            CharacterId = 5
                        },
                        new
                        {
                            MovieId = 4,
                            CharacterId = 6
                        });
                });

            modelBuilder.Entity("MovieFranchiseWebAPI.Models.Domain.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PictureURL")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Character");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "Baba Yaga",
                            FullName = "John Wick",
                            Gender = "Male",
                            PictureURL = "https://static1.colliderimages.com/wordpress/wp-content/uploads/2021/03/john-wick-keanu-reeves-social-1.jpg"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "Iron Man",
                            FullName = "Tony Stark",
                            Gender = "Male",
                            PictureURL = "https://img.joomcdn.net/dace9a3da47d7d748e13af43f96344a4449c7688_original.jpeg"
                        },
                        new
                        {
                            Id = 3,
                            Alias = "Captain America",
                            FullName = "Steve Rogers",
                            Gender = "Male",
                            PictureURL = "https://static.wikia.nocookie.net/marvel-cinematic/images/3/32/Steve_Rogers_2.jpg/revision/latest?cb=20131025030358"
                        },
                        new
                        {
                            Id = 4,
                            Alias = "Black Widow",
                            FullName = "Natasha Romanoff",
                            Gender = "Female",
                            PictureURL = "https://pbs.twimg.com/media/FC-HLpbWUAI4UCa.jpg"
                        },
                        new
                        {
                            Id = 5,
                            Alias = "Hulk",
                            FullName = "Bruce Banner",
                            Gender = "Male",
                            PictureURL = "https://upload.wikimedia.org/wikipedia/en/thumb/3/3b/Mark_Ruffalo_as_%22Professor_Hulk%22.jpeg/200px-Mark_Ruffalo_as_%22Professor_Hulk%22.jpeg"
                        },
                        new
                        {
                            Id = 6,
                            Alias = "Spider-Man",
                            FullName = "Peter Parker",
                            Gender = "Male",
                            PictureURL = "https://www.koimoi.com/wp-content/new-galleries/2021/12/new-spider-man-trilogy-to-witness-tom-hollands-peter-parker-in-college-001.jpg"
                        });
                });

            modelBuilder.Entity("MovieFranchiseWebAPI.Models.Domain.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Franchise");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "John Wick is an American neo-noir action-thriller media franchise created by screenwriter Derek Kolstad and starring Keanu Reeves as John Wick, a former hitman who is forced back into the criminal underworld he abandoned.",
                            Name = "John Wick"
                        },
                        new
                        {
                            Id = 2,
                            Description = "The Marvel Cinematic Universe (MCU) is an American media franchise and shared universe centered on a series of superhero films produced by Marvel Studios.",
                            Name = "The Marvel Cinematic Universe"
                        });
                });

            modelBuilder.Entity("MovieFranchiseWebAPI.Models.Domain.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Director")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("PictureURL")
                        .HasMaxLength(175)
                        .HasColumnType("nvarchar(175)");

                    b.Property<int>("ReleaseYear")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<string>("Tittle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TrailerURL")
                        .HasMaxLength(175)
                        .HasColumnType("nvarchar(175)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "Derek Kolstad",
                            FranchiseId = 1,
                            Genre = "Action, Crime, Drama, Thriller",
                            PictureURL = "https://filmyhotspot.com/wp-content/uploads/2020/12/39e611e5-870c-4c6d-97a1-e7c9ee51a97b.jpg",
                            ReleaseYear = 2023,
                            Tittle = "John Wick: Chapter 4",
                            TrailerURL = "https://www.youtube.com/watch?v=gy31U2bvVGU"
                        },
                        new
                        {
                            Id = 2,
                            Director = "Russo",
                            FranchiseId = 2,
                            Genre = "Action, Drama, Romace",
                            PictureURL = "https://m.media-amazon.com/images/M/MV5BMzA2NDkwODAwM15BMl5BanBnXkFtZTgwODk5MTgzMTE@._V1_.jpg",
                            ReleaseYear = 2014,
                            Tittle = "Captain America: The Winter Soldier",
                            TrailerURL = "https://www.youtube.com/watch?v=tbayiPxkUMM"
                        },
                        new
                        {
                            Id = 3,
                            Director = "Russo",
                            FranchiseId = 2,
                            Genre = "Action, Drama",
                            PictureURL = "https://m.media-amazon.com/images/M/MV5BMzA2NDkwODAwM15BMl5BanBnXkFtZTgwODk5MTgzMTE@._V1_.jpg",
                            ReleaseYear = 2016,
                            Tittle = "Captain America: Civil War",
                            TrailerURL = "https://www.youtube.com/watch?v=tbayiPxkUMM"
                        },
                        new
                        {
                            Id = 4,
                            Director = "Russo",
                            FranchiseId = 2,
                            Genre = "Action, Comedy, Drama, Romance",
                            PictureURL = "https://m.media-amazon.com/images/M/MV5BMjMxNjY2MDU1OV5BMl5BanBnXkFtZTgwNzY1MTUwNTM@._V1_.jpg",
                            ReleaseYear = 2018,
                            Tittle = "Avengers: Infinity War",
                            TrailerURL = "https://www.youtube.com/watch?v=QwievZ1Tx-8"
                        });
                });

            modelBuilder.Entity("MovieCharacter", b =>
                {
                    b.HasOne("MovieFranchiseWebAPI.Models.Domain.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieFranchiseWebAPI.Models.Domain.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieFranchiseWebAPI.Models.Domain.Movie", b =>
                {
                    b.HasOne("MovieFranchiseWebAPI.Models.Domain.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId");

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("MovieFranchiseWebAPI.Models.Domain.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
