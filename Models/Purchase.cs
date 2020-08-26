using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCRudnev.Models
{
    public class Purchase
    {
            public int PurchaseId { get; set; }
            // имя и фамилия покупателя
            //   [Required(ErrorMessage = "Введите имя")]
            public string Person { get; set; }
            // адрес покупателя
            // [Required(ErrorMessage = "Sisesta email")]
            public string Address { get; set; }
            // ID книги
            public int BookId { get; set; }
            public string BookName { get; set; }
            public string FilePath { get; set; }
            public string FileName { get; set; }

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