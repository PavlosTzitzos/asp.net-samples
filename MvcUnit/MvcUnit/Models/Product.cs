using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcUnit.Models
{
//    [Table("COMPANY", Schema = "ASPNET_DB_USER")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
    
    public class ProductDBContext : DbContext
    {
//        public ProductDBContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        public DbSet<Product> Products { get; set; }

    }
}
