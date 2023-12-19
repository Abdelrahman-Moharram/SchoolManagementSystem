using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixSubjectClassroomTeacherKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectClassroomTeacher_Classroom_ClassroomId",
                table: "SubjectClassroomTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectClassroomTeacher_Subject_SubjectId",
                table: "SubjectClassroomTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectClassroomTeacher_Teacher_TeacherId",
                table: "SubjectClassroomTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectClassroomTeacher",
                table: "SubjectClassroomTeacher");

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

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "SubjectClassroomTeacher",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ClassroomId",
                table: "SubjectClassroomTeacher",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "SubjectClassroomTeacher",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "SubjectClassroomTeacher",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "LecturePost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 18, 23, 51, 19, 117, DateTimeKind.Local).AddTicks(7364),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 18, 14, 18, 17, 611, DateTimeKind.Local).AddTicks(4346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Lecture",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 18, 23, 51, 19, 117, DateTimeKind.Local).AddTicks(6570),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 18, 14, 18, 17, 611, DateTimeKind.Local).AddTicks(3510));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectClassroomTeacher",
                table: "SubjectClassroomTeacher",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_SubjectClassroomTeacher_SubjectId",
                table: "SubjectClassroomTeacher",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectClassroomTeacher_Classroom_ClassroomId",
                table: "SubjectClassroomTeacher",
                column: "ClassroomId",
                principalTable: "Classroom",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectClassroomTeacher_Subject_SubjectId",
                table: "SubjectClassroomTeacher",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectClassroomTeacher_Teacher_TeacherId",
                table: "SubjectClassroomTeacher",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectClassroomTeacher_Classroom_ClassroomId",
                table: "SubjectClassroomTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectClassroomTeacher_Subject_SubjectId",
                table: "SubjectClassroomTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectClassroomTeacher_Teacher_TeacherId",
                table: "SubjectClassroomTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectClassroomTeacher",
                table: "SubjectClassroomTeacher");

            migrationBuilder.DropIndex(
                name: "IX_SubjectClassroomTeacher_SubjectId",
                table: "SubjectClassroomTeacher");

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

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SubjectClassroomTeacher");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "SubjectClassroomTeacher",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "SubjectClassroomTeacher",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClassroomId",
                table: "SubjectClassroomTeacher",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "LecturePost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 18, 14, 18, 17, 611, DateTimeKind.Local).AddTicks(4346),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 18, 23, 51, 19, 117, DateTimeKind.Local).AddTicks(7364));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Lecture",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 18, 14, 18, 17, 611, DateTimeKind.Local).AddTicks(3510),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 18, 23, 51, 19, 117, DateTimeKind.Local).AddTicks(6570));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectClassroomTeacher",
                table: "SubjectClassroomTeacher",
                columns: new[] { "SubjectId", "ClassroomId", "TeacherId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectClassroomTeacher_Classroom_ClassroomId",
                table: "SubjectClassroomTeacher",
                column: "ClassroomId",
                principalTable: "Classroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectClassroomTeacher_Subject_SubjectId",
                table: "SubjectClassroomTeacher",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectClassroomTeacher_Teacher_TeacherId",
                table: "SubjectClassroomTeacher",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
