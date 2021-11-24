using QuitoText_1._0.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuitoText_1._0.REPOSITORIO
{
    public class REPOSITORIOPRODUCTO
    {
        ContextoProducto contexto;
        private QuitoTexEntities db = new QuitoTexEntities();
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
            /*if (cadena!="")
            {
                BuscarProductos = db.buscarPedidos(cadena);
            }*/
            return consulta.ToList();
        }
        /*public List<PRODUCTO> BuscarProductos(string cadena)
        {
            List<PRODUCTO> pRODUCTOs = new List<PRODUCTO>();
            try
            {
                o
            }
        }*/
    }
}