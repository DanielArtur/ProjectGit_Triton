using UnityEngine;

[System.Serializable]
public abstract class Weapon : Item
{

    public float fireRate;
    public float damage;
    public float range;

    public Weapon(float baseFireRate, float baseDamage, float baseRange, string name, string itemUID, Sprite itemIcon) : base(name, itemUID, itemIcon, false)
    {
        fireRate = baseFireRate;
        damage = baseDamage;
        range = baseRange;

    }


    //public override void UseItem()
    //{

    //    Debug.Log("Used the item");

    //}

    public abstract void Shoot();

}
