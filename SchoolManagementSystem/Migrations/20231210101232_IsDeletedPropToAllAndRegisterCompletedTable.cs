using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class IsDeletedPropToAllAndRegisterCompletedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "281e774a-a22c-42da-9a89-b53ea7a2c186");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "dd692e0f-fccc-48fe-a630-0a479f47803a");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7fb4753e-805b-44ba-acf7-a5dfd55ef469", "38584dd0-e6e3-4d5a-ad08-475bfe44c1ba" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7fb4753e-805b-44ba-acf7-a5dfd55ef469");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "38584dd0-e6e3-4d5a-ad08-475bfe44c1ba");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Teacher",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Subject",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Level",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Exam",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Classroom",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "RegisterComplete",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterComplete", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18313ed4-37ce-4eb2-8153-9b4b4be8c0b5", null, "Admin", "Admin" },
                    { "1fcea113-b1c6-453c-bc54-90c75e7aeaa0", null, "Student", "Student" },
                    { "7fae8da2-1be4-433d-bbb8-67444d3f1113", null, "Teacher", "Teacher" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Date Of Birth", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6b39be6c-9620-4220-b90f-1946a7a709a2", 0, "f5712aca-0e82-439e-84e8-ce73e577679d", null, "admin@site.com", true, null, false, null, "admin@site.com", "Admin", "AQAAAAIAAYagAAAAEOzy3KQ1HWSBJoJWLA6ZaWKwCp/KxI6Ogg8vEwVWP6vT94AmyIBqcfUDf3UfHWCpDw==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "18313ed4-37ce-4eb2-8153-9b4b4be8c0b5", "6b39be6c-9620-4220-b90f-1946a7a709a2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterComplete");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1fcea113-b1c6-453c-bc54-90c75e7aeaa0");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7fae8da2-1be4-433d-bbb8-67444d3f1113");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "18313ed4-37ce-4eb2-8153-9b4b4be8c0b5", "6b39be6c-9620-4220-b90f-1946a7a709a2" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "18313ed4-37ce-4eb2-8153-9b4b4be8c0b5");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "6b39be6c-9620-4220-b90f-1946a7a709a2");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Level");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Classroom");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "281e774a-a22c-42da-9a89-b53ea7a2c186", null, "Student", "Student" },
                    { "7fb4753e-805b-44ba-acf7-a5dfd55ef469", null, "Admin", "Admin" },
                    { "dd692e0f-fccc-48fe-a630-0a479f47803a", null, "Teacher", "Teacher" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Date Of Birth", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "38584dd0-e6e3-4d5a-ad08-475bfe44c1ba", 0, "b81c4c29-1c71-4233-a225-8f635e339d73", null, "admin@site.com", true, null, false, null, "admin@site.com", "Admin", "AQAAAAIAAYagAAAAEFBc/yATNFqZNV0BI57hCDAxhXK2loGOFVDdBe2oC0jhSf+RTkcxw/BLXY/kmKtCnA==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7fb4753e-805b-44ba-acf7-a5dfd55ef469", "38584dd0-e6e3-4d5a-ad08-475bfe44c1ba" });
        }
    }
}
