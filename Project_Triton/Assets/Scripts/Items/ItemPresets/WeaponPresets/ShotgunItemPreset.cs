using UnityEngine;

[CreateAssetMenu(fileName = "ShotgunItemPreset", menuName = "ScriptableObjects/ShotgunItemPresets/Shotgun")]
public class ShotgunItemPreset : ScriptableObject
{
    [Header("Settings")]
    [SerializeField] float maxAmmo;
    [SerializeField] float fireRate;
    [SerializeField] float reloadSpeed;
    [SerializeField] GameObject itemPrefab;




}
