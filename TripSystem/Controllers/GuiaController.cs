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
    public class GuiaController : Controller
    {
        private SystemEntities db = new SystemEntities();

        //
        // GET: /Guia/

        public ActionResult Index()
        {
            return View(db.Guia.ToList());
        }

        //
        // GET: /Guia/Details/5

        public ActionResult Details(int id = 0)
        {
            Guia guia = db.Guia.Find(id);
            if (guia == null)
            {
                return HttpNotFound();
            }
            return View(guia);
        }

        //
        // GET: /Guia/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Guia/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Guia guia)
        {
            if (ModelState.IsValid)
            {
                db.Guia.Add(guia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guia);
        }

        //
        // GET: /Guia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Guia guia = db.Guia.Find(id);
            if (guia == null)
            {
                return HttpNotFound();
            }
            return View(guia);
        }

        //
        // POST: /Guia/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guia guia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guia);
        }

        //
        // GET: /Guia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Guia guia = db.Guia.Find(id);
            if (guia == null)
            {
                return HttpNotFound();
            }
            return View(guia);
        }

        //
        // POST: /Guia/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Guia guia = db.Guia.Find(id);
            db.Guia.Remove(guia);
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