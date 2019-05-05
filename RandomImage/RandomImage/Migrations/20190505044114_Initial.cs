using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RandomImage.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Filename = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<int>(nullable: false),
                    imageId = table.Column<int>(nullable: false),
                    preference = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Filename", "Name" },
                values: new object[,]
                {
                    { 1, "alberto-gasco-1397222-unsplash.jpg", "Image1" },
                    { 4, "andrea-reiman-1387147-unsplash.jpg", "Image2" },
                    { 8, "aviv-ben-or-1494731-unsplash.jpg", "Image3" },
                    { 9, "christian-neuheuser-1487789-unsplash.jpg", "Image4" },
                    { 16, "david-billings-1467594-unsplash.jpg", "Image5" },
                    { 24, "fabrizio-conti-1453997-unsplash.jpg", "Image6" },
                    { 53, "hanan-1399891-unsplash.jpg", "Image7" },
                    { 54, "ian-keefe-1505288-unsplash.jpg", "Image8" },
                    { 55, "james-eades-1384261-unsplash.jpg", "Image9" },
                    { 56, "josh-gordon-1475759-unsplash.jpg", "Image10" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "UserPreferences");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
