using API_LuisaBot.Models;

namespace API_LuisaBot.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        public ISugestaoRepository Sugestoes { get; }
        public ITemaRepository Temas { get; }
        public IPerguntaRepositoy Perguntas { get; }
        public ITemaPerguntaRepository TemasPerguntas { get; }
        public IRespostaRepository Respostas { get; }
        void Commit();
    }
}
