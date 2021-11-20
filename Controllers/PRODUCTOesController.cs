using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.WebPages;
using QuitoText_1._0.Datos;
using QuitoText_1._0.REPOSITORIO;

namespace QuitoText_1._0.Controllers
{
    public class PRODUCTOesController : Controller
    {
        REPOSITORIOPRODUCTO repo;
        public PRODUCTOesController()
        {
            repo= new REPOSITORIOPRODUCTO();
        }
        
        private QuitoTexEntities db = new QuitoTexEntities();

        // GET: PRODUCTOes
        public ActionResult Index()
        {
            var pRODUCTO = db.PRODUCTO.Include(p => p.CATEGORIA);
            return View(pRODUCTO.ToList());
        }

        // GET: PRODUCTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // GET: PRODUCTOes/Create
        public ActionResult Create()
        {
            ViewBag.CATE_ID = new SelectList(db.CATEGORIA, "CATE_ID", "CATE_NOMBRE");
            return View();
        }

        // POST: PRODUCTOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]


        public ActionResult Create([Bind(Include = "PRO_ID,CATE_ID,PRO_NOMBRE,PRO_DESCRIPCION,PRO_PRECIO,PRO_STOCK,PRO_IMAGEN,PRO_IMAGEN2,PRO_IMAGEN3,PRO_IMAGEN4,PRO_IMAGEN5")] PRODUCTO pRODUCTO)
        {
            //Desde aqui hice para convertirle a bytes
            HttpPostedFileBase http = Request.Files[0];
            WebImage webimage = new WebImage(http.InputStream);
            pRODUCTO.PRO_IMAGEN = webimage.GetBytes();
            //hasta aqui

            if (ModelState.IsValid)
            {
                db.PRODUCTO.Add(pRODUCTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CATE_ID = new SelectList(db.CATEGORIA, "CATE_ID", "CATE_NOMBRE", pRODUCTO.CATE_ID);
            return View(pRODUCTO);
        }

        // GET: PRODUCTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CATE_ID = new SelectList(db.CATEGORIA, "CATE_ID", "CATE_NOMBRE", pRODUCTO.CATE_ID);
            return View(pRODUCTO);
        }

        // POST: PRODUCTOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRO_ID,CATE_ID,PRO_NOMBRE,PRO_DESCRIPCION,PRO_PRECIO,PRO_STOCK,PRO_IMAGEN,PRO_IMAGEN2,PRO_IMAGEN3,PRO_IMAGEN4,PRO_IMAGEN5")] PRODUCTO pRODUCTO)
        {
            byte[] imagenActual = null;
            HttpPostedFileBase http = Request.Files[0];
            if (http==null)
            {
                imagenActual = db.PRODUCTO.SingleOrDefault(t=>t.PRO_ID ==pRODUCTO.PRO_ID).PRO_IMAGEN;
            }
            else
            {
                WebImage webimage = new WebImage(http.InputStream);
                pRODUCTO.PRO_IMAGEN = webimage.GetBytes();
            }
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CATE_ID = new SelectList(db.CATEGORIA, "CATE_ID", "CATE_NOMBRE", pRODUCTO.CATE_ID);
            return View(pRODUCTO);
        }

        // GET: PRODUCTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTO);
        }

        // POST: PRODUCTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            db.PRODUCTO.Remove(pRODUCTO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult getImage(int id)
        {
            PRODUCTO imagenDB = db.PRODUCTO.Find(id);
            byte[] byteImage = imagenDB.PRO_IMAGEN;

            MemoryStream memorySream = new MemoryStream(byteImage);
            Image imagen = Image.FromStream(memorySream);

            //dar formato
            memorySream = new MemoryStream();
            imagen.Save(memorySream, ImageFormat.Jpeg);
            memorySream.Position = 0;
            return File(memorySream,"image/jpg");
        }
        
        //GET:PRODUCTO
        public ActionResult ListaProductos(int? id)
        {
            if (id != null)
            {
                List<int> codigosProductos;
                if (Session["PRODUCTOes"]==null)
                {
                    codigosProductos = new List<int>();
                }
                else
                {
                    codigosProductos = Session["PRODUCTOes"] as List<int>;
                }
                codigosProductos.Add(id.Value);
                Session["PRODUCTOes"] = codigosProductos;                
            }
            ViewBag.Carrito = Session["PRODUCTOes"];
            List<PRODUCTO> prod = this.repo.GetPRODUCTOs();
            return View(prod);
        }

     
        public ActionResult ProductosCarrito(int? id)
        {
            if (id != null)
            {
                if (Session["PRODUCTOes"] != null)
				{
                    List<int> lista = (List<int>)Session["PRODUCTOes"];
                    lista.Remove(id.GetValueOrDefault());
                    if (lista.Count() == 0)
                    {
                        Session["PRODUCTOes"] = null;
                    }
                    else
                    {
                        Session["PRODUCTOes"] = lista;
                    }
                }
            }
            if (Session["PRODUCTOes"] == null)
            {
                return View();
            }
            else
            {
                List<int> lista = (List<int>)Session["PRODUCTOes"];
                List<PRODUCTO> prod = this.repo.BuscarProductos(lista);
                return View(prod);
            }

            //segundas funciones


            
        }
    }
}
