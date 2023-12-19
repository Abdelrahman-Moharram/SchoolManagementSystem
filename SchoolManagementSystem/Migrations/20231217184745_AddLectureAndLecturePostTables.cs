using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddLectureAndLecturePostTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9d5e8f8d-7ca6-4393-8711-4b1188ab950f");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d8badbfe-2e04-4536-8b37-17fa93b56bfb");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9d2287e2-91b8-4801-9a4a-1ce625237652", "e814f0fb-6f40-4563-b883-fff11eaa0ed8" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9d2287e2-91b8-4801-9a4a-1ce625237652");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "e814f0fb-6f40-4563-b883-fff11eaa0ed8");

            migrationBuilder.CreateTable(
                name: "Lecture",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 12, 17, 20, 47, 44, 854, DateTimeKind.Local).AddTicks(2984)),
                    SubjectId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TeacherId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lecture_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lecture_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LecturePost",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LectureId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturePost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LecturePost_Lecture_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lecture",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_SubjectId",
                table: "Lecture",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_TeacherId",
                table: "Lecture",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_LecturePost_LectureId",
                table: "LecturePost",
                column: "LectureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LecturePost");

            migrationBuilder.DropTable(
                name: "Lecture");

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

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9d2287e2-91b8-4801-9a4a-1ce625237652", null, "Admin", "Admin" },
                    { "9d5e8f8d-7ca6-4393-8711-4b1188ab950f", null, "Teacher", "Teacher" },
                    { "d8badbfe-2e04-4536-8b37-17fa93b56bfb", null, "Student", "Student" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Date Of Birth", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e814f0fb-6f40-4563-b883-fff11eaa0ed8", 0, "450292b1-93a3-46cf-8bb3-f8e465e08c6e", null, "admin@site.com", true, "img/users/user.webp", false, null, "admin@site.com", "Admin", "AQAAAAIAAYagAAAAEDFi0T62eOY+X/U4dgLcF7TgFIfVPeO0urnsulT9Jsko8eVutMYPLqqgGtCxA8uXNw==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9d2287e2-91b8-4801-9a4a-1ce625237652", "e814f0fb-6f40-4563-b883-fff11eaa0ed8" });
        }
    }
}
