using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class fixTablesRelationExceptExams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classroom_Teacher_TeacherId",
                table: "Classroom");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Teacher_TeacherId",
                table: "Subject");

            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.DropIndex(
                name: "IX_Classroom_TeacherId",
                table: "Classroom");

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

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Classroom");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Subject",
                newName: "subjectCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Subject_TeacherId",
                table: "Subject",
                newName: "IX_Subject_subjectCategoryId");

            migrationBuilder.AddColumn<string>(
                name: "subjectCategoryId",
                table: "Teacher",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LevelId",
                table: "Student",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClassroomSubject",
                columns: table => new
                {
                    ClassesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomSubject", x => new { x.ClassesId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_ClassroomSubject_Classroom_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Classroom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassroomSubject_Subject_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassroomTeacher",
                columns: table => new
                {
                    ClassroomsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeachersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomTeacher", x => new { x.ClassroomsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_ClassroomTeacher_Classroom_ClassroomsId",
                        column: x => x.ClassroomsId,
                        principalTable: "Classroom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassroomTeacher_Teacher_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsSubjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubjectId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TotalGrade = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsSubjects_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentsSubjects_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubjectCategory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectClassroomTeacher",
                columns: table => new
                {
                    TeacherId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClassroomId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectClassroomTeacher", x => new { x.SubjectId, x.ClassroomId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_SubjectClassroomTeacher_Classroom_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classroom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectClassroomTeacher_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectClassroomTeacher_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTeacher",
                columns: table => new
                {
                    SubjectsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeacherId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeacher", x => new { x.SubjectsId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Subject_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectTeacher_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_subjectCategoryId",
                table: "Teacher",
                column: "subjectCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_LevelId",
                table: "Student",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomSubject_SubjectsId",
                table: "ClassroomSubject",
                column: "SubjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomTeacher_TeachersId",
                table: "ClassroomTeacher",
                column: "TeachersId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsSubjects_StudentId",
                table: "StudentsSubjects",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsSubjects_SubjectId",
                table: "StudentsSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectClassroomTeacher_ClassroomId",
                table: "SubjectClassroomTeacher",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectClassroomTeacher_TeacherId",
                table: "SubjectClassroomTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeacher_TeacherId",
                table: "SubjectTeacher",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Level_LevelId",
                table: "Student",
                column: "LevelId",
                principalTable: "Level",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_SubjectCategory_subjectCategoryId",
                table: "Subject",
                column: "subjectCategoryId",
                principalTable: "SubjectCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_SubjectCategory_subjectCategoryId",
                table: "Teacher",
                column: "subjectCategoryId",
                principalTable: "SubjectCategory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Level_LevelId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Subject_SubjectCategory_subjectCategoryId",
                table: "Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_SubjectCategory_subjectCategoryId",
                table: "Teacher");

            migrationBuilder.DropTable(
                name: "ClassroomSubject");

            migrationBuilder.DropTable(
                name: "ClassroomTeacher");

            migrationBuilder.DropTable(
                name: "StudentsSubjects");

            migrationBuilder.DropTable(
                name: "SubjectCategory");

            migrationBuilder.DropTable(
                name: "SubjectClassroomTeacher");

            migrationBuilder.DropTable(
                name: "SubjectTeacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_subjectCategoryId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Student_LevelId",
                table: "Student");

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

            migrationBuilder.DropColumn(
                name: "subjectCategoryId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "subjectCategoryId",
                table: "Subject",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Subject_subjectCategoryId",
                table: "Subject",
                newName: "IX_Subject_TeacherId");

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Classroom",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    SubjectsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    studentsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => new { x.SubjectsId, x.studentsId });
                    table.ForeignKey(
                        name: "FK_StudentSubject_Student_studentsId",
                        column: x => x.studentsId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subject_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_TeacherId",
                table: "Classroom",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_studentsId",
                table: "StudentSubject",
                column: "studentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classroom_Teacher_TeacherId",
                table: "Classroom",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Teacher_TeacherId",
                table: "Subject",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id");
        }
    }
}
