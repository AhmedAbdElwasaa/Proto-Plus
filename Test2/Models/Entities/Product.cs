using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test2.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string DeviceDescription { get; set; }
        public string DeviceDating { get; set; }
        public string DeviceId { get; set; }
        public string Manfacturer { get; set; }
        public DateTime ManfacturerBirthDate { get; set; }
        public DateTime ManfacturerDeathDate { get; set; }
        public string ManfacturerNationality { get; set; }
    }
}
