namespace TrabalhoPooBanco.Domain.Entities;

public class Transferencia : Transacao
{
    public int IdTransferencia {get; set;}
    public Cliente De { get; private set; }
    public Cliente Para { get; private set; }

    public Transferencia(decimal valor) : base(valor)
    {
      
    }
    
    public override Resultado Executar()
    {
        return De.Conta.Transferir(Valor, Para.Conta);
    }
}