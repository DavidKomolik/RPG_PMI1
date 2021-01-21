using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryController : MonoBehaviour
{
    [SerializeField] ObjectsInventory playerInventory;

    [SerializeField] GameObject inventoryContainer;
    [SerializeField] InventoryDisplayer playerInventoryDisplayer;
    [SerializeField] InventoryDisplayer otherInventoryDisplayer;
    
    //used to visualise dragging items
    [SerializeField] ItemSlot dummySlot;

    private ItemSlot _oldItemSlot;
    private bool _isInventoryOpened;
    private bool _isDraggingItem;

    void Update()
    {
        if (_isInventoryOpened == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CheckForObjectWithInventory();
            }
        }

        if (_isInventoryOpened)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CheckForStartItemDragging();
            }

            if (Input.GetMouseButtonUp(0) && _isDraggingItem)
            {
                EndItemDragging();
            }

            if (Input.GetMouseButton(0) && _isDraggingItem)
            {
                dummySlot.transform.position = Input.mousePosition;
            }
        }
    }

    private void CheckForObjectWithInventory()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.transform.gameObject.TryGetComponent(out ObjectsInventory inventory))
            {
                if (inventory == playerInventory)
                    return;

                _isInventoryOpened = true;
                inventoryContainer.SetActive(true);

                //fill inventories
                playerInventoryDisplayer.DisplayInventory(playerInventory);
                otherInventoryDisplayer.DisplayInventory(inventory);
            }
        }
    }

    private void CheckForStartItemDragging()
    {
        var itemSlot = GetItemSlotOnMousePosition();

        if (itemSlot == null || itemSlot.IsEmpty)
            return;

        itemSlot.HideItem();
        _oldItemSlot = itemSlot;

        dummySlot.gameObject.SetActive(true);
        dummySlot.ChangeAndShowItem(itemSlot.ItemSprite);

        _isDraggingItem = true;
    }

    private void EndItemDragging()
    {
        var newItemSlot = GetItemSlotOnMousePosition();

        if (newItemSlot == null)
            return;

        if (newItemSlot.IsEmpty)
        {
            _oldItemSlot.HideItem();
            newItemSlot.ChangeAndShowItem(_oldItemSlot.ItemSprite);

            MoveItem(_oldItemSlot, newItemSlot);
        }
        else
        {
            _oldItemSlot.ShowItem();
        }

        _isDraggingItem = false;
        dummySlot.gameObject.SetActive(false);
    }

    private void MoveItem(ItemSlot fromItemSlot, ItemSlot toItemSlot)
    {
        var fromInventory = fromItemSlot.ObjectsInventory;
        var toInventory = toItemSlot.ObjectsInventory;

        var itemData = fromInventory.RemoveItem(fromItemSlot.ItemSlotID);
        toInventory.AddItem(itemData, toItemSlot.ItemSlotID);
    }

    private ItemSlot GetItemSlotOnMousePosition()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, raycastResults);

        ItemSlot itemSlotOnMousePosition = null;
        for (int i = 0; i < raycastResults.Count; i++)
        {
            if (raycastResults[i].gameObject.TryGetComponent(out ItemSlot itemSlot))
            {
                itemSlotOnMousePosition = itemSlot;
            }
        }

        return itemSlotOnMousePosition;
    }

    public void CloseInventory()
    {
        _isInventoryOpened = false;
        inventoryContainer.SetActive(false);
    }
}
