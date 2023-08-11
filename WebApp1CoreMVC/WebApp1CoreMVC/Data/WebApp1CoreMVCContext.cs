using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp1CoreMVC.Models;

namespace WebApp1CoreMVC.Data
{
    public class WebApp1CoreMVCContext : DbContext
    {
        public WebApp1CoreMVCContext (DbContextOptions<WebApp1CoreMVCContext> options)
            : base(options)
        {
        }

        public DbSet<WebApp1CoreMVC.Models.Movie> Movie { get; set; } = default!;
    }
}
