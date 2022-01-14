using Microsoft.EntityFrameworkCore;
using RestaurantLibrarys.Entities.EntitiesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestaurantFinder.DataAccess
{
    public class RestaurantDbContext : DbContext
    {
        //DataAccess katmanında entityframework işlemlerimizi yapacağız

        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=RestaurantDb; Trusted_Connection=True;");
        }
        //DbSet sayesinde add, remove, update gibi işlemleri yapan metodlara ulaşmış olduk
        public DbSet<Restaurant> restaurants => Set<Restaurant>();
        public DbSet<Employee> employees => Set<Employee>();

    }
}
