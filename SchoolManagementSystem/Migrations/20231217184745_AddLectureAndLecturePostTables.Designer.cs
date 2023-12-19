﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolManagementSystem.Data;

#nullable disable

namespace SchoolManagementSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231217184745_AddLectureAndLecturePostTables")]
    partial class AddLectureAndLecturePostTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClassroomSubject", b =>
                {
                    b.Property<string>("ClassesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SubjectsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ClassesId", "SubjectsId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("ClassroomSubject");
                });

            modelBuilder.Entity("ClassroomTeacher", b =>
                {
                    b.Property<string>("ClassroomsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TeachersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ClassroomsId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("ClassroomTeacher");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles", "Identity");

                    b.HasData(
                        new
                        {
                            Id = "433f3f6c-b0ca-4e69-b5f8-ffb50e55c559",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        },
                        new
                        {
                            Id = "6a2c30cd-6015-47c4-a7d7-20f09b2daf2b",
                            Name = "Teacher",
                            NormalizedName = "Teacher"
                        },
                        new
                        {
                            Id = "b39d0e95-714e-49e3-8d14-c5091d04b56c",
                            Name = "Student",
                            NormalizedName = "Student"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", "Identity");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "Identity");

                    b.HasData(
                        new
                        {
                            UserId = "66e3c906-075d-49f6-8327-6fe8b42ee3b8",
                            RoleId = "433f3f6c-b0ca-4e69-b5f8-ffb50e55c559"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", "Identity");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("date")
                        .HasColumnName("Date Of Birth");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", "Identity");

                    b.HasData(
                        new
                        {
                            Id = "66e3c906-075d-49f6-8327-6fe8b42ee3b8",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "2266f221-237d-4439-9f3f-4f2b58411a01",
                            Email = "admin@site.com",
                            EmailConfirmed = true,
                            Image = "img/users/user.webp",
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@site.com",
                            NormalizedUserName = "Admin",
                            PasswordHash = "AQAAAAIAAYagAAAAELXuQAWclAcvF1EkZ8Je168VLyAV18HWmKCpIwrkh3XftVaAS2uPpo3zfDZj+6YIrA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Classroom", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("capacity")
                        .HasColumnType("int");

                    b.Property<string>("levelId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("levelId");

                    b.ToTable("Classroom");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Exam", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("Grade")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<decimal?>("MinGrade")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TeacherId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("startDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Lecture", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 12, 17, 20, 47, 44, 854, DateTimeKind.Local).AddTicks(2984));

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TeacherId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Lecture");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.LecturePost", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("File")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LectureId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.ToTable("LecturePost");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Level", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Level");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.RegisterComplete", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsDone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RegisterComplete");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Student", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClassroomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LevelId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ClassroomId");

                    b.HasIndex("LevelId");

                    b.HasIndex("UserId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.StudentsSubjects", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("TotalGrade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentsSubjects");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Subject", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal?>("Grade")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("levelId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("subjectCategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("levelId");

                    b.HasIndex("subjectCategoryId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.SubjectCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SubjectCategory");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.SubjectClassroomTeacher", b =>
                {
                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClassroomId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TeacherId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SubjectId", "ClassroomId", "TeacherId");

                    b.HasIndex("ClassroomId");

                    b.HasIndex("TeacherId");

                    b.ToTable("SubjectClassroomTeacher");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Teacher", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<decimal>("Salary")
                        .HasColumnType("money");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("subjectCategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("subjectCategoryId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.Property<string>("SubjectsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TeacherId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SubjectsId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("SubjectTeacher");
                });

            modelBuilder.Entity("ClassroomSubject", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.Classroom", null)
                        .WithMany()
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClassroomTeacher", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.Classroom", null)
                        .WithMany()
                        .HasForeignKey("ClassroomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Classroom", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.Level", "level")
                        .WithMany("Classrooms")
                        .HasForeignKey("levelId");

                    b.Navigation("level");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Exam", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.Subject", null)
                        .WithMany("Exams")
                        .HasForeignKey("SubjectId");

                    b.HasOne("SchoolManagementSystem.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Lecture", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.Subject", "Subject")
                        .WithMany("Lectures")
                        .HasForeignKey("SubjectId");

                    b.HasOne("SchoolManagementSystem.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.LecturePost", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.Lecture", "Lecture")
                        .WithMany("Posts")
                        .HasForeignKey("LectureId");

                    b.Navigation("Lecture");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Student", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.Classroom", "Classroom")
                        .WithMany("students")
                        .HasForeignKey("ClassroomId");

                    b.HasOne("SchoolManagementSystem.Models.Level", "Level")
                        .WithMany("Students")
                        .HasForeignKey("LevelId");

                    b.HasOne("SchoolManagementSystem.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Classroom");

                    b.Navigation("Level");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.StudentsSubjects", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.HasOne("SchoolManagementSystem.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Subject", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.Level", "level")
                        .WithMany("subjects")
                        .HasForeignKey("levelId");

                    b.HasOne("SchoolManagementSystem.Models.SubjectCategory", "subjectCategory")
                        .WithMany()
                        .HasForeignKey("subjectCategoryId");

                    b.Navigation("level");

                    b.Navigation("subjectCategory");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.SubjectClassroomTeacher", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.Classroom", "classroom")
                        .WithMany("subjectClassroomTeacher")
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Models.Subject", "subject")
                        .WithMany("subjectClassroomTeacher")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Models.Teacher", "Teacher")
                        .WithMany("subjectClassroomTeacher")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");

                    b.Navigation("classroom");

                    b.Navigation("subject");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Teacher", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("SchoolManagementSystem.Models.SubjectCategory", "subjectCategory")
                        .WithMany()
                        .HasForeignKey("subjectCategoryId");

                    b.Navigation("User");

                    b.Navigation("subjectCategory");
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.HasOne("SchoolManagementSystem.Models.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementSystem.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Classroom", b =>
                {
                    b.Navigation("students");

                    b.Navigation("subjectClassroomTeacher");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Lecture", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Level", b =>
                {
                    b.Navigation("Classrooms");

                    b.Navigation("Students");

                    b.Navigation("subjects");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Subject", b =>
                {
                    b.Navigation("Exams");

                    b.Navigation("Lectures");

                    b.Navigation("subjectClassroomTeacher");
                });

            modelBuilder.Entity("SchoolManagementSystem.Models.Teacher", b =>
                {
                    b.Navigation("subjectClassroomTeacher");
                });
#pragma warning restore 612, 618
        }
    }
}
