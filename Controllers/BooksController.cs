using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneSystemi.Models;
using System.Data.Entity.Migrations;
using System.Web.Security;
using KutuphaneSystemi.Security;

namespace KutuphaneSystemi.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        // GET: Books
        LibrarSystemProjectEntities model = new LibrarSystemProjectEntities();
        [MyAuthorization(Roles = "A,P,C")]
        public ActionResult Index()
        {
            List<Books> book = model.Books.ToList();
            return View(book);
        }
        [HttpPost]
        [MyAuthorization(Roles = "A")]
        public void bookSil(int id)
        {
            Books b = model.Books.FirstOrDefault(x => x.book_id == id);
            if (b != null)
            {
                model.Books.Remove(b);
                model.SaveChanges();
            }
           
        }
        
        [HttpGet]
       public ActionResult kitapEkle()
        {
            Books book = new Books();
            List<Authors> authors = model.Authors.ToList();
            List<Categories> categories = model.Categories.ToList();
            List<Library> library = model.Library.ToList();
            ViewBag.authors = authors;
            ViewBag.categories = categories;
            ViewBag.library = library;

            return View(book);
        }
        [MyAuthorization(Roles = "A,P")]
        [HttpPost]
        public ActionResult kitapEkle(Books book)
        {
            model.Books.AddOrUpdate(book);
            model.SaveChanges();
            return RedirectToAction("Index");
        }
        [MyAuthorization(Roles = "A,P")]
        [HttpGet]
        public ActionResult kitapGuncelle(int id)
        {
            Books book = model.Books.FirstOrDefault(x => x.book_id == id);
            List<Authors> authors = model.Authors.ToList();
            List<Categories> categories = model.Categories.ToList();
            List<Library> library = model.Library.ToList();
            ViewBag.authors = authors;
            ViewBag.categories = categories;
            ViewBag.library = library;

            if (book != null)
            {
                return View("kitapEkle", book);
            }
            return null;
        }

    }
}