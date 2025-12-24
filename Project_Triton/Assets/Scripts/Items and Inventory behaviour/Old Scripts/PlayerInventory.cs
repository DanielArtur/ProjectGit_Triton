using QFSW.QC;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{



    public struct InventoryItem
    {
        public Vector2 itemPos { get; set; }
        public Item itemObject { get; set; }

    }


    public class PlayerInventory : MonoBehaviour
    {
        List<InventoryItem> _inventoryItems;
        [SerializeField] GameObject TestItem;


        private void Start()
        {
            _inventoryItems = new List<InventoryItem>();

            //Test
            //_inventoryItems.Add(TestItem.GetComponent<Item>());
        }



        [Command]
        public List<InventoryItem> GetInventory()
        {
            Debug.Log(_inventoryItems);
            return _inventoryItems;
        }

        public bool TryAddNewItem(Item newItem, int quantity)
        {

            InventoryItem i = new InventoryItem();
            i.itemObject = newItem;
            i.itemObject.quantity = quantity;
            i.itemPos = new Vector2(0, 0);

            _inventoryItems.Add(i);
            Debug.Log(_inventoryItems[0].itemObject.itemName);

            ShotgunWeapon shotgun = (ShotgunWeapon)_inventoryItems[0].itemObject;
            Debug.Log("shotgun reload speed is: " + shotgun.reloadSpeed);

            shotgun.reloadSpeed = 6;
            //_inventoryItems[0].itemObject = (Item)shotgun;


            Debug.Log("shotgun reload speed after change is: " + shotgun.reloadSpeed);



            return true;
        }

    }
}

