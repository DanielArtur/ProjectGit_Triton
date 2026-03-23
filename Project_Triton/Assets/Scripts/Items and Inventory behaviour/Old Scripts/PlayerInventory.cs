using ItemManagement;
using QFSW.QC;
using System.Collections.Generic;
using UnityEngine;



public struct InventoryItemSlot
{
    public Vector2 itemCellIndex { get; set; }

    //How many cells does item take;

    public Item inventoryItem { get; set; }

}


public class PlayerInventory : MonoBehaviour
{

    [SerializeField] InventoryUIManager inventoryUIManager;

    List<InventoryItemSlot> _inventoryItems;
    [SerializeField] GameObject TestItem;
    [SerializeField] ItemConstructor _itemDatabase;

    [SerializeField] GameObject testItem_Shotgun;

    public Vector2 inventorySize = new Vector2(5, 6);

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

        Vector2 newItemCellIndex;
        if (!IsFreeSpaceAvailable(newItem, out newItemCellIndex))
        {
            return false;
        }


        Debug.Log(newItemCellIndex);

        InventoryItemSlot itemToAdd = new InventoryItemSlot();
        itemToAdd.inventoryItem = newItem;
        itemToAdd.itemCellIndex = newItemCellIndex;

        _inventoryItems.Add(itemToAdd);


        if (inventoryUIManager == null)
            Debug.LogWarning("No inventoryUIManager found");


        // You could add events!
        inventoryUIManager.AddItemIcon(itemToAdd);


        if (_inventoryItems.Contains(itemToAdd))
            return true;




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

    bool IsFreeSpaceAvailable(Item itemToAdd, out Vector2 freeCellIndex)
    {

        if (_inventoryItems.Count == 0)
        {
            freeCellIndex = new Vector2(0, 0);
            return true;
        }

        Vector2 newItemEndCell;
        Vector2 newItemStartCell;
        bool foundFreeSpace;

        for (int currentYCellIndex = 0; currentYCellIndex < inventorySize.y; currentYCellIndex++)
        {
            for (int currentXCellIndex = 0; currentXCellIndex < inventorySize.x; currentXCellIndex++)
            {
                // Choose the area to test whether it is free:
                Rect areaToTest = new Rect(currentXCellIndex + 1, currentYCellIndex + 1, itemToAdd.itemSize.x, itemToAdd.itemSize.y);


                //newItemStartCell = new Vector2(currentXCellIndex, currentYCellIndex);
                //newItemEndCell = new Vector2(currentXCellIndex + ((int)itemToAdd.itemSize.x - 1), currentYCellIndex + ((int)itemToAdd.itemSize.y - 1));

                foundFreeSpace = true;

                //Debug.Log("Testing column. MinCellIndex " + currentXCellIndex + " MaxCellIndex " + newItemEndCell);


                if ((currentXCellIndex + itemToAdd.itemSize.x) > inventorySize.x)
                {
                    Debug.Log("The item is too large for the current row");
                    break;


                }


                foreach (var index in _inventoryItems)
                {
                    // Vector2 testItemStart = index.itemCellIndex;
                    // Vector2 testItemEnd = new Vector2(index.itemCellIndex.x + ((int)index.inventoryItem.itemSize.x - 1), index.itemCellIndex.x + ((int)index.inventoryItem.itemSize.y - 1));
                    //Debug.Log("Running iteratrion. TestItemStartPoint and testItemEnd: " + index.itemCellIndex.x + " " + testItemEnd + " While currentXCellIndex is " + currentXCellIndex + " and MaxCellIndex is " + newItemEndCell);

                    Rect testItem = new Rect(index.itemCellIndex.x + 1, index.itemCellIndex.y + 1, index.inventoryItem.itemSize.x, index.inventoryItem.itemSize.x);



                    if (areaToTest.Overlaps(testItem))
                    {
                        Debug.Log("The cell num. " + currentXCellIndex + " is alredy in use");
                        foundFreeSpace = false;
                        break;

                    }

                }

                //Debug.Log("We were testiing position for MinCelIndex and MaxCellIndex: " + currentXCellIndex + " " + newItemEndCell + ". " + );

                if (!foundFreeSpace)
                {
                    Debug.Log("No free space, Iterate next");
                    continue;

                }
                Debug.Log("Found free space");
                freeCellIndex = new Vector2(currentXCellIndex, currentYCellIndex);
                return true;

            }

        }

        Debug.Log("False");
        freeCellIndex = Vector2.zero;
        return false;
    }


    public void OnDropItem()
    {

        if (TryDropItem(_inventoryItems[0]))
            Debug.Log("The object was succesfully instantiated");


    }

}


