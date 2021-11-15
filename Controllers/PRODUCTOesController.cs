using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.WebPages;
using QuitoText_1._0.Datos;

namespace QuitoText_1._0.Controllers
{
    public class PRODUCTOesController : Controller
    {
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
    }
}
