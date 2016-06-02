using System;
using System.Collections.Generic;
using Zebo.Domain.Models.Inventory;
using Zebo.Domain.Models.Tickets;

namespace Zebo.Persistance
{

    public interface IInventoryDao
    {
        IEnumerable<InventoryTransaction> GetTransactionItems(DateTime workPeriodStartDate, int warehouseId);
        IEnumerable<InventoryTransaction> GetTransactionItems(DateTime workPeriodStartDate, int inventoryItemId, int warehouseId);
        IEnumerable<Order> GetOrdersFromRecipes(DateTime startDate, int inventoryItemId, int warehouseId);
        IEnumerable<Order> GetOrdersFromRecipes(DateTime startDate, int warehouseId);
        Recipe GetRecipe(string portionName, int menuItemId);
        IEnumerable<string> GetGroupCodes();
        IEnumerable<string> GetInventoryItemNames();
        bool RecipeExists();
        IEnumerable<InventoryItem> GetInventoryItems();
        PeriodicConsumption GetPeriodicConsumptionByWorkPeriodId(int workPeriodId);
        PeriodicConsumptionItem GetPeriodConsumptionItem(int workPeriodId, int inventoryItemId, int warehouseId);
        IEnumerable<string> GetWarehouseNames();
    }
}
