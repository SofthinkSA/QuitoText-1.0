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
            var consulta = from Datos in contexto.PRODUCTOes select Datos;
            return consulta.ToList();
        }
        public List<PRODUCTO> BuscarProductos(List<int> id)
        {
            var consulta = from Datos in contexto.PRODUCTOes where id.Contains(Datos.PRO_ID) select Datos;
            return consulta.ToList();
        }
    }
}