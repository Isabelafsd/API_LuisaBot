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
        public DbSet<SugestaoModel> Sugestoes { get; set; }
        public DbSet<RespostaModel> Respostas { get; set; }
        public DbSet<TemaModel> Temas { get; set; }
        public DbSet<TemaPerguntaModel> TemasPerguntas { get; set; }
        public DbSet<PerguntaModel> Perguntas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        }

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
        }
    }
}
