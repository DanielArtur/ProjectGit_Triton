using UnityEngine;

public class TestInteraction : MonoBehaviour, IInteractable
{

    //Item shotgunItem;

    [SerializeField] ItemDatabase ItemDatabase;
    [SerializeField] ItemPresetSO gfg;
    public void doInteraction()
    {

        Debug.Log("You have interacted with object:" + gameObject.name);

        ItemDatabase.TryGetItemPreset(gfg.uid, out ItemPresetSO newPresetToCreate);
        Item newItem = ItemDatabase.CreateItem(newPresetToCreate);

        Debug.Log($"New item created: ({newItem})");

        ShotgunWeapon weapon = (ShotgunWeapon)newItem;
        Debug.Log($"If it is a shotgun then it's damage is: ({weapon.damage})");

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
