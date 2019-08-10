using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test2.Models.Entities;

namespace Test2.Models
{
    public class ProtoRepository : IProtoRepository
    {
        private readonly ProtoContext _context;
        private readonly ILogger<ProtoRepository> _logger;

        public ProtoRepository(ProtoContext context,ILogger<ProtoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
            _logger.LogInformation("GetAllProducts was called");
            return _context.Products
                .OrderBy(p => p.Title)
                .ToList();

            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            try
            {
                _logger.LogInformation("GetProductsByCategory was called");

                return _context.Products
                .Where(p => p.Category == category)
                .ToList();

            }
            catch (Exception ex)
            {

                _logger.LogError($"Failed to get  productsBycategory: {ex}");
                return null;
            }
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
