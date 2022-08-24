using API_LuisaBot.Interfaces.Repositories;
using API_LuisaBot.Models;
using API_LuisaBot.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace API_LuisaBot.Repositories.ConcreteRepositories
{
    public class SugestaoRepository : BaseRepository<SugestaoModel>, ISugestaoRepository
    {
        public SugestaoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
