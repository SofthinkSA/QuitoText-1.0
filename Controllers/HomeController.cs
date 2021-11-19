using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuitoText_1._0.Datos;


namespace QuitoText_1._0.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /*[HttpGet]
        public JsonResult ListarProducto()
        {
            List<PRODUCTO> oLista = new List<Producto>();

            oLista = ProductoLogica.Instancia.Listar();
            oLista = (from o in oLista
                      select new Producto()
                      {
                          IdProducto = o.IdProducto,
                          Nombre = o.Nombre,
                          Descripcion = o.Descripcion,
                          oMarca = o.oMarca,
                          oCategoria = o.oCategoria,
                          Precio = o.Precio,
                          Stock = o.Stock,
                          RutaImagen = o.RutaImagen,
                          base64 = utilidades.convertirBase64(Server.MapPath(o.RutaImagen)),
                          extension = Path.GetExtension(o.RutaImagen).Replace(".", ""),
                          Activo = o.Activo
                      }).ToList();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }*/
    }
}