using QFSW.QC;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOperations : MonoBehaviour
{

    List<Item> _inventoryItems;

    [Command]
    public List<Item> GetInventory()
    {
        Debug.Log(_inventoryItems);
        return _inventoryItems;
    }

    //public bool CreateNewInventory()
    //{

    //    _inventoryItems = new List<inventoryItem>();




    //}

    public bool TryAddItem(Item newItem, int quantity, int[] cellsOccupied)
    {

        if (newItem.isStackable || TryStack(newItem, quantity))
            return true;


        return TryAddNewItem(newItem, quantity);

    }

    public bool TryStack(Item newItem, int quantity)
    {

        for (int i = 0; i < _inventoryItems.Count; i++)
        {

            var invItem = _inventoryItems[i];

            if (invItem != newItem) continue;


            invItem.quantity += quantity;
            _inventoryItems[i] = invItem;
            return true;

        }
        return false;

    }

    public bool TryAddNewItem(Item newItem, int quantity)
    {

        for (int i = 0; i < _inventoryItems.Count; i++)
        {
            var invItem = _inventoryItems[i];

            if (invItem != null)
                continue;

            invItem = newItem;
            invItem.quantity = quantity;
            _inventoryItems[i] = invItem;
            return true;
        }

        return false;
    }

}
