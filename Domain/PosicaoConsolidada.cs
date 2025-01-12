using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PosicaoConsolidada
    {
        public int Id { get; set; }
        public decimal Financeiro { get; set; }
        public IEnumerable<Custodia> Custodia { get; set; }
    }
}
