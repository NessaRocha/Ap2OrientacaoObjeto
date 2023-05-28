
namespace TrabalhoPooBanco.Domain.Entities;

public class ContaCorrente : Conta
{
   
   
    public ContaCorrente( int id, string numero, decimal saldo) : base( numero, saldo)
    {
        
    }

    
}