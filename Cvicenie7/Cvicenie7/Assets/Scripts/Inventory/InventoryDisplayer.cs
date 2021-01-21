using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplayer : MonoBehaviour
{
    [SerializeField] List<ItemSlot> inventorySlots;

    public void DisplayInventory(ObjectsInventory inventory)
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            inventorySlots[i].ItemSlotID = i;
            inventorySlots[i].ObjectsInventory = inventory;

            if (inventory.InventoryItems[i] == null)
            {
                inventorySlots[i].HideItem();
            }
            else
            {
                inventorySlots[i].ChangeAndShowItem(inventory.InventoryItems[i].Sprite);
            }
        }
    }
}