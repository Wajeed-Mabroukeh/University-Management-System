namespace MyApiProject.DataBase;
using Microsoft.EntityFrameworkCore;
public class UniversityManagementContext : DbContext
{
    public UniversityManagementContext(DbContextOptions<UniversityManagementContext> options)
        : base(options) { }

    // public DbSet<Course> Courses => Set<Course>();
    // public DbSet<CourseClass> CourseClasses => Set<CourseClass>();
    // public DbSet<Student> Students => Set<Student>();
    // public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    
    public virtual DbSet<Course> Course { get; set; } 
    public virtual DbSet<CourseClass> CourseClass { get; set; } 
    public virtual DbSet<Student> Student { get; set; } 
    public virtual DbSet<Enrollment> Enrollment { get; set; } 
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=WAJEED\\MSSQLSERVER01;Database=UniversityManagement;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true", x => x.UseNetTopologySuite());
}


