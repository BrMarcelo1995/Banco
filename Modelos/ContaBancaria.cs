using System.Text;
namespace Banco.Modelos
{
    public class ContaBancaria
    {
        private static int numeroContaSemente = 1000;
        public string Numero { get; }
        public string Titular { get; set; }
        public decimal Saldo
        {
            get
            {

                decimal saldo = 0;

                foreach (var item in TodasTransacoes)
                {
                    saldo += item.valor;
                }

                return saldo;
            }
        }

        private List<Transacao> TodasTransacoes = new List<Transacao>();

        public ContaBancaria() { }

        public ContaBancaria(string nomeTitular, decimal valorInicial)
        {
            numeroContaSemente++;
            Numero = numeroContaSemente.ToString();
            Titular = nomeTitular;
            Depositar(valorInicial, DateTime.Now, "Deposito de Abertura de Conta");
        }

        public void Depositar(decimal quantia, DateTime data, string descricao)
        {
            if (quantia <= 0)
            {
                throw new ArgumentException(nameof(quantia), "o valor do deposito deve ser positivo");
            }

            var deposito = new Transacao(quantia, data, descricao);
            TodasTransacoes.Add(deposito);
        }

        public void Sacar(decimal quantia, DateTime data, string descricao)
        {
            if (quantia <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantia), "O valor para sacar deve ser positivo");
            }
            if (Saldo - quantia < 0)
            {
                throw new InvalidOperationException("Você não possui saldo suficiente para essa retiada ");
            }

            var saque = new Transacao(-quantia, data, descricao);
            TodasTransacoes.Add(saque);
        }

        public string GetHistorico()
        {
            var report = new StringBuilder();

            decimal saldo = 0;
            report.Append("Tipo\t\t\t\t\tData\t\tTransacao\tSaldo Disponível\tDescrição\n");

            foreach (var item in TodasTransacoes)
            {
                saldo += item.valor;
                report.AppendLine($"{this.GetType().Name}\t\t\t\t{item.Data.ToShortDateString()}\t{item.valor}\t\t{saldo}\t\t\t{item.Descricao}");
            }

            return report.ToString();

        }
        public virtual void RealizarTransacoesFinalDoMes()
        {
            if (Saldo > 500m)
            {
                decimal juros = Saldo * 0.05m;
                Depositar(juros, DateTime.Now, "Aplicar juros mensais");
            }
        }
    }
}
