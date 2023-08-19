using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KutuphaneSystemi.Models;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;
using KutuphaneSystemi.Security;

namespace KutuphaneSystemi.Controllers
{
    public class ReturnBookController : Controller
    {
        // GET: ReturnBook
        LibrarSystemProjectEntities model = new LibrarSystemProjectEntities();
        [HttpGet]
        [MyAuthorization(Roles = "A,P,C")]
        public ActionResult ReturnBooks()
        {
            BorrowedBooks borrow = new BorrowedBooks();
            List<Books> book = model.Books.ToList();
            List<Student> student = model.Student.ToList();
            ViewBag.book = book;
            ViewBag.student = student;


            return View(borrow);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAuthorization(Roles = "A,P,C")]
        public ActionResult ReturnBooks(int student_id, int book_id)
        {
            
            
                SqlParameter returnMessage = new SqlParameter("@return_message", SqlDbType.NVarChar, 100);
                returnMessage.Direction = ParameterDirection.Output;

                model.Database.ExecuteSqlCommand("EXEC ReturnStudentBook @student_id, @book_id, @return_message OUT",
                    new SqlParameter("@student_id", student_id),
                    new SqlParameter("@book_id", book_id),
                    returnMessage);

                 TempData["ReturnMessage"] = returnMessage.Value.ToString();
            

            // Redirect to a view or action after returning a book
            return RedirectToAction("ReturnBooks");
        }
    }
}