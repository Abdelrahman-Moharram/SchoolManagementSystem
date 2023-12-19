using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Configurations;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;


namespace SchoolManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // entities configurations
            new ApplicationUserConfigurations().Configure(builder.Entity<ApplicationUser>());
            new ClassroomConfigurations().Configure(builder.Entity<Classroom>());
            new ExamConfigurations().Configure(builder.Entity<Exam>());
            new LevelConfigurations().Configure(builder.Entity<Level>());
            new StudentConfigurations().Configure(builder.Entity<Student>());
            new SubjectConfigurations().Configure(builder.Entity<Subject>());
            new TeacherConfigurations().Configure(builder.Entity<Teacher>());
            new RegisterCompleteConfigurations().Configure(builder.Entity<RegisterComplete>());
            


            builder
                .Entity<SubjectClassroomTeacher>()
                .HasKey(x=>x.Id);
            builder
                .Entity<Lecture>()
                .Property(x=>x.DateTime)
                .HasDefaultValue(DateTime.Now);
            builder
                .Entity<Lecture>()
                .Property(x => x.IsDeleted)
                .HasDefaultValue(false);
            builder
                .Entity<LecturePost>()
                .Property(x => x.IsDeleted)
                .HasDefaultValue(false);
            builder
                .Entity<LecturePost>()
                .Property(x => x.DateTime)
                .HasDefaultValue(DateTime.Now);

            builder
                .Entity<LecturePost>()
                .HasOne(i=>i.User)
                .WithMany()
                .HasForeignKey(i=>i.UserId);

            builder.Entity<SubjectClassroomTeacher>()
                .HasMany(i=>i.Lectures)
                .WithOne(b=>b.SubjectClassroomTeacher)
                .HasForeignKey(i=>i.SubjectClassroomTeacherId);

            builder
                .Entity<Admin>()
                .Property(x => x.IsDeleted)
                .HasDefaultValue(false);

            builder.Entity<Admin>()
                .Property(i => i.Salary)
                .HasColumnType("money");


            // Identity Tables
            builder.Entity<ApplicationUser>().ToTable("Users", schema: "Identity");
            builder.Entity<IdentityRole>().ToTable("Roles", schema: "Identity");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", schema: "Identity");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", schema: "Identity");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", schema: "Identity");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", schema: "Identity");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", schema: "Identity");




            // data seedding

            // create Roles

            string AdminRoleId = Guid.NewGuid().ToString();
            string AdminId = Guid.NewGuid().ToString();


                // Roles
                builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                    {
                        Id = AdminRoleId,
                        Name = "Admin",
                        NormalizedName = "Admin"
                    },
                new IdentityRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Teacher",
                        NormalizedName = "Teacher"
                    },
                new IdentityRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Student",
                        NormalizedName = "Student"
                    }
                );

            //  create system admin

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(
                    new ApplicationUser
                    {
                        Id=AdminId,
                        UserName="Admin",
                        NormalizedUserName="Admin",
                        Email="admin@site.com",
                        NormalizedEmail = "admin@site.com",
                        EmailConfirmed= true,
                        PasswordHash = hasher.HashPassword(null, "12345678"),
                        SecurityStamp = string.Empty,
                        Image="img/users/user.webp"
                    });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = AdminRoleId,
                UserId = AdminId
            });

            builder.Entity<Admin>().HasData(new Admin
            {
                UserId = AdminId,
                Salary = 50000m,
            });



        }
        public DbSet<SchoolManagementSystem.Models.Student> Student { get; set; } = default!;
        public DbSet<SchoolManagementSystem.Models.Teacher> Teacher { get; set; } = default!;
        public DbSet<SchoolManagementSystem.Models.SubjectCategory> SubjectCategory { get; set; } = default!;
        public DbSet<SchoolManagementSystem.Models.Level> Level { get; set; } = default!;
        public DbSet<SchoolManagementSystem.Models.Subject> Subject { get; set; } = default!;
        public DbSet<SchoolManagementSystem.Models.Classroom> Classroom { get; set; } = default!;
        public DbSet<SchoolManagementSystem.Models.Lecture> Lecture { get; set; } = default!;


    }
}
