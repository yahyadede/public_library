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
    public class AuthorsController : Controller
    {

        // GET: Authors
        
        LibrarSystemProjectEntities model = new LibrarSystemProjectEntities();
        [MyAuthorization(Roles = "A,P,C")]
        public ActionResult Index()
        {
            List<Authors> a = model.Authors.ToList();
            return View(a);

        }

        [MyAuthorization(Roles = "A,P")]
        [HttpPost]

        public ActionResult addAuthors(Authors author)
        {
            model.Authors.AddOrUpdate(author);
            model.SaveChanges();

            return RedirectToAction("Index");

        }


        [MyAuthorization(Roles = "A,P")]
        [HttpPost]
        public ActionResult updateAuthors(Authors a)
        {
            
           
                model.Authors.AddOrUpdate(a);
                model.SaveChanges();
                return RedirectToAction("Index");
            
           

        }
        [MyAuthorization(Roles = "A")]
        [HttpPost]
        public void authorDelete(int id)
        {
            Authors b = model.Authors.FirstOrDefault(x => x.author_id == id);
            if (b != null)
            {
                model.Authors.Remove(b);
                model.SaveChanges();
            }
            //return RedirectToAction("Index");
        }


    }
}