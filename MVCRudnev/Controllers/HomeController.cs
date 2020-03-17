using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Books = books;
            // возвращаем представление
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;
            var list = books.ToList();
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return ViewBag.BookName =  "<h2>" + "Спасибо, " + purchase.Person + ", за покупку! "+ "</h2>"  +"ты купил книгу: " + 
                "<br>" + " Автор: " + list[purchase.BookId - 1].Author
                + "<br>" + " Название книги:"+ list[purchase.BookId-1].Name + 
                "<br>"  + "Она стоила: " + list[purchase.BookId - 1].Price +  "евро"
                +"<br>" + " Время и дата покупки: " + purchase.Date
                + "<br>" + " Книга будет доставлена на адресс: " + purchase.Address;
        }
    }
}