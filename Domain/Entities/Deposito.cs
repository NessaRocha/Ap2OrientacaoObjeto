namespace TrabalhoPooBanco.Domain.Entities
{
    public class Deposito : Transacao
    {
        public int IdDeposito { get; set; }
        public Cliente Cliente { get; private set; }
        public ContaCorrente ContaCorrente { get; set; }

        // Remova o parâmetro 'Cliente' do construtor
        public Deposito(decimal valor) : base(valor)
        {
        }
        public void DefinirCliente(Cliente cliente)
        {
            Cliente = cliente;
        }
        // Adicione um método para atribuir o valor da propriedade 'Cliente'
    
        public override Resultado Executar()
        {
            return Cliente.Conta.Depositar(Valor);
        }
    }
}


