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

            migrationBuilder.AddColumn<bool>(
                name: "IsAdministrator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedHandle",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
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
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
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
                    State = table.Column<string>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roaster", x => x.RoasterId);
                    table.ForeignKey(
                        name: "FK_Roaster_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "Handle", "IsAdministrator", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedHandle", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "cdc419b1-37e9-449b-b867-a0606c708a4f", 0, "Nashville", "5a631d65-c360-4eb8-b69a-acb046c98793", "admin@admin.com", true, "admin", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEF/ghVQcKIO4Yxs2UoiLGOEk/qJXKME3cCMfeeEKuVnFlSocFhHY2s4zviUkraCXfw==", null, false, "e1a95846-7c80-42b6-b786-f03061ea8ff4", "TN", false, "admin@admin.com" },
                    { "6e64d6bb-c1bb-4690-9943-34b48887960d", 0, "Chattanooga", "ad4b5b7b-80e7-4352-8c3d-f1d219193505", "barnyardbarista@hotmail.com", true, "BarnyardBarista", false, false, null, "BARNYARDBARISTA@HOTMAIL.COM", "BARNYARDBARISTA", "BARNYARDBARISTA@HOTMAIL.COM", "AQAAAAEAACcQAAAAEOVUlyEhdBy3KicxCtYiDZP5fJyMjj1gv+JEUgPNzzm6mmyEswSJfvsUK1NIt1A0Mg==", null, false, "6d95f76f-b57c-4389-9df0-ffba730cdee1", "TN", false, "barnyardbarista@hotmail.com" },
                    { "fdaf41bd-4c65-4bd9-8aa8-acadc5d80b82", 0, "Nashville", "8422161f-4834-47a0-aa66-63ed8f2630c0", "info@bongojava.com", true, "BongoJava", false, false, null, "INFO@BONGOJAVA.COM", "BONGOJAVA", "INFO@BONGOJAVA.COM", "AQAAAAEAACcQAAAAEGXI6qyTzvHm+4SlUp5sPBdbKPmIANiH08lCHg5s/U4lNYeZ41uYdm4wcDINzVAB/A==", null, false, "d13645ba-86cd-4497-b788-763016abbfe0", "TN", false, "info@bongojava.com" }
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
                table: "Location",
                columns: new[] { "LocationId", "Address", "City", "Name", "State" },
                values: new object[,]
                {
                    { 4, "711 Gallatin Ave", "Nashville", "Kroger", "TN" },
                    { 3, "1817 21st Ave S", "Nashville", "Revelator Coffee Company", "TN" },
                    { 1, "701 Woodland St", "Nashville", "The Turnip Truck", "TN" },
                    { 2, "107 S 11th St", "Nashville", "Bongo East", "TN" }
                });

            migrationBuilder.InsertData(
                table: "RoastIntensity",
                columns: new[] { "RoastIntensityId", "Intensity" },
                values: new object[,]
                {
                    { 1, "Light" },
                    { 2, "Medium-Light" },
                    { 3, "Medium" },
                    { 4, "Medium-Dark" },
                    { 5, "Dark" }
                });

            migrationBuilder.InsertData(
                table: "Roaster",
                columns: new[] { "RoasterId", "City", "ImagePath", "Name", "State", "UserId" },
                values: new object[,]
                {
                    { 4, "Chicago", null, "Intelligentsia", "IL", null },
                    { 2, "Birmingham", null, "Revelator Coffee Company", "AL", null },
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
                columns: new[] { "RoasterId", "City", "ImagePath", "Name", "State", "UserId" },
                values: new object[] { 1, "Nashville", null, "Bongo Java", "TN", "fdaf41bd-4c65-4bd9-8aa8-acadc5d80b82" });

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
                values: new object[] { 1, 4, "6e64d6bb-c1bb-4690-9943-34b48887960d" });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "BrewMethodId", "CoffeeId", "LocationId", "Narrative", "Price", "Score", "UserId" },
                values: new object[] { 2, 6, 4, 1, "I've said it before, and I'll say it again, Frothy Monkey's single origin coffees are underrated. The El Salvador El Manzano Honey gives me apple, orange, and fig. It's also a little nutty, just like me. ", 15.99, 9, "6e64d6bb-c1bb-4690-9943-34b48887960d" });

            migrationBuilder.InsertData(
                table: "Wishlist",
                columns: new[] { "WishlistId", "CoffeeId", "UserId" },
                values: new object[] { 1, 2, "6e64d6bb-c1bb-4690-9943-34b48887960d" });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "BrewMethodId", "CoffeeId", "LocationId", "Narrative", "Price", "Score", "UserId" },
                values: new object[] { 1, 6, 1, 2, "The Bible Belt Blend is a signature blend for Bongo Java. I'm a big fan. I taste the brown sugar, cocoa, and baked pear mentioned in Bongo Java's description, but I also enjoy hints of blackberry and molasses. Love this roast's name!", 12.99, 9, "6e64d6bb-c1bb-4690-9943-34b48887960d" });

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
                name: "IX_Review_LocationId",
                table: "Review",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e64d6bb-c1bb-4690-9943-34b48887960d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cdc419b1-37e9-449b-b867-a0606c708a4f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fdaf41bd-4c65-4bd9-8aa8-acadc5d80b82");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Handle",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsAdministrator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedHandle",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "AspNetUsers");
        }
    }
}
