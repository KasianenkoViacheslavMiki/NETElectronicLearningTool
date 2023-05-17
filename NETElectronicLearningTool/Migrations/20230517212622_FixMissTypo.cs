using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETElectronicLearningTool.Migrations
{
    /// <inheritdoc />
    public partial class FixMissTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementLearning_Users_UserId",
                table: "ElementLearning");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelKnowledge_Users_UserId",
                table: "LevelKnowledge");

            migrationBuilder.DropIndex(
                name: "IX_ElementLearning_UserId",
                table: "ElementLearning");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "ElementLearning");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ElementLearning");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "LevelKnowledge",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_LevelKnowledge_UserId",
                table: "LevelKnowledge",
                newName: "IX_LevelKnowledge_IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_LevelKnowledge_Users_IdUser",
                table: "LevelKnowledge",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LevelKnowledge_Users_IdUser",
                table: "LevelKnowledge");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "LevelKnowledge",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LevelKnowledge_IdUser",
                table: "LevelKnowledge",
                newName: "IX_LevelKnowledge_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "IdUser",
                table: "ElementLearning",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ElementLearning",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElementLearning_UserId",
                table: "ElementLearning",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementLearning_Users_UserId",
                table: "ElementLearning",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LevelKnowledge_Users_UserId",
                table: "LevelKnowledge",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
