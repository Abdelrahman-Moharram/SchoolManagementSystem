using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class addUserAndDateTimeFieldInPostLecture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6a2c30cd-6015-47c4-a7d7-20f09b2daf2b");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b39d0e95-714e-49e3-8d14-c5091d04b56c");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "433f3f6c-b0ca-4e69-b5f8-ffb50e55c559", "66e3c906-075d-49f6-8327-6fe8b42ee3b8" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "433f3f6c-b0ca-4e69-b5f8-ffb50e55c559");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "66e3c906-075d-49f6-8327-6fe8b42ee3b8");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "LecturePost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 18, 14, 18, 17, 611, DateTimeKind.Local).AddTicks(4346));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "LecturePost",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Lecture",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 18, 14, 18, 17, 611, DateTimeKind.Local).AddTicks(3510),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 17, 20, 47, 44, 854, DateTimeKind.Local).AddTicks(2984));

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35199871-9575-42e8-978a-d1171b90352b", null, "Admin", "Admin" },
                    { "f4c804fb-b7a0-44c2-9b1e-2300b9730d70", null, "Student", "Student" },
                    { "f72a1406-2d23-4ec6-b366-5febc81a1a58", null, "Teacher", "Teacher" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Date Of Birth", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5a3108b6-76e6-4744-8444-ab10093c58f7", 0, "5acfc3d3-9696-4b35-a26f-9663e6ea44c3", null, "admin@site.com", true, "img/users/user.webp", false, null, "admin@site.com", "Admin", "AQAAAAIAAYagAAAAEPXab7s4/6TivyQ/Yh6l3RPzCFUdEQGVcERBtKpPzKghG8Uhw66/C63mmk+lBsAYwA==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "35199871-9575-42e8-978a-d1171b90352b", "5a3108b6-76e6-4744-8444-ab10093c58f7" });

            migrationBuilder.CreateIndex(
                name: "IX_LecturePost_UserId",
                table: "LecturePost",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LecturePost_Users_UserId",
                table: "LecturePost",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LecturePost_Users_UserId",
                table: "LecturePost");

            migrationBuilder.DropIndex(
                name: "IX_LecturePost_UserId",
                table: "LecturePost");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f4c804fb-b7a0-44c2-9b1e-2300b9730d70");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f72a1406-2d23-4ec6-b366-5febc81a1a58");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "35199871-9575-42e8-978a-d1171b90352b", "5a3108b6-76e6-4744-8444-ab10093c58f7" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "35199871-9575-42e8-978a-d1171b90352b");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "5a3108b6-76e6-4744-8444-ab10093c58f7");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "LecturePost");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LecturePost");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Lecture",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 17, 20, 47, 44, 854, DateTimeKind.Local).AddTicks(2984),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 18, 14, 18, 17, 611, DateTimeKind.Local).AddTicks(3510));

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "433f3f6c-b0ca-4e69-b5f8-ffb50e55c559", null, "Admin", "Admin" },
                    { "6a2c30cd-6015-47c4-a7d7-20f09b2daf2b", null, "Teacher", "Teacher" },
                    { "b39d0e95-714e-49e3-8d14-c5091d04b56c", null, "Student", "Student" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Date Of Birth", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "66e3c906-075d-49f6-8327-6fe8b42ee3b8", 0, "2266f221-237d-4439-9f3f-4f2b58411a01", null, "admin@site.com", true, "img/users/user.webp", false, null, "admin@site.com", "Admin", "AQAAAAIAAYagAAAAELXuQAWclAcvF1EkZ8Je168VLyAV18HWmKCpIwrkh3XftVaAS2uPpo3zfDZj+6YIrA==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "433f3f6c-b0ca-4e69-b5f8-ffb50e55c559", "66e3c906-075d-49f6-8327-6fe8b42ee3b8" });
        }
    }
}
