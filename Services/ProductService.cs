using InventoryManagement.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.ConsoleApp.Services {
    internal class ProductService {
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
        public void UpdateProduct(Product product)
        {

        }
    }
}
