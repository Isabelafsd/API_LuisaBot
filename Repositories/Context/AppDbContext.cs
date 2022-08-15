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


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        }
    }
}
