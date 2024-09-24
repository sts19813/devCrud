using Microsoft.EntityFrameworkCore;
using System;

namespace devCRUD.Models
{
    /// <summary>
    /// clase para el contexto
    /// </summary>
    public class DatabaseContext : DbContext
    {
        //contexto
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
                : base(options)
        {
        }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Enrollments> Enrollments { get; set; }
        public DbSet<CourseAssignments> CourseAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir clave primaria explícitamente
            modelBuilder.Entity<CourseAssignments>()
                .HasKey(ca => ca.AssignmentId);

            // Opcional: Configurar relaciones si es necesario
            modelBuilder.Entity<CourseAssignments>()
                .HasOne(ca => ca.Course)
                .WithMany(c => c.CourseAssignments)
                .HasForeignKey(ca => ca.CourseId);

            modelBuilder.Entity<CourseAssignments>()
                .HasOne(ca => ca.Teacher)
                .WithMany(t => t.CourseAssignments)
                .HasForeignKey(ca => ca.TeacherId);



            // Configurar la clave primaria explícitamente
            modelBuilder.Entity<Enrollments>()
                .HasKey(e => e.EnrollmentId);

            // Configurar las relaciones
            modelBuilder.Entity<Enrollments>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollments>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);
        }
    }
}
