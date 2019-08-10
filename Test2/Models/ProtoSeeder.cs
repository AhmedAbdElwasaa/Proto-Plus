using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Test2.Models.Entities;

namespace Test2.Models
{
    public class ProtoSeeder
    {
        private readonly ProtoContext _ctx;
        private readonly IHostingEnvironment _hosting;

        public ProtoSeeder(ProtoContext ctx,IHostingEnvironment hosting)
        {
            _ctx = ctx;
           _hosting = hosting;
        }


        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if(!_ctx.Products.Any())
            {
                //need create sample data
                var filePath = Path.Combine(_hosting.ContentRootPath, "Models/art.json");
                var json = File.ReadAllText(filePath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _ctx.Products.AddRange(products);

                var order = _ctx.Orders.Where(o => o.Id == 2).FirstOrDefault();

                if(order!=null)
                {
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                             Product=products.First(),
                              Quantity=5,
                              UnitPrice=products.First().Price
                        }
                    };
                }


                _ctx.SaveChanges();
            }
        }
    }
}
