using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TripSystem.Models;

namespace TripSystem.Controllers
{
    public class StoreController : Controller
    {
        SystemEntities storeDB = new SystemEntities();

        //
        // GET: /Store/

        public ActionResult Index()
        {
            var genres = storeDB.Genero.ToList();

            return View(genres);
        }

        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = storeDB.Genero.Include("Excurcao")
                .Single(g => g.Nome == genre);

            return View(genreModel);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id)
        {
            var album = storeDB.Excurcao.Find(id);

            return View(album);
        }

        //
        // GET: /Store/GenreMenu

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = storeDB.Genero.ToList();

            return PartialView(genres);
        }

    }
}