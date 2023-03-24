using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ODataPractice.Migrations
{
    /// <inheritdoc />
    public partial class gujaratStateColumnAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GujaratStates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STCode = table.Column<int>(type: "int", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DTCode = table.Column<int>(type: "int", nullable: false),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDTCode = table.Column<int>(type: "int", nullable: false),
                    SubDistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TownCode = table.Column<int>(type: "int", nullable: false),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GujaratStates", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GujaratStates");
        }
    }
}
