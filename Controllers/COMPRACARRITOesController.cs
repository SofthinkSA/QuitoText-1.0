using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuitoText_1._0.Datos;

namespace QuitoText_1._0.Controllers
{
    public class COMPRACARRITOesController : Controller
    {
        private QuitoTexEntities db = new QuitoTexEntities();

        // GET: COMPRACARRITOes
        public ActionResult Index()
        {
            var cOMPRACARRITO = db.COMPRACARRITO.Include(c => c.AspNetUsers).Include(c => c.PRODUCTO).Include(c => c.ESTADOS);
            return View(cOMPRACARRITO.ToList());
        }

        // GET: COMPRACARRITOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPRACARRITO cOMPRACARRITO = db.COMPRACARRITO.Find(id);
            if (cOMPRACARRITO == null)
            {
                return HttpNotFound();
            }
            return View(cOMPRACARRITO);
        }

        // GET: COMPRACARRITOes/Create
        public ActionResult Create()
        {
            ViewBag.User_Id = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Prod_id = new SelectList(db.PRODUCTO, "PRO_ID", "PRO_NOMBRE");
            ViewBag.State_Compra = new SelectList(db.ESTADOS, "Id_state", "Nombre_state");
            return View();
        }

        // POST: COMPRACARRITOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Compra_ID,User_Id,Prod_id,FechaCompra,State_Compra")] COMPRACARRITO cOMPRACARRITO)
        {
            if (ModelState.IsValid)
            {
                db.COMPRACARRITO.Add(cOMPRACARRITO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_Id = new SelectList(db.AspNetUsers, "Id", "Email", cOMPRACARRITO.User_Id);
            ViewBag.Prod_id = new SelectList(db.PRODUCTO, "PRO_ID", "PRO_NOMBRE", cOMPRACARRITO.Prod_id);
            ViewBag.State_Compra = new SelectList(db.ESTADOS, "Id_state", "Nombre_state", cOMPRACARRITO.State_Compra);
            return View(cOMPRACARRITO);
        }

        // GET: COMPRACARRITOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPRACARRITO cOMPRACARRITO = db.COMPRACARRITO.Find(id);
            if (cOMPRACARRITO == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_Id = new SelectList(db.AspNetUsers, "Id", "Email", cOMPRACARRITO.User_Id);
            ViewBag.Prod_id = new SelectList(db.PRODUCTO, "PRO_ID", "PRO_NOMBRE", cOMPRACARRITO.Prod_id);
            ViewBag.State_Compra = new SelectList(db.ESTADOS, "Id_state", "Nombre_state", cOMPRACARRITO.State_Compra);
            return View(cOMPRACARRITO);
        }

        // POST: COMPRACARRITOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Compra_ID,User_Id,Prod_id,FechaCompra,State_Compra")] COMPRACARRITO cOMPRACARRITO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMPRACARRITO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_Id = new SelectList(db.AspNetUsers, "Id", "Email", cOMPRACARRITO.User_Id);
            ViewBag.Prod_id = new SelectList(db.PRODUCTO, "PRO_ID", "PRO_NOMBRE", cOMPRACARRITO.Prod_id);
            ViewBag.State_Compra = new SelectList(db.ESTADOS, "Id_state", "Nombre_state", cOMPRACARRITO.State_Compra);
            return View(cOMPRACARRITO);
        }

        // GET: COMPRACARRITOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMPRACARRITO cOMPRACARRITO = db.COMPRACARRITO.Find(id);
            if (cOMPRACARRITO == null)
            {
                return HttpNotFound();
            }
            return View(cOMPRACARRITO);
        }

        // POST: COMPRACARRITOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COMPRACARRITO cOMPRACARRITO = db.COMPRACARRITO.Find(id);
            db.COMPRACARRITO.Remove(cOMPRACARRITO);
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
