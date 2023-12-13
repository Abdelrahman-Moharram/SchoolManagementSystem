using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class RemoveExtraInfosFromRegisterComplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2a8cf546-2556-4056-af3d-68a48bb73920");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d5ac4ec2-c190-4924-8a77-d55ae18b7a6b");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c683756-03de-40a7-b3dd-4e6728b1117d", "1f3aac04-90e5-494d-b021-fc4b4d15d9c4" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c683756-03de-40a7-b3dd-4e6728b1117d");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "1f3aac04-90e5-494d-b021-fc4b4d15d9c4");

            migrationBuilder.DropColumn(
                name: "UserImage",
                table: "RegisterComplete");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "RegisterComplete");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "RegisterComplete");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c18ee41-fe9d-4f8d-8cf8-eb2aa8804b37", null, "Admin", "Admin" },
                    { "3c4ccc37-e66b-4f33-b992-7b910513102d", null, "Teacher", "Teacher" },
                    { "d09cf9bd-b010-4cbf-bfac-7f65c052db5a", null, "Student", "Student" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Date Of Birth", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1d3c0ff7-8425-4fc0-b624-e8bc6d99ee0c", 0, "3c2f8187-e6ee-48fb-8b8d-db81428d643e", null, "admin@site.com", true, null, false, null, "admin@site.com", "Admin", "AQAAAAIAAYagAAAAEIkhRMzvZHFbNOFkudZw1W64gVFmKjxdehScpzPo+CaUENOqnUvL9nVWKrb5d819fQ==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2c18ee41-fe9d-4f8d-8cf8-eb2aa8804b37", "1d3c0ff7-8425-4fc0-b624-e8bc6d99ee0c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3c4ccc37-e66b-4f33-b992-7b910513102d");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d09cf9bd-b010-4cbf-bfac-7f65c052db5a");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c18ee41-fe9d-4f8d-8cf8-eb2aa8804b37", "1d3c0ff7-8425-4fc0-b624-e8bc6d99ee0c" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2c18ee41-fe9d-4f8d-8cf8-eb2aa8804b37");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "1d3c0ff7-8425-4fc0-b624-e8bc6d99ee0c");

            migrationBuilder.AddColumn<string>(
                name: "UserImage",
                table: "RegisterComplete",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "RegisterComplete",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "RegisterComplete",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a8cf546-2556-4056-af3d-68a48bb73920", null, "Teacher", "Teacher" },
                    { "2c683756-03de-40a7-b3dd-4e6728b1117d", null, "Admin", "Admin" },
                    { "d5ac4ec2-c190-4924-8a77-d55ae18b7a6b", null, "Student", "Student" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Date Of Birth", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1f3aac04-90e5-494d-b021-fc4b4d15d9c4", 0, "5bad9955-8f3a-45f5-a5ef-8c958097485d", null, "admin@site.com", true, null, false, null, "admin@site.com", "Admin", "AQAAAAIAAYagAAAAEAgQ7jHPw+DVuVAJlKoCG3Sy6EVDI6Pm7Xfr3Cz0MzKoU+IRR3RMR4aye+VinY4n6Q==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2c683756-03de-40a7-b3dd-4e6728b1117d", "1f3aac04-90e5-494d-b021-fc4b4d15d9c4" });
        }
    }
}
