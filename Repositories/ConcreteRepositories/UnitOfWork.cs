using API_LuisaBot.Interfaces.Repositories;
using API_LuisaBot.Models;
using API_LuisaBot.Repositories.Context;
using System;

namespace API_LuisaBot.Repositories.ConcreteRepositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private AppDbContext _contexto = null;
        private bool disposed = false;

        #region repositories
        public ISugestaoRepository Sugestoes { get; set; }
        public ITemaRepository Temas { get; set; }
        public IPerguntaRepositoy Perguntas { get; set; }
        public ITemaPerguntaRepository TemasPerguntas { get; set; }
        public IRespostaRepository Respostas { get; set; }

        #endregion

        public UnitOfWork(AppDbContext context)
        {
            _contexto = context;
            Sugestoes = new SugestaoRepository(_contexto);
            Temas = new TemaRepository(_contexto);
            Perguntas = new PerguntaRepository(_contexto);
            TemasPerguntas = new TemaPerguntaRepository(_contexto);
            Respostas = new RespostaRepository(_contexto);
        }
        public void Commit()
        {
            _contexto.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _contexto.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
