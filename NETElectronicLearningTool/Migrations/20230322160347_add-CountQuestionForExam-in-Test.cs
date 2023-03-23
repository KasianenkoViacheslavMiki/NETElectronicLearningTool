using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETElectronicLearningTool.Migrations
{
    /// <inheritdoc />
    public partial class addCountQuestionForExaminTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountQuestionForExam",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountQuestionForExam",
                table: "Tests");
        }
    }
}
