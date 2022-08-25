using API_LuisaBot.Interfaces.Repositories;
using API_LuisaBot.Models;
using API_LuisaBot.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API_LuisaBot.Repositories.ConcreteRepositories
{
    public class TemaRepository : BaseRepository<TemaModel>, ITemaRepository
    {
        public TemaRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<TemaModel> GetByName(string name)
        {
            var tema = await _context.Temas.FirstOrDefaultAsync(x => x.Nome == name);
            return tema;
        }
    }
}
