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
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    StateAbbrev = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Location_State_StateAbbrev",
                        column: x => x.StateAbbrev,
                        principalTable: "State",
                        principalColumn: "StateAbbrev",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Location_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Coffee_Roaster_RoasterId",
                        column: x => x.RoasterId,
                        principalTable: "Roaster",
                        principalColumn: "RoasterId",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorite_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    LocationId = table.Column<int>(nullable: true),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Coffee_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffee",
                        principalColumn: "CoffeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wishlist_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { "7b8048d1-0dff-40cf-a224-330ef41afaed", 0, "Nashville", "17e90bda-9941-4d18-bfe2-7b1943cf9fe1", "admin@admin.com", true, "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEMgSioN/OysF0/ntr7uaaRTr4J9qXs4az5sW6sRzDYNNigE1ixMni6EWK0Wt9wb8cw==", null, false, "fe90d5d0-7e82-4c04-8deb-515511ddd378", "TN", false, "admin@admin.com" },
                    { "8ac655d6-99ba-4347-98fd-e708a6241baf", 0, "Chattanooga", "5dcbb4fa-592f-42d7-a56f-0a9c9b4a87cf", "barnyardbarista@hotmail.com", true, "BarnyardBarista", false, null, "BARNYARDBARISTA@HOTMAIL.COM", "BARNYARDBARISTA", "BARNYARDBARISTA@HOTMAIL.COM", "AQAAAAEAACcQAAAAEDzcjYnk2f74Mvbj5luJFvSAdKnYAWGjN7PKCRN7L+2QASUCy9/7hCie1uzhHkbf+A==", null, false, "e7cc185c-b4f5-4e79-aa1e-f23ba67f09a6", "TN", false, "barnyardbarista@hotmail.com" },
                    { "5fbfedaf-d823-4ad7-8106-7d92863d7692", 0, "Nashville", "2047d46f-9c97-49ce-8222-d2726b90716a", "info@bongojava.com", true, "BongoJava", false, null, "INFO@BONGOJAVA.COM", "BONGOJAVA", "INFO@BONGOJAVA.COM", "AQAAAAEAACcQAAAAEIWMVnGHkN73F76BaQa9NTVcaJHbQ44gqgI3nPDS3QoOa0Yj1p4+gmOUKnef6O6ypQ==", null, false, "03304db6-e0f4-42ce-bc86-984d80a0406e", "TN", false, "info@bongojava.com" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "LocationId", "Address", "City", "Name", "StateAbbrev", "UserId" },
                values: new object[,]
                {
                    { 1, "701 Woodland St", "Nashville", "The Turnip Truck", "TN", null },
                    { 2, "107 S 11th St", "Nashville", "Bongo East", "TN", null },
                    { 3, "1817 21st Ave S", "Nashville", "Revelator Coffee Company", "TN", null },
                    { 4, "711 Gallatin Ave", "Nashville", "Kroger", "TN", null }
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
                values: new object[] { 1, "Nashville", null, "Bongo Java", "TN", "5fbfedaf-d823-4ad7-8106-7d92863d7692" });

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
                values: new object[] { 1, 4, "8ac655d6-99ba-4347-98fd-e708a6241baf" });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "BrewMethodId", "CoffeeId", "LocationId", "Narrative", "Price", "Score", "UserId" },
                values: new object[] { 2, 6, 4, 1, "I've said it before, and I'll say it again, Frothy Monkey's single origin coffees are underrated. The El Salvador El Manzano Honey gives me apple, orange, and fig. It's also a little nutty, just like me. ", 15.99, 9, "8ac655d6-99ba-4347-98fd-e708a6241baf" });

            migrationBuilder.InsertData(
                table: "Wishlist",
                columns: new[] { "WishlistId", "CoffeeId", "UserId" },
                values: new object[] { 1, 2, "8ac655d6-99ba-4347-98fd-e708a6241baf" });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "BrewMethodId", "CoffeeId", "LocationId", "Narrative", "Price", "Score", "UserId" },
                values: new object[] { 1, 6, 1, 2, "The Bible Belt Blend is a signature blend for Bongo Java. I'm a big fan. I taste the brown sugar, cocoa, and baked pear mentioned in Bongo Java's description, but I also enjoy hints of blackberry and molasses. Love this roast's name!", 12.99, 9, "8ac655d6-99ba-4347-98fd-e708a6241baf" });

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
                name: "IX_Location_StateAbbrev",
                table: "Location",
                column: "StateAbbrev");

            migrationBuilder.CreateIndex(
                name: "IX_Location_UserId",
                table: "Location",
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
                name: "IX_Review_LocationId",
                table: "Review",
                column: "LocationId");

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
                onDelete: ReferentialAction.Cascade);
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
                name: "Location");

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
                keyValue: "5fbfedaf-d823-4ad7-8106-7d92863d7692");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b8048d1-0dff-40cf-a224-330ef41afaed");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8ac655d6-99ba-4347-98fd-e708a6241baf");

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
