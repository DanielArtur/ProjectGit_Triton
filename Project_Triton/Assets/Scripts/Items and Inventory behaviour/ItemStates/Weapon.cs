using UnityEngine;

[System.Serializable]
public abstract class Weapon : Item
{

    public float fireRate;
    public float damage;
    public float range;

    public Weapon(float baseFireRate, float baseDamage, float baseRange, string name, string itemUID, Sprite itemIcon, GameObject weaponPrefab, Vector2 size) : base(name, itemUID, itemIcon, false, true, weaponPrefab, size)
    {
        fireRate = baseFireRate;
        damage = baseDamage;
        range = baseRange;

    }


    //public override void UseItem()
    //{

    //    Debug.Log("Used the inventoryItem");

    //}

    public abstract void Shoot();

}
