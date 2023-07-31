using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {



            //------MURAT HOCANIN YAPTIĞI ----

            //optionsBuilder.UseSqlServer("server=DESKTOP-83R1MUR;database=DbNewOopCore1;user id=sa;password=1234;integrated security=true;");




            optionsBuilder.UseSqlServer("server=DESKTOP-83R1MUR;database=DbNewOopCore1;user id=sa;password=1234;persist security info=True;");



        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Job> Jobs { get; set; }




    }
}
