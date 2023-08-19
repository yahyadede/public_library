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
    public class HomeController : Controller
    {
        // GET: Home
        LibrarSystemProjectEntities model = new LibrarSystemProjectEntities();
        [MyAuthorization(Roles = "A,P,C")]
        public ActionResult Index()
        {
            List<BorrowedBooksView> borrowedBooks = model.BorrowedBooksView.ToList();
            List<rapor_reservation_student> rapor = model.rapor_reservation_student.ToList();
            ViewBag.rapor = rapor;
            return View(borrowedBooks);
            
        }

        [MyAuthorization(Roles = "C")]
        public ActionResult Index2(Student s)
        {
            Student student = model.Student.FirstOrDefault(x=>x.student_id==s.student_id);
            return View(student);

        }


    }
}