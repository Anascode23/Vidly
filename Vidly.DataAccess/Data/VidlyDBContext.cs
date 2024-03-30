using Microsoft.EntityFrameworkCore;
using Vidly.Models;


namespace Vidly.Access.Data
{
    public class VidlyDBContext : DbContext
    {
        public VidlyDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
               new Customer { Id = 1, Name = "Sarah", BirthDate = new DateTime(2013, 11, 02), MembershipTypeId = 4 },
               new Customer { Id = 2, Name = "Jack", BirthDate = new DateTime(2005, 01, 15), MembershipTypeId = 5 },
               new Customer { Id = 3, Name = "Marry", BirthDate = new DateTime(2019, 05, 09), MembershipTypeId = 6 },
               new Customer { Id = 4, Name = "Salem", BirthDate = new DateTime(2000, 03, 25), MembershipTypeId = 7 }
               );



            modelBuilder.Entity<MembershipType>().HasData(
              new MembershipType
              {
                  Id = 4,
                  Name = "Pay as You Go",
                  SignUpFee = 0,
                  DurationInMonths = 0,
                  DiscountRate = 0
              },
              new MembershipType
              {
                  Id = 5,
                  Name = "Monthly",
                  SignUpFee = 30,
                  DurationInMonths = 1,
                  DiscountRate = 10
              },
              new MembershipType
              {
                  Id = 6,
                  Name = "Quarterly",
                  SignUpFee = 90,
                  DurationInMonths = 3,
                  DiscountRate = 15
              },
              new MembershipType
              {
                  Id = 7,
                  Name = "Annual",
                  SignUpFee = 300,
                  DurationInMonths = 12,
                  DiscountRate = 20
              }
              );

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Name = "Iron Man",
                    ReleaseDate = new DateTime(2008, 05, 01),
                    DateAdded = new DateTime(2024, 03, 24),
                    NumbersInStock = 5,
                    GenreId = 5
                },
                new Movie
                {
                    Id = 2,
                    Name = "Us",
                    ReleaseDate = new DateTime(2019, 03, 22),
                    DateAdded = new DateTime(2024, 03, 24),
                    NumbersInStock = 5,
                    GenreId = 6
                },
                new Movie
                {
                    Id = 3,
                    Name = "Dora and the Lost City of Gold",
                    ReleaseDate = new DateTime(2019, 08, 09),
                    DateAdded = new DateTime(2024, 03, 24),
                    NumbersInStock = 5,
                    GenreId = 7
                },
                new Movie
                {
                    Id = 4,
                    Name = "A Silent Voice",
                    ReleaseDate = new DateTime(2016, 09, 17),
                    DateAdded = new DateTime(2024, 03, 24),
                    NumbersInStock = 5,
                    GenreId = 8
                }
                );



            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 5, Name = "Action" },
                new Genre { Id = 6, Name = "Horror" },
                new Genre { Id = 7, Name = "Adventure" },
                new Genre { Id = 8, Name = "Romance" }
             );
        }
    }
}