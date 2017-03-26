using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using api.cvetbenavente.Data;

namespace api.cvetbenavente.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20170326162419_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("api.cvetbenavente.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Genero");

                    b.Property<int>("IdCliente");

                    b.Property<int>("IdEspecie");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEspecie");

                    b.ToTable("Animais");
                });

            modelBuilder.Entity("api.cvetbenavente.Models.ApiKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationUserId");

                    b.Property<string>("Key")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ApiKeys");
                });

            modelBuilder.Entity("api.cvetbenavente.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("api.cvetbenavente.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contacto");

                    b.Property<string>("Morada");

                    b.Property<string>("Nome");

                    b.Property<string>("Observacoes");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("api.cvetbenavente.Models.Especie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Especies");
                });

            modelBuilder.Entity("api.cvetbenavente.Models.Animal", b =>
                {
                    b.HasOne("api.cvetbenavente.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("api.cvetbenavente.Models.Especie", "Especie")
                        .WithMany()
                        .HasForeignKey("IdEspecie")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
