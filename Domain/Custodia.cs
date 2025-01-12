using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Custodia
    {
        public string Ticker { get; set; }
        public int Quantidade { get; set; }
        public decimal CotacaoHoje { get; set; }
    }
}
