﻿// <auto-generated />
using System;
using API_LuisaBot.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_LuisaBot.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

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
#pragma warning restore 612, 618
        }
    }
}