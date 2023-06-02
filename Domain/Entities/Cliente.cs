

namespace TrabalhoPooBanco.Domain.Entities
{
    public class Cliente : Pessoa
    {
        public Conta Conta { get; set; }


        public Cliente(int id, string nome, string CPF, ESexo sexo) :
            base(id, nome, CPF, sexo)
        {

        }
        public void DefinirConta(Conta conta)
        {
            Conta = (ContaCorrente)conta;
        }
        public override void MostrarDados()
        {
            base.MostrarDados();
            Conta.MostrarDados();
        }

    }
}