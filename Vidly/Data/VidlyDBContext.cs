﻿using Microsoft.EntityFrameworkCore;
using Vidly.Models;

namespace Vidly.Data
{
    public class VidlyDBContext : DbContext
    {
        public VidlyDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
               new Customer { Id = 1, Name = "Sarah" },
               new Customer { Id = 2, Name = "Jack" },
               new Customer { Id = 3, Name = "Marry" }
               );



            modelBuilder.Entity<MembershipType>().HasData(
              new MembershipType
              {
                  Id = 4,
                  SignUpFee = 0,
                  DurationInMonths = 0,
                  DiscountRate = 0
              },
              new MembershipType
              {
                  Id = 5,
                  SignUpFee = 30,
                  DurationInMonths = 1,
                  DiscountRate = 10
              },
              new MembershipType
              {
                  Id = 6,
                  SignUpFee = 90,
                  DurationInMonths = 3,
                  DiscountRate = 15
              },
              new MembershipType
              {
                  Id = 7,
                  SignUpFee = 300,
                  DurationInMonths = 12,
                  DiscountRate = 20
              }
              );
        }
    }
}