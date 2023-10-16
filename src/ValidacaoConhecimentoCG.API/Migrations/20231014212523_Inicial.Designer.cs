﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ValidacaoConhecimentoCG.API.Infrastructure.Data.Context;

#nullable disable

namespace ValidacaoConhecimentoCG.API.Migrations
{
    [DbContext(typeof(ValidacaoConhecimentoDBContext))]
    [Migration("20231014212523_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ValidacaoConhecimentoCG.API.Domain.Entidades.Conta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(99);

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(98);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Conta", "Sistema");
                });
#pragma warning restore 612, 618
        }
    }
}
