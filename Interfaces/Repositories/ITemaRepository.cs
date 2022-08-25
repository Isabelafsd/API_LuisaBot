using API_LuisaBot.Models;
using System.Threading.Tasks;

namespace API_LuisaBot.Interfaces.Repositories
{
    public interface ITemaRepository : IBaseRepository<TemaModel>
    {
        Task<TemaModel> GetByName(string name);
    }
}
