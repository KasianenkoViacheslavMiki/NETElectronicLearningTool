using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETElectronicLearningTool.Migrations
{
    /// <inheritdoc />
    public partial class fixtestquastion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_Tests_Id",
                table: "TestQuestions");

            migrationBuilder.AddColumn<Guid>(
                name: "IdTest",
                table: "TestQuestions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_IdTest",
                table: "TestQuestions",
                column: "IdTest");

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_Tests_IdTest",
                table: "TestQuestions",
                column: "IdTest",
                principalTable: "Tests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_Tests_IdTest",
                table: "TestQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestions_IdTest",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "IdTest",
                table: "TestQuestions");

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_Tests_Id",
                table: "TestQuestions",
                column: "Id",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
