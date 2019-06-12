﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RateTheRoast.Data;

namespace RateTheRoast.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190612173937_add-migration RateTheRoastTables")]
    partial class addmigrationRateTheRoastTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RateTheRoast.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsAdministrator");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "6235a0ba-95cc-4e41-83ad-ec28578b3b6f",
                            AccessFailedCount = 0,
                            City = "Nashville",
                            ConcurrencyStamp = "949a00d7-e441-49ac-b63f-0b001e9eb026",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            IsAdministrator = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEKYHUvWxVTUvA4XBQrWDkqCyRsTz0C2a6zJ6UT2xH6uHlvVSUXB5KN1H8gC1bu69MA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4567ac3d-d3e0-449b-9b1e-0bcd8d0aa1cf",
                            State = "TN",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "57e3ed46-19c3-4c0c-bc9e-cbe04e660a8b",
                            AccessFailedCount = 0,
                            City = "Chattanooga",
                            ConcurrencyStamp = "34671055-9794-40d1-973c-cb5edf9d8caa",
                            Email = "barnyardbarista@hotmail.com",
                            EmailConfirmed = true,
                            IsAdministrator = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "BARNYARDBARISTA@HOTMAIL.COM",
                            NormalizedUserName = "BARNYARDBARISTA",
                            PasswordHash = "AQAAAAEAACcQAAAAEA9ZxkIc4c/2SzkJqkEIqZZE+TSKmLgkXg/GkkGTeAAcVn3uylvnpkcJIQDBvGLZYg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fd699e60-3126-4390-b1ab-0e03726ad5c6",
                            State = "TN",
                            TwoFactorEnabled = false,
                            UserName = "BarnyardBarista"
                        },
                        new
                        {
                            Id = "9692dd2b-b06b-48e2-a43c-dd8c77ae2814",
                            AccessFailedCount = 0,
                            City = "Nashville",
                            ConcurrencyStamp = "2f734933-5561-4c9d-804a-973a7f2d97a1",
                            Email = "info@bongojava.com",
                            EmailConfirmed = true,
                            IsAdministrator = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "INFO@BONGOJAVA.COM",
                            NormalizedUserName = "BONGOJAVA",
                            PasswordHash = "AQAAAAEAACcQAAAAEK7hhTbIkTrO/PQZuchyoGulVX8mmdV+fZbef9/6+khBPwFMKILaNhAx6mS8cCrvnA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "235aca19-7d28-4ce0-b615-0c72864da69a",
                            State = "TN",
                            TwoFactorEnabled = false,
                            UserName = "BongoJava"
                        });
                });

            modelBuilder.Entity("RateTheRoast.Models.BrewMethod", b =>
                {
                    b.Property<int>("BrewMethodId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Method");

                    b.HasKey("BrewMethodId");

                    b.ToTable("BrewMethod");

                    b.HasData(
                        new
                        {
                            BrewMethodId = 1,
                            Method = "AeroPress"
                        },
                        new
                        {
                            BrewMethodId = 2,
                            Method = "Chemex"
                        },
                        new
                        {
                            BrewMethodId = 3,
                            Method = "Drip coffee maker (non-SCAA certified)"
                        },
                        new
                        {
                            BrewMethodId = 4,
                            Method = "Drip coffee maker (SCAA certified)"
                        },
                        new
                        {
                            BrewMethodId = 5,
                            Method = "French press"
                        },
                        new
                        {
                            BrewMethodId = 6,
                            Method = "Pour over (Kalita Wave, Hario V60, etc.)"
                        },
                        new
                        {
                            BrewMethodId = 7,
                            Method = "SoftBrew"
                        },
                        new
                        {
                            BrewMethodId = 8,
                            Method = "Vacuum pot / Siphon"
                        });
                });

            modelBuilder.Entity("RateTheRoast.Models.Coffee", b =>
                {
                    b.Property<int>("CoffeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Origin")
                        .IsRequired();

                    b.Property<string>("Region");

                    b.Property<int>("RoastIntensityId");

                    b.Property<int>("RoasterId");

                    b.HasKey("CoffeeId");

                    b.HasIndex("RoastIntensityId");

                    b.HasIndex("RoasterId");

                    b.ToTable("Coffee");

                    b.HasData(
                        new
                        {
                            CoffeeId = 1,
                            Description = "A nod to our hometown, lovingly referred to as the Buckle of the Bible Belt. Flavor notes of Brown Sugar, Cocoa, and Baked Pear",
                            Name = "Bible Belt",
                            Origin = "Blend",
                            RoastIntensityId = 1,
                            RoasterId = 1
                        },
                        new
                        {
                            CoffeeId = 2,
                            Description = "SOTARÁ EDITION | After four lots from Nariño, our Tres Santos tour of Colombia's most exciting growing regions takes us to Cauca, where we have been working since 2016 with a group of 80 smallholder farmers committed to quality. We blended the four best single-farm lots of the bunch for this Tres Santos offering, which comes from the farms of Hover Guevara, Eudaro Garzón, José Chicangana, and Ramón Manzano. Flavor Notes: Apple, Caramel, Baked Lemon",
                            Name = "Colombia Tres Santos",
                            Origin = "Colombia",
                            Region = "Cauca",
                            RoastIntensityId = 2,
                            RoasterId = 4
                        },
                        new
                        {
                            CoffeeId = 3,
                            Description = "Ethiopia is where coffee was discovered and these are some of the best organic beans this country has to offer. A floral cup with delicate sweet lemon acidity, strong aroma of bergamont and jasmine flowers. Flavor notes Sweet Citrus Orange and Honeydew",
                            Name = "Ethiopia Yirgacheffe",
                            Origin = "Ethiopia",
                            Region = "Yirgacheffe",
                            RoastIntensityId = 1,
                            RoasterId = 1
                        },
                        new
                        {
                            CoffeeId = 4,
                            Description = "This is an insanely smooth, balanced coffee, with notes of caramel apples, figs, and cashews throughout. It’s acidity is subtly citrusy, just like a clementine, and it’s sweetness is like strawberry candy.",
                            Name = "El Salvador El Manzano Honey",
                            Origin = "El Salvador",
                            Region = "Santa Ana",
                            RoastIntensityId = 2,
                            RoasterId = 5
                        });
                });

            modelBuilder.Entity("RateTheRoast.Models.Favorite", b =>
                {
                    b.Property<int>("FavoriteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoffeeId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("FavoriteId");

                    b.HasIndex("CoffeeId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorite");

                    b.HasData(
                        new
                        {
                            FavoriteId = 1,
                            CoffeeId = 4,
                            UserId = "57e3ed46-19c3-4c0c-bc9e-cbe04e660a8b"
                        });
                });

            modelBuilder.Entity("RateTheRoast.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.HasKey("LocationId");

                    b.ToTable("Location");

                    b.HasData(
                        new
                        {
                            LocationId = 1,
                            Address = "701 Woodland St",
                            City = "Nashville",
                            Name = "The Turnip Truck",
                            State = "TN"
                        },
                        new
                        {
                            LocationId = 2,
                            Address = "107 S 11th St",
                            City = "Nashville",
                            Name = "Bongo East",
                            State = "TN"
                        },
                        new
                        {
                            LocationId = 3,
                            Address = "1817 21st Ave S",
                            City = "Nashville",
                            Name = "Revelator Coffee Company",
                            State = "TN"
                        },
                        new
                        {
                            LocationId = 4,
                            Address = "711 Gallatin Ave",
                            City = "Nashville",
                            Name = "Kroger",
                            State = "TN"
                        });
                });

            modelBuilder.Entity("RateTheRoast.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrewMethodId");

                    b.Property<int>("CoffeeId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateEdited")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int?>("LocationId");

                    b.Property<string>("Narrative")
                        .IsRequired();

                    b.Property<double>("Price");

                    b.Property<int>("Score");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("ReviewId");

                    b.HasIndex("BrewMethodId");

                    b.HasIndex("CoffeeId");

                    b.HasIndex("LocationId");

                    b.HasIndex("UserId");

                    b.ToTable("Review");

                    b.HasData(
                        new
                        {
                            ReviewId = 1,
                            BrewMethodId = 6,
                            CoffeeId = 1,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LocationId = 2,
                            Narrative = "The Bible Belt Blend is a signature blend for Bongo Java. I'm a big fan. I taste the brown sugar, cocoa, and baked pear mentioned in Bongo Java's description, but I also enjoy hints of blackberry and molasses. Love this roast's name!",
                            Price = 12.99,
                            Score = 9,
                            UserId = "57e3ed46-19c3-4c0c-bc9e-cbe04e660a8b"
                        },
                        new
                        {
                            ReviewId = 2,
                            BrewMethodId = 6,
                            CoffeeId = 4,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LocationId = 1,
                            Narrative = "I've said it before, and I'll say it again, Frothy Monkey's single origin coffees are underrated. The El Salvador El Manzano Honey gives me apple, orange, and fig. It's also a little nutty, just like me. ",
                            Price = 15.99,
                            Score = 9,
                            UserId = "57e3ed46-19c3-4c0c-bc9e-cbe04e660a8b"
                        });
                });

            modelBuilder.Entity("RateTheRoast.Models.RoastIntensity", b =>
                {
                    b.Property<int>("RoastIntensityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Intensity");

                    b.HasKey("RoastIntensityId");

                    b.ToTable("RoastIntensity");

                    b.HasData(
                        new
                        {
                            RoastIntensityId = 1,
                            Intensity = "Light"
                        },
                        new
                        {
                            RoastIntensityId = 2,
                            Intensity = "Medium-Light"
                        },
                        new
                        {
                            RoastIntensityId = 3,
                            Intensity = "Medium"
                        },
                        new
                        {
                            RoastIntensityId = 4,
                            Intensity = "Medium-Dark"
                        },
                        new
                        {
                            RoastIntensityId = 5,
                            Intensity = "Dark"
                        });
                });

            modelBuilder.Entity("RateTheRoast.Models.Roaster", b =>
                {
                    b.Property<int>("RoasterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("RoasterId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Roaster");

                    b.HasData(
                        new
                        {
                            RoasterId = 1,
                            City = "Nashville",
                            Name = "Bongo Java",
                            State = "TN",
                            UserId = "9692dd2b-b06b-48e2-a43c-dd8c77ae2814"
                        },
                        new
                        {
                            RoasterId = 2,
                            City = "Birmingham",
                            Name = "Revelator Coffee Company",
                            State = "AL"
                        },
                        new
                        {
                            RoasterId = 3,
                            City = "New Orleans",
                            Name = "Folgers",
                            State = "LA"
                        },
                        new
                        {
                            RoasterId = 4,
                            City = "Chicago",
                            Name = "Intelligentsia",
                            State = "IL"
                        },
                        new
                        {
                            RoasterId = 5,
                            City = "Nashville",
                            Name = "Frothy Monkey",
                            State = "TN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RateTheRoast.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RateTheRoast.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RateTheRoast.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RateTheRoast.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RateTheRoast.Models.Coffee", b =>
                {
                    b.HasOne("RateTheRoast.Models.RoastIntensity", "RoastIntensity")
                        .WithMany("Coffees")
                        .HasForeignKey("RoastIntensityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RateTheRoast.Models.Roaster", "Roaster")
                        .WithMany("Coffees")
                        .HasForeignKey("RoasterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RateTheRoast.Models.Favorite", b =>
                {
                    b.HasOne("RateTheRoast.Models.Coffee", "Coffee")
                        .WithMany("Favorites")
                        .HasForeignKey("CoffeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RateTheRoast.Models.ApplicationUser", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RateTheRoast.Models.Review", b =>
                {
                    b.HasOne("RateTheRoast.Models.BrewMethod", "BrewMethod")
                        .WithMany("Reviews")
                        .HasForeignKey("BrewMethodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RateTheRoast.Models.Coffee", "Coffee")
                        .WithMany()
                        .HasForeignKey("CoffeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RateTheRoast.Models.Location", "Location")
                        .WithMany("Reviews")
                        .HasForeignKey("LocationId");

                    b.HasOne("RateTheRoast.Models.ApplicationUser", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RateTheRoast.Models.Roaster", b =>
                {
                    b.HasOne("RateTheRoast.Models.ApplicationUser", "User")
                        .WithOne("Roaster")
                        .HasForeignKey("RateTheRoast.Models.Roaster", "UserId");
                });
#pragma warning restore 612, 618
        }
    }
}