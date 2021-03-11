using Microsoft.EntityFrameworkCore.Migrations;

namespace CarMarket.Migrations
{
    public partial class carModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abs = table.Column<bool>(type: "bit", nullable: false),
                    ElectricWindowLift = table.Column<bool>(type: "bit", nullable: false),
                    Bluetooth = table.Column<bool>(type: "bit", nullable: false),
                    Hatch = table.Column<bool>(type: "bit", nullable: false),
                    Alarm = table.Column<bool>(type: "bit", nullable: false),
                    ParkingControl = table.Column<bool>(type: "bit", nullable: false),
                    Navigation = table.Column<bool>(type: "bit", nullable: false),
                    OnBoardComputer = table.Column<bool>(type: "bit", nullable: false),
                    MultiWheel = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
