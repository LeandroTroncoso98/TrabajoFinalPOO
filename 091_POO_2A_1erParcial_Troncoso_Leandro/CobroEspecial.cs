using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _091_POO_2A_1erParcial_Troncoso_Leandro
{
    class CobroEspecial : Cobro
    {
        public override decimal CalcularImporteRetraso()
        {
            if (Realizado) return 0;
            if (DateTime.Now > FechaVencimiento)
            {
                decimal importeAdicional = Importe * (decimal)0.2;
                return importeAdicional;
            }
            return 0;
        }
    }
}
