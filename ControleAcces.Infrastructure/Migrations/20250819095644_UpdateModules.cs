using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleAcces.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Session",
                table: "Modules");

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "Modules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salles_SessionId",
                table: "Salles",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_SalleId",
                table: "Modules",
                column: "SalleId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_SessionId",
                table: "Modules",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Salles_SalleId",
                table: "Modules",
                column: "SalleId",
                principalTable: "Salles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Sessions_SessionId",
                table: "Modules",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Salles_Sessions_SessionId",
                table: "Salles",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Salles_SalleId",
                table: "Modules");

            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Sessions_SessionId",
                table: "Modules");

            migrationBuilder.DropForeignKey(
                name: "FK_Salles_Sessions_SessionId",
                table: "Salles");

            migrationBuilder.DropIndex(
                name: "IX_Salles_SessionId",
                table: "Salles");

            migrationBuilder.DropIndex(
                name: "IX_Modules_SalleId",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Modules_SessionId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Modules");

            migrationBuilder.AddColumn<string>(
                name: "Session",
                table: "Modules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
