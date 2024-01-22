using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2d5e25bb-62b3-40fe-904c-8bcfb8e3347b", "0f059df9-a51c-4117-96f6-27aec976285a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ecce12c3-538d-41c3-8912-aef78a2ef52b", "113e7a96-2c0f-494c-8596-ca7829ea37df" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5e25bb-62b3-40fe-904c-8bcfb8e3347b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ecce12c3-538d-41c3-8912-aef78a2ef52b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f059df9-a51c-4117-96f6-27aec976285a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "113e7a96-2c0f-494c-8596-ca7829ea37df");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Organizations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c29e8ffb-d727-4486-ba44-90e155dc4e0d", "c29e8ffb-d727-4486-ba44-90e155dc4e0d", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f113f519-86b9-4495-a447-a8e54c7bb6cc", 0, "b31fb779-9f7a-48ad-84d7-b868e1235a6a", "adam@wsei.edu.pl", true, false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEG9xK/214OQ9QZDVi3hhHRe56ENk1vj+Fbs8wUqAOoFYoyw2xt0lp9LHzJBqpvvEMg==", null, false, "6105922b-fbdc-4674-8e8c-5e426f1ca11b", false, "adam" });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2024, 1, 22, 17, 38, 39, 324, DateTimeKind.Local).AddTicks(5490));

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicationDate",
                value: new DateTime(2024, 1, 22, 17, 38, 39, 324, DateTimeKind.Local).AddTicks(5556));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c29e8ffb-d727-4486-ba44-90e155dc4e0d", "f113f519-86b9-4495-a447-a8e54c7bb6cc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c29e8ffb-d727-4486-ba44-90e155dc4e0d", "f113f519-86b9-4495-a447-a8e54c7bb6cc" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c29e8ffb-d727-4486-ba44-90e155dc4e0d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f113f519-86b9-4495-a447-a8e54c7bb6cc");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Organizations",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d5e25bb-62b3-40fe-904c-8bcfb8e3347b", "2d5e25bb-62b3-40fe-904c-8bcfb8e3347b", "admin", "ADMIN" },
                    { "ecce12c3-538d-41c3-8912-aef78a2ef52b", "ecce12c3-538d-41c3-8912-aef78a2ef52b", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0f059df9-a51c-4117-96f6-27aec976285a", 0, "ffb48079-6a35-40af-b87b-7e7a1be1cf1b", "adam@wsei.edu.pl", true, false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEIuEKc4QEQijMZOX+6GD29DC3dYonbSa/SfG9AS6lKD0sTiPdlyrGv3BJ9iMLBBFuA==", null, false, "02bd9b58-90d6-4b53-babc-e1456f8f5c1c", false, "adam" },
                    { "113e7a96-2c0f-494c-8596-ca7829ea37df", 0, "f2ecbe7b-0081-4e24-ba11-96288aad7a1f", "john@wsei.edu.pl", true, false, null, null, "JOHN", "AQAAAAIAAYagAAAAEN6DKv6oJ2rJk7wvHpwq5q/65UAMe1gSuGc31HZq1ReYt+FGC3sO7/GhCwStVPMe0g==", null, false, "fbe3cb7c-20ee-4840-92ad-3ccabcbab378", false, "john" }
                });

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2024, 1, 22, 17, 29, 19, 985, DateTimeKind.Local).AddTicks(4936));

            migrationBuilder.UpdateData(
                table: "posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublicationDate",
                value: new DateTime(2024, 1, 22, 17, 29, 19, 985, DateTimeKind.Local).AddTicks(5007));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2d5e25bb-62b3-40fe-904c-8bcfb8e3347b", "0f059df9-a51c-4117-96f6-27aec976285a" },
                    { "ecce12c3-538d-41c3-8912-aef78a2ef52b", "113e7a96-2c0f-494c-8596-ca7829ea37df" }
                });
        }
    }
}
