using UnityEngine;




[System.Serializable]
public class Item : MonoBehaviour
{
    // There was monobehaviour
    public GameObject itemPrefab;
    public string itemName;
    public string itemUID;
    public Sprite itemIcon;
    public int quantity = 1;
    public bool isStackable = false;
    public bool canEquip = false;
    public Vector2 itemSize;

    public Item(string name, string itemUID, Sprite itemIcon, bool isStackable, bool canEquip, GameObject itemPrefab, Vector2 size)
    {
        this.itemName = name;
        this.itemUID = itemUID;
        this.itemIcon = itemIcon;
        this.isStackable = isStackable;
        this.canEquip = canEquip;
        this.itemPrefab = itemPrefab;
        this.itemSize = size;
    }


    // public abstract void UseItem();



}


