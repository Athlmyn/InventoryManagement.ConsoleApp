using InventoryManagement.ConsoleApp.Services.Interfaces;
using InventoryManagement.ConsoleApp.Services;

namespace InventoryManagement.ConsoleApp {
    internal class Program {
        static void Main(string[] args)
        {
            IProductService productService = new ProductService();
            IInventoryService inventoryService = new InventoryService();
            var manager = new InventoryManager( productService, inventoryService );
            
            var data = new DataSeeder( productService, inventoryService );    
            data.SeedData();

            manager.Run();
        }
    }
}