using AllCourses.Domain.Entites;
using AllCourses.Domain.Entites.ApplicationsForTeaching;
using AllCourses.Domain.Entites.Courses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AllCourses.Domain
{
    public class AllCoursesDbContext : IdentityDbContext<IdentityUser>
    {
        public AllCoursesDbContext(DbContextOptions<AllCoursesDbContext> options) : base(options) { }

        public DbSet<NewsEntity> News { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<UserAvatarEntity> UsersAvatars { get; set; }
        public DbSet<CourseCategoryTypeEntity> CourseCategoryTypes { get; set; }
        public DbSet<ApplicationForTeachingEntity> ApplicationsForTeaching { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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
                    PasswordHash = hasher.HashPassword(null, "Admin2004#"),
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
                    PasswordHash = hasher.HashPassword(null, "Moderator2004#"),
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            };
        }

        private static IEnumerable<IdentityUserRole<string>> GetUserRoles()
        {
            return new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string> { RoleId = "1", UserId = "6c0eff69-b00a-49ba-b093-2e9e974828f6" },
                new IdentityUserRole<string> { RoleId = "2", UserId = "ef26d68c-2299-407b-a953-a8a63dda5f5c" }
            };
        }
    }
}
