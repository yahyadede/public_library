using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneSystemi.Models;
using System.Data.Entity.Migrations;
using KutuphaneSystemi.Security;

namespace KutuphaneSystemi.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
        LibrarSystemProjectEntities model = new LibrarSystemProjectEntities();
        [MyAuthorization(Roles = "A,P")]
        public ActionResult Index()
        {
            List<Employee> employees = model.Employee.ToList();
            Employee e = new Employee();
            List<Library> library = model.Library.ToList();
            ViewBag.library = library;
            ViewBag.e = e;
            return View(employees);
        }
        [HttpPost]
        public ActionResult Addemployee(Employee e)
        {
            model.Employee.AddOrUpdate(e);
            model.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [MyAuthorization(Roles = "A")]
        public ActionResult Updateemployee(Employee a)
        {

            model.Employee.AddOrUpdate(a);
            model.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [MyAuthorization(Roles = "A,P")]
        public ActionResult Silemployee(int id)
        {

            Employee e = model.Employee.FirstOrDefault(x => x.employee_id == id);
            if (e != null)
            {
                model.Employee.Remove(e);
                model.SaveChanges();
                return RedirectToAction("Index");
            }
            return null;
        }
    }
}