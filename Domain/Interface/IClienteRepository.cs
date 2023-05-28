using TrabalhoPooBanco.Domain.Entities;
using TrabalhoPooBanco.Domain.Interface;

namespace TrabalhoPooBanco.Domain.Interfaces;

public interface IClienteRepository : IBaseRepository<Cliente> 
{
  IEnumerable<Cliente> Listar();
       
}