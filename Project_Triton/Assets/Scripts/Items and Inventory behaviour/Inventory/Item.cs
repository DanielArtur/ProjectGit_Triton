using UnityEngine;




[System.Serializable]
public class Item : MonoBehaviour
{
    public string itemName;
    public string itemID;
    public Sprite itemIcon;
    public int quantity = 1;
    public bool isStackable = false;
    public bool canEquip = false;

    public Item(string name, string itemUID, Sprite itemIcon, bool isStackable, bool canEquip)
    {
        this.itemName = name;
        this.itemID = itemUID;
        this.itemIcon = itemIcon;
        this.isStackable = isStackable;
        this.canEquip = canEquip;
    }


    // public abstract void UseItem();



}


