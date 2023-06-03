using InventoryManagement.ConsoleApp.Models;
using InventoryManagement.ConsoleApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.ConsoleApp.Services {
    public class InventoryService : IInventoryService {
        public List<Inventory> Inventories { get; set; }

        public InventoryService()
        {
            Inventories = new List<Inventory>();
        }

        public void AdjustInventory(int productId, int quantity)
        {
            var inventory = Inventories.FirstOrDefault( i => i.ProductId == productId );
            if (inventory != null)
            {
                inventory.Quantity = quantity;
            }
            else
            {
                Inventories.Add( new Inventory { ProductId = productId, Quantity = quantity } );
            }
        }
    }
}
