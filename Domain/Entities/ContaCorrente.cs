
namespace TrabalhoPooBanco.Domain.Entities;

public class ContaCorrente : Conta
{
    public ContaCorrente(string numero, decimal saldo) : base(numero, saldo)
    {
    }

    public ContaCorrente( int id, string numero, decimal saldo) : base( numero, saldo)
    {
        
    }

    
}