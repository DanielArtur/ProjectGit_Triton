using UnityEngine;

[System.Serializable]
public class ShotgunItem : Item
{

    readonly string itemType = "Weapon";

    float maxAmmo;
    float fireRate;
    float damage;
    float range;
    float reloadSpeed;
    GameObject itemPrefab;



    public ShotgunItem(ShotgunItemPreset preset)
        : base(preset.name, preset.uid, preset.baseSprite)
    {
        damage = preset.baseDamage;
        range = preset.baseRange;
        fireRate = preset.baseFireRate;
        reloadSpeed = preset.baseReloadSpeed;
        maxAmmo = preset.baseMaxAmmo;
    }


    public override void UseItem()
    {
        Debug.Log($"Using weapon: {name}");
        // Logic for using the weapon
    }
}
