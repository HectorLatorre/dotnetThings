using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using firstapp.Data;

namespace firstapp.Migrations
{
    [DbContext(typeof(UniContext))]
    partial class UniContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("firstapp.Models.Curso", b =>
                {
                    b.Property<int>("IDCurso");

                    b.Property<int>("Creditos");

                    b.Property<string>("Nombre");

                    b.HasKey("IDCurso");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("firstapp.Models.Inscripcion", b =>
                {
                    b.Property<int>("IDInscripcion")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IDCurso");

                    b.Property<int>("IDUser");

                    b.Property<int?>("Nota");

                    b.HasKey("IDInscripcion");

                    b.HasIndex("IDCurso");

                    b.HasIndex("IDUser");

                    b.ToTable("Inscripcion");
                });

            modelBuilder.Entity("firstapp.Models.User", b =>
                {
                    b.Property<int>("IDUser")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellido");

                    b.Property<string>("Nombre");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("IDUser");

                    b.ToTable("User");
                });

            modelBuilder.Entity("firstapp.Models.Inscripcion", b =>
                {
                    b.HasOne("firstapp.Models.Curso", "Curso")
                        .WithMany("Inscripciones")
                        .HasForeignKey("IDCurso")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("firstapp.Models.User", "User")
                        .WithMany("Inscripciones")
                        .HasForeignKey("IDUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
