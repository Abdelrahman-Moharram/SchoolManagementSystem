using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class fixLectureEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Subject_SubjectId",
                table: "Lecture");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Teacher_TeacherId",
                table: "SubjectTeacher");

            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: "47a824ab-f7b6-49d8-8cd4-2d057ac910a0");

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

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "SubjectTeacher",
                newName: "TeachersId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTeacher_TeacherId",
                table: "SubjectTeacher",
                newName: "IX_SubjectTeacher_TeachersId");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Lecture",
                newName: "subjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Lecture_SubjectId",
                table: "Lecture",
                newName: "IX_Lecture_subjectId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "LecturePost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 19, 22, 44, 52, 989, DateTimeKind.Local).AddTicks(4513),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 19, 15, 48, 36, 371, DateTimeKind.Local).AddTicks(5411));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Lecture",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 19, 22, 44, 52, 989, DateTimeKind.Local).AddTicks(3652),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 19, 15, 48, 36, 371, DateTimeKind.Local).AddTicks(4606));

            migrationBuilder.AddColumn<string>(
                name: "ClassroomId",
                table: "Lecture",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Lecture",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4617ed76-f9d5-4502-82fe-9f5879ea6037", null, "Admin", "Admin" },
                    { "4abc79a8-5d41-44e5-b0f2-7666c21ebc38", null, "Student", "Student" },
                    { "743387b7-f9e5-47c6-a32a-9f29d16c9f01", null, "Teacher", "Teacher" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Date Of Birth", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6b0ebfa0-4a64-459a-84ce-41755808ae6d", 0, "6559ad61-7322-40af-99c4-043d59c18444", null, "admin@site.com", true, "img/users/user.webp", false, null, "admin@site.com", "Admin", "AQAAAAIAAYagAAAAEB+J08x3bLtWl3X2SwWTgcL9pMOKvQm/2gem+K92afRSfZajJvePUoYdrGriLEy1PQ==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "Salary", "UserId" },
                values: new object[] { "3f82462a-e9b8-4efa-923c-7b236c5c7ab0", 50000m, "6b0ebfa0-4a64-459a-84ce-41755808ae6d" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4617ed76-f9d5-4502-82fe-9f5879ea6037", "6b0ebfa0-4a64-459a-84ce-41755808ae6d" });

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_ClassroomId",
                table: "Lecture",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Lecture_TeacherId",
                table: "Lecture",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Classroom_ClassroomId",
                table: "Lecture",
                column: "ClassroomId",
                principalTable: "Classroom",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Subject_subjectId",
                table: "Lecture",
                column: "subjectId",
                principalTable: "Subject",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Teacher_TeacherId",
                table: "Lecture",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Teacher_TeachersId",
                table: "SubjectTeacher",
                column: "TeachersId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Classroom_ClassroomId",
                table: "Lecture");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Subject_subjectId",
                table: "Lecture");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Teacher_TeacherId",
                table: "Lecture");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Teacher_TeachersId",
                table: "SubjectTeacher");

            migrationBuilder.DropIndex(
                name: "IX_Lecture_ClassroomId",
                table: "Lecture");

            migrationBuilder.DropIndex(
                name: "IX_Lecture_TeacherId",
                table: "Lecture");

            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: "3f82462a-e9b8-4efa-923c-7b236c5c7ab0");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4abc79a8-5d41-44e5-b0f2-7666c21ebc38");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "743387b7-f9e5-47c6-a32a-9f29d16c9f01");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4617ed76-f9d5-4502-82fe-9f5879ea6037", "6b0ebfa0-4a64-459a-84ce-41755808ae6d" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4617ed76-f9d5-4502-82fe-9f5879ea6037");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Users",
                keyColumn: "Id",
                keyValue: "6b0ebfa0-4a64-459a-84ce-41755808ae6d");

            migrationBuilder.DropColumn(
                name: "ClassroomId",
                table: "Lecture");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Lecture");

            migrationBuilder.RenameColumn(
                name: "TeachersId",
                table: "SubjectTeacher",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTeacher_TeachersId",
                table: "SubjectTeacher",
                newName: "IX_SubjectTeacher_TeacherId");

            migrationBuilder.RenameColumn(
                name: "subjectId",
                table: "Lecture",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Lecture_subjectId",
                table: "Lecture",
                newName: "IX_Lecture_SubjectId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "LecturePost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 19, 15, 48, 36, 371, DateTimeKind.Local).AddTicks(5411),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 19, 22, 44, 52, 989, DateTimeKind.Local).AddTicks(4513));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Lecture",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 19, 15, 48, 36, 371, DateTimeKind.Local).AddTicks(4606),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 19, 22, 44, 52, 989, DateTimeKind.Local).AddTicks(3652));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Subject_SubjectId",
                table: "Lecture",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Teacher_TeacherId",
                table: "SubjectTeacher",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
