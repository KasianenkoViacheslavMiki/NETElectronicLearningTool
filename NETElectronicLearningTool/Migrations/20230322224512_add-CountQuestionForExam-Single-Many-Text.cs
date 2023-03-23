using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETElectronicLearningTool.Migrations
{
    /// <inheritdoc />
    public partial class addCountQuestionForExamSingleManyText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountQuestionForExam",
                table: "Tests",
                newName: "CountQuestionForExamText");

            migrationBuilder.AddColumn<int>(
                name: "CountQuestionForExamMany",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountQuestionForExamSingle",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountQuestionForExamMany",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "CountQuestionForExamSingle",
                table: "Tests");

            migrationBuilder.RenameColumn(
                name: "CountQuestionForExamText",
                table: "Tests",
                newName: "CountQuestionForExam");
        }
    }
}
