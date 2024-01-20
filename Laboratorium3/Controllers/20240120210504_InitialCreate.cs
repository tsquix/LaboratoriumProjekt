using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Tags = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Comment = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "Id", "Author", "Comment", "Content", "PublicationDate", "Tags" },
                values: new object[,]
                {
                    { 1, "Author 1", "Comment 1", "Serious Post", new DateTime(2024, 1, 20, 22, 5, 4, 170, DateTimeKind.Local).AddTicks(6625), "Tag1" },
                    { 2, "Author 2", "Comment 2", "Less Serious Post", new DateTime(2024, 1, 20, 22, 5, 4, 170, DateTimeKind.Local).AddTicks(6673), "Tag2" },
                    { 3, "Author 3", "Comment 3", "Not Serious Post", new DateTime(2024, 1, 20, 22, 5, 4, 170, DateTimeKind.Local).AddTicks(6677), "Tag3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posts");
        }
    }
}
