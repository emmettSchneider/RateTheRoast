﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RateTheRoast.Models;

namespace RateTheRoast.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<RoastIntensity> RoastIntensity { get; set; }
        public DbSet<BrewMethod> BrewMethod { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Roaster> Roaster { get; set; }
        public DbSet<Coffee> Coffee { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Review>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Coffee>()
                .Property(c => c.DateAdded)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<RoastIntensity>().HasData(
                new RoastIntensity()
                {
                    RoastIntensityId = 1,
                    Intensity = "Light"
                },
                new RoastIntensity()
                {
                    RoastIntensityId = 2,
                    Intensity = "Medium-Light"
                },
                new RoastIntensity()
                {
                    RoastIntensityId = 3,
                    Intensity = "Medium"
                },
                new RoastIntensity()
                {
                    RoastIntensityId = 4,
                    Intensity = "Medium-Dark"
                },
                new RoastIntensity()
                {
                    RoastIntensityId = 5,
                    Intensity = "Dark"
                });

            modelBuilder.Entity<BrewMethod>().HasData(


                new BrewMethod()
                {
                    BrewMethodId = 1,
                    Method = "AeroPress"
                },
                new BrewMethod()
                {
                    BrewMethodId = 2,
                    Method = "Chemex"
                },
                new BrewMethod()
                {
                    BrewMethodId = 3,
                    Method = "Drip coffee maker (non-SCAA certified)"
                },
                new BrewMethod()
                {
                    BrewMethodId = 4,
                    Method = "Drip coffee maker (SCAA certified)"
                },
                new BrewMethod()
                {
                    BrewMethodId = 5,
                    Method = "French press"
                },
                new BrewMethod()
                {
                    BrewMethodId = 6,
                    Method = "Pour over (Kalita Wave, Hario V60, etc.)"
                },
                new BrewMethod()
                {
                    BrewMethodId = 7,
                    Method = "SoftBrew"
                },
                new BrewMethod()
                {
                    BrewMethodId = 8,
                    Method = "Vacuum pot / Siphon"
                });

            modelBuilder.Entity<State>().HasData(
                new State()
                {
                    StateName = "Alabama",
                    StateAbbrev = "AL"
                },
                new State()
                {
                    StateName = "Alaska",
                    StateAbbrev = "AK"
                },
                new State()
                {
                    StateName = "Arizona",
                    StateAbbrev = "AZ"
                },
                new State()
                {
                    StateName = "Arkansas",
                    StateAbbrev = "AR"
                },
                new State()
                {
                    StateName = "California",
                    StateAbbrev = "CA"
                },
                new State()
                {
                    StateName = "Colorado",
                    StateAbbrev = "CO"
                },
                new State()
                {
                    StateName = "Connecticut",
                    StateAbbrev = "CT"
                },
                new State()
                {
                    StateName = "Delaware",
                    StateAbbrev = "DE"
                },
                new State()
                {
                    StateName = "Florida",
                    StateAbbrev = "FL"
                },
                new State()
                {
                    StateName = "Georgia",
                    StateAbbrev = "GA"
                },
                new State()
                {
                    StateName = "Hawaii",
                    StateAbbrev = "HI"
                },
                new State()
                {
                    StateName = "Idaho",
                    StateAbbrev = "ID"
                },
                new State()
                {
                    StateName = "Illinois",
                    StateAbbrev = "IL"
                },
                new State()
                {
                    StateName = "Indiana",
                    StateAbbrev = "IN"
                },
                new State()
                {
                    StateName = "Iowa",
                    StateAbbrev = "IA"
                },
                new State()
                {
                    StateName = "Kansas",
                    StateAbbrev = "KS"
                },
                new State()
                {
                    StateName = "Kentucky",
                    StateAbbrev = "KY"
                },
                new State()
                {
                    StateName = "Louisiana",
                    StateAbbrev = "LA"
                },
                new State()
                {
                    StateName = "Maine",
                    StateAbbrev = "ME"
                },
                new State()
                {
                    StateName = "Maryland",
                    StateAbbrev = "MD"
                },
                new State()
                {
                    StateName = "Massachusetts",
                    StateAbbrev = "MA"
                },
                new State()
                {
                    StateName = "Michigan",
                    StateAbbrev = "MI"
                },
                new State()
                {
                    StateName = "Minnesota",
                    StateAbbrev = "MN"
                },
                new State()
                {
                    StateName = "Mississippi",
                    StateAbbrev = "MS"
                },
                new State()
                {
                    StateName = "Missouri",
                    StateAbbrev = "MO"
                },
                new State()
                {
                    StateName = "Montana",
                    StateAbbrev = "MT"
                },
                new State()
                {
                    StateName = "Nebraska",
                    StateAbbrev = "NE"
                },
                new State()
                {
                    StateName = "Nevada",
                    StateAbbrev = "NV"
                },
                new State()
                {
                    StateName = "New Hampshire",
                    StateAbbrev = "NH"
                },
                new State()
                {
                    StateName = "New Jersey",
                    StateAbbrev = "NJ"
                },
                new State()
                {
                    StateName = "New Mexico",
                    StateAbbrev = "NM"
                },
                new State()
                {
                    StateName = "New York",
                    StateAbbrev = "NY"
                },
                new State()
                {
                    StateName = "North Carolina",
                    StateAbbrev = "NC"
                },
                new State()
                {
                    StateName = "North Dakota",
                    StateAbbrev = "ND"
                },
                new State()
                {
                    StateName = "Ohio",
                    StateAbbrev = "OH"
                },
                new State()
                {
                    StateName = "Oklahoma",
                    StateAbbrev = "OK"
                },
                new State()
                {
                    StateName = "Oregon",
                    StateAbbrev = "OR"
                },
                new State()
                {
                    StateName = "Pennsylvania",
                    StateAbbrev = "PA"
                },
                new State()
                {
                    StateName = "Rhode Island",
                    StateAbbrev = "RI"
                },
                new State()
                {
                    StateName = "South Carolina",
                    StateAbbrev = "SC"
                },
                new State()
                {
                    StateName = "South Dakota",
                    StateAbbrev = "SD"
                },
                new State()
                {
                    StateName = "Tennessee",
                    StateAbbrev = "TN"
                },
                new State()
                {
                    StateName = "Texas",
                    StateAbbrev = "TX"
                },
                new State()
                {
                    StateName = "Utah",
                    StateAbbrev = "UT"
                },
                new State()
                {
                    StateName = "Vermont",
                    StateAbbrev = "VT"
                },
                new State()
                {
                    StateName = "Virgina",
                    StateAbbrev = "VA"
                },
                new State()
                {
                    StateName = "Washington",
                    StateAbbrev = "WA"
                },
                new State()
                {
                    StateName = "West Virginia",
                    StateAbbrev = "WV"
                },
                new State()
                {
                    StateName = "Wisconsin",
                    StateAbbrev = "WI"
                },
                new State()
                {
                    StateName = "Wyoming",
                    StateAbbrev = "WY"
                }
                );

            modelBuilder.Entity<Location>().HasData(
                new Location()
                {
                    LocationId = 1,
                    Name = "The Turnip Truck",
                    Address = "701 Woodland St",
                    City = "Nashville",
                    StateAbbrev = "TN"
                },
                new Location()
                {
                    LocationId = 2,
                    Name = "Bongo East",
                    Address = "107 S 11th St",
                    City = "Nashville",
                    StateAbbrev = "TN"
                },
                new Location()
                {
                    LocationId = 3,
                    Name = "Revelator Coffee Company",
                    Address = "1817 21st Ave S",
                    City = "Nashville",
                    StateAbbrev = "TN"
                },
                new Location()
                {
                    LocationId = 4,
                    Name = "Kroger",
                    Address = "711 Gallatin Ave",
                    City = "Nashville",
                    StateAbbrev = "TN"
                });

            ApplicationUser user = new ApplicationUser
            {
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Handle = "admin",
                NormalizedHandle = "ADMIN",
                City = "Nashville",
                StateAbbrev = "TN"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "P@ssword99");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            ApplicationUser user2 = new ApplicationUser
            {
                UserName = "barnyardbarista@hotmail.com",
                NormalizedUserName = "BARNYARDBARISTA@HOTMAIL.COM",
                Email = "barnyardbarista@hotmail.com",
                NormalizedEmail = "BARNYARDBARISTA@HOTMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Handle = "BarnyardBarista",
                NormalizedHandle = "BARNYARDBARISTA",
                City = "Chattanooga",
                StateAbbrev = "TN"
            };
            passwordHash = new PasswordHasher<ApplicationUser>();
            user2.PasswordHash = passwordHash.HashPassword(user2, "P@ssword99");
            modelBuilder.Entity<ApplicationUser>().HasData(user2);

            ApplicationUser user3 = new ApplicationUser
            {
                UserName = "info@bongojava.com",
                NormalizedUserName = "INFO@BONGOJAVA.COM",
                Email = "info@bongojava.com",
                NormalizedEmail = "INFO@BONGOJAVA.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Handle = "BongoJava",
                NormalizedHandle = "BONGOJAVA",
                City = "Nashville",
                StateAbbrev = "TN"
            };
            passwordHash = new PasswordHasher<ApplicationUser>();
            user3.PasswordHash = passwordHash.HashPassword(user3, "P@ssword99");
            modelBuilder.Entity<ApplicationUser>().HasData(user3);

            modelBuilder.Entity<Roaster>().HasData(
                new Roaster()
                {
                    RoasterId = 1,
                    UserId = user3.Id,
                    Name = "Bongo Java",
                    City = "Nashville",
                    StateAbbrev = "TN",
                    ImagePath = null
                },
                new Roaster()
                {
                    RoasterId = 2,
                    UserId = null,
                    Name = "Revelator Coffee Company",
                    City = "Birmingham",
                    StateAbbrev = "AL",
                    ImagePath = null
                },
                new Roaster()
                {
                    RoasterId = 3,
                    UserId = null,
                    Name = "Folgers",
                    City = "New Orleans",
                    StateAbbrev = "LA",
                    ImagePath = null
                },
                new Roaster()
                {
                    RoasterId = 4,
                    UserId = null,
                    Name = "Intelligentsia",
                    City = "Chicago",
                    StateAbbrev = "IL",
                    ImagePath = null
                },
                new Roaster()
                {
                    RoasterId = 5,
                    UserId = null,
                    Name = "Frothy Monkey",
                    City = "Nashville",
                    StateAbbrev = "TN",
                    ImagePath = null
                });

            modelBuilder.Entity<Coffee>().HasData(
                new Coffee()
                {
                    CoffeeId = 1,
                    RoasterId = 1,
                    Name = "Bible Belt",
                    Origin = "Blend",
                    Region = null,
                    Description = "A nod to our hometown, lovingly referred to as the Buckle of the Bible Belt. Flavor notes of Brown Sugar, Cocoa, and Baked Pear",
                    RoastIntensityId = 1,
                    ImagePath = null
                },
                new Coffee()
                {
                    CoffeeId = 2,
                    RoasterId = 4,
                    Name = "Colombia Tres Santos",
                    Origin = "Colombia",
                    Region = "Cauca",
                    Description = "SOTARÁ EDITION | After four lots from Nariño, our Tres Santos tour of Colombia's most exciting growing regions takes us to Cauca, where we have been working since 2016 with a group of 80 smallholder farmers committed to quality. We blended the four best single-farm lots of the bunch for this Tres Santos offering, which comes from the farms of Hover Guevara, Eudaro Garzón, José Chicangana, and Ramón Manzano. Flavor Notes: Apple, Caramel, Baked Lemon",
                    RoastIntensityId = 2,
                    ImagePath = null
                },
                new Coffee()
                {
                    CoffeeId = 3,
                    RoasterId = 1,
                    Name = "Ethiopia Yirgacheffe",
                    Origin = "Ethiopia",
                    Region = "Yirgacheffe",
                    Description = "Ethiopia is where coffee was discovered and these are some of the best organic beans this country has to offer. A floral cup with delicate sweet lemon acidity, strong aroma of bergamont and jasmine flowers. Flavor notes Sweet Citrus Orange and Honeydew",
                    RoastIntensityId = 1,
                    ImagePath = null
                },
                new Coffee()
                {
                    CoffeeId = 4,
                    RoasterId = 5,
                    Name = "El Salvador El Manzano Honey",
                    Origin = "El Salvador",
                    Region = "Santa Ana",
                    Description = "This is an insanely smooth, balanced coffee, with notes of caramel apples, figs, and cashews throughout. It’s acidity is subtly citrusy, just like a clementine, and it’s sweetness is like strawberry candy.",
                    RoastIntensityId = 2,
                    ImagePath = null
                });

            modelBuilder.Entity<Review>().HasData(
                new Review()
                {
                    ReviewId = 1,
                    CoffeeId = 1,
                    UserId = user2.Id,
                    BrewMethodId = 6,
                    Price = 12.99,
                    LocationId = 2,
                    Narrative = "The Bible Belt Blend is a signature blend for Bongo Java. I'm a big fan. I taste the brown sugar, cocoa, and baked pear mentioned in Bongo Java's description, but I also enjoy hints of blackberry and molasses. Love this roast's name!",
                    Score = 9,
                    DateEdited = null
                },
                new Review()
                {
                    ReviewId = 2,
                    CoffeeId = 4,
                    UserId = user2.Id,
                    BrewMethodId = 6,
                    Price = 15.99,
                    LocationId = 1,
                    Narrative = "I've said it before, and I'll say it again, Frothy Monkey's single origin coffees are underrated. The El Salvador El Manzano Honey gives me apple, orange, and fig. It's also a little nutty, just like me. ",
                    Score = 9,
                    DateEdited = null
                });

            modelBuilder.Entity<Favorite>().HasData(
                new Favorite()
                {
                    FavoriteId = 1,
                    UserId = user2.Id,
                    CoffeeId = 4
                });

            modelBuilder.Entity<Wishlist>().HasData(
                new Wishlist()
                {
                    WishlistId = 1,
                    UserId = user2.Id,
                    CoffeeId = 2
                });
        }
    }
}
