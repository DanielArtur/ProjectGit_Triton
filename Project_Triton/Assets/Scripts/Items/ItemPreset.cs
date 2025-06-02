using UnityEngine;

[CreateAssetMenu(fileName = "ItemPreset", menuName = "ScriptableObjects/ItemPreset")]
public class ItemPreset : ScriptableObject
{
    readonly public string uid;
    [SerializeField] string itemName;
    [SerializeField] Item itemPrefab;
    [SerializeField] Sprite itemIcon;



#if UNITY_EDITOR
    private void OnValidate()
    {

    }


#endif
}
