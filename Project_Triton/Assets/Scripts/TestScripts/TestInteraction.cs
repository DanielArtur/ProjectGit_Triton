using ItemManagement;
using UnityEngine;
public class TestInteraction : MonoBehaviour
{

    //inventoryItem shotgunItem;

    [SerializeField] ItemConstructor ItemDatabase;
    [SerializeField] ItemPresetSO gfg;
    [SerializeField] PlayerInventory _PlayerInventory;
    [SerializeField] Item testitem11;
    public void doInteraction()
    {

        Debug.Log("You have interacted with object:" + gameObject.name);

        ItemDatabase.TryGetItemPreset(gfg.uid, out ItemPresetSO newPresetToCreate);
        Item newItem = ItemDatabase.CreateItem(newPresetToCreate);

        Debug.Log($"New inventoryItem created: ({newItem})");

        ShotgunWeapon weapon = (ShotgunWeapon)newItem;
        Debug.Log($"If it is a shotgun then it's damage is: ({weapon.damage})");

    }

    void Start()
    {
        // _PlayerInventory.TryAddNewItem(testitem11, 1);
        //   Debug.Log("It works!");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
