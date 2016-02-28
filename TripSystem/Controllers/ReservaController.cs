using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TripSystem.Models;

namespace TripSystem.Controllers
{
    public class ReservaController : Controller
    {
        private SystemEntities db = new SystemEntities();

        //
        // GET: /Reserva/

        public ActionResult Index()
        {
            var reserva = db.Reserva.Include(r => r.Excurcao);
            return View(reserva.ToList());
        }

        //
        // GET: /Reserva/Details/5

        public ActionResult Details(int id = 0)
        {
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        //
        // GET: /Reserva/Create

        public ActionResult Create()
        {
            ViewBag.ExcurcaoId = new SelectList(db.Excurcao, "ID", "Titulo");
            return View();
        }

        //
        // POST: /Reserva/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Reserva.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExcurcaoId = new SelectList(db.Excurcao, "ID", "Titulo", reserva.ExcurcaoId);
            return View(reserva);
        }

        //
        // GET: /Reserva/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExcurcaoId = new SelectList(db.Excurcao, "ID", "Titulo", reserva.ExcurcaoId);
            return View(reserva);
        }

        //
        // POST: /Reserva/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExcurcaoId = new SelectList(db.Excurcao, "ID", "Titulo", reserva.ExcurcaoId);
            return View(reserva);
        }

        //
        // GET: /Reserva/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        //
        // POST: /Reserva/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserva reserva = db.Reserva.Find(id);
            db.Reserva.Remove(reserva);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}