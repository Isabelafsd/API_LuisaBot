using API_LuisaBot.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace API_LuisaBot.Interfaces.Repositories
{
    public interface ITemaPerguntaRepository : IBaseRepository<TemaPerguntaModel>
    {
        Task<List<PerguntaModel>> GetAllPerguntasByTemaId(int temaId);
    }
}
