using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TrabalhoPooBanco.Domain.Entities;

public abstract class Transacao
{
    public decimal Valor { get; protected set; }
    [Key]
    public int  IdTransacao { get; set; }

    public Transacao(decimal valor)
    {
       
    }

    public abstract Resultado Executar();
}

