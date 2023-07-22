using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace WebApplication2.Models
{
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

    public class DrugDBContext : DbContext
    {
        public DbSet<Drug> Drugs { get; set; }
    }
}