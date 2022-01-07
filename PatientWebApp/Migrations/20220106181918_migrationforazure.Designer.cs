﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientWebApp.Data;

namespace PatientWebApp.Migrations
{
    [DbContext(typeof(PatientDbContext))]
    [Migration("20220106181918_migrationforazure")]
    partial class migrationforazure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PatientWebApp.Models.Medecin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PrixVisite")
                        .HasColumnType("real");

                    b.Property<string>("Specialite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Medecin");
                });

            modelBuilder.Entity("PatientWebApp.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("PatientWebApp.Models.RendezVous", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MedecinID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<bool>("Valider")
                        .HasColumnType("bit");

                    b.Property<DateTime>("dateRendezVous")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("MedecinID");

                    b.HasIndex("PatientID");

                    b.ToTable("RendezVous");
                });

            modelBuilder.Entity("PatientWebApp.Models.RendezVous", b =>
                {
                    b.HasOne("PatientWebApp.Models.Medecin", "Medecin")
                        .WithMany()
                        .HasForeignKey("MedecinID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PatientWebApp.Models.Patient", "Patient")
                        .WithMany("RendezVous")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
