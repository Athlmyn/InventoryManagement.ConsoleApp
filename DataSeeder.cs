using InventoryManagement.ConsoleApp.Models;
using InventoryManagement.ConsoleApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.ConsoleApp {
    internal class DataSeeder {
        private readonly IProductService _productService;
        private readonly IInventoryService _inventoryService;

        public DataSeeder(IProductService productService, IInventoryService inventoryService)
        {
            _productService = productService;
            _inventoryService = inventoryService;
        }
        public void SeedData()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Apple", Description = "A fruit", Price = 0.50m },
                new Product { Id = 2, Name = "Banana", Description = "A fruit", Price = 0.75m },
                new Product { Id = 3, Name = "Orange", Description = "A fruit", Price = 0.60m },
                new Product { Id = 4, Name = "Pear", Description = "A fruit", Price = 0.40m },
                new Product { Id = 5, Name = "Pineapple", Description = "A fruit", Price = 1.00m },
                new Product { Id = 6, Name = "Strawberry", Description = "A fruit", Price = 0.25m },
                new Product { Id = 7, Name = "Blueberry", Description = "A fruit", Price = 0.30m },
                new Product { Id = 8, Name = "Raspberry", Description = "A fruit", Price = 0.35m },
                new Product { Id = 9, Name = "Blackberry", Description = "A fruit", Price = 0.40m },
                new Product { Id = 10, Name = "Watermelon", Description = "A fruit", Price = 1.50m },
                new Product { Id = 11, Name = "Cantaloupe", Description = "A fruit", Price = 1.25m },
                new Product { Id = 12, Name = "Honeydew", Description = "A fruit", Price = 1.25m },
                new Product { Id = 13, Name = "Kiwi", Description = "A fruit", Price = 0.75m },
                new Product { Id = 14, Name = "Mango", Description = "A fruit", Price = 1.00m },
                new Product { Id = 15, Name = "Peach", Description = "A fruit", Price = 0.50m },
                new Product { Id = 16, Name = "Plum", Description = "A fruit", Price = 0.50m },
                new Product { Id = 17, Name = "Cherry"}
            };
            foreach (var product in products)
            {
                _productService.AddProduct(product);
                _inventoryService.AdjustInventory(product.Id, 100);
            }
        }
    }
}
