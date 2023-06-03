using InventoryManagement.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.ConsoleApp.Services {
    internal class InventoryService {
        public List<Inventory> Inventories { get; set; }

        public InventoryService()
        {
            Inventories = new List<Inventory>();
        }

        public void AdjustInventory(int productId, int quantity)
        {
        }
    }
}
