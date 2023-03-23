using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETElectronicLearningTool.Migrations
{
    /// <inheritdoc />
    public partial class HistoryPassExamEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAnswerTests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IdTest = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswerTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnswerTests_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAnswerTests_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    TextAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUserAnswerTest = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdQuestionAnswer = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnswers_QuestionAnswers_IdQuestionAnswer",
                        column: x => x.IdQuestionAnswer,
                        principalTable: "QuestionAnswers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAnswers_UserAnswerTests_IdUserAnswerTest",
                        column: x => x.IdUserAnswerTest,
                        principalTable: "UserAnswerTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_IdQuestionAnswer",
                table: "UserAnswers",
                column: "IdQuestionAnswer");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_IdUserAnswerTest",
                table: "UserAnswers",
                column: "IdUserAnswerTest");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswerTests_IdUser",
                table: "UserAnswerTests",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswerTests_TestId",
                table: "UserAnswerTests",
                column: "TestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAnswers");

            migrationBuilder.DropTable(
                name: "UserAnswerTests");
        }
    }
}
