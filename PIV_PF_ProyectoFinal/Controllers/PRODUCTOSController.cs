using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PIV_PF_ProyectoFinal.Controllers
{
    public class PRODUCTOSController : Controller
    {
        private testEntities db = new testEntities();

        // GET: PRODUCTOS
        public ActionResult Index()
        {
            var pRODUCTOS = db.PRODUCTOS.Include(p => p.CATEGORIA_PRODUCTO);
            return View(pRODUCTOS.ToList());
        }

        // GET: PRODUCTOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            if (pRODUCTOS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTOS);
        }

        // GET: PRODUCTOS/Create
        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.CATEGORIA_PRODUCTO, "IdCategoria", "NombreCategoria");
            return View();
        }

        // POST: PRODUCTOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProducto,NombreProducto,DescripcionProducto,Cantidad,Precio,IdCategoria")] PRODUCTOS pRODUCTOS)
        {
            if (ModelState.IsValid)
            {
                pRODUCTOS.Estado = "A";
                db.PRODUCTOS.Add(pRODUCTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(db.CATEGORIA_PRODUCTO, "IdCategoria", "NombreCategoria", pRODUCTOS.IdCategoria);
            return View(pRODUCTOS);
        }

        // GET: PRODUCTOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            if (pRODUCTOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategoria = new SelectList(db.CATEGORIA_PRODUCTO, "IdCategoria", "NombreCategoria", pRODUCTOS.IdCategoria);
            return View(pRODUCTOS);
        }

        // POST: PRODUCTOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProducto,NombreProducto,DescripcionProducto,Cantidad,Precio,IdCategoria")] PRODUCTOS pRODUCTOS)
        {
            if (ModelState.IsValid)
            {
                pRODUCTOS.Estado = "A";
                db.Entry(pRODUCTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoria = new SelectList(db.CATEGORIA_PRODUCTO, "IdCategoria", "NombreCategoria", pRODUCTOS.IdCategoria);
            return View(pRODUCTOS);
        }

        // GET: PRODUCTOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            if (pRODUCTOS == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCTOS);
        }

        // POST: PRODUCTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTOS pRODUCTOS = db.PRODUCTOS.Find(id);
            db.PRODUCTOS.Remove(pRODUCTOS);
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
