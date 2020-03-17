using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCRudnev.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        // имя и фамилия покупателя
        public string Person { get; set; }
        // адрес покупателя
        public string Address { get; set; }
        // ID книги
        public int BookId { get; set; }
        public string BookName { get; set; }

        /*Book book = new Book();
        public string BookName
        {
            get { return  book.Name; }   
            set { book.Name = book.Name; }  
        }*/
        // дата покупки
        public DateTime Date { get; set; }
    }
}