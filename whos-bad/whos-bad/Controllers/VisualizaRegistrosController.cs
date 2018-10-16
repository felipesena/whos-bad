using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using whos_bad.Models;

namespace whos_bad.Controllers
{
    public class VisualizaRegistrosController : Controller
    {
        private whosBadDBEntities db = new whosBadDBEntities();

        // GET: VisualizaRegistros
        public ActionResult Index()
        {
            var registro = db.Usuario.Where(e => e.Perfil == "Paciente").ToList();
            return View(registro.ToList());
        }

        // GET: VisualizaRegistros/Details/5
        public ActionResult registros(int? id)
        {
            var registro = db.Registro.Where(e => e.FKUserId == id).ToList();
            return View(registro.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro registro = db.Registro.Find(id);
            if (registro == null)
            {
                return HttpNotFound();
            }
            return View(registro);
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
