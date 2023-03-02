using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETElectronicLearningTool.Migrations
{
    /// <inheritdoc />
    public partial class AddMethodDiscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DictionaryOfFunctions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    NameClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameFunction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscriptionFunction = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DictionaryOfFunctions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DictionaryOfFunctions");
        }
    }
}
