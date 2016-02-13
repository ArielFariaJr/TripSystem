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
    public class GeneroController : Controller
    {
        private SystemEntities db = new SystemEntities();

        //
        // GET: /Genero/

        public ActionResult Index()
        {
            return View(db.Genero.ToList());
        }

        //
        // GET: /Genero/Details/5

        public ActionResult Details(int id = 0)
        {
            Genero genero = db.Genero.Find(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        //
        // GET: /Genero/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Genero/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genero genero)
        {
            if (ModelState.IsValid)
            {
                db.Genero.Add(genero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genero);
        }

        //
        // GET: /Genero/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Genero genero = db.Genero.Find(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        //
        // POST: /Genero/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genero genero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genero);
        }

        //
        // GET: /Genero/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Genero genero = db.Genero.Find(id);
            if (genero == null)
            {
                return HttpNotFound();
            }
            return View(genero);
        }

        //
        // POST: /Genero/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genero genero = db.Genero.Find(id);
            db.Genero.Remove(genero);
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