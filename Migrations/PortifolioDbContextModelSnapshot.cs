﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using portifolioInvestimento.Configuration;

#nullable disable

namespace portifolioInvestimento.Migrations
{
    [DbContext(typeof(PortifolioDbContext))]
    partial class PortifolioDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("portifolioInvestimento.Models.Investimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoRisco")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidadeProduto")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("investimentos");
                });

            modelBuilder.Entity("portifolioInvestimento.Models.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataTransacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("InvestimentoId")
                        .HasColumnType("int");

                    b.Property<string>("NomeInvestimento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoTransacao")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorTransacao")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("transacao");
                });

            modelBuilder.Entity("portifolioInvestimento.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
