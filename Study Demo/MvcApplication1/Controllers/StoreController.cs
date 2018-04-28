using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class StoreController : Controller
    {

        MusicStoreEntities storeDB = new MusicStoreEntities();

        //
        // GET: /Store/
     
        public ActionResult Index()
        {     
            var genres = storeDB.Genres.ToList();
            return View(genres);
        }

        public ActionResult Browse(string genre)  //浏览
        {
            var genreModel = storeDB.Genres.Include("Albums").Single(g=>g.Name==genre);
            return View(genreModel);
        }

        public ActionResult Details(int id)  //明细
        {
            var album = storeDB.Albums.Find(id);
            return View(album);
        }

    }
}
