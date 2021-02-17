﻿// <auto-generated />
using System;
using CrudApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrudApp.Migrations
{
    [DbContext(typeof(ApplicationDatabase))]
    partial class ApplicationDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CrudApp.Models.Estado", b =>
                {
                    b.Property<int>("PK_Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("PK_Estado");

                    b.HasIndex("Sigla")
                        .IsUnique();

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("CrudApp.Models.Funcionario", b =>
                {
                    b.Property<int>("PK_Funcionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("FK_Estado")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("Salario")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PK_Funcionario");

                    b.HasIndex("FK_Estado")
                        .IsUnique()
                        .HasFilter("[FK_Estado] IS NOT NULL");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("CrudApp.Models.Funcionario", b =>
                {
                    b.HasOne("CrudApp.Models.Estado", "Estado")
                        .WithOne()
                        .HasForeignKey("CrudApp.Models.Funcionario", "FK_Estado")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Estado");
                });
#pragma warning restore 612, 618
        }
    }
}
