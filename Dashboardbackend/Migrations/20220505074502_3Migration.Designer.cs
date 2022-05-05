﻿// <auto-generated />
using Dashboardbackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dashboardbackend.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220505074502_3Migration")]
    partial class _3Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApproachTool", b =>
                {
                    b.Property<int>("ApproachId")
                        .HasColumnType("int");

                    b.Property<int>("ToolId")
                        .HasColumnType("int");

                    b.HasKey("ApproachId", "ToolId");

                    b.HasIndex("ToolId");

                    b.ToTable("ApproachTool");
                });

            modelBuilder.Entity("Dashboardbackend.Models.Approach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ConcernId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImplementationDifficulty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaintenanceDifficulty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConcernId");

                    b.ToTable("approaches");
                });

            modelBuilder.Entity("Dashboardbackend.Models.ApproachTool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ApproachId")
                        .HasColumnType("int");

                    b.Property<int>("ConfigurationDifficulty")
                        .HasColumnType("int");

                    b.Property<int>("ToolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApproachId");

                    b.HasIndex("ToolId");

                    b.ToTable("approachTools");
                });

            modelBuilder.Entity("Dashboardbackend.Models.Concern", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObjectiveId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ObjectiveId");

                    b.ToTable("concerns");
                });

            modelBuilder.Entity("Dashboardbackend.Models.Objective", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("objectives");
                });

            modelBuilder.Entity("Dashboardbackend.Models.Tool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tools");
                });

            modelBuilder.Entity("ApproachTool", b =>
                {
                    b.HasOne("Dashboardbackend.Models.Tool", null)
                        .WithMany()
                        .HasForeignKey("ApproachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dashboardbackend.Models.Approach", null)
                        .WithMany()
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dashboardbackend.Models.Approach", b =>
                {
                    b.HasOne("Dashboardbackend.Models.Concern", "Concern")
                        .WithMany()
                        .HasForeignKey("ConcernId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concern");
                });

            modelBuilder.Entity("Dashboardbackend.Models.ApproachTool", b =>
                {
                    b.HasOne("Dashboardbackend.Models.Approach", "Approach")
                        .WithMany()
                        .HasForeignKey("ApproachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dashboardbackend.Models.Tool", "Tool")
                        .WithMany()
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Approach");

                    b.Navigation("Tool");
                });

            modelBuilder.Entity("Dashboardbackend.Models.Concern", b =>
                {
                    b.HasOne("Dashboardbackend.Models.Objective", "Objective")
                        .WithMany()
                        .HasForeignKey("ObjectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Objective");
                });
#pragma warning restore 612, 618
        }
    }
}
