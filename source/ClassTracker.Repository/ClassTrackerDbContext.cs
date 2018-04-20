using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace KadGen.ClassTracker.Repository
{
    public class ClassTrackerDbContextFactory : IDbContextFactory<ClassTrackerDbContext>
    {
        public ClassTrackerDbContext Create()
        {
            return new ClassTrackerDbContext("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kathl\\Documents\\Presentations\\201804 CodeStock\\Functional\\Code\\ClassTracker\\source\\ClassTracker.WebApi\\ClassTracker.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }

    public class ClassTrackerDbContext : DbContext
    {
        //public ClassTrackerDbContext() : base("name=DefaultConnection")
        //{ }

        public ClassTrackerDbContext(string connString) : base(connString)
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
