using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneSystemi.Models;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Web.Security;
using KutuphaneSystemi.Security;

namespace KutuphaneSystemi.Controllers
{
    [Authorize]
    
    public class BorrowBooksController : Controller
    {
        // GET: BorrowBooks
        LibrarSystemProjectEntities model = new LibrarSystemProjectEntities();
        //public ActionResult Index()
        //{
        //    List<BorrowedBooksView> borrowedBooks = model.BorrowedBooksView.ToList();
        //    return View(borrowedBooks);

        //}
        [HttpGet]
        public ActionResult BorrowBook()
        {


            BorrowedBooks borrow = new BorrowedBooks();
            List<Books> book = model.Books.ToList();
            List<Student> student = model.Student.ToList();
            ViewBag.book = book;
            ViewBag.student = student;


            return View(borrow);
        }
        [MyAuthorization(Roles = "A,P,C")]

        [HttpPost]
        public ActionResult BorrowBook(int student_id, int book_id, DateTime borrowDate, DateTime returnDate)
        {
            string message;

            using (var model = new LibrarSystemProjectEntities())
            {
                var result = model.Database.SqlQuery<string>(
                    "EXEC BorrowBook @student_id, @book_id, @borrow_date, @return_date",
                    new SqlParameter("student_id", student_id),
                    new SqlParameter("book_id", book_id),
                    new SqlParameter("borrow_date", borrowDate),
                    new SqlParameter("return_date", returnDate)
                ).FirstOrDefault();

                message = result ?? "An unknown error occurred.";  // Default message if result is null
                
            }

            TempData["BorrowMessage"] = message;



            return RedirectToAction("BorrowBook");


        }
    }
}