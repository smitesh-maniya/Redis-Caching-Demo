using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ODataPractice.Migrations
{
    /// <inheritdoc />
    public partial class identityadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "GujaratStates",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GujaratStates",
                newName: "ID");
        }
    }
}
