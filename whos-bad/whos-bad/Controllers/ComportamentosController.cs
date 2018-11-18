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
    public class ComportamentosController : Controller
    {
        private whosBadDBEntities db = new whosBadDBEntities();

        // GET: Comportamentos
        public ActionResult Index()
        {
            var comportamento = db.Comportamento.Include(c => c.Humor).Include(c => c.Sentimento).Include(c => c.Usuario);
            return View(comportamento.ToList());
        }

        // GET: Comportamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comportamento comportamento = db.Comportamento.Find(id);
            if (comportamento == null)
            {
                return HttpNotFound();
            }
            return View(comportamento);
        }

        // GET: Comportamentos/Create
        public ActionResult Create()
        {
            ViewBag.FKHumorId = new SelectList(db.Humor, "HumorId", "Nome");
            ViewBag.FKSentimentoId = new SelectList(db.Sentimento, "SentimentoId", "Nome");
            ViewBag.FKUserId = new SelectList(db.Usuario, "UserId", "Nome");
            return View();
        }

        [Route("Comportamentos/Cadastrar")]
        public ActionResult Cadastrar()
        {
            int idUsuario = int.Parse(Session["idUsu"].ToString());

            //return RedirectToAction("Edit", idUsuario);
            return RedirectToRoute(new { controller = "Comportamentos", action = "Create", id = idUsuario });

        }

        // POST: Comportamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComportamentoId,NomeDoComportamento,FKSentimentoId,IntensidadeDoSentimento,FKHumorId,FKUserId")] Comportamento comportamento)
        {
            if (ModelState.IsValid)
            {
                db.Comportamento.Add(comportamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FKHumorId = new SelectList(db.Humor, "HumorId", "Nome", comportamento.FKHumorId);
            ViewBag.FKSentimentoId = new SelectList(db.Sentimento, "SentimentoId", "Nome", comportamento.FKSentimentoId);
            ViewBag.FKUserId = new SelectList(db.Usuario, "UserId", "Nome", comportamento.FKUserId);
            return View(comportamento);
        }

        // GET: Comportamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comportamento comportamento = db.Comportamento.Find(id);
            if (comportamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.FKHumorId = new SelectList(db.Humor, "HumorId", "Nome", comportamento.FKHumorId);
            ViewBag.FKSentimentoId = new SelectList(db.Sentimento, "SentimentoId", "Nome", comportamento.FKSentimentoId);
            ViewBag.FKUserId = new SelectList(db.Usuario, "UserId", "Nome", comportamento.FKUserId);
            return View(comportamento);
        }

        // POST: Comportamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComportamentoId,NomeDoComportamento,FKSentimentoId,IntensidadeDoSentimento,FKHumorId,FKUserId")] Comportamento comportamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comportamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FKHumorId = new SelectList(db.Humor, "HumorId", "Nome", comportamento.FKHumorId);
            ViewBag.FKSentimentoId = new SelectList(db.Sentimento, "SentimentoId", "Nome", comportamento.FKSentimentoId);
            ViewBag.FKUserId = new SelectList(db.Usuario, "UserId", "Nome", comportamento.FKUserId);
            return View(comportamento);
        }

        // GET: Comportamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comportamento comportamento = db.Comportamento.Find(id);
            if (comportamento == null)
            {
                return HttpNotFound();
            }
            return View(comportamento);
        }

        // POST: Comportamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comportamento comportamento = db.Comportamento.Find(id);
            db.Comportamento.Remove(comportamento);
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
