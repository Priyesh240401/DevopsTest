using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TokensAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBookAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LentByUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CurrentlyBorrowedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserModelId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Users_CurrentlyBorrowedById",
                        column: x => x.CurrentlyBorrowedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Books_Users_LentByUserId",
                        column: x => x.LentByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Users_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "TokensAvailable", "Username" },
                values: new object[,]
                {
                    { "145c4a26-fed6-4ef2-a67e-1fc55433b075", "Demo User 3", "password", 10, "DemoUser3" },
                    { "91dc118b-d6ae-492d-a622-791cf2cec142", "Demo User 2", "Password", 10, "DemoUser2" },
                    { "ba74660f-f3c6-4a51-ac1c-567b1e281ee2", "Demo User 1", "Password", 10, "Demouser1" },
                    { "edeb3c02-42e3-4cf3-8841-4c15ecf784bc", "Priyesh Zope", "Pzoistbpl@2001", 10, "zopepriyesh" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CurrentlyBorrowedById",
                table: "Books",
                column: "CurrentlyBorrowedById");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LentByUserId",
                table: "Books",
                column: "LentByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserModelId",
                table: "Books",
                column: "UserModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
