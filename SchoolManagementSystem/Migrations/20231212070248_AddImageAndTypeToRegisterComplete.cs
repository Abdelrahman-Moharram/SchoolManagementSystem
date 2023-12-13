using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddImageAndTypeToRegisterComplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "301a261e-b20f-49b0-b4ce-8f64629fea17");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5e2157b3-4c3e-4045-a090-204fe04709e8");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2b82f922-2c17-4293-bfc1-0b775ceb2a25", "745cbd15-8258-4374-b5ce-9149bbae270b" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2b82f922-2c17-4293-bfc1-0b775ceb2a25");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "745cbd15-8258-4374-b5ce-9149bbae270b");

            migrationBuilder.AddColumn<string>(
                name: "UserImage",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "UserType",
                table: "RegisterComplete");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b82f922-2c17-4293-bfc1-0b775ceb2a25", null, "Admin", "Admin" },
                    { "301a261e-b20f-49b0-b4ce-8f64629fea17", null, "Student", "Student" },
                    { "5e2157b3-4c3e-4045-a090-204fe04709e8", null, "Teacher", "Teacher" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Date Of Birth", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "745cbd15-8258-4374-b5ce-9149bbae270b", 0, "5ea3fe79-31e2-4d1d-a700-ff90ae1e4cfc", null, "admin@site.com", true, null, false, null, "admin@site.com", "Admin", "AQAAAAIAAYagAAAAEOosHybMN4tmuygvbBdhd7BL1ZvpTmsyanAqMnFyvJJdpAQnEXf3RW/L2F4Wj8KWVw==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2b82f922-2c17-4293-bfc1-0b775ceb2a25", "745cbd15-8258-4374-b5ce-9149bbae270b" });
        }
    }
}
