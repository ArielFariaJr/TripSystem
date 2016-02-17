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
    public class VeiculoController : Controller
    {
        private SystemEntities db = new SystemEntities();

        //
        // GET: /Veiculo/

        public ActionResult Index()
        {
            var veiculo = db.Veiculo.Include(v => v.Transportadora);
            return View(veiculo.ToList());
        }

        //
        // GET: /Veiculo/Details/5

        public ActionResult Details(int id = 0)
        {
            Veiculo veiculo = db.Veiculo.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        //
        // GET: /Veiculo/Create

        public ActionResult Create()
        {
            ViewBag.TransportadoraId = new SelectList(db.Transportadora, "ID", "Nome");
            return View();
        }

        //
        // POST: /Veiculo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Veiculo.Add(veiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TransportadoraId = new SelectList(db.Transportadora, "ID", "Nome", veiculo.TransportadoraId);
            return View(veiculo);
        }

        //
        // GET: /Veiculo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Veiculo veiculo = db.Veiculo.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.TransportadoraId = new SelectList(db.Transportadora, "ID", "Nome", veiculo.TransportadoraId);
            return View(veiculo);
        }

        //
        // POST: /Veiculo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TransportadoraId = new SelectList(db.Transportadora, "ID", "Nome", veiculo.TransportadoraId);
            return View(veiculo);
        }

        //
        // GET: /Veiculo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Veiculo veiculo = db.Veiculo.Find(id);
            if (veiculo == null)
            {
                return HttpNotFound();
            }
            return View(veiculo);
        }

        //
        // POST: /Veiculo/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Veiculo veiculo = db.Veiculo.Find(id);
            db.Veiculo.Remove(veiculo);
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