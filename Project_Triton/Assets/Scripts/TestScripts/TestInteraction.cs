using UnityEngine;

public class TestInteraction : MonoBehaviour, IInteractable
{

    //Item shotgunItem;
    [SerializeField] ItemDatabase _ItemDatabase;
    [SerializeField] ShotgunItemPreset _Preset;

    ShotgunItemPreset newPreset;
    public void doInteraction()
    {

        // shotgunItem = new Shotgun_Weapon();
        // shotgunItem.model

        Debug.Log("You have interacted with object:" + gameObject.name);

        _ItemDatabase.TryGetItemPreset(_Preset.uid, out newPreset);
        Debug.Log($"new ShotgunItemPreset fetched: ({newPreset})");
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
