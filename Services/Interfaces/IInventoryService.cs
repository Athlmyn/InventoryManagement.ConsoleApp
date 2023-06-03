using InventoryManagement.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.ConsoleApp.Services.Interfaces {
    public interface IInventoryService {
        void AdjustInventory(int productId, int quantity);
        Inventory GetInventoryByProductId(int productId);
    }
}
