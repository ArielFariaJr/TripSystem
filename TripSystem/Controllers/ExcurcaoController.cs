using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TripSystem.Models;

namespace TripSystem.Controllers
{
    public class ExcurcaoController : Controller
    {
        private SystemEntities db = new SystemEntities();

        //
        // GET: /Excurcao/

        public ActionResult Index()
        {
            var excurcao = db.Excurcao.Include(e => e.Genero).Include(e => e.Guia).Include(e => e.Veiculo);
            return View(excurcao.ToList());
        }

        //
        // GET: /Excurcao/Details/5

        public ActionResult Details(int id = 0)
        {
            Excurcao excurcao = db.Excurcao.Find(id);
            if (excurcao == null)
            {
                return HttpNotFound();
            }
            return View(excurcao);
        }

        //
        // GET: /Excurcao/Create

        public ActionResult Create()
        {
            ViewBag.GeneroId = new SelectList(db.Genero, "ID", "Nome");
            ViewBag.GuiaId = new SelectList(db.Guia, "ID", "Nome");
            ViewBag.VeicuiloId = new SelectList(db.Veiculo, "VeiculoId", "MarcaCarro");
            return View();
        }

        //
        // POST: /Excurcao/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Excurcao excurcao)
        {
            if (ModelState.IsValid)
            {
                db.Excurcao.Add(excurcao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GeneroId = new SelectList(db.Genero, "ID", "Nome", excurcao.GeneroId);
            ViewBag.GuiaId = new SelectList(db.Guia, "ID", "Nome", excurcao.GuiaId);
            ViewBag.VeicuiloId = new SelectList(db.Veiculo, "VeiculoId", "MarcaCarro", excurcao.VeicuiloId);
            return View(excurcao);
        }

        //
        // GET: /Excurcao/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Excurcao excurcao = db.Excurcao.Find(id);
            if (excurcao == null)
            {
                return HttpNotFound();
            }
            ViewBag.GeneroId = new SelectList(db.Genero, "ID", "Nome", excurcao.GeneroId);
            ViewBag.GuiaId = new SelectList(db.Guia, "ID", "Nome", excurcao.GuiaId);
            ViewBag.VeicuiloId = new SelectList(db.Veiculo, "VeiculoId", "MarcaCarro", excurcao.VeicuiloId);
            return View(excurcao);
        }

        //
        // POST: /Excurcao/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Excurcao excurcao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(excurcao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GeneroId = new SelectList(db.Genero, "ID", "Nome", excurcao.GeneroId);
            ViewBag.GuiaId = new SelectList(db.Guia, "ID", "Nome", excurcao.GuiaId);
            ViewBag.VeicuiloId = new SelectList(db.Veiculo, "VeiculoId", "MarcaCarro", excurcao.VeicuiloId);
            return View(excurcao);
        }

        //
        // GET: /Excurcao/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Excurcao excurcao = db.Excurcao.Find(id);
            if (excurcao == null)
            {
                return HttpNotFound();
            }
            return View(excurcao);
        }

        //
        // POST: /Excurcao/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Excurcao excurcao = db.Excurcao.Find(id);
            db.Excurcao.Remove(excurcao);
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