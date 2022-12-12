using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Modelos
{
    public static class ContaService
    {
        public static ContaBancaria? BuscarConta(List<ContaBancaria> listaContas, string numero)
        {

            foreach (var conta in listaContas)
            {
                if (conta.Numero == numero)
                {
                    return conta;
                }
            }

            return null;
        }

        public static void ListarContas(List<ContaBancaria> Contas)
        {
            foreach (var conta in Contas)
            {
                Console.WriteLine(conta);
            }
        }

        public static void ListarHistorico(List<ContaBancaria> Contas, string NumeroDaConta = "")
        {
            if (NumeroDaConta != "")
            {
                Console.WriteLine(BuscarConta(Contas, NumeroDaConta).GetHistorico());
            }
            else
            {
                foreach (var conta in Contas)
                {
                    Console.WriteLine(conta.GetHistorico());
                }
            }


        }
    }
}
