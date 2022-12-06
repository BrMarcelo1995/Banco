using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class Transacao
    {
        public decimal Quantia { get; }
        public DateTime Data { get; }
        public string Descricao { get; }

        public Transacao(decimal quantia, DateTime data, string descricao)
        {
            Quantia = quantia;
            Data = data;
            Descricao = descricao;
        }
    }
}
