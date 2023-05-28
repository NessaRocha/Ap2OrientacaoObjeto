namespace TrabalhoPooBanco.Domain.Entities;

public class Pessoa
{
    public int Id { get; set;}
    public string Nome { get; protected set; }
    public string CPF { get; protected set; }
    public ESexo Sexo { get; protected set; }


    public Pessoa(int id, string nome, string cpf, ESexo sexo)
    {
        Id = id;
        Nome = nome;
        CPF = cpf;
        Sexo = sexo;
    }

    public virtual void MostrarDados()

    {
        Console.WriteLine($"Id: {Id}");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Cpf: {CPF}");
        Console.WriteLine($"Sexo: {Sexo.ToString()}");
    }
}

public enum ESexo
{
    Masculino = 1,
    Feminino = 2,
}