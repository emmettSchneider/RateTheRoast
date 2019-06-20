using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RateTheRoast.Data.Migrations
{
    public partial class RateTheRoastTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Handle",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedHandle",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StateAbbrev",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BrewMethod",
                columns: table => new
                {
                    BrewMethodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Method = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrewMethod", x => x.BrewMethodId);
                });

            migrationBuilder.CreateTable(
                name: "RoastIntensity",
                columns: table => new
                {
                    RoastIntensityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Intensity = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoastIntensity", x => x.RoastIntensityId);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateAbbrev = table.Column<string>(nullable: false),
                    StateName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateAbbrev);
                });

            migrationBuilder.CreateTable(
                name: "Roaster",
                columns: table => new
                {
                    RoasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    StateAbbrev = table.Column<string>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roaster", x => x.RoasterId);
                    table.ForeignKey(
                        name: "FK_Roaster_State_StateAbbrev",
                        column: x => x.StateAbbrev,
                        principalTable: "State",
                        principalColumn: "StateAbbrev",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roaster_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Coffee",
                columns: table => new
                {
                    CoffeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoasterId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Origin = table.Column<string>(nullable: false),
                    Region = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    RoastIntensityId = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffee", x => x.CoffeeId);
                    table.ForeignKey(
                        name: "FK_Coffee_RoastIntensity_RoastIntensityId",
                        column: x => x.RoastIntensityId,
                        principalTable: "RoastIntensity",
                        principalColumn: "RoastIntensityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Coffee_Roaster_RoasterId",
                        column: x => x.RoasterId,
                        principalTable: "Roaster",
                        principalColumn: "RoasterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Favorite",
                columns: table => new
                {
                    FavoriteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    CoffeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorite", x => x.FavoriteId);
                    table.ForeignKey(
                        name: "FK_Favorite_Coffee_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffee",
                        principalColumn: "CoffeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Favorite_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoffeeId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    DateEdited = table.Column<DateTime>(nullable: true),
                    BrewMethodId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    PurchaseAddress = table.Column<string>(nullable: true),
                    PurchaseCity = table.Column<string>(nullable: true),
                    StateAbbrev = table.Column<string>(nullable: true),
                    Narrative = table.Column<string>(nullable: false),
                    Score = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_BrewMethod_BrewMethodId",
                        column: x => x.BrewMethodId,
                        principalTable: "BrewMethod",
                        principalColumn: "BrewMethodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_Coffee_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffee",
                        principalColumn: "CoffeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_State_StateAbbrev",
                        column: x => x.StateAbbrev,
                        principalTable: "State",
                        principalColumn: "StateAbbrev",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    WishlistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    CoffeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.WishlistId);
                    table.ForeignKey(
                        name: "FK_Wishlist_Coffee_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffee",
                        principalColumn: "CoffeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wishlist_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BrewMethod",
                columns: new[] { "BrewMethodId", "Method" },
                values: new object[,]
                {
                    { 1, "AeroPress" },
                    { 2, "Chemex" },
                    { 3, "Drip coffee maker (non-SCAA certified)" },
                    { 4, "Drip coffee maker (SCAA certified)" },
                    { 5, "French press" },
                    { 6, "Pour over (Kalita Wave, Hario V60, etc.)" },
                    { 7, "SoftBrew" },
                    { 8, "Vacuum pot / Siphon" }
                });

            migrationBuilder.InsertData(
                table: "RoastIntensity",
                columns: new[] { "RoastIntensityId", "Intensity" },
                values: new object[,]
                {
                    { 5, "Dark" },
                    { 3, "Medium" },
                    { 4, "Medium-Dark" },
                    { 1, "Light" },
                    { 2, "Medium-Light" }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "StateAbbrev", "StateName" },
                values: new object[,]
                {
                    { "OK", "Oklahoma" },
                    { "NE", "Nebraska" },
                    { "NV", "Nevada" },
                    { "NH", "New Hampshire" },
                    { "NJ", "New Jersey" },
                    { "NM", "New Mexico" },
                    { "NY", "New York" },
                    { "NC", "North Carolina" },
                    { "ND", "North Dakota" },
                    { "OH", "Ohio" },
                    { "OR", "Oregon" },
                    { "TX", "Texas" },
                    { "RI", "Rhode Island" },
                    { "SC", "South Carolina" },
                    { "SD", "South Dakota" },
                    { "TN", "Tennessee" },
                    { "MT", "Montana" },
                    { "UT", "Utah" },
                    { "VT", "Vermont" },
                    { "VA", "Virgina" },
                    { "WA", "Washington" },
                    { "WV", "West Virginia" },
                    { "PA", "Pennsylvania" },
                    { "MO", "Missouri" },
                    { "ME", "Maine" },
                    { "MN", "Minnesota" },
                    { "AL", "Alabama" },
                    { "AK", "Alaska" },
                    { "AZ", "Arizona" },
                    { "AR", "Arkansas" },
                    { "CA", "California" },
                    { "CO", "Colorado" },
                    { "CT", "Connecticut" },
                    { "DE", "Delaware" },
                    { "FL", "Florida" },
                    { "GA", "Georgia" },
                    { "MS", "Mississippi" },
                    { "HI", "Hawaii" },
                    { "IL", "Illinois" },
                    { "IN", "Indiana" },
                    { "IA", "Iowa" },
                    { "KS", "Kansas" },
                    { "KY", "Kentucky" },
                    { "LA", "Louisiana" },
                    { "WI", "Wisconsin" },
                    { "MD", "Maryland" },
                    { "MA", "Massachusetts" },
                    { "MI", "Michigan" },
                    { "ID", "Idaho" },
                    { "WY", "Wyoming" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "Handle", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedHandle", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StateAbbrev", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "ada48f36-1a43-418d-9eb9-0aa1979749bd", 0, "Nashville", "bca24a23-76b8-41b3-97b7-0be31d29931a", "admin@admin.com", true, "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEF+vFH4DNWNDevRx/sTLdGH3hWwczflYBz6G7LFfSJxw9WtlUlP8d6fASEuU3OFpzA==", null, false, "0e360fde-1184-4e63-972c-d2fafbd2eeea", "TN", false, "admin@admin.com" },
                    { "7df8c6f8-5079-4e54-9d17-6cecfd4f01a3", 0, "Chattanooga", "058779cf-62f5-46b6-9558-eb7bf6d3a8d5", "barnyardbarista@hotmail.com", true, "BarnyardBarista", false, null, "BARNYARDBARISTA@HOTMAIL.COM", "BARNYARDBARISTA", "BARNYARDBARISTA@HOTMAIL.COM", "AQAAAAEAACcQAAAAEPmCZYQUqfHonIQ4GFJ0efamvpHrFyE1XTmRB3oDzLXidGTSwtfxOOYVcfEyuNm1Wg==", null, false, "dccc01ae-54e1-4b05-bfef-486172fb1f07", "TN", false, "barnyardbarista@hotmail.com" },
                    { "b9d0608d-1569-4150-bf19-f2bcd472ecb8", 0, "Nashville", "ce7e3cfe-9305-478b-8953-2076555f50ce", "info@bongojava.com", true, "BongoJava", false, null, "INFO@BONGOJAVA.COM", "BONGOJAVA", "INFO@BONGOJAVA.COM", "AQAAAAEAACcQAAAAEGAb3TWM5C3YRW7mO5D2IZFSFV594HhpOqEwW8xsX29fbNHSAmFmVpjwjf3mriZT2A==", null, false, "de7f153a-52bb-44d0-9b73-5925f6773977", "TN", false, "info@bongojava.com" }
                });

            migrationBuilder.InsertData(
                table: "Roaster",
                columns: new[] { "RoasterId", "City", "ImagePath", "Name", "StateAbbrev", "UserId" },
                values: new object[,]
                {
                    { 2, "Birmingham", null, "Revelator Coffee Company", "AL", null },
                    { 4, "Chicago", null, "Intelligentsia", "IL", null },
                    { 3, "New Orleans", null, "Folgers", "LA", null },
                    { 5, "Nashville", null, "Frothy Monkey", "TN", null }
                });

            migrationBuilder.InsertData(
                table: "Coffee",
                columns: new[] { "CoffeeId", "Description", "ImagePath", "Name", "Origin", "Region", "RoastIntensityId", "RoasterId" },
                values: new object[] { 2, "SOTARÁ EDITION | After four lots from Nariño, our Tres Santos tour of Colombia's most exciting growing regions takes us to Cauca, where we have been working since 2016 with a group of 80 smallholder farmers committed to quality. We blended the four best single-farm lots of the bunch for this Tres Santos offering, which comes from the farms of Hover Guevara, Eudaro Garzón, José Chicangana, and Ramón Manzano. Flavor Notes: Apple, Caramel, Baked Lemon", null, "Colombia Tres Santos", "Colombia", "Cauca", 2, 4 });

            migrationBuilder.InsertData(
                table: "Coffee",
                columns: new[] { "CoffeeId", "Description", "ImagePath", "Name", "Origin", "Region", "RoastIntensityId", "RoasterId" },
                values: new object[] { 4, "This is an insanely smooth, balanced coffee, with notes of caramel apples, figs, and cashews throughout. It’s acidity is subtly citrusy, just like a clementine, and it’s sweetness is like strawberry candy.", null, "El Salvador El Manzano Honey", "El Salvador", "Santa Ana", 2, 5 });

            migrationBuilder.InsertData(
                table: "Roaster",
                columns: new[] { "RoasterId", "City", "ImagePath", "Name", "StateAbbrev", "UserId" },
                values: new object[] { 1, "Nashville", null, "Bongo Java", "TN", "b9d0608d-1569-4150-bf19-f2bcd472ecb8" });

            migrationBuilder.InsertData(
                table: "Coffee",
                columns: new[] { "CoffeeId", "Description", "ImagePath", "Name", "Origin", "Region", "RoastIntensityId", "RoasterId" },
                values: new object[] { 1, "A nod to our hometown, lovingly referred to as the Buckle of the Bible Belt. Flavor notes of Brown Sugar, Cocoa, and Baked Pear", null, "Bible Belt", "Blend", null, 1, 1 });

            migrationBuilder.InsertData(
                table: "Coffee",
                columns: new[] { "CoffeeId", "Description", "ImagePath", "Name", "Origin", "Region", "RoastIntensityId", "RoasterId" },
                values: new object[] { 3, "Ethiopia is where coffee was discovered and these are some of the best organic beans this country has to offer. A floral cup with delicate sweet lemon acidity, strong aroma of bergamont and jasmine flowers. Flavor notes Sweet Citrus Orange and Honeydew", null, "Ethiopia Yirgacheffe", "Ethiopia", "Yirgacheffe", 1, 1 });

            migrationBuilder.InsertData(
                table: "Favorite",
                columns: new[] { "FavoriteId", "CoffeeId", "UserId" },
                values: new object[] { 1, 4, "7df8c6f8-5079-4e54-9d17-6cecfd4f01a3" });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "BrewMethodId", "CoffeeId", "DateEdited", "Narrative", "Price", "PurchaseAddress", "PurchaseCity", "Score", "StateAbbrev", "UserId" },
                values: new object[] { 2, 6, 4, null, "I've said it before, and I'll say it again, Frothy Monkey's single origin coffees are underrated. The El Salvador El Manzano Honey gives me apple, orange, and fig. It's also a little nutty, just like me. ", 15.99, "The Turnip Truck", "Nashville", 9, "TN", "7df8c6f8-5079-4e54-9d17-6cecfd4f01a3" });

            migrationBuilder.InsertData(
                table: "Wishlist",
                columns: new[] { "WishlistId", "CoffeeId", "UserId" },
                values: new object[] { 1, 2, "7df8c6f8-5079-4e54-9d17-6cecfd4f01a3" });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "BrewMethodId", "CoffeeId", "DateEdited", "Narrative", "Price", "PurchaseAddress", "PurchaseCity", "Score", "StateAbbrev", "UserId" },
                values: new object[] { 1, 6, 1, null, "The Bible Belt Blend is a signature blend for Bongo Java. I'm a big fan. I taste the brown sugar, cocoa, and baked pear mentioned in Bongo Java's description, but I also enjoy hints of blackberry and molasses. Love this roast's name!", 12.99, "Bongo East", "Nashville", 9, "TN", "7df8c6f8-5079-4e54-9d17-6cecfd4f01a3" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StateAbbrev",
                table: "AspNetUsers",
                column: "StateAbbrev");

            migrationBuilder.CreateIndex(
                name: "IX_Coffee_RoastIntensityId",
                table: "Coffee",
                column: "RoastIntensityId");

            migrationBuilder.CreateIndex(
                name: "IX_Coffee_RoasterId",
                table: "Coffee",
                column: "RoasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_CoffeeId",
                table: "Favorite",
                column: "CoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_UserId",
                table: "Favorite",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_BrewMethodId",
                table: "Review",
                column: "BrewMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_CoffeeId",
                table: "Review",
                column: "CoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_StateAbbrev",
                table: "Review",
                column: "StateAbbrev");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roaster_StateAbbrev",
                table: "Roaster",
                column: "StateAbbrev");

            migrationBuilder.CreateIndex(
                name: "IX_Roaster_UserId",
                table: "Roaster",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_CoffeeId",
                table: "Wishlist",
                column: "CoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_UserId",
                table: "Wishlist",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_State_StateAbbrev",
                table: "AspNetUsers",
                column: "StateAbbrev",
                principalTable: "State",
                principalColumn: "StateAbbrev",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_State_StateAbbrev",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Favorite");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "BrewMethod");

            migrationBuilder.DropTable(
                name: "Coffee");

            migrationBuilder.DropTable(
                name: "RoastIntensity");

            migrationBuilder.DropTable(
                name: "Roaster");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StateAbbrev",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7df8c6f8-5079-4e54-9d17-6cecfd4f01a3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ada48f36-1a43-418d-9eb9-0aa1979749bd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b9d0608d-1569-4150-bf19-f2bcd472ecb8");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Handle",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedHandle",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StateAbbrev",
                table: "AspNetUsers");
        }
    }
}
