

using Microsoft.EntityFrameworkCore;
using SimpleProject.Models;
using System.Runtime.CompilerServices;

namespace SimpleProject.Data
{
    public class AppDBContext : DbContext

    {
        public AppDBContext()
        {


        }



        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=simpledb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}






    }

}
