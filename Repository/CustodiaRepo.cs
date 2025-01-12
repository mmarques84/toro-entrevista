using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustodiaRepo
    {
        List<PosicaoConsolidada> repo = new List<PosicaoConsolidada>
            {
                new PosicaoConsolidada
            {
                Financeiro = 1000,
                Id = 1,
                Custodia = new List<Custodia>
                 {
                     new Custodia
                     {
                         Ticker = "VALE3",
                         Quantidade = 1,
                         CotacaoHoje = 10m,
                     },
                     new Custodia
                     {
                         Ticker = "PETR3",
                         Quantidade = 2,
                         CotacaoHoje = 20m,
                     }
                 }
            }};

        public PosicaoConsolidada GetById(int id)
        {
            return repo.FirstOrDefault(o => o.Id == id);
        }
    }
}
