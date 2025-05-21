using Hexagon.Domain.Entites;
using Hexagon.Domain.Entites.ApplicationsForTeaching;
using Hexagon.Domain.Entites.Courses;
using Hexagon.Domain.Entites.Forum;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Hexagon.Domain
{
    public class HexagonDbContext : IdentityDbContext<IdentityUser>
    {
        public HexagonDbContext(DbContextOptions<HexagonDbContext> options) : base(options) { }

        public DbSet<NewsEntity> News { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<UserAvatarEntity> UsersAvatars { get; set; }
        public DbSet<CourseCategoryTypeEntity> CourseCategoryTypes { get; set; }
        public DbSet<ApplicationForTeachingEntity> ApplicationsForTeaching { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<TestEntity> Tests { get; set; }   
        public DbSet<UserCoursesEntity> UsersCourses { get; set; }
        public DbSet<DiscussionEntity> Discussions { get; set; }
        public DbSet<CourseUserProgessEntity> UsersProgress { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserCoursesEntity>().HasKey(u => u.UserId);
            builder.Entity<IdentityRole>().HasData(GetPredefinedRoles());
            builder.Entity<IdentityUser>().HasData(GetPredefinedUsers());
            builder.Entity<IdentityUserRole<string>>().HasData(GetUserRoles());
        }

        private static IEnumerable<IdentityRole> GetPredefinedRoles()
        {
            return new List<IdentityRole>
            {
                new IdentityRole { Id = "1", Name = "admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "moderator", NormalizedName = "MODERATOR" },               
                new IdentityRole { Id = "3", Name = "teacher", NormalizedName = "TEACHER" },
                new IdentityRole { Id = "4", Name = "student", NormalizedName = "STUDENT" }
            };
        }

        private static IEnumerable<IdentityUser> GetPredefinedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            return new List<IdentityUser>
            {
                new IdentityUser
                {
                    Id = "6c0eff69-b00a-49ba-b093-2e9e974828f6",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin#2004"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new IdentityUser
                {
                    Id = "ef26d68c-2299-407b-a953-a8a63dda5f5c",
                    UserName = "moderator",
                    NormalizedUserName = "MODERATOR",
                    Email = "moderator@gmail.com",
                    NormalizedEmail = "MODERATOR@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Moderator#2004"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new IdentityUser
                {
                    Id = "17c01453-0cd8-4fc8-8c39-48028912f8b7",
                    UserName = "teacher",
                    NormalizedUserName = "TEACHER",
                    Email = "teacher@gmail.com",
                    NormalizedEmail = "TEACHER@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Teacher#2004"),
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            };
        }

        private static IEnumerable<IdentityUserRole<string>> GetUserRoles()
        {
            return new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string> { RoleId = "1", UserId = "6c0eff69-b00a-49ba-b093-2e9e974828f6" },
                new IdentityUserRole<string> { RoleId = "2", UserId = "ef26d68c-2299-407b-a953-a8a63dda5f5c" },
                new IdentityUserRole<string> { RoleId = "3", UserId = "17c01453-0cd8-4fc8-8c39-48028912f8b7" },
            };
        }
    }
}
