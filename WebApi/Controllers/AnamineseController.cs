using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NET_PROVA.Context;
using ASP.NET_PROVA.Models;

namespace ASP.NET_PROVA.Controllers
{
    public class AnamineseController : Controller
    {
        private BaseContext db = new BaseContext();

        // GET: Anaminese
        public ActionResult Index()
        {
            return View(db.Anaminese.ToList());
        }

        // GET: Anaminese/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anaminese anaminese = db.Anaminese.Find(id);
            if (anaminese == null)
            {
                return HttpNotFound();
            }
            return View(anaminese);
        }

        // GET: Anaminese/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Anaminese/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Sintomas,DoençasAnteriores,PartesCorpo")] Anaminese anaminese)
        {
            if (ModelState.IsValid)
            {
                db.Anaminese.Add(anaminese);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anaminese);
        }

        // GET: Anaminese/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anaminese anaminese = db.Anaminese.Find(id);
            if (anaminese == null)
            {
                return HttpNotFound();
            }
            return View(anaminese);
        }

        // POST: Anaminese/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Sintomas,DoençasAnteriores,PartesCorpo")] Anaminese anaminese)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anaminese).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anaminese);
        }

        // GET: Anaminese/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anaminese anaminese = db.Anaminese.Find(id);
            if (anaminese == null)
            {
                return HttpNotFound();
            }
            return View(anaminese);
        }

        // POST: Anaminese/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anaminese anaminese = db.Anaminese.Find(id);
            db.Anaminese.Remove(anaminese);
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
