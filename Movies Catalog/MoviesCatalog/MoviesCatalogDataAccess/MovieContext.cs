using Microsoft.EntityFrameworkCore;
using MoviesCatalogDomain.Models;
using System;

namespace MoviesCatalogDataAccess
{
    public class MovieContext : DbContext
    {


        public MovieContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Movie Entity
            modelBuilder.Entity<Movie>()
               .HasKey(x => x.Id);
            modelBuilder.Entity<Movie>()
               .Property(x => x.Title)
                .HasMaxLength(200)
                .IsRequired();
            modelBuilder.Entity<Movie>()
                .Property(x => x.ReleaseDate);

            modelBuilder.Entity<Movie>()
                .HasMany(x => x.MovieGenres)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<Movie>()
                .HasMany(x => x.MoviePeople)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId);


            //Person Entity
            modelBuilder.Entity<Person>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Person>()
                .Property(x => x.FullName)
                .HasMaxLength(100)
                .IsRequired();


            //Genre Entity
            modelBuilder.Entity<Genre>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Genre>()
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Role>()
              .HasKey(x => x.Id);
            modelBuilder.Entity<Role>()
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<MovieGenre>()
              .HasKey(e => new { e.MovieId, e.GenreId });

            modelBuilder.Entity<MoviePerson>()
             .HasKey(e => new { e.MovieId, e.PersonId });

            modelBuilder.Entity<PersonRole>()
             .HasKey(e => new { e.PersonId, e.RoleId });


            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);


        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            Genre genreAction = new Genre { Id = 1, Name = "Action" };
            Genre genreComedy = new Genre { Id = 2, Name = "Comedy" };
            Genre genreRomance = new Genre { Id = 3, Name = "Romance" };

            modelBuilder.Entity<Genre>()
                .HasData(genreAction, genreComedy, genreRomance);

            Role roleActor = new Role { Id = 1, Name = "Actor" };
            Role roleDirector = new Role { Id = 2, Name = "Director" };
            Role roleProducer = new Role { Id = 3, Name = "Producer" };

            modelBuilder.Entity<Role>()
                .HasData(roleActor, roleDirector, roleProducer);

            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, FullName = "Name 1" },
                new Person { Id = 2, FullName = "Name 2" },
                new Person { Id = 3, FullName = "Name 3" });

            modelBuilder.Entity<Movie>()
                .HasData(
                    new Movie
                    {
                        Id = 1,
                        Title = "MovieTest1",
                        ReleaseDate = DateTime.Now
                    },
                    new Movie
                    {
                        Id = 2,
                        Title = "MovieTest2",
                        ReleaseDate = DateTime.Now
                    });

            modelBuilder.Entity<MovieGenre>()
             .HasData(
                new MovieGenre { MovieId = 1, GenreId = 1 },
                new MovieGenre { MovieId = 1, GenreId = 2 },
                new MovieGenre { MovieId = 2, GenreId = 3 },
                new MovieGenre { MovieId = 2, GenreId = 2 }
                );

            modelBuilder.Entity<MoviePerson>().HasData(
                new MoviePerson { MovieId = 1, PersonId = 1 },
                new MoviePerson { MovieId = 1, PersonId = 2 },
                new MoviePerson { MovieId = 2, PersonId = 1 },
                new MoviePerson { MovieId = 2, PersonId = 3 }
                );

            modelBuilder.Entity<PersonRole>().HasData(
                new PersonRole { PersonId = 1, RoleId = 1 },
                new PersonRole { PersonId = 1, RoleId = 2 },
                new PersonRole { PersonId = 2, RoleId = 2 },
                new PersonRole { PersonId = 3, RoleId = 3 }
                );
        }

    }
}