using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace whos_bad.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return RedirectToAction("Autenticar");
        }

        
        public ActionResult Autenticar(string login, string senha)
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }
    }
}