using UnityEngine;

namespace DiUi
{
    public interface IInventoryItemSprites
    {
        Sprite GetIcon(InventoryItem item);
    }
}
