using API_LuisaBot.Models;

namespace API_LuisaBot.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        public ISugestaoRepository Sugestoes { get; }

        void Commit();
    }
}
