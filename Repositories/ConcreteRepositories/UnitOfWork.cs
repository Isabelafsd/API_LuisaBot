using API_LuisaBot.Interfaces.Repositories;
using API_LuisaBot.Models;
using API_LuisaBot.Repositories.Context;
using System;

namespace API_LuisaBot.Repositories.ConcreteRepositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public ISugestaoRepository Sugestoes { get; set;}
        private AppDbContext _contexto = null;
        private bool disposed = false;

        public UnitOfWork(AppDbContext context)
        {
            _contexto = context;
            Sugestoes = new SugestaoRepository(_contexto);
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
