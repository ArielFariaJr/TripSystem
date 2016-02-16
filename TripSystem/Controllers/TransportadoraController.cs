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
    public class TransportadoraController : Controller
    {
        private SystemEntities db = new SystemEntities();

        //
        // GET: /Transportadora/

        public ActionResult Index()
        {
            return View(db.Transportadora.ToList());
        }

        //
        // GET: /Transportadora/Details/5

        public ActionResult Details(int id = 0)
        {
            Transportadora transportadora = db.Transportadora.Find(id);
            if (transportadora == null)
            {
                return HttpNotFound();
            }
            return View(transportadora);
        }

        //
        // GET: /Transportadora/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Transportadora/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transportadora transportadora)
        {
            if (ModelState.IsValid)
            {
                db.Transportadora.Add(transportadora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transportadora);
        }

        //
        // GET: /Transportadora/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Transportadora transportadora = db.Transportadora.Find(id);
            if (transportadora == null)
            {
                return HttpNotFound();
            }
            return View(transportadora);
        }

        //
        // POST: /Transportadora/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transportadora transportadora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transportadora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transportadora);
        }

        //
        // GET: /Transportadora/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Transportadora transportadora = db.Transportadora.Find(id);
            if (transportadora == null)
            {
                return HttpNotFound();
            }
            return View(transportadora);
        }

        //
        // POST: /Transportadora/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transportadora transportadora = db.Transportadora.Find(id);
            db.Transportadora.Remove(transportadora);
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