﻿// <auto-generated />
using System;
using API_LuisaBot.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API_LuisaBot.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220923194732_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("API_LuisaBot.Models.PerguntaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<int>("Ordem")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("Ordem")
                        .IsUnique();

                    b.ToTable("Perguntas");
                });

            modelBuilder.Entity("API_LuisaBot.Models.RespostaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<bool>("IsImagem")
                        .HasColumnType("boolean");

                    b.Property<int>("Ordem")
                        .HasColumnType("integer");

                    b.Property<int>("PerguntaId")
                        .HasColumnType("integer");

                    b.Property<string>("Referencia")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("Ordem")
                        .IsUnique();

                    b.HasIndex("PerguntaId");

                    b.ToTable("Respostas");
                });

            modelBuilder.Entity("API_LuisaBot.Models.SugestaoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<bool>("IsPergunta")
                        .HasColumnType("boolean");

                    b.Property<string>("Tema")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Sugestoes");
                });

            modelBuilder.Entity("API_LuisaBot.Models.TemaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("Ordem")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("Ordem")
                        .IsUnique();

                    b.ToTable("Temas");
                });

            modelBuilder.Entity("API_LuisaBot.Models.TemaPerguntaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PerguntaId")
                        .HasColumnType("integer");

                    b.Property<int>("TemaId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("PerguntaId");

                    b.HasIndex("TemaId");

                    b.ToTable("TemasPerguntas");
                });

            modelBuilder.Entity("API_LuisaBot.Models.RespostaModel", b =>
                {
                    b.HasOne("API_LuisaBot.Models.PerguntaModel", "Pergunta")
                        .WithMany("Respostas")
                        .HasForeignKey("PerguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pergunta");
                });

            modelBuilder.Entity("API_LuisaBot.Models.TemaPerguntaModel", b =>
                {
                    b.HasOne("API_LuisaBot.Models.PerguntaModel", "Pergunta")
                        .WithMany("TemaPerguntas")
                        .HasForeignKey("PerguntaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_LuisaBot.Models.TemaModel", "Tema")
                        .WithMany("TemaPerguntas")
                        .HasForeignKey("TemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pergunta");

                    b.Navigation("Tema");
                });

            modelBuilder.Entity("API_LuisaBot.Models.PerguntaModel", b =>
                {
                    b.Navigation("Respostas");

                    b.Navigation("TemaPerguntas");
                });

            modelBuilder.Entity("API_LuisaBot.Models.TemaModel", b =>
                {
                    b.Navigation("TemaPerguntas");
                });
#pragma warning restore 612, 618
        }
    }
}