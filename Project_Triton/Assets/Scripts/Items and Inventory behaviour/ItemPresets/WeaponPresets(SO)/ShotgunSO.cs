using UnityEngine;

[CreateAssetMenu(fileName = "ShotgunItemPreset", menuName = "ScriptableObjects/Weapons/Shotgun")]
public class ShotgunSO : ItemPresetSO
{
    [Header("Settings")]
    public float baseMaxAmmo;
    public float baseFireRate;
    public float baseReloadSpeed;
    public float baseDamage;
    public float baseRange;
    public float baseSpread;


    public override Item CreateItem()
    {
        Debug.Log($"Create a shotgun with preset: ({this})");
        return new ShotgunWeapon(this);
    }

}