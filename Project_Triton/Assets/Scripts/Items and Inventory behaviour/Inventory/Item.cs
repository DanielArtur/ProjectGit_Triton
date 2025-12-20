using UnityEngine;




[System.Serializable]
public abstract class Item
{
    public string name;
    public string itemID;
    public Sprite itemIcon;
    public int quantity = 1;
    public bool isStackable = false;

    public Item(string name, string itemUID, Sprite itemIcon, bool isStackable)
    {
        this.name = name;
        this.itemID = itemUID;
        this.itemIcon = itemIcon;
        this.isStackable = isStackable;
    }


    public abstract void UseItem();



}


