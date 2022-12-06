using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Modelos
{
    public class ContaGanhaJuros : ContaBancaria
    {
        public ContaGanhaJuros(string nome, decimal valorInicial) : base(nome, valorInicial)
        {
        }

        public override void RealizarTransacoesFinalDoMes()
        { 
            if (Saldo < 0)
            {
                decimal juros = -Saldo * 0.07m;
                Depositar(juros, DateTime.Now, "Cobrar juros mensais");
            }
        }
    }
}
