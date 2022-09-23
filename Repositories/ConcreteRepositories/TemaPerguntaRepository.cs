using API_LuisaBot.Interfaces.Repositories;
using API_LuisaBot.Models;
using API_LuisaBot.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_LuisaBot.Repositories.ConcreteRepositories
{
    public class TemaPerguntaRepository : BaseRepository<TemaPerguntaModel>, ITemaPerguntaRepository
    {
        public TemaPerguntaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<PerguntaModel>> GetAllPerguntasByTemaId(int temaId) {

            var temasPerguntas = await _context.TemasPerguntas
                  .Include(x=>x.Pergunta)
                  .Where(x => x.TemaId == temaId)
                  .ToListAsync();
            var perguntas = temasPerguntas.Select(x=>x.Pergunta).ToList();
            return perguntas;
        }
    }
}
