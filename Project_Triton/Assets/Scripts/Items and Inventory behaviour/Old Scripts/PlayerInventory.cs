using Unity.Netcode;

public class PlayerInventory : NetworkBehaviour
{

    //[SerializeField] private SyncArray<InventoryItem> _inventoryItems = new();

    //public bool TryAddItem(ItemPresetSO preset, int quantity)
    //{

    //    if (TryStack(preset, quantity))
    //        return true;




    //    return TryAddNewItem(preset, quantity);

    //}

    //public bool TryStack(ItemPresetSO preset, int quantity)
    //{

    //    for (int i = 0; i < _inventoryItems.Length; i++)
    //    {

    //        var invItem = _inventoryItems[i];

    //        if (invItem.preset != preset) continue;


    //        invItem.quantity += quantity;
    //        _inventoryItems[i] = invItem;
    //        return true;

    //    }
    //    return false;

    //}

    //public bool TryAddNewItem(ItemPresetSO preset, int quantity)
    //{

    //    for (int i = 0; i < _inventoryItems.Length; i++)
    //    {
    //        var invItem = _inventoryItems[i];

    //        if (invItem.preset)
    //            continue;

    //        invItem.preset = preset;
    //        invItem.quantity = quantity;
    //        return true;
    //    }

    //    return false;
    //}
}


public struct InventoryItem
{

    public ItemPresetSO preset;

    public int quantity;


}
