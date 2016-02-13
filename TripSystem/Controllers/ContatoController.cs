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
    public class ContatoController : Controller
    {
        private SystemEntities db = new SystemEntities();

        //
        // GET: /Contato/

        public ActionResult Index()
        {
            return View(db.Contato.ToList());
        }

        //
        // GET: /Contato/Details/5

        public ActionResult Details(int id = 0)
        {
            Contato contato = db.Contato.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        //
        // GET: /Contato/Create

        public ActionResult Create()
        {
            return PartialView();
        }

        //
        // POST: /Contato/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contato contato)
        {
            if (ModelState.IsValid)
            {
                db.Contato.Add(contato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contato);
        }

        //
        // GET: /Contato/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Contato contato = db.Contato.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        //
        // POST: /Contato/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contato contato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contato);
        }

        //
        // GET: /Contato/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Contato contato = db.Contato.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        //
        // POST: /Contato/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contato contato = db.Contato.Find(id);
            db.Contato.Remove(contato);
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