using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TripSystem.Models;

namespace TripSystem.Controllers
{
    public class HomeController : Controller
    {
        SystemEntities storeDB = new SystemEntities();

        public ActionResult ListaEmbarque()
        {
            using (TripSystemEntities ts = new TripSystemEntities()){

                var result = ts.Excurcaos.ToList();

                return View(result);
            }            
        }



         public ActionResult Index()
        {
            // Get most popular albums
            var excurcoes = GetTopSellingAlbums(5);

            return View(excurcoes);
        }

         private List<Excurcao> GetTopSellingAlbums(int count)
         {
             // Group the order details by album and return
             // the albums with the highest count
             return storeDB.Excurcao
             .OrderByDescending(a => a.ItensOrdem.Count())
             .Take(count)
             .ToList();
         }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
