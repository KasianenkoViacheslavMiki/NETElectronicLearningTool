using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETElectronicLearningTool.Migrations
{
    /// <inheritdoc />
    public partial class fixaddtest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswer_TestQuestion_TestQuestionId",
                table: "QuestionAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestion_Test_Id",
                table: "TestQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestQuestion",
                table: "TestQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Test",
                table: "Test");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionAnswer",
                table: "QuestionAnswer");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "TestQuestion",
                newName: "TestQuestions");

            migrationBuilder.RenameTable(
                name: "Test",
                newName: "Tests");

            migrationBuilder.RenameTable(
                name: "QuestionAnswer",
                newName: "QuestionAnswers");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionAnswer_TestQuestionId",
                table: "QuestionAnswers",
                newName: "IX_QuestionAnswers_TestQuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestQuestions",
                table: "TestQuestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tests",
                table: "Tests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionAnswers",
                table: "QuestionAnswers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswers_TestQuestions_TestQuestionId",
                table: "QuestionAnswers",
                column: "TestQuestionId",
                principalTable: "TestQuestions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_Tests_Id",
                table: "TestQuestions",
                column: "Id",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswers_TestQuestions_TestQuestionId",
                table: "QuestionAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_Tests_Id",
                table: "TestQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tests",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestQuestions",
                table: "TestQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionAnswers",
                table: "QuestionAnswers");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Tests",
                newName: "Test");

            migrationBuilder.RenameTable(
                name: "TestQuestions",
                newName: "TestQuestion");

            migrationBuilder.RenameTable(
                name: "QuestionAnswers",
                newName: "QuestionAnswer");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionAnswers_TestQuestionId",
                table: "QuestionAnswer",
                newName: "IX_QuestionAnswer_TestQuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Test",
                table: "Test",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestQuestion",
                table: "TestQuestion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionAnswer",
                table: "QuestionAnswer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswer_TestQuestion_TestQuestionId",
                table: "QuestionAnswer",
                column: "TestQuestionId",
                principalTable: "TestQuestion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestion_Test_Id",
                table: "TestQuestion",
                column: "Id",
                principalTable: "Test",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
