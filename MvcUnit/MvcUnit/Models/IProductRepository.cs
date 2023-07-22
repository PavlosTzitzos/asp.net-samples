using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace MvcUnit.Models
{

    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        Product Add(Product item);
        bool Update(Product item);
        bool Delete(int id);
    }
    /*
    public class IProductRepositoryDBContext : DbContext
    {
        public IProductRepositoryDBContext() { }
        //public DbSet<IProductRepository> IProductRepositorys { get; set; }

    }*/
}