using UnityEngine;

public class interactableItem : MonoBehaviour, IInteractable
{

    [HideInInspector] public Item item;
    public ItemPresetSO preset;

    // Item Data



    void Start()
    {

        if (preset != null)
        {

            item = preset.CreateItem();
            AssignName();

        }


    }

    public void AssignName()
    {

        gameObject.name = item.itemName;
    }


    public void Interact(Interactor interactor)
    {

        if (!interactor.inventory.TryAddNewItem(item, 1))
        {
            Debug.LogWarning("Could not add item: " + item.itemName);
            return;
        }

        //Destroy(gameObject);
    }





}
