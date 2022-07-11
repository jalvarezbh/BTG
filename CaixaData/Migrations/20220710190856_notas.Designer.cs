﻿// <auto-generated />
using System;
using CaixaData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CaixaData.Migrations
{
    [DbContext(typeof(CaixaContext))]
    [Migration("20220710190856_notas")]
    partial class notas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CaixaDomain.Models.Notas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime")
                        .HasColumnName("DataAtualizacao");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.ToTable("Notas");
                });

            modelBuilder.Entity("CaixaDomain.Models.Saques", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime")
                        .HasColumnName("Data");

                    b.Property<int>("QuantidadeNotas")
                        .HasColumnType("int")
                        .HasColumnName("QuantidadeNotas");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.ToTable("Saques");
                });
#pragma warning restore 612, 618
        }
    }
}