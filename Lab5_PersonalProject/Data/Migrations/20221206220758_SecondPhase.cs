using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab5_PersonalProject.Data.Migrations
{
    public partial class SecondPhase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    SellerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(nullable: false),
                    Last_Name = table.Column<string>(nullable: false),
                    City_Location = table.Column<string>(nullable: false),
                    Year_Joined = table.Column<int>(nullable: false),
                    Selling_Computer_Part = table.Column<int>(nullable: false),
                    Part_Condition = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.SellerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seller");
        }
    }
}
