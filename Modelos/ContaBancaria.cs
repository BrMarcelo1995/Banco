using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Banco.Modelos
{
    public class ContaBancaria
    {
        private static int numeroContaSemente = 123456789;
        public string Numero { get; }
        public string Titular { get; set; }
        public decimal Saldo
        {
            get
            {

                decimal saldo = 0;

                foreach (var item in TodasTransacoes)
                {
                    saldo += item.Quantia;
                }

                return saldo;
            }
        }

        private List<Transacao> TodasTransacoes = new List<Transacao>();

        public ContaBancaria(string nome, decimal valorInicial)
        {
            Numero = numeroContaSemente.ToString();
            numeroContaSemente++;
            Titular = nome;
            Depositar(valorInicial, DateTime.Now, "valor inicial");
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
            report.Append("Data\t\tQuantidade\tValor\tDescrição\n");

            foreach (var item in TodasTransacoes)
            {
                saldo += item.Quantia;
                report.AppendLine($"{item.Data.ToShortDateString()}\t{item.Quantia}\t{saldo}\t{item.Descricao}");
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
