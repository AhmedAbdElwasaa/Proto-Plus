using System.Collections.Generic;
using Test2.Models.Entities;

namespace Test2.Models
{
    public interface IProtoRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
    }
}