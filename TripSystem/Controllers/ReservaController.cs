using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TripSystem.Models;
using System.Web.SessionState;

namespace TripSystem.Controllers
{
    public class ReservaController : Controller
    {
        private SystemEntities db = new SystemEntities();

        //
        // GET: /Reserva/

        public ActionResult Finalizar()
        {
            var id = db.Reserva.Where(x => x.Username == User.Identity.Name && x.SessionID == Session.SessionID).
                Select(p => p.OrdemId).FirstOrDefault();

            return RedirectToAction("Complete",
            new { id = id });
        }

        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = db.Reserva.Any(
                o => o.OrdemId == id &&
                o.Username == User.Identity.Name);

            if (isValid)
            {

                //Limpa carrinho
                //var cartItem = db.Carrinho.Include(cart => cart.CarrinhoId == User.Identity.Name).ToList();

                var cartItem = db.Carrinho.Where(cart => cart.CarrinhoId == User.Identity.Name).ToList();
                int itemCount = 0;

                if (cartItem != null)
                {
                    if (cartItem.Count > 1)
                    {
                        foreach (var aux in cartItem)
                        {
                            aux.Count--;
                            itemCount = cartItem.Count;
                            db.Carrinho.Remove(aux);

                            if (cartItem == null)
                            {
                                break;
                            }
                        }

                    }
                    else
                    {
                        db.Carrinho.Remove(cartItem.FirstOrDefault());
                    }

                    // Save changes
                    db.SaveChanges();
                }


                //Renova Session

                Session.Contents.Abandon();
                Session.Contents.RemoveAll();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId"));

                return View(id);
            }
            else
            {
                return View("Error");
            }
        }

        [Authorize]
        public ActionResult Index()
        {
            var reserva = db.Reserva.Include(r => r.Excurcao).Where(r => r.SessionID == Session.SessionID);
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
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                reserva.Username = User.Identity.Name.ToString();
                reserva.OrderDate = DateTime.Now;
                reserva.SessionID = Session.SessionID.ToString();

                //Seleciona ultima ordem
                var lastOrder = db.Reserva.OrderByDescending(p => p.OrdemId).Select(c => c.OrdemId).Take(1).FirstOrDefault();

                var lastOrderMem = db.Reserva.Where(x => x.Username == User.Identity.Name && x.SessionID == Session.SessionID).
                    Select(p => p.OrdemId).FirstOrDefault();

                if (lastOrder > lastOrderMem)
                {

                    lastOrder = lastOrder + 1;
                    reserva.OrdemId = lastOrder;
                }
                else
                {
                    reserva.OrdemId = lastOrderMem;
                }

                //Seleciona ultimo item da ordem atual
                var lastItem = db.Reserva.Where(x => x.Username == User.Identity.Name && x.SessionID == Session.SessionID
                    && x.OrdemId == lastOrderMem).Select(p => p.passageiroID).FirstOrDefault();

                lastItem = lastItem + 1;
                reserva.passageiroID = lastItem;


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