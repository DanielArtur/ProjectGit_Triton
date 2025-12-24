using UnityEngine;

public class interactableItem : MonoBehaviour, IInteractable
{
    [SerializeField] ItemDatabase itemDatabase;


    public Item item;

    public interactableItem(Item i)
    {
        item = i;


    }


    private void Start()
    {
        ItemPresetSO newPreset;
        itemDatabase.TryGetItemPreset("a5b809d3b6aa11045b310f4ee3b9d990", out newPreset);
        item = itemDatabase.CreateItem(newPreset);


        //item = new Item("moeo", "1324", null, true);
    }


    public void Interact(Interactor interactor)
    {

        if (!interactor.inventory.TryAddNewItem(item, 1))
        {
            Debug.LogWarning("Could not add item: " + item.itemName);
            return;
        }

        Destroy(gameObject);
    }





}
