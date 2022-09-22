using API_LuisaBot.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API_LuisaBot.Repositories.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
 
        }


        public DbSet<SugestaoModel> Sugestoes { get; set; }
        public DbSet<RespostaModel> Respostas { get; set; }
        public DbSet<TemaModel> Temas { get; set; }
        public DbSet<TemaPerguntaModel> TemasPerguntas { get; set; }
        public DbSet<PerguntaModel> Perguntas { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RespostaModel>()
                .HasOne(e => e.Pergunta)
                .WithMany(c => c.Respostas);

            modelBuilder.Entity<TemaPerguntaModel>()
                .HasOne(bc => bc.Tema)
                .WithMany(b => b.TemaPerguntas)
                .HasForeignKey(bc => bc.TemaId);
            modelBuilder.Entity<TemaPerguntaModel>()
                .HasOne(bc => bc.Pergunta)
                .WithMany(c => c.TemaPerguntas)
                .HasForeignKey(bc => bc.PerguntaId);

            modelBuilder.Entity<RespostaModel>()
                   .HasIndex(e => e.Ordem)
                   .IsUnique(true);
            modelBuilder.Entity<RespostaModel>()
                 .HasIndex(e => e.PerguntaId)
                 .IsUnique(false);

            modelBuilder.Entity<TemaModel>()
                 .HasIndex(e => e.Ordem)
                 .IsUnique(true);
            modelBuilder.Entity<PerguntaModel>()
                 .HasIndex(e => e.Ordem)
                 .IsUnique(true);

        }
    }
}
