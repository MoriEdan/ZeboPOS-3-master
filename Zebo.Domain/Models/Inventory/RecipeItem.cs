using Zebo.Infrastructure.Data;

namespace Zebo.Domain.Models.Inventory
{
    public class RecipeItem : ValueClass
    {
        public int RecipeId { get; set; }
        public virtual InventoryItem InventoryItem { get; set; }
        public decimal Quantity { get; set; }
    }
}
