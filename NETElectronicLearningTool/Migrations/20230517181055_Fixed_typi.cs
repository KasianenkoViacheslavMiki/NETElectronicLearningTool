using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETElectronicLearningTool.Migrations
{
    /// <inheritdoc />
    public partial class Fixedtypi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LevelKnowladge");

            migrationBuilder.RenameColumn(
                name: "WishsLevelKnowladge",
                table: "Users",
                newName: "WishsLevelKnowledge");

            migrationBuilder.CreateTable(
                name: "LevelKnowledge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    LvlKnowledge = table.Column<float>(type: "real", nullable: true),
                    IdElementLearning = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelKnowledge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelKnowledge_ElementLearning_IdElementLearning",
                        column: x => x.IdElementLearning,
                        principalTable: "ElementLearning",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LevelKnowledge_IdElementLearning",
                table: "LevelKnowledge",
                column: "IdElementLearning");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LevelKnowledge");

            migrationBuilder.RenameColumn(
                name: "WishsLevelKnowledge",
                table: "Users",
                newName: "WishsLevelKnowladge");

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
                name: "IX_LevelKnowladge_IdElementLearning",
                table: "LevelKnowladge",
                column: "IdElementLearning");
        }
    }
}
