using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentRG.Models.DataModels;
using System.Collections.Generic;

namespace StudentRG.DAO
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }

        public DbSet<EnrollmentEntity> Enrollments { get; set; }
        public DbSet<AttendanceEntity> Attendances { get; set; }

        public DbSet<PrerequisiteCourseEntity> PrerequisiteCourses { get; set; }
    }
}
