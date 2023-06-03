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
            bool keepRunning = true;
            while (keepRunning) // Main loop
            {
                DrawUI();

                var choice = DataValidator.GetIntInput( "Your option: " );

                switch (choice)
                {
                    case 1: AddProduct(); break;
                    case 2: RemoveProduct(); break;
                    case 3: UpdateProduct(); break;
                    case 4: AdjustInventory(); break;
                    case 5: ViewAllProducts(); break;
                    case 6: keepRunning = false; break;
                    default: Console.WriteLine( "Invalid option." ); break;
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
                _productService.RemoveProductById( removeProductId );
                Console.WriteLine( "Product removed successfully." );
            }
            catch (ArgumentException)
            {
                return;
            }
        }

        private void UpdateProduct()
        {
            try
            {
                var productId = DataValidator.GetIntInput( "Enter the id of the product you want to update: " );
                var existingProduct = _productService.GetProductById( productId );

                if (existingProduct == null)
                {
                    Console.WriteLine( $"Product with id {productId} does not exist." );
                    return;
                }

                var updatedName = DataValidator.GetStringInput( $"Enter new product name (current: {existingProduct.Name}): " );
                var updatedDescription = DataValidator.GetStringInput( $"Enter new product description (current: {existingProduct.Description}): " );
                var updatedPrice = DataValidator.GetDecimalInput( $"Enter new product price (current: {existingProduct.Price}): " );

                var updatedProduct = new Product
                {
                    Id = productId,
                    Name = updatedName,
                    Description = updatedDescription,
                    Price = updatedPrice
                };

                _productService.UpdateProduct( updatedProduct );
                Console.WriteLine( "Product updated successfully." );
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine( ex.Message );
            }
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

                var currentQuantity = _inventoryService.GetInventoryByProductId( products[productIndex].Id ).Quantity;
                Console.WriteLine( $"Current quantity of {products[productIndex].Name}: {currentQuantity}" );

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
