using InventoryManagement.ConsoleApp.Models;
using InventoryManagement.ConsoleApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.ConsoleApp.Services {
    public class ProductService : IProductService {
        public List<Product> Products { get; set; }

        public ProductService()
        {
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add( product );
        }
        public void RemoveProduct(Product product)
        {
            Products.Remove( product );
        }
        public void RemoveProduct(int productId)
        {
            var p = Products.First( p => p.Id == productId );
            RemoveProduct( p );
        }
        public void UpdateProduct(Product product)
        {
            RemoveProduct( product );
            AddProduct( product );
        }
    }
}
