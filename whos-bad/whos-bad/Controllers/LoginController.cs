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
            return View();
        }

        [HttpPost]
        public ActionResult Autenticar(string login, string senha)
        {
            try
            {
                Usuario usu = db.Usuario.Where(e => e.NomeDeUsuario == login).First();

                string senhaUsu = usu.Senha.Split(' ')[0];
                if (senhaUsu == senha)
                {
                    Session["idUsu"] = usu.UserId;
                    Session["NomeUsu"] = usu.Nome;
                    Session["perfil"] = usu.Perfil;
                    Session["erro"] = "";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session["erro"] = "Usuário e/ou senha digitados são inválidos.";
                    return View();
                }
            }
            catch
            {
                Session["idUsu"] = null;
                Session["NomeUsu"] = null;
                Session["perfil"] = null;
                Session["erro"] = "O usuário informado não existe";
                return View();
            }

        }

        public ActionResult Cadastrar()
        {
            return View();
        }
        [Route("Login/Logout")]
        public ActionResult Logout()
        {
            Session["idUsu"] = null;
            Session["NomeUsu"] = null;
            Session["perfil"] = null;
            Session["erro"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}