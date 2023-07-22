using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace WebApplication5DemoDTjs.Models
{
    [Table("TEST_CUSTOMERS", Schema = "ASPNET_DB_USER")]
    public class Customers
    {
        [Key]
        [Column("CUSTOMER_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "Required CompanyName")]

        [Column("CUSTOMER_COMPANY_NAME")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Required ContactName")]

        [Column("CUSTOMER_CONTACT_NAME")]
        public string ContactName { get; set; }
        [Required(ErrorMessage = "Required ContactTitle")]

        [Column("CUSTOMER_CONTACT_TITLE")]
        public string ContactTitle { get; set; }

        [Column("CUSTOMER_ADDRESS")]
        public string Address { get; set; }

        [Column("CUSTOMER_CITY")]
        [Required(ErrorMessage = "Required City")]
        public string City { get; set; }

        [Column("CUSTOMER_REGION")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Required PostalCode")]
        [Column("CUSTOMER_POSTAL_CODE")]
        public string PostalCode { get; set; }

        [Column("CUSTOMER_COUNTRY")]
        [Required(ErrorMessage = "Required Country")]
        public string Country { get; set; }

        [Column("CUSTOMER_PHONE")]
        [Required(ErrorMessage = "Required Phone")]
        public string Phone { get; set; }

        [Column("CUSTOMER_FAX")]
        public string Fax { get; set; }
    }
    public class CustomersDBContext : DbContext
    {
        public CustomersDBContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        public DbSet<Customers> Customerss { get; set; }
    }
}
/* SQL to create the above table:

CREATE TABLE "ASPNET_DB_USER".TEST_CUSTOMERS(
CUSTOMER_ID INT NOT NULL,
CUSTOMER_COMPANY_NAME VARCHAR2(256),
CUSTOMER_CONTACT_NAME VARCHAR2(256),
CUSTOMER_CONTACT_TITLE VARCHAR2(256),
CUSTOMER_ADDRESS VARCHAR2(256),
CUSTOMER_CITY VARCHAR2(256),
CUSTOMER_REGION VARCHAR2(256),
CUSTOMER_POSTAL_CODE VARCHAR2(256),
CUSTOMER_COUNTRY VARCHAR2(256),
CUSTOMER_PHONE VARCHAR2(256),
CUSTOMER_FAX VARCHAR2(256),
PRIMARY KEY(CUSTOMER_ID)
);
*/