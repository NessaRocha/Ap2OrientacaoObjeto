namespace TrabalhoPooBanco.Domain.Entities;

public abstract class Transacao
{
    public decimal Valor { get; protected set; }
    public int Id { get; internal set; }

    public Transacao(decimal valor)
    {
       
    }

    public abstract Resultado Executar();
}

