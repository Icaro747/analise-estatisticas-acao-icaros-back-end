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
    [Migration("20230708201955_addCotacao")]
    partial class addCotacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AnaliseAcaoIcaros.Models.Carteira", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Carteiras");
                });

            modelBuilder.Entity("AnaliseAcaoIcaros.Models.CotacoesAcoes", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Acao")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<DateTime>("DataObtida")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ValorAtual")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("cotacoesAcoes");
                });

            modelBuilder.Entity("AnaliseAcaoIcaros.Models.Dividendos", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdPapel")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Valor")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdPapel");

                    b.ToTable("Dividendos");
                });

            modelBuilder.Entity("AnaliseAcaoIcaros.Models.Movimentacao", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdPapel")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Operacao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Qtd")
                        .HasColumnType("int");

                    b.Property<decimal>("Taxa")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Valor")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdPapel");

                    b.ToTable("Movimentacao");
                });

            modelBuilder.Entity("AnaliseAcaoIcaros.Models.Papel", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Classe")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("IdCarteira")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Setor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdCarteira");

                    b.ToTable("Papels");
                });

            modelBuilder.Entity("AnaliseAcaoIcaros.Models.Dividendos", b =>
                {
                    b.HasOne("AnaliseAcaoIcaros.Models.Papel", "Papel")
                        .WithMany("Dividendos")
                        .HasForeignKey("IdPapel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Papel");
                });

            modelBuilder.Entity("AnaliseAcaoIcaros.Models.Movimentacao", b =>
                {
                    b.HasOne("AnaliseAcaoIcaros.Models.Papel", "Papel")
                        .WithMany("movimentacoes")
                        .HasForeignKey("IdPapel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Papel");
                });

            modelBuilder.Entity("AnaliseAcaoIcaros.Models.Papel", b =>
                {
                    b.HasOne("AnaliseAcaoIcaros.Models.Carteira", "Carteira")
                        .WithMany("Papels")
                        .HasForeignKey("IdCarteira")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carteira");
                });

            modelBuilder.Entity("AnaliseAcaoIcaros.Models.Carteira", b =>
                {
                    b.Navigation("Papels");
                });

            modelBuilder.Entity("AnaliseAcaoIcaros.Models.Papel", b =>
                {
                    b.Navigation("Dividendos");

                    b.Navigation("movimentacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
