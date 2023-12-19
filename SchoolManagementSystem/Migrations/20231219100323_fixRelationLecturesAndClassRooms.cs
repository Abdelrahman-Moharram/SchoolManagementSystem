using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class fixRelationLecturesAndClassRooms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Teacher_TeacherId",
                table: "Lecture");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "53a4fb41-d6ce-40d4-8071-6297a0ba7889");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ee2bc1f8-ab88-409a-8c7e-ab99d83f3174");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1e53c6f2-987d-4a33-81b2-53f19df123ef", "af636606-d038-4c70-b80a-313aa92a2036" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1e53c6f2-987d-4a33-81b2-53f19df123ef");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "af636606-d038-4c70-b80a-313aa92a2036");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Lecture",
                newName: "SubjectClassroomTeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Lecture_TeacherId",
                table: "Lecture",
                newName: "IX_Lecture_SubjectClassroomTeacherId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "LecturePost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 19, 12, 3, 23, 8, DateTimeKind.Local).AddTicks(4708),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 18, 23, 51, 19, 117, DateTimeKind.Local).AddTicks(7364));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Lecture",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 19, 12, 3, 23, 8, DateTimeKind.Local).AddTicks(3915),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 18, 23, 51, 19, 117, DateTimeKind.Local).AddTicks(6570));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_SubjectClassroomTeacher_SubjectClassroomTeacherId",
                table: "Lecture",
                column: "SubjectClassroomTeacherId",
                principalTable: "SubjectClassroomTeacher",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_SubjectClassroomTeacher_SubjectClassroomTeacherId",
                table: "Lecture");

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

            migrationBuilder.RenameColumn(
                name: "SubjectClassroomTeacherId",
                table: "Lecture",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Lecture_SubjectClassroomTeacherId",
                table: "Lecture",
                newName: "IX_Lecture_TeacherId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "LecturePost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 18, 23, 51, 19, 117, DateTimeKind.Local).AddTicks(7364),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 19, 12, 3, 23, 8, DateTimeKind.Local).AddTicks(4708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Lecture",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 18, 23, 51, 19, 117, DateTimeKind.Local).AddTicks(6570),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 19, 12, 3, 23, 8, DateTimeKind.Local).AddTicks(3915));

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e53c6f2-987d-4a33-81b2-53f19df123ef", null, "Admin", "Admin" },
                    { "53a4fb41-d6ce-40d4-8071-6297a0ba7889", null, "Teacher", "Teacher" },
                    { "ee2bc1f8-ab88-409a-8c7e-ab99d83f3174", null, "Student", "Student" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Date Of Birth", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "af636606-d038-4c70-b80a-313aa92a2036", 0, "15c0fad0-04ee-46ed-a44f-78fa9dee2f00", null, "admin@site.com", true, "img/users/user.webp", false, null, "admin@site.com", "Admin", "AQAAAAIAAYagAAAAEMqVNJTKZH2SM2oNaBaPwUmrIjqb1rahUoCT1DNyjLpN9w3hsF90uBSjqhq7D/2mQA==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1e53c6f2-987d-4a33-81b2-53f19df123ef", "af636606-d038-4c70-b80a-313aa92a2036" });

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Teacher_TeacherId",
                table: "Lecture",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id");
        }
    }
}
