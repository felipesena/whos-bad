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
    public class RegistrosController : Controller
    {
        private whosBadDBEntities db = new whosBadDBEntities();

        // GET: Registros
        public ActionResult Index()
        {
            var registro = db.Registro.Include(r => r.Usuario);
            return View(registro.ToList());
        }

        // GET: Registros/Details/5
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

        // GET: Registros/Create
        public ActionResult Create()
        {
            ViewBag.FKUserId = new SelectList(db.Usuario, "UserId", "Nome");
            ViewBag.FKSentimentoId = new SelectList(db.Humor, "HumorId", "Nome");
            ViewBag.FKHumorId = new SelectList(db.Sentimento, "SentimentoId", "Nome");

            return View();
        }

        // POST: Registros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegistroId,Contexto,Atitude,FKSentimentoId,FKHumorId,Data,Pensamento,FKUserId")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                db.Registro.Add(registro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FKUserId = new SelectList(db.Usuario, "UserId", "Nome", registro.FKUserId);
            ViewBag.FKSentimentoId = new SelectList(db.Humor, "HumorId", "Nome");
            ViewBag.FKHumorId = new SelectList(db.Sentimento, "SentimentoId", "Nome");
            return View(registro);
        }

        // GET: Registros/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.FKUserId = new SelectList(db.Usuario, "UserId", "Nome", registro.FKUserId);
            ViewBag.FKSentimentoId = new SelectList(db.Humor, "HumorId", "Nome", registro.FKHumorId);
            ViewBag.FKHumorId = new SelectList(db.Sentimento, "SentimentoId", "Nome", registro.FKSentimentoId);

            return View(registro);
        }

        // POST: Registros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegistroId,Contexto,Atitude,FKSentimentoId,FKHumorId,Data,Pensamento,FKUserId")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FKUserId = new SelectList(db.Usuario, "UserId", "Nome", registro.FKUserId);
            ViewBag.FKSentimentoId = new SelectList(db.Humor, "HumorId", "Nome", registro.FKHumorId);
            ViewBag.FKHumorId = new SelectList(db.Sentimento, "SentimentoId", "Nome", registro.FKSentimentoId);
            return View(registro);
        }

        // GET: Registros/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Registros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registro registro = db.Registro.Find(id);
            db.Registro.Remove(registro);
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
