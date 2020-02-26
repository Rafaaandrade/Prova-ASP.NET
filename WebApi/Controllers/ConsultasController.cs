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
    public class ConsultasController : Controller
    {
        private BaseContext db = new BaseContext();

        // GET: Consultas
        public ActionResult Index()
        {
            var consultas = db.Consultas.Include(c => c.Anaminese).Include(c => c.Paciente);
            return View(consultas.ToList());
        }

        // GET: Consultas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consultas.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // GET: Consultas/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Anaminese, "Id", "Sintomas");
            ViewBag.PacienteId = new SelectList(db.Paciente, "Id", "Nome");
            return View();
        }

        // POST: Consultas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataConsulta,Procedimento,Horario,PacienteId")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Consultas.Add(consulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Anaminese, "Id", "Sintomas", consulta.Id);
            ViewBag.PacienteId = new SelectList(db.Paciente, "Id", "Nome", consulta.PacienteId);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consultas.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Anaminese, "Id", "Sintomas", consulta.Id);
            ViewBag.PacienteId = new SelectList(db.Paciente, "Id", "Nome", consulta.PacienteId);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataConsulta,Procedimento,Horario,PacienteId")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Anaminese, "Id", "Sintomas", consulta.Id);
            ViewBag.PacienteId = new SelectList(db.Paciente, "Id", "Nome", consulta.PacienteId);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consultas.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consulta consulta = db.Consultas.Find(id);
            db.Consultas.Remove(consulta);
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
