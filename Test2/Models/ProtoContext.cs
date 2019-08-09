using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2.Models.Entities;

namespace Test2.Models
{
    public class ProtoContext:DbContext
    {
        public ProtoContext(DbContextOptions<ProtoContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Order>().HasData(new Order() {
                   
            //   });
        }
    }
}
