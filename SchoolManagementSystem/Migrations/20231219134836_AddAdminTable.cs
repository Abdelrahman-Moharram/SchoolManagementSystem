using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "54e2d01d-5869-4176-99b9-c687dc8c89f8");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8d3c7232-8542-4a94-add8-3983c9017fbf");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fc2b2ff4-1f85-4d6e-a3f4-945c0532cab5", "82899d50-2c8d-4d8a-bcb2-535e0119fc64" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "fc2b2ff4-1f85-4d6e-a3f4-945c0532cab5");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "82899d50-2c8d-4d8a-bcb2-535e0119fc64");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "LecturePost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 19, 15, 48, 36, 371, DateTimeKind.Local).AddTicks(5411),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 19, 12, 3, 23, 8, DateTimeKind.Local).AddTicks(4708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Lecture",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 19, 15, 48, 36, 371, DateTimeKind.Local).AddTicks(4606),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 19, 12, 3, 23, 8, DateTimeKind.Local).AddTicks(3915));

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33227a45-4644-4575-afdf-959cb95e223a", null, "Student", "Student" },
                    { "3f23d836-ebc1-4a97-839e-82765172006c", null, "Teacher", "Teacher" },
                    { "c864f615-edf2-4585-923f-91ffcfa31499", null, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Date Of Birth", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "72735797-34f8-4af3-9a73-fd2f1379c549", 0, "2dccd8b3-959c-4690-af6d-cf9ac366fac4", null, "admin@site.com", true, "img/users/user.webp", false, null, "admin@site.com", "Admin", "AQAAAAIAAYagAAAAENLH1HUOvI+OtDAs8rcKpDDnnVLSEk6o7CdHADbO1z8nuk5oLGNZhsflZBoKdaOGUg==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "Salary", "UserId" },
                values: new object[] { "47a824ab-f7b6-49d8-8cd4-2d057ac910a0", 50000m, "72735797-34f8-4af3-9a73-fd2f1379c549" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c864f615-edf2-4585-923f-91ffcfa31499", "72735797-34f8-4af3-9a73-fd2f1379c549" });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_UserId",
                table: "Admin",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "33227a45-4644-4575-afdf-959cb95e223a");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3f23d836-ebc1-4a97-839e-82765172006c");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c864f615-edf2-4585-923f-91ffcfa31499", "72735797-34f8-4af3-9a73-fd2f1379c549" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c864f615-edf2-4585-923f-91ffcfa31499");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "72735797-34f8-4af3-9a73-fd2f1379c549");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "LecturePost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 19, 12, 3, 23, 8, DateTimeKind.Local).AddTicks(4708),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 19, 15, 48, 36, 371, DateTimeKind.Local).AddTicks(5411));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Lecture",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 19, 12, 3, 23, 8, DateTimeKind.Local).AddTicks(3915),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 19, 15, 48, 36, 371, DateTimeKind.Local).AddTicks(4606));

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54e2d01d-5869-4176-99b9-c687dc8c89f8", null, "Teacher", "Teacher" },
                    { "8d3c7232-8542-4a94-add8-3983c9017fbf", null, "Student", "Student" },
                    { "fc2b2ff4-1f85-4d6e-a3f4-945c0532cab5", null, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Date Of Birth", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "82899d50-2c8d-4d8a-bcb2-535e0119fc64", 0, "0b38d2eb-9258-41f1-a084-d66aa85014b2", null, "admin@site.com", true, "img/users/user.webp", false, null, "admin@site.com", "Admin", "AQAAAAIAAYagAAAAEFvdJ4JLw0Fdn6M3O9uBWthnOBY6OMswQ2iQk/WiFPDFAgR5ZxF2Fj3qhDK916SBfw==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fc2b2ff4-1f85-4d6e-a3f4-945c0532cab5", "82899d50-2c8d-4d8a-bcb2-535e0119fc64" });
        }
    }
}
