using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _091_POO_2A_1erParcial_Troncoso_Leandro
{
    class Cobro : IComparable<Cobro>
    {
        public string Codigo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Importe { get; set; }
        public Cliente Cliente { get; set; }
        public bool Realizado { get; set; }
        public decimal Interes { get; set; }
        public decimal Total { get; set; }
        public virtual decimal CalcularImporteRetraso()
        {
            if (Realizado) return 0;
            if (DateTime.Now > FechaVencimiento)
            {
                decimal importeAdicional = Importe * (decimal)0.1;
                return importeAdicional;
            }
            return 0;
        }
        public static bool CodigoExiste(List<Cobro> cobros, string codigo)
        {
            return cobros.Any(c => c.Codigo == codigo);
        }
        public static List<Cobro> ListarCobrosPagadosGeneral(List<Cobro> cobros)
        {
            return cobros.Where(C => C.Realizado = true && C.Cliente != null).ToList();
        }
        public static List<Cobro> ListarCobrosPendientes(List<Cobro> cobros, Cliente cliente)
        {
            return cobros.Where(c => c.Cliente == cliente && c.Realizado == false).ToList();
        }
        public static List<Cobro> ListarCobrosPagados(List<Cobro> cobros, Cliente cliente)
        {
            return cobros.Where(c => c.Cliente == cliente && c.Realizado == true).ToList();
        }

        public int CompareTo(Cobro other)
        {
            return Total.CompareTo(other.Total);
        }
    }

    class TotalAscendente : IComparer<Cobro>
    {
        public int Compare(Cobro x, Cobro y)
        {
            return x.CompareTo(y);
        }
    }

    class TotalDescendente : IComparer<Cobro>
    {
        public int Compare(Cobro x, Cobro y)
        {
            return y.CompareTo(x);
        }
    }
}
