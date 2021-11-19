using QuitoText_1._0.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuitoText_1._0.REPOSITORIO
{
    public class REPOSITORIOPRODUCTO
    {
        ContextoProducto contexto;
        public REPOSITORIOPRODUCTO()
        {
            this.contexto = new ContextoProducto();
        }
        public List<PRODUCTO> GetPRODUCTOs()
        {
            var consulta = from datos in contexto.PRODUCTOs select datos;
            return consulta.ToList();
        }
        public List<PRODUCTO> BuscarProductos(List<int> id)
        {
            var consulta = from datos in contexto.PRODUCTOs where id.Contains(datos.PRO_ID) select datos;
            return consulta.ToList();
        }
    }
}