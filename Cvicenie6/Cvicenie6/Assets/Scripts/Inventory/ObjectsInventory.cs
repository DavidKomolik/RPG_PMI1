using System;
using UnityEngine;

public class ObjectsInventory : MonoBehaviour
{
    private const int INVENTORY_SIZE = 12;

    [SerializeField] ItemData[] inventoryItems = new ItemData[INVENTORY_SIZE];

    public ItemData[] InventoryItems => inventoryItems;

    private void OnValidate()
    {
        if (inventoryItems.Length != INVENTORY_SIZE)
        {
            Debug.Log("Don't change the size of inventory!");
            Array.Resize(ref inventoryItems, INVENTORY_SIZE);
        }
    }

    public void AddItem(ItemData itemData, int index)
    {
        inventoryItems[index] = itemData;
    }

    public ItemData RemoveItem(int index)
    {
        var itemData = inventoryItems[index];
        
        inventoryItems[index] = null;

        return itemData;
    }
}