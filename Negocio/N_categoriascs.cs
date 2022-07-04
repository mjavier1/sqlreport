using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades;

namespace Negocio
{
    public  class N_categoriascs
    {
        public static DataTable Listar_ca(String cTexto)
        {
            D_categorias Datos = new D_categorias();
            return Datos.Listar_ca(cTexto);



        }
        public static string Guardar_ca (int Opcion, E_categorias oca)
        {
            D_categorias Datos = new D_categorias();
            return Datos.Guardar_ca(Opcion, oca);
            //drop_ca
        }
        public static string drop_ca(int Codigo)
        {
            D_categorias Datos = new D_categorias();

            return Datos.drop_ca(Codigo);
            //drop_ca
        }

    }
}
