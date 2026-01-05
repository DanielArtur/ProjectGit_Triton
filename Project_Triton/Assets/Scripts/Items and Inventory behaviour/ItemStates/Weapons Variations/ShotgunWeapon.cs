using UnityEngine;

[System.Serializable]
public class ShotgunWeapon : Weapon
{

    public float shotgunSpread;
    public float reloadSpeed;
    public float maxAmmo;

    public ShotgunWeapon(ShotgunSO preset) : base(preset.baseFireRate, preset.baseDamage, preset.baseRange, preset.itemName, preset.uid, preset.itemIcon, preset.itemPrefab)

    {

        shotgunSpread = preset.baseSpread;
        maxAmmo = preset.baseMaxAmmo;
        reloadSpeed = preset.baseReloadSpeed;
    }


    //public override void UseItem()
    //{
    //    Debug.Log($"Using weapon: {itemName}");
    //    // Logic for using the weapon
    //}


    public override void Shoot()
    {

        Debug.Log("Shoot logic here");

    }

}
