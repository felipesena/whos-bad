using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using whos_bad.Models;

namespace whos_bad.Controllers
{
    public class LoginController : Controller
    {
        private whosBadDBEntities db = new whosBadDBEntities();
        // GET: Login
        public ActionResult Autenticar()
        {
            Session["erro"] = "";
            Session["idUsu"] = "";
            Session["NomeUsu"] = "";
            Session["perfil"] = "";
            return View();
        }

        [HttpPost]
        public ActionResult Autenticar(string login, string senha)
        {
            Usuario usu = db.Usuario.Where(e => e.NomeDeUsuario == login).First();

            if(usu != null)
            {
                string senhaUsu = usu.Senha.Split(' ')[0];
                if(senhaUsu == senha)
                {
                    Session["idUsu"] = usu.UserId;
                    Session["NomeUsu"] = usu.Nome;
                    Session["perfil"] = usu.Perfil;
                    Session["erro"] = "";
                    return RedirectToAction("Index", "Home");
                }
            }
            Session["idUsu"] = "";
            Session["NomeUsu"] = "";
            Session["perfil"] = "";
            Session["erro"] = "Erro ao logar no sistema";

            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }
    }
}