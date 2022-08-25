using API_LuisaBot.Interfaces.Repositories;
using API_LuisaBot.Models;
using API_LuisaBot.Repositories.Context;

namespace API_LuisaBot.Repositories.ConcreteRepositories
{
    public class RespostaRepository : BaseRepository<RespostaModel>, IRespostaRepository
    {
        public RespostaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
