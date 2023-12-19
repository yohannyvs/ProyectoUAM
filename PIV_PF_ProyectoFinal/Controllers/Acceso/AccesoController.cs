using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIV_PF_ProyectoFinal.Controllers.Acceso
{
    public class AccesoController : Controller
    {
        private testEntities dbContext;
        private Utils.Cifrado cifrado;


        public AccesoController()
        {
            dbContext = new testEntities();
            cifrado = new Utils.Cifrado();
        }

        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public bool IniciarSesion(string pCorreo, string pClave)
        {
            try
            {
                string claveEncriptada = cifrado.EncriptarAES(pClave);
                bool? activo = dbContext.USUARIOS.Where(x => x.Correo == pCorreo && x.Clave == claveEncriptada).Select(x => x.Activo).FirstOrDefault();

                if (activo == true)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                string mensaje = e.Message;
                return false;
            }
            

        }

        public ActionResult CerrarSesion()
        {
            return View();
        }

        [HttpPost]
        public bool Registrarse(string pNombre, string pCorreo, string pClave)
        {
            try
            {
                USUARIOS usuario = new USUARIOS()
                {
                    NombreCompleto = pNombre,
                    Correo = pCorreo,
                    Clave = cifrado.EncriptarAES(pClave),
                    Activo = true,
                    IdRol = 2
                };

                dbContext.USUARIOS.Add(usuario);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                string mensaje = e.Message;
                return false;
            }
            

            return true;
        }

    }
}