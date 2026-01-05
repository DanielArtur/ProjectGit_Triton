using ItemManagement;
using QFSW.QC;
using System.Collections.Generic;
using UnityEngine;



public struct InventoryItemSlot
{
    public Vector2 ItemPos { get; set; }

    //How many cells does item take;
    public Vector2 cellIndex { get; set; }

    public Item inventoryItem { get; set; }

}


public class PlayerInventory : MonoBehaviour
{

    [SerializeField] InventoryUIManager inventoryUIManager;

    List<InventoryItemSlot> _inventoryItems;
    [SerializeField] GameObject TestItem;
    [SerializeField] ItemConstructor _itemDatabase;

    [SerializeField] GameObject testItem_Shotgun;


    Vector2 inventorySize;
    private void Start()
    {
        _inventoryItems = new List<InventoryItemSlot>();

        //Test
        //_inventoryItems.Add(TestItem.GetComponent<inventoryItem>());


        //ItemPresetSO newPreset;
        //_itemDatabase.TryGetItemPreset("a5b809d3b6aa11045b310f4ee3b9d990", out newPreset);
        //Item createdItem = _itemDatabase.CreateItem(newPreset);

        //ShotgunWeapon newShotgun = (ShotgunWeapon)createdItem;
        //newShotgun.fireRate = 100;

        //createdItem = (Item)newShotgun;


        //ShotgunWeapon shotgunWeapon2 = (ShotgunWeapon)createdItem;
        //Debug.Log("Created inventoryItem " + createdItem.itemName + ". Its fireRate is " + shotgunWeapon2.fireRate);

        //testItem_Shotgun.GetComponent<interactableItem>().item = createdItem;



    }



    [Command]
    public List<InventoryItemSlot> GetInventory()
    {
        Debug.Log(_inventoryItems);
        return _inventoryItems;
    }

    public bool TryAddNewItem(Item newItem, int quantity)
    {
        Vector2 newItemPosition;

        if (!IsFreeSpaceAvailable(newItem, out newItemPosition))
        {
            Debug.Log("No free space");
            return false;
        }




        var itemToAdd = new InventoryItemSlot();
        itemToAdd.inventoryItem = newItem;
        itemToAdd.ItemPos = newItemPosition;

        _inventoryItems.Add(itemToAdd);

        if (inventoryUIManager == null)
            Debug.LogWarning("No inventoryUIManager found");
        // You could add events!
        inventoryUIManager.AddItemIcon(itemToAdd);


        if (_inventoryItems.Contains(itemToAdd))
        {
            Debug.Log("Now your inventory contains createdItem: " + _inventoryItems[0].inventoryItem.itemName);
            return true;

        }
        return false;
    }


    public bool TryDropItem(InventoryItemSlot itemToDrop)
    {

        Item i = itemToDrop.inventoryItem;
        _inventoryItems.Remove(itemToDrop);
        Debug.Log("The object is null? " + _inventoryItems.Contains(itemToDrop));

        GameObject droppedItem = _itemDatabase.InstantiateItem(i, this.gameObject.transform.position, Quaternion.identity);
        ShotgunWeapon weaponItem = (ShotgunWeapon)droppedItem.GetComponent<interactableItem>().item;
        Debug.Log("The shotgun that we threw has fire rate of " + weaponItem.fireRate);

        return droppedItem != null;

    }

    bool IsFreeSpaceAvailable(Item newItem, out Vector2 freeCellIndex)
    {
        float spaceToTry;

        for (int currentRowIndex = 0; currentRowIndex < inventorySize.y; currentRowIndex++)
        {
            for (int currentCellIndex = 0; currentCellIndex < inventorySize.x; currentCellIndex++)
            {
                // Choose the cells to test whether they are free:
                spaceToTry = currentCellIndex + newItem.size.x;

                foreach (var index in _inventoryItems)
                {

                    if (currentCellIndex == index.cellIndex.x)
                        continue;

                    freeCellIndex = new Vector2(currentCellIndex, currentRowIndex);
                    return true;


                }


            }

        }

        freeCellIndex = Vector2.zero;
        return false;
    }


    public void OnDropItem()
    {

        if (TryDropItem(_inventoryItems[0]))
            Debug.Log("The object was succesfully instantiated");


    }

}


