using UnityEngine;

[CreateAssetMenu(fileName = "ShotgunItemPreset", menuName = "ScriptableObjects/ShotgunItemPresets/Shotgun")]
public class ShotgunItemPreset : ScriptableObject
{
    private string _uid;
    public string uid => _uid;

    [Header("Settings")]
    public string itemName;
    public float baseMaxAmmo;
    public float baseFireRate;
    public float baseReloadSpeed;
    public float baseDamage;
    public float baseRange;
    public Sprite baseSprite;

    [SerializeField] GameObject itemPrefab;



#if UNITY_EDITOR
    private void OnValidate()
    {
        var assetPath = UnityEditor.AssetDatabase.GetAssetPath(this);


        if (assetPath == null)
        {

            _uid = string.Empty;
            return;

        }


        var assetGuid = UnityEditor.AssetDatabase.GUIDFromAssetPath(assetPath).ToString();

        if (string.IsNullOrEmpty(_uid) || _uid == assetGuid)
            _uid = assetGuid;
    }


#endif
}
