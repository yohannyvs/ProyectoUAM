using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PIV_PF_ProyectoFinal;

namespace PIV_PF_ProyectoFinal.Controllers
{
    public class MetodosPagoController : Controller
    {
        private testEntities db = new testEntities();

        // GET: MetodosPago
        public ActionResult Index()
        {
            return View(db.METODOS_PAGO.ToList());
        }

        // GET: MetodosPago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            METODOS_PAGO mETODOS_PAGO = db.METODOS_PAGO.Find(id);
            if (mETODOS_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(mETODOS_PAGO);
        }

        // GET: MetodosPago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MetodosPago/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMetodoPago,metodoPago")] METODOS_PAGO mETODOS_PAGO)
        {
            if (ModelState.IsValid)
            {
                db.METODOS_PAGO.Add(mETODOS_PAGO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mETODOS_PAGO);
        }

        // GET: MetodosPago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            METODOS_PAGO mETODOS_PAGO = db.METODOS_PAGO.Find(id);
            if (mETODOS_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(mETODOS_PAGO);
        }

        // POST: MetodosPago/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMetodoPago,metodoPago")] METODOS_PAGO mETODOS_PAGO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mETODOS_PAGO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mETODOS_PAGO);
        }

        // GET: MetodosPago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            METODOS_PAGO mETODOS_PAGO = db.METODOS_PAGO.Find(id);
            if (mETODOS_PAGO == null)
            {
                return HttpNotFound();
            }
            return View(mETODOS_PAGO);
        }

        // POST: MetodosPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            METODOS_PAGO mETODOS_PAGO = db.METODOS_PAGO.Find(id);
            db.METODOS_PAGO.Remove(mETODOS_PAGO);
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
