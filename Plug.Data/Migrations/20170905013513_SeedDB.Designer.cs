﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Plug.Data;
using System;

namespace Plug.Data.Migrations
{
    [DbContext(typeof(PlugDbContext))]
    [Migration("20170905013513_SeedDB")]
    partial class SeedDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Plug.Entities.Choice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsAnswer");

                    b.Property<string>("Option")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<Guid>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Choices");
                });

            modelBuilder.Entity("Plug.Entities.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description")
                        .HasMaxLength(5000);

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("UpdateBy");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Plug.Entities.Enrollment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CourseId");

                    b.Property<string>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<Guid>("StudentId");

                    b.Property<string>("UpdateBy");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("Plug.Entities.EnrollModule", b =>
                {
                    b.Property<Guid>("EnrollmentId");

                    b.Property<Guid>("ModuleId");

                    b.Property<bool>("IsCompleted");

                    b.Property<bool>("IsStarted");

                    b.Property<DateTime>("LastVisited");

                    b.HasKey("EnrollmentId", "ModuleId");

                    b.HasIndex("ModuleId");

                    b.ToTable("EnrollModule");
                });

            modelBuilder.Entity("Plug.Entities.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanSkip");

                    b.Property<Guid>("CourseId");

                    b.Property<string>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Icon");

                    b.Property<int>("Order")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("UpdateBy");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Modules");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Module");
                });

            modelBuilder.Entity("Plug.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(2500);

                    b.Property<string>("UpdateBy");

                    b.Property<DateTime>("UpdateDate");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Plug.Entities.Question", b =>
                {
                    b.HasBaseType("Plug.Entities.Module");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(2500);

                    b.ToTable("QuestionModules");

                    b.HasDiscriminator().HasValue("Question");
                });

            modelBuilder.Entity("Plug.Entities.Text", b =>
                {
                    b.HasBaseType("Plug.Entities.Module");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.ToTable("TextModules");

                    b.HasDiscriminator().HasValue("Text");
                });

            modelBuilder.Entity("Plug.Entities.Video", b =>
                {
                    b.HasBaseType("Plug.Entities.Module");

                    b.Property<TimeSpan>("Duration");

                    b.Property<string>("Uri")
                        .IsRequired();

                    b.ToTable("VideoModules");

                    b.HasDiscriminator().HasValue("Video");
                });

            modelBuilder.Entity("Plug.Entities.Choice", b =>
                {
                    b.HasOne("Plug.Entities.Question", "Question")
                        .WithMany("Choices")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Plug.Entities.Enrollment", b =>
                {
                    b.HasOne("Plug.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Plug.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Plug.Entities.EnrollModule", b =>
                {
                    b.HasOne("Plug.Entities.Enrollment", "Enrollment")
                        .WithMany("EnrollModules")
                        .HasForeignKey("EnrollmentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Plug.Entities.Module", "Module")
                        .WithMany("EnrollModules")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Plug.Entities.Module", b =>
                {
                    b.HasOne("Plug.Entities.Course", "Course")
                        .WithMany("Modules")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
