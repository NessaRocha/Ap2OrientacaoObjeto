using Microsoft.EntityFrameworkCore;
using Data.Context;
using TrabalhoPooBanco.Domain.Entities;
using TrabalhoPooBanco.Domain.Interfaces;


namespace TrabalhoPooBanco.Data.Repositories
{
   public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext context;
        public ClienteRepository(DataContext context)
        {
            this.context = context;
        }

        public bool Delete(int entityId)
        {
            var cliente = GetById(entityId);
            context.Remove(cliente);
            context.SaveChanges();
            return true;

        }

        public IList<Cliente> GetAll()
        {
            return context.Clientes.Include(x=>x.CPF).ToList();
        }

        public Cliente GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Save(Cliente entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Update(Cliente entity)
        {
            context.Clientes.Update(entity);
            context.SaveChanges();
        }

        
    }
}