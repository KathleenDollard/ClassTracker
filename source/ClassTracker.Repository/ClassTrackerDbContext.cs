using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace KadGen.ClassTracker.Repository
{
    public class ClassTrackerDbContext : DbContext
    {
        public ClassTrackerDbContext() : base("name=ClassTrackerDatabase")
        { }

        public DbSet<EfOrganization> Organizations { get; set; }
        public DbSet<EfSection> Sections { get; set; }
        public DbSet<EfTerm> Terms { get; set; }
        public DbSet<EfInstructor> Instructors { get; set; }
        public DbSet<EfCourse> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<EfOrganization>()
                .HasKey(i => i.Id)
                .ToTable ("Organization");
            builder.Entity<EfOrganization>()
              .Property(i => i.Id)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
              .HasColumnName("Id");

            builder.Entity<EfSection>()
                .HasKey(i => i.Id)
                .ToTable("Section");
            builder.Entity<EfSection>()
              .Property(i => i.Id)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
              .HasColumnName("Id");

            builder.Entity<EfTerm>()
                 .HasKey(i => i.Id)
                 .ToTable("Term");
            builder.Entity<EfTerm>()
              .Property(i => i.Id)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
              .HasColumnName("Id");

            builder.Entity<EfInstructor>()
                .HasKey(i => i.Id)
                .ToTable("Instructor");
            builder.Entity<EfInstructor>()
              .Property(i => i.Id)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
              .HasColumnName("Id");

            builder.Entity<EfCourse>()
                .HasKey(i => i.Id)
                .ToTable("Course");
            builder.Entity<EfCourse>()
              .Property(i => i.Id)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
              .HasColumnName("Id");
        }



    }
}
