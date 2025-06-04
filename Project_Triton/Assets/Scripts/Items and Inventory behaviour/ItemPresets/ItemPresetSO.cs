using UnityEngine;

public abstract class ItemPresetSO : ScriptableObject
{
    private string _uid;
    public string uid => _uid;

    public string itemName;
    public GameObject itemPrefab;
    public Sprite itemIcon;

    public abstract Item CreateItem();

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
