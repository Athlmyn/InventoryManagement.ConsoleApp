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

        }
        public void RemoveProduct(Product product)
        {

        }
        public void RemoveProduct(int productId)
        {
            var p = Products.First( p => p.Id == productId );
            Products.Remove(p);
        }
        public void UpdateProduct(Product product)
        {

        }
    }
}
