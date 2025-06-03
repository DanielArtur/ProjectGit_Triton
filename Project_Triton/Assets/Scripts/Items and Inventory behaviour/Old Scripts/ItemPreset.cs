using UnityEngine;

[CreateAssetMenu(fileName = "ItemPreset", menuName = "ScriptableObjects/ItemPreset")]
public class ItemPreset : ScriptableObject
{
    private string _uid;
    public string uid => _uid;

    [SerializeField] string itemName;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Sprite itemIcon;



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
