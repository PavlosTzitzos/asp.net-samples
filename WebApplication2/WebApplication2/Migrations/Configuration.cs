namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication2.Models.ProductDBCintext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication2.Models.ProductDBCintext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.\
            context.Products.AddOrUpdate(i => i.Name,
                new Product
                {
                    Name = "Inductor 1uH THT",
                    ExpirationDate = DateTime.Parse("2014-01-01"),
                    QRCode = "29835612",
                    Price = 0.05M
                },
                new Product
                {
                    Name = "Inductor 1uH SMD",
                    ExpirationDate = DateTime.Parse("2015-01-01"),
                    QRCode = "0348765",
                    Price = 0.1M
                },
                new Product
                {
                    Name = "Capacitor 1uH SMD",
                    ExpirationDate = DateTime.Parse("2016-11-01"),
                    QRCode = "09374653",
                    Price = 0.08M
                }
                );
        }
    }
}
