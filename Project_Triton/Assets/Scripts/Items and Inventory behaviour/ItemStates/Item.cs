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
    public Vector2 size;

    public Item(string name, string itemUID, Sprite itemIcon, bool isStackable, bool canEquip, GameObject itemPrefab)
    {
        this.itemName = name;
        this.itemUID = itemUID;
        this.itemIcon = itemIcon;
        this.isStackable = isStackable;
        this.canEquip = canEquip;
        this.itemPrefab = itemPrefab;
    }


    // public abstract void UseItem();



}


