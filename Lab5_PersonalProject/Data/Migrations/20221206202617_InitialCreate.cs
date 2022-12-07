using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab5_PersonalProject.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "parts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    computerBrand = table.Column<string>(nullable: true),
                    computerPart = table.Column<string>(nullable: true),
                    computerCreatedYear = table.Column<int>(nullable: false),
                    computerPartPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "parts");
        }
    }
}
