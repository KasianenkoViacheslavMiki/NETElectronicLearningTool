using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETElectronicLearningTool.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToLab4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "WishsLevelKnowladge",
                table: "Users",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdElementLearning",
                table: "TestQuestions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ElementLearning",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementLearning", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LevelKnowladge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IdElementLearning = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelKnowladge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelKnowladge_ElementLearning_IdElementLearning",
                        column: x => x.IdElementLearning,
                        principalTable: "ElementLearning",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_IdElementLearning",
                table: "TestQuestions",
                column: "IdElementLearning");

            migrationBuilder.CreateIndex(
                name: "IX_LevelKnowladge_IdElementLearning",
                table: "LevelKnowladge",
                column: "IdElementLearning");

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_ElementLearning_IdElementLearning",
                table: "TestQuestions",
                column: "IdElementLearning",
                principalTable: "ElementLearning",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_ElementLearning_IdElementLearning",
                table: "TestQuestions");

            migrationBuilder.DropTable(
                name: "LevelKnowladge");

            migrationBuilder.DropTable(
                name: "ElementLearning");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestions_IdElementLearning",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WishsLevelKnowladge",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdElementLearning",
                table: "TestQuestions");
        }
    }
}
