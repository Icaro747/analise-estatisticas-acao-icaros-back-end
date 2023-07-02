﻿// <auto-generated />
using System;
using AnaliseAcaoIcaros.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnaliseAcaoIcaros.Migrations
{
    [DbContext(typeof(AnaliseAcaoContext))]
    [Migration("20230625024333_inti")]
    partial class inti
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AnaliseAcaoIcaros.Models.Papel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Classe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Operacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Qtd")
                        .HasColumnType("int");

                    b.Property<decimal>("Taxa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Papels");
                });
#pragma warning restore 612, 618
        }
    }
}