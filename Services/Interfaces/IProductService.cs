using InventoryManagement.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.ConsoleApp.Services.Interfaces {
    public interface IProductService {
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        void RemoveProduct(int productId);
        void UpdateProduct(Product product);
        List<Product> GetAllProducts();
    }
}
