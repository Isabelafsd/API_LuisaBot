using API_LuisaBot.Interfaces.Repositories;
using API_LuisaBot.Models;
using API_LuisaBot.Repositories.Context;

namespace API_LuisaBot.Repositories.ConcreteRepositories
{
    public class PerguntaRepository : BaseRepository<PerguntaModel>, IPerguntaRepositoy
    {
        public PerguntaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
