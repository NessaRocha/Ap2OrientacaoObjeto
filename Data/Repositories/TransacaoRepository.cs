using Microsoft.EntityFrameworkCore;
using Data.Context;
using TrabalhoPooBanco.Domain.Entities;
using TrabalhoPooBanco.Domain.Interfaces;

namespace TrabalhoPooBanco.Data.Repositories
{
   public class TransacaoRepository : ITransacaoRepository 
    {
        private readonly DataContext context;

        public TransacaoRepository()
        {
        }

        public TransacaoRepository(DataContext context)
        {
            this.context = context;
        }

        public bool Delete(int entityId)
        {
            var transacao = GetById(entityId);
            context.Remove(transacao);
            context.SaveChanges();
            return true;

        }

        public IList<Transacao> GetAll()
        {
            return context.Transacoes.Include(x=>x.Valor).ToList();
        }

        public Transacao GetById(int entityId)
        {
            return context.Transacoes.Include(x=>x.Valor).SingleOrDefault(x=>x.IdTransacao
            == entityId);
        }

        public void Save(Transacao entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Update(Transacao entity)
        {
            context.Transacoes.Update(entity);
            context.SaveChanges();
        }

        internal void Save(Deposito deposito)
        {
            throw new NotImplementedException();
        }
    }
}