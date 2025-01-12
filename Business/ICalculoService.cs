using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ICalculoService
    {
        void CalcularFinanceiro(int cliente, string ticker, int qdte);
        void CalcularCustodia(int cliente, string ticker, int qdte);
    }

}
