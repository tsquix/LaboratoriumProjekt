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
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Regon = table.Column<string>(type: "TEXT", nullable: false),
                    Nip = table.Column<string>(type: "TEXT", nullable: false),
                    Address_City = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Street = table.Column<string>(type: "TEXT", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Address_Region = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

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
                    Comment = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    OrganizationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_posts_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Address_City", "Address_PostalCode", "Address_Region", "Address_Street", "Nip", "Regon", "Title" },
                values: new object[,]
                {
                    { 1, "Kraków", "31-150", "małopolskie", "Św. Filipa 17", "83492384", "13424234", "WSEI" },
                    { 2, "Kraków", "31-150", "małopolskie", "Krowoderska 45/6", "2498534", "0873439249", "Firma" }
                });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "Id", "Author", "Comment", "Content", "OrganizationId", "PublicationDate", "Tags" },
                values: new object[,]
                {
                    { 1, "siergiej96", "Comment 1", "Wojna na Ukrainie kwitnie", null, new DateTime(2024, 1, 21, 0, 9, 36, 72, DateTimeKind.Local).AddTicks(950), "Tag1" },
                    { 2, "Antoni Macierewicz", "Comment 2", "PIS wygrał wybory", null, new DateTime(2024, 1, 21, 0, 9, 36, 72, DateTimeKind.Local).AddTicks(999), "Tag2" },
                    { 3, "maciek2006", "Comment 3", "Barcelona na szczycie", null, new DateTime(2010, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tag3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_posts_OrganizationId",
                table: "posts",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
