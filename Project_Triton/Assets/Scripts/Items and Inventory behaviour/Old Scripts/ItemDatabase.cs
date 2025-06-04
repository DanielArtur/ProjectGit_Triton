using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{

    private Dictionary<string, ItemPresetSO> _itemPreset = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        var presets = Resources.LoadAll<ItemPresetSO>("");

        foreach (var preset in presets)
        {
            if (!_itemPreset.TryAdd(preset.uid, preset))
                Debug.LogError($"Duplicate item preset UID found ({preset.uid})");

        }




    }


    public bool TryGetItemPreset(string uid, out ItemPresetSO preset)
    {

        if (string.IsNullOrEmpty(uid))
        {
            Debug.Log($"No preset with UID: ({uid}) is found. The given preset variable will be set to null");

            preset = null;
            return false;

        }

        return _itemPreset.TryGetValue(uid, out preset);



    }


    public Item CreateItem(ItemPresetSO preset)
    {

        return preset.CreateItem();

    }
}
