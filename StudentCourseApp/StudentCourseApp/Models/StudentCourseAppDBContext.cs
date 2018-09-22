using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentCourseApp.Models
{
    public partial class StudentCourseAppDBContext : DbContext
    {
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<TopicArea> TopicArea { get; set; }

        public StudentCourseAppDBContext(DbContextOptions<StudentCourseAppDBContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("char(4)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cname)
                    .HasColumnName("CName")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Compulsory)
                    .IsRequired()
                    .HasColumnType("char(1)");

                entity.Property(e => e.Desc).HasColumnType("text");

                entity.Property(e => e.PreReq).HasColumnType("text");

                entity.Property(e => e.Semester)
                    .IsRequired()
                    .HasColumnType("char(1)");

                entity.Property(e => e.TId).HasColumnName("TId");

                entity.HasOne(d => d.TopicA)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.TId)
                    .HasConstraintName("FK_TpcArea");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CourseId).HasColumnType("char(4)");

                entity.Property(e => e.Sid).HasColumnName("SId");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_CourseEnrol");

                entity.HasOne(d => d.S)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("FK_StdEnrol");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TopicArea>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AreaName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
