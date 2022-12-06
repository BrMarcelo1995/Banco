using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Modelos
{
    public class ContaCartaoPresente : ContaBancaria
    {
        private readonly decimal _depositoMensal = 0m;
        public ContaCartaoPresente(string nome, decimal valorInicial, decimal depositoMensal = 0) : base(nome, valorInicial) => _depositoMensal = valorInicial;


        public override void RealizarTransacoesFinalDoMes()
        {
            if (_depositoMensal != 0)
            {
                Depositar(_depositoMensal, DateTime.Now, "adicionando deposito mensal");
            }
        }
    }
}
