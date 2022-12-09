using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class Transacao
    {
        public decimal valor { get; }
        public DateTime Data { get; }
        public string Descricao { get; }

        public Transacao(decimal valor, DateTime data, string descricao)
        {
            this.valor = valor;
            Data = data;
            Descricao = descricao;
        }
    }
}
