using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIV_PF_ProyectoFinal.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            using (testEntities te = new testEntities())
            {
                return View(te.CLIENTES.ToList());


            }

        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            using (testEntities te = new testEntities())
            {
                return View(te.CLIENTES.Where(x => x.IdCliente == id).FirstOrDefault());


            }

        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(CLIENTES clientes) 
        {
            try
            {
                using (testEntities te = new testEntities())
                {
                    te.CLIENTES.Add(clientes);
                    te.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            using (testEntities te = new testEntities())
            {
                return View(te.CLIENTES.Where(x => x.IdCliente == id).FirstOrDefault());

            }

        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CLIENTES cliente)
        {
            try
            {
                using (testEntities te = new testEntities())
                {
                    te.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                    te.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            using (testEntities te = new testEntities())
            {
                return View(te.CLIENTES.Where(x => x.IdCliente == id).FirstOrDefault());

            }
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (testEntities te = new testEntities())
                {

                    CLIENTES clientes = te.CLIENTES.Where(x => x.IdCliente == id).FirstOrDefault();
                    te.CLIENTES.Remove(clientes);
                    te.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
