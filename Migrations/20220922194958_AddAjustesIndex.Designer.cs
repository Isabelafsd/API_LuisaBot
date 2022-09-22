﻿// <auto-generated />
using System;
using API_LuisaBot.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_LuisaBot.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220922194958_AddAjustesIndex")]
    partial class AddAjustesIndex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("API_LuisaBot.Models.PerguntaModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<int>("Ordem")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Ordem")
                        .IsUnique();

                    b.ToTable("Perguntas");
                });

            modelBuilder.Entity("API_LuisaBot.Models.RespostaModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsImagem")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ordem")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("PerguntaId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Referencia")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Ordem")
                        .IsUnique();

                    b.HasIndex("PerguntaId");

                    b.ToTable("Respostas");
                });

            modelBuilder.Entity("API_LuisaBot.Models.SugestaoModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPergunta")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tema")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sugestoes");
                });

            modelBuilder.Entity("API_LuisaBot.Models.TemaModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("Ordem")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Ordem")
                        .IsUnique();

                    b.ToTable("Temas");
                });

            modelBuilder.Entity("API_LuisaBot.Models.TemaPerguntaModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PerguntaId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TemaId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

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