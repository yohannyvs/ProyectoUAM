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
    public class FacturasController : Controller
    {
        private testEntities db = new testEntities();

        public ActionResult Create()
        {
            var fACTURAS = new FACTURAS
            {
                fecha = DateTime.Now,
            };

            ViewBag.FechaActual = fACTURAS.fecha.ToString("yyyy-MM-dd");
            ViewBag.idCliente = new SelectList(db.CLIENTES, "IdCliente", "NombreCliente");
            ViewBag.idMetodoPago = new SelectList(db.METODOS_PAGO, "idMetodoPago", "metodoPago");
            ViewBag.ProductosDisponibles = db.PRODUCTOS.ToList();
            return View(fACTURAS);
        }


        // POST: Facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFactura,fecha,idCliente,idMetodoPago,impuesto,subtotal,total,idProducto")] FACTURAS fACTURAS)
        {
            if (ModelState.IsValid)
            {
                db.FACTURAS.Add(fACTURAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCliente = new SelectList(db.CLIENTES, "IdCliente", "NombreCliente", fACTURAS.idCliente);
            ViewBag.idMetodoPago = new SelectList(db.METODOS_PAGO, "idMetodoPago", "metodoPago", fACTURAS.idMetodoPago);
            ViewBag.idProducto = new SelectList(db.PRODUCTOS, "IdProducto", "NombreProducto", fACTURAS.idProducto);
            ViewBag.ProductosDisponibles = db.PRODUCTOS.ToList();

            return View(fACTURAS);
        }        
    }
}

/* 
    // GET: Facturas
    public ActionResult Index()
    {
        var fACTURAS = db.FACTURAS.Include(f => f.CLIENTES);
        return View(fACTURAS);
    }


   // GET: Facturas/Details/5
    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        FACTURAS fACTURAS = db.FACTURAS.Find(id);
        if (fACTURAS == null)
        {
            return HttpNotFound();
        }
        return View(fACTURAS);
    }

    // GET: Facturas/Create
    public ActionResult Create()
    {
        var fACTURAS = new FACTURAS
        {
            fecha = DateTime.Now
        };

        ViewBag.FechaActual = fACTURAS.fecha.ToString("yyyy-MM-dd");

        ViewBag.idCliente = new SelectList(db.CLIENTES, "IdCliente", "NombreCliente");
        ViewBag.idMetodoPago = new SelectList(db.METODOS_PAGO, "idMetodoPago", "metodoPago");
        ViewBag.idProducto = new SelectList(db.PRODUCTOS, "IdProducto", "NombreProducto");

        return View(fACTURAS);
    }

    // POST: Facturas/Create
    // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
    // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "idFactura,fecha,idCliente,idMetodoPago,impuesto,subtotal,total,idProducto")] FACTURAS fACTURAS)
    {
        if (ModelState.IsValid)
        {
            db.FACTURAS.Add(fACTURAS);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.idCliente = new SelectList(db.CLIENTES, "IdCliente", "NombreCliente", fACTURAS.idCliente);
        ViewBag.idMetodoPago = new SelectList(db.METODOS_PAGO, "idMetodoPago", "metodoPago", fACTURAS.idMetodoPago);
        ViewBag.idProducto = new SelectList(db.PRODUCTOS, "IdProducto", "NombreProducto", fACTURAS.idProducto);
        return View(fACTURAS);
    }

    // GET: Facturas/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        FACTURAS fACTURAS = db.FACTURAS.Find(id);
        if (fACTURAS == null)
        {
            return HttpNotFound();
        }
        ViewBag.idCliente = new SelectList(db.CLIENTES, "IdCliente", "NombreCliente", fACTURAS.idCliente);
        ViewBag.idMetodoPago = new SelectList(db.METODOS_PAGO, "idMetodoPago", "metodoPago", fACTURAS.idMetodoPago);
        ViewBag.idProducto = new SelectList(db.PRODUCTOS, "IdProducto", "NombreProducto", fACTURAS.idProducto);
        return View(fACTURAS);
    }

    // POST: Facturas/Edit/5
    // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
    // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "idFactura,fecha,idCliente,idMetodoPago,impuesto,subtotal,total,idProducto")] FACTURAS fACTURAS)
    {
        if (ModelState.IsValid)
        {
            db.Entry(fACTURAS).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.idCliente = new SelectList(db.CLIENTES, "IdCliente", "NombreCliente", fACTURAS.idCliente);
        ViewBag.idMetodoPago = new SelectList(db.METODOS_PAGO, "idMetodoPago", "metodoPago", fACTURAS.idMetodoPago);
        ViewBag.idProducto = new SelectList(db.PRODUCTOS, "IdProducto", "NombreProducto", fACTURAS.idProducto);
        return View(fACTURAS);
    }

    // GET: Facturas/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        FACTURAS fACTURAS = db.FACTURAS.Find(id);
        if (fACTURAS == null)
        {
            return HttpNotFound();
        }
        return View(fACTURAS);
    }

    // POST: Facturas/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        FACTURAS fACTURAS = db.FACTURAS.Find(id);
        db.FACTURAS.Remove(fACTURAS);
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
*/