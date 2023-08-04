using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp6WebAPI2.Models
{
    /// <summary>
    /// Products Model
    /// </summary>
    public class Product
    {
        /// <summary>
        /// ID of product
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of product
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Category of product
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Price of product in $$.$$
        /// </summary>
        public decimal Price { get; set; }
    }
    
}