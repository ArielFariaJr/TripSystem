using System;
using System.Linq;
using System.Web.Mvc;
using TripSystem.Models;

namespace MvcMusicStore.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        SystemEntities storeDB = new SystemEntities();
        const string PromoCode = "FREE";

        //
        // GET: /Checkout/AddressAndPayment

        public ActionResult PeopleForm()
        {
            return View();
        }

        //
        // POST: /Checkout/AddressAndPayment

        [HttpPost]
        public ActionResult PeopleForm(FormCollection values)
        {
            var order = new Ordem();
            TryUpdateModel(order);

            try
            {
                order.Username = User.Identity.Name;
                order.OrderDate = DateTime.Now;

                //Save Order
                storeDB.Ordem.Add(order);
                storeDB.SaveChanges();

                //Process the order
                var cart = ShoppingCart.GetCart(this.HttpContext);
                cart.CreateOrder(order);

                return RedirectToAction("Complete",
                    new { id = order.OrdemId });

            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        //
        // GET: /Checkout/Complete

        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = storeDB.Ordem.Any(
                o => o.OrdemId == id &&
                o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}
