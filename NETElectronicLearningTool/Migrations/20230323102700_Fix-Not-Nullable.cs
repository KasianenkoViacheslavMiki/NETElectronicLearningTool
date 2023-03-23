using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETElectronicLearningTool.Migrations
{
    /// <inheritdoc />
    public partial class FixNotNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_QuestionAnswers_IdQuestionAnswer",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_UserAnswerTests_IdUserAnswerTest",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswerTests_Users_IdUser",
                table: "UserAnswerTests");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdUser",
                table: "UserAnswerTests",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdTest",
                table: "UserAnswerTests",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdUserAnswerTest",
                table: "UserAnswers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdQuestionAnswer",
                table: "UserAnswers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "CountQuestionForExamText",
                table: "Tests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountQuestionForExamSingle",
                table: "Tests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountQuestionForExamMany",
                table: "Tests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_QuestionAnswers_IdQuestionAnswer",
                table: "UserAnswers",
                column: "IdQuestionAnswer",
                principalTable: "QuestionAnswers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_UserAnswerTests_IdUserAnswerTest",
                table: "UserAnswers",
                column: "IdUserAnswerTest",
                principalTable: "UserAnswerTests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswerTests_Users_IdUser",
                table: "UserAnswerTests",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_QuestionAnswers_IdQuestionAnswer",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_UserAnswerTests_IdUserAnswerTest",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswerTests_Users_IdUser",
                table: "UserAnswerTests");

            migrationBuilder.AlterColumn<Guid>(
                name: "IdUser",
                table: "UserAnswerTests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdTest",
                table: "UserAnswerTests",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdUserAnswerTest",
                table: "UserAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IdQuestionAnswer",
                table: "UserAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountQuestionForExamText",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountQuestionForExamSingle",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountQuestionForExamMany",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_QuestionAnswers_IdQuestionAnswer",
                table: "UserAnswers",
                column: "IdQuestionAnswer",
                principalTable: "QuestionAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_UserAnswerTests_IdUserAnswerTest",
                table: "UserAnswers",
                column: "IdUserAnswerTest",
                principalTable: "UserAnswerTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswerTests_Users_IdUser",
                table: "UserAnswerTests",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
