using System.Collections.Generic;

namespace DiUi
{
    public class InventoryData : IInventoryData
    {
        public Dictionary<InventoryItem, int> MyInventory { get; set; }

        public InventoryData()
        {
            MyInventory = new Dictionary<InventoryItem, int>
            {
                { InventoryItem.Crystal, 100 },
                { InventoryItem.Ore, 9 },
                { InventoryItem.Wood, 9999 }
            };
        }

    }

    public enum InventoryItem
    {
        Wood,
        Crystal,
        Ore
    }
}