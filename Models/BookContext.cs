using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity;

namespace MVCRudnev.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}