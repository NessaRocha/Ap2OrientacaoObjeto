namespace TrabalhoPooBanco.Domain.Entities;
public class Saque : Transacao
{
    public int IdSaque {get; set;}
    public Cliente Cliente { get; private set; }

    public Saque(decimal valor) : base(valor)
    {
        
    }
    public void DefinirCliente(Cliente cliente)
        {
            Cliente = cliente;
        }

    public override Resultado Executar()
    {
        return Cliente.Conta.Sacar(Valor);
    }
}