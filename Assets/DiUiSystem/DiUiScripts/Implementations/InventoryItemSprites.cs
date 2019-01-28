using System.Collections.Generic;
using UnityEngine;

namespace DiUi
{
    public class InventoryItemSprites : MonoBehaviour, IInventoryItemSprites
    {
        public List<ItemIcon> Icons;

        public Sprite GetIcon(InventoryItem item)
        {
            for (int i = 0; i < Icons.Count; i++)
            {
                if (Icons[i].Type == item)
                {
                    return Icons[i].Icon;
                }
            }

            return null;
        }
    }

    [System.Serializable]
    public struct ItemIcon
    {
        public InventoryItem Type;
        public Sprite Icon;
    }
}
