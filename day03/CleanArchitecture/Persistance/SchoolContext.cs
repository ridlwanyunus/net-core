
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistence
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) 
        {
            SavingChanges += SavingChangeEvent;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SchoolDB;TrustServerCertificate=True;Trusted_Connection=True;"));
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("ridlwan");
            builder.Entity<Student>
            (
                e =>
                {
                    e.HasKey(x => x.ID);
                    e.Property(x => x.LastName).HasColumnName("last_name").HasMaxLength(100);
                    e.Property(x => x.FirstMidName).IsRequired().HasMaxLength(255);
                    e.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
                    e.HasQueryFilter(x => x.DeletedAt == null);

                    e.HasMany(x => x.Enrollments).WithOne(x => x.Student).HasForeignKey(x => x.StudentID);
                }
            );

            builder.Entity<Enrollment>
            (
                e =>
                {
                    e.HasKey(x => x.EnrollmentID);
                    e.Property(x => x.StudentID).IsRequired();
                    e.Property(x => x.CourseID).IsRequired();

                    e.HasOne(x => x.Student).WithMany(x => x.Enrollments).HasForeignKey(x => x.StudentID);
                    e.HasOne(x => x.Course).WithMany(x => x.Enrollments).HasForeignKey(x => x.CourseID);
                }
            );

            builder.Entity<Course>
            (
                e =>
                {
                    e.HasKey(x => x.CourseID);
                    e.Property(x => x.Credits).IsRequired().HasMaxLength(512);
                    e.Property(x => x.Title).IsRequired().HasMaxLength(255);

                    e.HasMany(x => x.Enrollments).WithOne(x => x.Course).HasForeignKey(x => x.CourseID);
                }
            );

            builder.Entity<Users>
            (
                e =>
                {
                    e.HasKey(x => x.ID);
                    e.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
                }
            );

            builder.Entity<UserRole>
            (
                e =>
                {
                    e.HasKey(x => x.ID);
                    e.Property(x => x.CreatedAt).HasDefaultValueSql("getdate()");
                }
            );
        }

        public void SavingChangeEvent(object? sender, SavingChangesEventArgs e)
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if(entry.Entity is Student Student && entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    Student.DeletedAt = DateTime.Now;
                }
            }
        }

    }
}
