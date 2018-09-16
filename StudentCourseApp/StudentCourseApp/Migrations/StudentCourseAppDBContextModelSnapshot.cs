﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using StudentCourseApp.Models;
using System;

namespace StudentCourseApp.Migrations
{
    [DbContext(typeof(StudentCourseAppDBContext))]
    partial class StudentCourseAppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentCourseApp.Models.Course", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("char(4)");

                    b.Property<string>("Cname")
                        .HasColumnName("CName")
                        .HasMaxLength(40)
                        .IsUnicode(false);

                    b.Property<string>("Compulsory")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<string>("Desc")
                        .HasColumnType("text");

                    b.Property<string>("PreReq")
                        .HasColumnType("text");

                    b.Property<string>("Semester")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<int>("YearLevel");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("StudentCourseApp.Models.Enrollment", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("CourseId")
                        .HasColumnType("char(4)");

                    b.Property<int?>("Sid")
                        .HasColumnName("SId");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("Sid");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("StudentCourseApp.Models.Student", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("StudentCourseApp.Models.Enrollment", b =>
                {
                    b.HasOne("StudentCourseApp.Models.Course", "Course")
                        .WithMany("Enrollment")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_CourseEnrol");

                    b.HasOne("StudentCourseApp.Models.Student", "S")
                        .WithMany("Enrollment")
                        .HasForeignKey("Sid")
                        .HasConstraintName("FK_StdEnrol");
                });
#pragma warning restore 612, 618
        }
    }
}