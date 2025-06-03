using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{

    private Dictionary<string, ShotgunItemPreset> _itemPreset = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        var presets = Resources.LoadAll<ShotgunItemPreset>("");

        foreach (var preset in presets)
        {
            if (!_itemPreset.TryAdd(preset.uid, preset))
                Debug.LogError($"Duplicate item preset UID found ({preset.uid})");

        }




    }


    public bool TryGetItemPreset(string uid, out ShotgunItemPreset preset)
    {

        if (string.IsNullOrEmpty(uid))
        {
            preset = null;
            return false;
        }

        return _itemPreset.TryGetValue(uid, out preset);



    }
}
