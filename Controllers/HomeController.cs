using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MVCRudnev.Models;

namespace MVCRudnev.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
        public ActionResult Index()
        {
            IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;
            return View();
        }
        [HttpGet]
        public ActionResult New_Book()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
        [HttpGet]
        public ActionResult Edit_Book(int id)
        {
            return View(db.Books.Where(x => x.Id == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Buy(Purchase purchase)
        {

            IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;
            var list = books.ToList();
            purchase.Date = DateTime.Now;
            purchase.FileName = "download.png";
            db.Purchases.Add(purchase);
            db.SaveChanges();   
            void SendMail()
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "phloyd666@gmail.com";
                WebMail.Password = "Topsteamegor123";
                WebMail.Send(purchase.Address, "благодорим за покупку," + " " + purchase.Person,
                    "Вы купили книгу:" + list[purchase.BookId - 1].Name +
                    "<br>" + "Автора:" + list[purchase.BookId - 1].Author +
                    "<br>" + " Время и дата покупки: " + purchase.Date, "phloyd666@gmail.com");
            }
            ViewBag.BookName =
                    "<div class= \'order\'>" +
                    "<h2>" + "Спасибо, " + purchase.Person + ", за покупку! " + "</h2>" + "ты купил книгу: "
                    + "<br>" + " Автор: " + list[purchase.BookId - 1].Author
                    + "<br>" + " Название книги:" + list[purchase.BookId - 1].Name +
                    "<br>" + "Она стоила: " + list[purchase.BookId - 1].Price + "евро"
                    + "<br>" + " Время и дата покупки: " + purchase.Date
                    + "<br>" + " Книга будет доставлена на адресс: " + purchase.Address;
            SendMail();
            return View();
        }
        public ActionResult New_Book(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete_Book(int id)
        {
            db.Books.Remove(db.Books.Where(x => x.Id == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit_Book(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}