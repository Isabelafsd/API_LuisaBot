using API_LuisaBot.Interfaces.Repositories;
using API_LuisaBot.Models;
using API_LuisaBot.Repositories.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace API_LuisaBot.Repositories.ConcreteRepositories
{
    public class RespostaRepository : BaseRepository<RespostaModel>, IRespostaRepository
    {
        public RespostaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<RespostaModel>> GetAllRespostasByPergunta(int perguntaId)
        {

            var respostas = await _context.Respostas
                  .Where(x => x.PerguntaId == perguntaId)
                  .ToListAsync();
            return respostas;
        }
    }
}
