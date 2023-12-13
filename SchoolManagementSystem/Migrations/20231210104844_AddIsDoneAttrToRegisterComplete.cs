using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDoneAttrToRegisterComplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "RegisterComplete",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "RegisterComplete");

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
    }
}
