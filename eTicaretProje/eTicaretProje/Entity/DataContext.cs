using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eTicaretProje.Entity
{
    public class DataContext : DbContext
    {
        public DataContext() : base("dataConnection")
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet <Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CreditCart> CreditCarts { get; set; }
    }
}