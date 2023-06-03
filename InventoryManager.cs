using InventoryManagement.ConsoleApp.Models;
using InventoryManagement.ConsoleApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.ConsoleApp {
    internal class InventoryManager {
        private readonly IProductService _productService;
        private readonly IInventoryService _inventoryService;

        public InventoryManager(IProductService productService, IInventoryService inventoryService)
        {
            _productService = productService;
            _inventoryService = inventoryService;
        }

        public void Run()
        {
            while (true) // Main loop
            {
                DrawUI();

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1": // Add product
                        AddProduct();
                        break;

                    case "2": // Remove product
                        RemoveProduct();
                        break;

                    case "3": // Update product
                        UpdateProduct();
                        break;

                    case "4": // Adjust inventory
                        AdjustInventory();
                        break;

                    case "5": // View all products
                        ViewAllProducts();
                        break;

                    case "6": // Exit
                        return;

                    default:
                        Console.WriteLine( "Invalid option, please choose again." );
                        break;
                }
            }

            
        }
        private void DrawUI()
        {
            Console.WriteLine( "***********************************" );
            Console.WriteLine( "Welcome to the Inventory Manager!" );
            Console.WriteLine( "1. Add Product" );
            Console.WriteLine( "2. Remove Product" );
            Console.WriteLine( "3. Update Product" );
            Console.WriteLine( "4. Adjust Inventory" );
            Console.WriteLine( "5. View All Products" );
            Console.WriteLine( "6. Exit" );
            Console.Write( "Choose an option: " );
        }

        private void AddProduct()
        {
            var newProduct = new Product();

            try
            {
                newProduct.Name = DataValidator.GetStringInput( "Enter product name: " );
                newProduct.Description = DataValidator.GetStringInput( "Enter product description: " );
                newProduct.Price = DataValidator.GetDecimalInput( "Enter product price: " );

                _productService.AddProduct( newProduct );
                Console.WriteLine( $"Product added successfully with ID {newProduct.Id}." );
            }   
            catch (ArgumentException ex)
            {
                Console.WriteLine( ex.Message );
            }
        }

        private void RemoveProduct()
        {
            try
            {
                var removeProductId = DataValidator.GetIntInput( "Enter product id to remove: " );
                _productService.RemoveProduct( removeProductId );
                Console.WriteLine( "Product removed successfully." );
            }
            catch (ArgumentException)
            {
                return;
            }
        }

        private void UpdateProduct()
        {
            var updateProduct = new Product();

            try
            {
                updateProduct.Id = DataValidator.GetIntInput( "Enter product id: " );
                updateProduct.Name = DataValidator.GetStringInput( "Enter new product name: " );
                updateProduct.Description = DataValidator.GetStringInput( "Enter new product description: " );
                updateProduct.Price = DataValidator.GetDecimalInput( "Enter new product price: " );
            }
            catch (ArgumentException)
            {
                return;
            }

            _productService.UpdateProduct( updateProduct );
            Console.WriteLine( "Product updated successfully." );
        }

        private void AdjustInventory()
        {
            try
            {
                Console.WriteLine( "Select a product to adjust inventory:" );
                var products = _productService.GetAllProducts();
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine( $"{i + 1}. {products[i].Name}" );
                }

                var productIndex = DataValidator.GetIntInput( "" ) - 1; // Convert from 1-based to 0-based index
                if (productIndex < 0 || productIndex >= products.Count)
                {
                    Console.WriteLine( "Invalid selection." );
                    return;
                }

                var quantity = DataValidator.GetIntInput( "Enter new quantity: " );

                _inventoryService.AdjustInventory( products[productIndex].Id, quantity );
                Console.WriteLine( "Inventory adjusted successfully." );
            }
            catch (ArgumentException)
            {
                return;
            }
        }

        private void ViewAllProducts()
        {
            Console.WriteLine( "All Products:" );
            foreach (var product in _productService.GetAllProducts())
            {
                Console.WriteLine( $"Id: {product.Id}, Name: {product.Name}, Description: {product.Description}, Price: {product.Price}" );
            }
        }
    }
}
