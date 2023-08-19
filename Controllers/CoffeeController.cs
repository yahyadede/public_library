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
    public class CoffeeController : Controller
    {
        // GET: Coffee
        LibrarSystemProjectEntities model = new LibrarSystemProjectEntities();
        [MyAuthorization(Roles = "A,P,C")]
        public ActionResult Index()
        {
            List<Coffee> coffee = model.Coffee.ToList();
            List<Library> libraries = model.Library.ToList();
            List<Student> student = model.Student.ToList();
            List<Employee> employees = model.Employee.ToList();
            ViewBag.libraries = libraries;
            ViewBag.student = student;
            ViewBag.employees = employees;


            return View(coffee);
        }
        [HttpPost]
        [MyAuthorization(Roles = "A,P")]
        public ActionResult AddUrun(Coffee c)
        {
            model.Coffee.AddOrUpdate(c);
            model.SaveChanges();


            return RedirectToAction("Index");
        }
        [HttpPost]
        [MyAuthorization(Roles = "A")]
        public ActionResult urunDelete(int id)
        {
            Coffee cof = model.Coffee.FirstOrDefault(x => x.coffee_id == id);
            if (cof != null)
            {
                model.Coffee.Remove(cof);
                model.SaveChanges();
                return RedirectToAction("Index");
            }


            return null;
        }
        
        public ActionResult urunUpdate(Coffee c)
        {

            
            model.Coffee.AddOrUpdate(c);

            model.SaveChanges();
            return RedirectToAction("Index");


            
        }
        [MyAuthorization(Roles = "A,P")]
        public ActionResult makeOrder()
        {
            Coffee coffee = new Coffee();
            List<Employee> employee = model.Employee.ToList();
            List<Student> student = model.Student.ToList();
            ViewBag.employee = employee;
            ViewBag.student = student;


            return View(coffee);
        }
    }
}