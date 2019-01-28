using System.Collections.Generic;

namespace DiUi
{
    public interface IInventoryData
    {
        Dictionary<InventoryItem, int> MyInventory { get; set; }
    }
}
