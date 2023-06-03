using InventoryManagement.ConsoleApp.Models;
using InventoryManagement.ConsoleApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.ConsoleApp.Services {
    public class InventoryService : IInventoryService {
        private List<Inventory> _inventories;

        public InventoryService()
        {
            _inventories = new List<Inventory>();
        }

        public void AdjustInventory(int productId, int quantity)
        {
            var inventory = _inventories.FirstOrDefault( i => i.ProductId == productId );
            if (inventory != null)
            {
                inventory.Quantity = quantity;
            }
            else
            {
                _inventories.Add( new Inventory { ProductId = productId, Quantity = quantity } );
            }
        }

        public Inventory GetInventoryByProductId(int productId)
        {
            return _inventories.FirstOrDefault( i => i.ProductId == productId );
        }
    }
}
