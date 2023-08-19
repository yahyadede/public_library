using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneSystemi.Models;
using System.Data.Entity.Migrations;
using KutuphaneSystemi.Security;
using System.Web.Security;

namespace KutuphaneSystemi.Controllers
{
   
    public class CategoryController : Controller
    {
        // GET: Category
        LibrarSystemProjectEntities model = new LibrarSystemProjectEntities();
        //   LibrarSystemProjectModeli model = new LibrarSystemProjectModeli();
        [MyAuthorization(Roles = "A,C,P")]
        public ActionResult Index()
        {
            List<Categories> categories = model.Categories.ToList();
            return View(categories);
        }
       

        [HttpGet]
        [MyAuthorization(Roles = "A,P")]
        public ActionResult AddCategory()
        {
            Categories c = new Categories();


            return View(c);
        }
        [HttpPost]
        [MyAuthorization(Roles = "A,P")]
        public ActionResult AddCategory(Categories categories)
        {
            model.Categories.AddOrUpdate(categories);
            model.SaveChanges();


            return RedirectToAction("Index");
        }

        //******************************** another page to delete *********************************//
        [HttpGet]
        [MyAuthorization(Roles = "P")]
        public ActionResult SilCategory(int id)
        {
            Categories category = model.Categories.FirstOrDefault(x => x.category_id == id);
            if (category != null)
            {
                return View(category);
            }
            return null;
            //if (category != null)
            //{
            //    model.Categories.Remove(category);
            //    model.SaveChanges();
            //}
            //return RedirectToAction("Index");
        }
        [HttpPost]
        [MyAuthorization(Roles = "P")]
        public ActionResult SilCategory(Categories u)
        {
            Categories category = model.Categories.FirstOrDefault(x => x.category_id == u.category_id);
            if (category != null)
            {
                model.Categories.Remove(category);
                model.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        //********************************         *********************************//

        [HttpGet]
        [MyAuthorization(Roles = "A,P")]
        public ActionResult UpdateCategory(int id)
        {
            Categories category = model.Categories.FirstOrDefault(x => x.category_id == id);
            if (category != null)
            {
                return View("AddCategory", category);
            }
            return null;
        }
    }
}