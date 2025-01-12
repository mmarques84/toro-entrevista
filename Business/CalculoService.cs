using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CalculoService : ICalculoService
    {
        public void CalcularFinanceiro(int cliente, string ticker, int qdte)
        {
            var entidade = new CustodiaRepo().GetById(cliente);
            var ativo = entidade.Custodia.FirstOrDefault(o => o.Ticker == ticker);
            var vlCompra = ativo.CotacaoHoje * qdte;

            entidade.Financeiro -= vlCompra;
        }

        public void CalcularCustodia(int cliente, string ticker, int qdte)
        {
            var entidade = new CustodiaRepo().GetById(cliente);
            var ativo = entidade.Custodia.FirstOrDefault(o => o.Ticker == ticker);
            ativo.Quantidade += qdte;
        }
    }
}
