using static System.Console;
using TrabalhoPooBanco.Domain.Entities;
using TrabalhoPooBanco.Data.Repositories;

class Program
{
    static void Main()
    {
        var clienteRepository = new ClienteRepository();
        var transacaoRepository = new TransacaoRepository();

        do
        {
            WriteLine("--- Escolha a operação que deseja realizar");
            WriteLine("------- 1 - Criar uma conta");
            WriteLine("------- 2 - Listar clientes");
            WriteLine("------- 3 - Realizar uma transferência");
            WriteLine("------- 4 - Realizar um saque");
            WriteLine("------- 5 - Realizar um depósito");
            WriteLine("------- 6 - Sair");

            var input = ReadLine();
            if (!int.TryParse(input, out var escolha))
            {
                WriteLine("Você não informou uma opção correta!");
                continue;
            }

            if (escolha == 1)
            {
                // Criar conta
                WriteLine("Certo, vamos criar a sua conta!!");
                WriteLine("Informe o seu nome:");
                var nome = ReadLine();

                WriteLine("Informe o seu CPF:");
                var cpf = ReadLine();

                WriteLine("Informe o seu sexo:");
                WriteLine("-- 1 para masculino");
                WriteLine("-- 2 para feminino");
                var sexoInput = ReadLine();

                var conta = new ContaCorrente(Random.Shared.NextInt64(2000).ToString(), 0);
                var cliente = new Cliente(nome, cpf, Enum.Parse<ESexo>(sexoInput), conta);

                clienteRepository.Salvar(cliente);

                cliente.MostrarDados();
            }
            else if (escolha == 2)
            {
                var clientes = clienteRepository.Listar();
                foreach (var cliente in clientes)
                {
                    cliente.MostrarDados();
                    WriteLine();
                }
            }
            else if (escolha == 3)
            {
                // Realizar transferência
            }
            else if (escolha == 4)
            {
                // Realizar saque
            }
            else if (escolha == 5)
            {
                WriteLine("Informe o número da conta que deseja fazer o depósito:");
                var numeroConta = ReadLine();

                var cliente = clienteRepository.ObterClientePeloNumeroConta(numeroConta);
                if (cliente == null)
                {
                    WriteLine("Conta não existente!");
                    continue;
                }

                WriteLine("Informe o valor que deseja depositar na conta:");
                var valorInput = ReadLine();
                // Validar se realmente é um decimal
                if (!decimal.TryParse(valorInput, out var valor))
                {
                    WriteLine("Valor inválido!");
                    continue;
                }

                var deposito = new Deposito(cliente, valor);
                var resultado = deposito.Executar();

                transacaoRepository.Salvar(deposito);

                WriteLine(resultado.Mensagem);
            }
            else if (escolha == 6)
            {
                break;
            }
            else
            {
                WriteLine("Você não informou uma opção correta!");
                continue;
            }

        } while (true);
    }
}
