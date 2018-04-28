using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;
using System.Data.Entity;

namespace MvcApplication1.Controllers
{
    public class StoreManagerController : Controller
    {

        MusicStoreEntities storeDB = new MusicStoreEntities();
        //
        // GET: /StoreManager/

        public ActionResult Index()
        {
            var albums = storeDB.Albums.Include("Genre").Include("Artist");
            return View(albums);
        }

        //
        // GET: /StoreManager/Details/5

        public ActionResult Details(int id)
        {
            Album album = storeDB.Albums.Find(id);
            return View(album);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(storeDB.Genres,"GenreId","Name");
            ViewBag.ArtistId = new SelectList(storeDB.Artists,"ArtistId","Name");
            return View();
        }

        //
        // POST: /StoreManager/Create

        [HttpPost]
        public ActionResult Create(Album album)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    storeDB.Albums.Add(album);
                    storeDB.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);
                ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);
                return View(album);
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /StoreManager/Edit/5

        public ActionResult Edit(int id)
        {
            Album album = storeDB.Albums.Find(id);
            ViewBag.GenreId = new SelectList(storeDB.Genres,"GenreId","Name",album.GenreId);
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Album album)
        {

            if (ModelState.IsValid)
            {
                storeDB.Entry(album).State = System.Data.Entity.EntityState.Modified;
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        //
        // GET: /StoreManager/Delete/5

        public ActionResult Delete(int id)
        {
            Album album = storeDB.Albums.Find(id);
            return View(album);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Album album = storeDB.Albums.Find(id);
                storeDB.Albums.Remove(album);
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
