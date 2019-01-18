using System.Collections.Generic;
using UnityEngine;

public class AddingInheritedItemsToList : MonoBehaviour
{
    public List<Item> ItemsList;

    // Start is called before the first frame update
    void Start()
    {
        ItemsList = new List<Item>();
        var newItem = new Item();
        newItem.isMovable = false;
        newItem.ItemType = TestItemType.Basic;

        var advancedItem = new AdvancedItem();
        advancedItem.isMovable = true;
        newItem.ItemType = TestItemType.Advanced;


        ItemsList.Add(newItem);
        ItemsList.Add(advancedItem);

        ReportHitPoints();
    }

    void ReportHitPoints()
    {
        for (int i = 0; i < ItemsList.Count; i++)
        {
            if (ItemsList[i].ItemType == TestItemType.Advanced)
            {
                //var hp = ItemsList[i].HitPoints;
                Debug.LogFormat("Item {0} in List, is Movable", i);
            }
            else
            {
                Debug.LogFormat("Item {0} in List, is Not Movable", i);
            }
        }
    }

    void ReportMovable()
    {
        for (int i = 0; i < ItemsList.Count; i++)
        {
            if (ItemsList[i].isMovable)
            {
                Debug.LogFormat("Item {0} in List, is Movable", i);
            }
            else
            {
                Debug.LogFormat("Item {0} in List, is Not Movable", i);
            }
        }
    }
}

public enum TestItemType
{
    Basic,
    Advanced
}
