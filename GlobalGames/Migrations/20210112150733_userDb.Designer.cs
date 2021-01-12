﻿// <auto-generated />
using System;
using GlobalGames.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GlobalGames.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210112150733_userDb")]
    partial class userDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GlobalGames.Data.Entidades.Contactos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<string>("msg");

                    b.HasKey("Id");

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("GlobalGames.Data.Entidades.Inscricoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("Birthday");

                    b.Property<int>("CCidadao");

                    b.Property<string>("LastName");

                    b.Property<string>("Localidade");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Inscricoes");
                });

            modelBuilder.Entity("GlobalGames.Data.Entidades.UserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("UserLogin");
                });
#pragma warning restore 612, 618
        }
    }
}