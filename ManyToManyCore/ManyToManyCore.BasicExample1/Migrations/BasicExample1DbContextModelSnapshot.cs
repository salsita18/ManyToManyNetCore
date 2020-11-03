﻿// <auto-generated />
using System;
using ManyToManyCore.BasicExample1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManyToManyCore.BasicExample1.Migrations
{
    [DbContext(typeof(BasicExample1DbContext))]
    partial class BasicExample1DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ManyToManyCore.BasicExample1.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("ManyToManyCore.BasicExample1.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("ManyToManyCore.MiddleEntity<ManyToManyCore.BasicExample1.Job, ManyToManyCore.BasicExample1.Person, System.Guid, int>", b =>
                {
                    b.Property<int>("IdHolder")
                        .HasColumnType("int");

                    b.Property<Guid>("IdDependent")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("IdHolder", "IdDependent");

                    b.HasIndex("IdDependent");

                    b.HasIndex("PersonId");

                    b.ToTable("MiddleEntity<Job, Person, Guid, int>");
                });

            modelBuilder.Entity("ManyToManyCore.MiddleEntity<ManyToManyCore.BasicExample1.Job, ManyToManyCore.BasicExample1.Person, System.Guid, int>", b =>
                {
                    b.HasOne("ManyToManyCore.BasicExample1.Job", "Dependent")
                        .WithMany()
                        .HasForeignKey("IdDependent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManyToManyCore.BasicExample1.Person", "Holder")
                        .WithMany()
                        .HasForeignKey("IdHolder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManyToManyCore.BasicExample1.Person", null)
                        .WithMany("PersonToJob")
                        .HasForeignKey("PersonId");
                });
#pragma warning restore 612, 618
        }
    }
}
