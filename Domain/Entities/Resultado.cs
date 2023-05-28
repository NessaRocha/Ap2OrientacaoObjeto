namespace TrabalhoPooBanco.Domain.Entities;

public class Resultado
{
    public int Id { get; set;}
    public required bool Status { get; set; }
    public required string Mensagem { get; set; }

    public static Resultado Falha(string mensagem)
    {
        return new Resultado
        {
            Status = false,
            Mensagem = mensagem
        };
    }

    public static Resultado Sucesso(string mensagem)
    {
        return new Resultado
        {
            Status = true,
            Mensagem = mensagem
        };
    }
}