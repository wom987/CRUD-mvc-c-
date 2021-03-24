using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//incluyendo la carpeta modelos
using WebApplication1.Models;

namespace com.myApp
{
    namespace WebApplication1.Controllers
    {
        public class HomeController : Controller
        {
            DAOUsers dao = new DAOUsers();


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

            public ActionResult helpers()
            {

                return View();
            }

            [HttpPost]
            public ActionResult recibeForm(string txtNombre, string txtpassword, string combo)
            {
                string nombre = txtNombre;
                string pass = txtpassword;
                string nivel = combo;


                return RedirectToAction("helpers");
            }


            public ActionResult Usuarios()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Usuarios(Usuarios u)
            {
                if (ModelState.IsValid)
                {
                    if (dao.insertar(u))
                    {
                        ViewBag.ins = "true";
                        ViewBag.user = u.username;
                    }
                }
                return View(u);
            }
            public ActionResult Editar()
            {
                return RedirectToAction("Index");
            }
            [HttpPost]
            public JsonResult Editar(int id, String username, String password, int nivel)
            {
                bool result = dao.editar(id, username, password, nivel);
                
                    return Json(result);
                
            }
            public ActionResult ListarUsuarios()
            {
                return View(dao.getTabla());
            }

            public ActionResult UserList()
            {
                return View(dao.getTabla());
            }
            public ActionResult Eliminar()
            {
                return RedirectToAction("Index");
            }
            [HttpPost]
            public JsonResult Eliminar(int id)
            {
                bool result = dao.eliminar(id);

                return Json(result);

            }

        }
    }
}