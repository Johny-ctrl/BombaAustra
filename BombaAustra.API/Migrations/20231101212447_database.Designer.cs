﻿// <auto-generated />
using System;
using BombaAustra.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BombaAustra.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231101212447_database")]
    partial class database
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BombaAustra.Shared.Entities.Compañia", b =>
                {
                    b.Property<int>("ID_COMPAÑIA")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_COMPAÑIA"));

                    b.Property<int>("ID_NOMBRE_COMPANIA")
                        .HasColumnType("int");

                    b.HasKey("ID_COMPAÑIA");

                    b.HasIndex("ID_COMPAÑIA")
                        .IsUnique();

                    b.ToTable("COMPANIAS");
                });

            modelBuilder.Entity("BombaAustra.Shared.Entities.Equipo", b =>
                {
                    b.Property<int>("ID_EQUIPO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_EQUIPO"));

                    b.Property<int>("ESTADO_EQUIPO")
                        .HasColumnType("int");

                    b.Property<string>("NOMBRE_EQUIPO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TIPO_EQUIPO")
                        .HasColumnType("int");

                    b.HasKey("ID_EQUIPO");

                    b.HasIndex("ID_EQUIPO")
                        .IsUnique();

                    b.ToTable("EQUIPOS");
                });

            modelBuilder.Entity("BombaAustra.Shared.Entities.EstadoEquipo", b =>
                {
                    b.Property<int>("ID_ESTADO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_ESTADO"));

                    b.Property<string>("DESCRIPCION")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_ESTADO");

                    b.HasIndex("ID_ESTADO")
                        .IsUnique();

                    b.ToTable("ESTADO_EQUIPO");
                });

            modelBuilder.Entity("BombaAustra.Shared.Entities.Gastos", b =>
                {
                    b.Property<string>("ID_GASTO")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AÑO_ACTUAL")
                        .HasColumnType("int");

                    b.Property<int>("AÑO_PASADO")
                        .HasColumnType("int");

                    b.Property<int>("COSTO_REVISION_TEC")
                        .HasColumnType("int");

                    b.HasKey("ID_GASTO");

                    b.HasIndex("ID_GASTO")
                        .IsUnique();

                    b.ToTable("GASTOS");
                });

            modelBuilder.Entity("BombaAustra.Shared.Entities.ModeloVehiculo", b =>
                {
                    b.Property<int>("ID_MODELO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_MODELO"));

                    b.Property<string>("DESCRIPCION")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_MODELO");

                    b.HasIndex("ID_MODELO")
                        .IsUnique();

                    b.ToTable("MODELO_VEHICULO");
                });

            modelBuilder.Entity("BombaAustra.Shared.Entities.NombreCompañia", b =>
                {
                    b.Property<int>("ID_NOMBRE_COMPAÑIA")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_NOMBRE_COMPAÑIA"));

                    b.Property<string>("NOMBRE_COMPAÑIA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_NOMBRE_COMPAÑIA");

                    b.HasIndex("ID_NOMBRE_COMPAÑIA")
                        .IsUnique();

                    b.ToTable("NOMBRE_COMPANIAS");
                });

            modelBuilder.Entity("BombaAustra.Shared.Entities.Reporte", b =>
                {
                    b.Property<int>("ID_REPORTE")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_REPORTE"));

                    b.Property<string>("DESCRIPCION")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_REPORTE");

                    b.HasIndex("ID_REPORTE")
                        .IsUnique();

                    b.ToTable("REPORTES");
                });

            modelBuilder.Entity("BombaAustra.Shared.Entities.TipoEquipo", b =>
                {
                    b.Property<int>("ID_TIPO_EQUIPO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_TIPO_EQUIPO"));

                    b.Property<string>("DESCRIPCION")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_TIPO_EQUIPO");

                    b.HasIndex("ID_TIPO_EQUIPO")
                        .IsUnique();

                    b.ToTable("TIPO_EQUIPO");
                });

            modelBuilder.Entity("BombaAustra.Shared.Entities.TipoUsuario", b =>
                {
                    b.Property<int>("ID_TIPO_USUARIO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_TIPO_USUARIO"));

                    b.Property<string>("DESCRIPCION")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_TIPO_USUARIO");

                    b.HasIndex("ID_TIPO_USUARIO")
                        .IsUnique();

                    b.ToTable("TIPO_USUARIOS");
                });

            modelBuilder.Entity("BombaAustra.Shared.Entities.TipoVehiculo", b =>
                {
                    b.Property<string>("SIGLA")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ID_MODELO")
                        .HasColumnType("int");

                    b.Property<string>("MARCA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PATENTE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ULTIMA_REVISION_TEC")
                        .HasColumnType("datetime2");

                    b.HasKey("SIGLA");

                    b.HasIndex("SIGLA")
                        .IsUnique();

                    b.ToTable("TIPO_VEHICULO");
                });

            modelBuilder.Entity("BombaAustra.Shared.Entities.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("APELLIDO_M")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("APELLIDO_P")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DV_RUT")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ID_RUT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NOMBRE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("Usertype")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BombaAustra.Shared.Entities.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BombaAustra.Shared.Entities.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BombaAustra.Shared.Entities.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BombaAustra.Shared.Entities.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
