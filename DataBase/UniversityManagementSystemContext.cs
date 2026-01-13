using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UniversityManagement.Models;

public partial class UniversityManagementSystemContext : DbContext
{
    public UniversityManagementSystemContext()
    {
    }

    public UniversityManagementSystemContext(DbContextOptions<UniversityManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseClass> CourseClasses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WAJEED\\MSSQLSERVER01;Database=UniversityManagementSystem;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.MajorName)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<CourseClass>(entity =>
        {
            entity.ToTable("CourseClass");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClassName)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.CourseName)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Days)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(100)
                .IsFixedLength();

            entity.HasOne(d => d.Course).WithMany(p => p.CourseClasses)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CourseID");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.ToTable("Enrollment");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.CourseClass).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CourseClassID");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("StudentID");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Major)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.StudentNumber)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
