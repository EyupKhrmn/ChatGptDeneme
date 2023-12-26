using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIService.Migrations
{
    /// <inheritdoc />
    public partial class v61 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AIResponses_LastLoginUsers_LastLoginUserId",
                table: "AIResponses");

            migrationBuilder.DropTable(
                name: "LastLoginUsers");

            migrationBuilder.DropIndex(
                name: "IX_AIResponses_LastLoginUserId",
                table: "AIResponses");

            migrationBuilder.DropColumn(
                name: "LastLoginUserId",
                table: "AIResponses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastLoginUserId",
                table: "AIResponses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LastLoginUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Kilo = table.Column<int>(type: "int", nullable: false),
                    LoginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastLoginUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AIResponses_LastLoginUserId",
                table: "AIResponses",
                column: "LastLoginUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AIResponses_LastLoginUsers_LastLoginUserId",
                table: "AIResponses",
                column: "LastLoginUserId",
                principalTable: "LastLoginUsers",
                principalColumn: "Id");
        }
    }
}
