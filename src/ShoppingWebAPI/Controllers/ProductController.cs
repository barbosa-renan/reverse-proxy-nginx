using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly string[] ProductNames = new[]
        {
            "Xiaomi Redmi Note 8 Pro", "iPhone X", "Amazfit Gts 2 Mini", "Apple Watch", "Notebook Dell Inspiron", "Echo Dot (Gen 4)", "Echo Show 5 (Gen 2)", "Spot Gen 4", "Spot X"
        };

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Product
            {
                Price = rng.Next(1000, 10000),
                Name = ProductNames[rng.Next(ProductNames.Length)]
            })
            .ToArray();
        }
    }
}
