using MvcUnit.Models;
using System.Collections.Generic;
using System;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Web;

namespace MvcUnit.Models
{
    //ProductRepository.cs
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> products = new List<Product>();
        private int _nextId = 1;

        public ProductRepository()
        {
            // Add products for the Demonstration
            Add(new Product { Id = 1, Name = "Computer", Category = "Electronics", Price = 23.54M });
            Add(new Product { Id = 2, Name = "Laptop", Category = "Electronics", Price = 33.75M });
            Add(new Product { Id = 3, Name = "iPhone4", Category = "Phone", Price = 16.99M });
        }

        public IEnumerable<Product> GetAll()
        {

            //ProductDBContext dbContext = new ProductDBContext();

            // TO DO : Code to get the list of all the records in database
            
            //IEnumerable<Product> products = new List<Product> ();
            //{new Product () {Id = 4, Name = "Makis" , Category = "Human", Price = 99.99M}};

            var productsList = from m in products select m;

            return productsList;

        }

        public Product Get(int id)
        {
            // TO DO : Code to find a record in database
            return products.Find(p => p.Id == id);

        }

        public Product Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to save record into database ????????????????????????????
            item.Id = _nextId++;
            products.Add(item);

            return item;
        }

        public bool Update(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to update record into database
            int index = products.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            products.RemoveAt(index);
            products.Add(item);

            return true;
        }

        public bool Delete(int id)
        {
            // TO DO : Code to remove the records from database
            products.RemoveAll(p => p.Id == id);

            return true;
        }
        /*
        IEnumerable<Product> IProductRepository.GetAll()
        {
            throw new NotImplementedException();
        }*/
    }
}
