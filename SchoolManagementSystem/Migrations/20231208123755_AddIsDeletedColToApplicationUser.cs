using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedColToApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "158a7308-1f2d-4829-b708-a90abd98cd81");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3cc87945-fc4c-4e5d-a815-94921252e3ee");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "08438c87-9009-4139-80ab-bfb54ddcb6a6", "7f6033cc-de8d-4c51-86aa-76eb5d32c66f" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "08438c87-9009-4139-80ab-bfb54ddcb6a6");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "7f6033cc-de8d-4c51-86aa-76eb5d32c66f");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e1c8d3e-d6d6-4d91-8788-8a1be74fbbce", null, "Admin", "Admin" },
                    { "76f52e00-7967-4c8d-9862-9b4cee963b72", null, "Student", "Student" },
                    { "fc68e854-89ed-40ec-a633-af23c8bbd3e8", null, "Teacher", "Teacher" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Date Of Birth", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3e9b4f25-7550-42b7-a71c-5cc1719b13fe", 0, "c0a57984-0f3e-4fc9-a0a0-9b237d32ca7d", null, "admin@site.com", true, null, false, null, "admin@site.com", "Admin", "AQAAAAIAAYagAAAAEDF8Ims8YUzRp68EEhFUQgjm0+o4sVYUz0VzusQtTI7d9w137gbtieKl0XLLIqheAQ==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0e1c8d3e-d6d6-4d91-8788-8a1be74fbbce", "3e9b4f25-7550-42b7-a71c-5cc1719b13fe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "76f52e00-7967-4c8d-9862-9b4cee963b72");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "fc68e854-89ed-40ec-a633-af23c8bbd3e8");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0e1c8d3e-d6d6-4d91-8788-8a1be74fbbce", "3e9b4f25-7550-42b7-a71c-5cc1719b13fe" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0e1c8d3e-d6d6-4d91-8788-8a1be74fbbce");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "3e9b4f25-7550-42b7-a71c-5cc1719b13fe");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Identity",
                table: "Users");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08438c87-9009-4139-80ab-bfb54ddcb6a6", null, "Admin", "Admin" },
                    { "158a7308-1f2d-4829-b708-a90abd98cd81", null, "Student", "Student" },
                    { "3cc87945-fc4c-4e5d-a815-94921252e3ee", null, "Teacher", "Teacher" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Date Of Birth", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7f6033cc-de8d-4c51-86aa-76eb5d32c66f", 0, "59a89c36-d2ea-4d20-94e9-447ce934757e", null, "admin@site.com", true, null, false, null, "admin@site.com", "Admin", "AQAAAAIAAYagAAAAEC0HKRmACqXkpe9x8Cvbz538ECuyV5sryHu4loHVIQRdYMXeSlI8TiRir3V+8TE/Ow==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "08438c87-9009-4139-80ab-bfb54ddcb6a6", "7f6033cc-de8d-4c51-86aa-76eb5d32c66f" });
        }
    }
}
