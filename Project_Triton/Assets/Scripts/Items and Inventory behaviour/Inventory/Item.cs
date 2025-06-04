using UnityEngine;




[System.Serializable]
public abstract class Item
{
    public string name;
    public string itemID;
    public Sprite itemIcon;
    public int quantity = 1;


    public Item(string name, string itemUID, Sprite itemIcon)
    {
        this.name = name;
        this.itemID = itemUID;
        this.itemIcon = itemIcon;
    }


    public abstract void UseItem();



}


