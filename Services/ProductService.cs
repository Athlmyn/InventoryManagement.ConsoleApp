using InventoryManagement.ConsoleApp.Models;
using InventoryManagement.ConsoleApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.ConsoleApp.Services {
    public class ProductService : IProductService {
        private List<Product> _products;
        private int _nextId = 1;

        public ProductService()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product newProduct)
        {
            if (_products.Any( p => p.Name == newProduct.Name && p.Id == newProduct.Id ))
            {
                throw new ArgumentException( $"Product with name {newProduct.Name} and id {newProduct.Id} already exists." );
            }

            newProduct.Id = _nextId++;

            _products.Add( newProduct );
        }
        public void RemoveProduct(Product product)
        {
            _products.Remove( product );
        }
        public void RemoveProductById(int productId)
        {
            var p = _products.First( p => p.Id == productId );
            RemoveProduct( p );
        }
        public void UpdateProduct(Product updatedProduct)
        {
            Product? existingProduct = GetProductById( updatedProduct.Id );

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;
        }

        public Product GetProductById(int productId)
        {
            var existingProduct = _products.FirstOrDefault( p => p.Id == productId );

            if (existingProduct == null)
            {
                throw new ArgumentException( $"Product with id {productId} does not exist." );
            }

            return existingProduct;
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }
    }
}
