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
    public class CATEGORIA_PRODUCTOController : Controller
    {
        private testEntities db = new testEntities();

        // GET: CATEGORIA_PRODUCTO
        public ActionResult Index()
        {
            return View(db.CATEGORIA_PRODUCTO.ToList());
        }

        // GET: CATEGORIA_PRODUCTO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIA_PRODUCTO cATEGORIA_PRODUCTO = db.CATEGORIA_PRODUCTO.Find(id);
            if (cATEGORIA_PRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIA_PRODUCTO);
        }

        // GET: CATEGORIA_PRODUCTO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CATEGORIA_PRODUCTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCategoria,NombreCategoria")] CATEGORIA_PRODUCTO cATEGORIA_PRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORIA_PRODUCTO.Add(cATEGORIA_PRODUCTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cATEGORIA_PRODUCTO);
        }

        // GET: CATEGORIA_PRODUCTO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIA_PRODUCTO cATEGORIA_PRODUCTO = db.CATEGORIA_PRODUCTO.Find(id);
            if (cATEGORIA_PRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIA_PRODUCTO);
        }

        // POST: CATEGORIA_PRODUCTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCategoria,NombreCategoria")] CATEGORIA_PRODUCTO cATEGORIA_PRODUCTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEGORIA_PRODUCTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cATEGORIA_PRODUCTO);
        }

        // GET: CATEGORIA_PRODUCTO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORIA_PRODUCTO cATEGORIA_PRODUCTO = db.CATEGORIA_PRODUCTO.Find(id);
            if (cATEGORIA_PRODUCTO == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORIA_PRODUCTO);
        }

        // POST: CATEGORIA_PRODUCTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATEGORIA_PRODUCTO cATEGORIA_PRODUCTO = db.CATEGORIA_PRODUCTO.Find(id);
            db.CATEGORIA_PRODUCTO.Remove(cATEGORIA_PRODUCTO);
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
