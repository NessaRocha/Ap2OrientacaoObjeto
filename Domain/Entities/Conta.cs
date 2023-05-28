using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TrabalhoPooBanco.Domain.Entities
{

    public class Conta 
    {
        [Key]
        public int Id {get; set;}
        public string Numero { get;  set; }
        public decimal Saldo { get;  set; }


        public Conta(int id, string numero, decimal saldo)
        {
            Id = id;
            Numero = numero;
            Saldo = saldo;
        }

        public Conta(string numero, decimal saldo)
        {
            Numero = numero;
            Saldo = saldo;
        }

        [ForeignKey("Cliente")]
        public int ClienteId {get;set;}
        public Cliente Cliente {get; set;}
    
        public void MostrarDados()
        {
            Console.WriteLine($"Numero da conta: {Numero}");
            Console.WriteLine($"Saldo: {Saldo}");
        }

        public Resultado Depositar(decimal valor)
        {
            if (valor < 0)
            {
                return Resultado.Falha("Não é possível realizar um depósito com valor negativo!");
            }

            Saldo = Saldo + valor;

            return Resultado.Sucesso("Deposito realizado com sucesso!");
        }
        public Resultado Transferir(decimal valor, Conta alvo)
        {
            if ((Saldo - valor) < 0)
            {
                return Resultado.Falha("Não é possível realizar uma transferência com valor negativo!");
            }

            if (Saldo < valor)
            {
                return Resultado.Falha("Não há saldo na conta para efetuar essa transferência!");
            }

            Saldo = Saldo - valor;

            var resultadoDeposito = alvo.Depositar(valor);
            if (resultadoDeposito.Status)
            {
                return Resultado.Sucesso("Transferência realizada com sucesso!");
            }
            else
            {
                return resultadoDeposito;
            }
        }

        public Resultado Sacar(decimal valor)
        {
            if (valor < 0)
            {
                return Resultado.Falha("Não é possível realizar um saque com valor negativo!");
            }

            if (Saldo < valor)
            {
                return Resultado.Falha("Não há saldo suficiente na conta!");
            }

            Saldo = Saldo - valor;
            return Resultado.Sucesso("Saque efetuado com sucesso!");
        }
    }
}
