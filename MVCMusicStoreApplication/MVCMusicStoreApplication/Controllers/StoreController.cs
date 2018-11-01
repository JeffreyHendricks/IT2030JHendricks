using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStoreApplication.Models;

namespace MVCMusicStoreApplication.Controllers
{


    public class StoreController : Controller
    {
        private MVCMusicStoreDB db = new MVCMusicStoreDB();

        // GET: Store
        public ActionResult Index(int id)
        {
            var albums = GetAlbums(id);
            return View("Index", albums);
        }

        private List<Album> GetAlbums(int genId)
            {
            return db.Albums.Where(a => a.GenreId==(genId)).ToList();
            }

        
        public ActionResult Browse()
        {
            var genre = GetGenre();
            return View("Browse", genre);
        }

        private List<Genre> GetGenre()
        {
            return db.Genres.OrderBy(a => a.Name).ToList();
            
        }

        public ActionResult Details(int id)
        {
            var album = GetAlbum(id);
            return View("Details", album);
        }

        private Album GetAlbum(int albumId)
        {
            return db.Albums.Single(a => a.AlbumId == (albumId));
        }
    }
}