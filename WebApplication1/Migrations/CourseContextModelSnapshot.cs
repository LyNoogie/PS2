﻿// <auto-generated />
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(CourseContext))]
    partial class CourseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDb.Models.CourseDescription", b =>
                {
                    b.Property<int>("DescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("DescriptionId");

                    b.ToTable("Description");
                });

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDb.Models.CourseInstance", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dept");

                    b.Property<int>("DescriptionID");

                    b.Property<int>("Number");

                    b.Property<string>("Semester");

                    b.Property<int>("Year");

                    b.HasKey("ID");

                    b.HasIndex("DescriptionID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDb.Models.CourseInstance", b =>
                {
                    b.HasOne("EFGetStarted.AspNetCore.NewDb.Models.CourseDescription", "Description")
                        .WithMany("Courses")
                        .HasForeignKey("DescriptionID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
