using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _091_POO_2A_1erParcial_Troncoso_Leandro
{
    class Cliente
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public static bool ExisteLegajo(List<Cliente> listClientes,int legajo)
        {
            return listClientes.Any(c => c.Legajo == legajo);
        }
        public static bool ExisteLegajo(List<Cliente> listClientes,int legajo, int legajoExcepcion)
        {
            return listClientes.Any(c => c.Legajo == legajo && c.Legajo != legajoExcepcion);
        }
        public static bool ExisteNombre(List<Cliente> listClientes, string nombre,string nombreExcepcion = null)
        {
            return listClientes.Any(n => n.Nombre == nombre && n.Nombre != nombreExcepcion);
        }
        public static bool SoloLetras(string nombre)
        {
            foreach(char c in nombre)
            {
                if (Char.IsDigit(c)) return false;
            }
            return true;
        }
    }
}
