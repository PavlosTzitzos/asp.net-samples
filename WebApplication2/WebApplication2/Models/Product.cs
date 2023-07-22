using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace WebApplication2.Models
{
    public class Product
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }

        [Required]
        [StringLength(10)]
        public string QRCode { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]

        public decimal Price { get; set; }
    }
    /*Alternative product -> drug
     * taken from one of my projects: https://github.com/PavlosTzitzos/database-project
    public class Drug
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public int SerialCode { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public bool Approval { get; set; }
    }
    */
    public class ProductDBCintext : DbContext
    {
        public DbSet<Product> Products { get; set;}
    }
}
