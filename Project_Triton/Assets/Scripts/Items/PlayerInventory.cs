using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerInventory : NetworkBehaviour
{

    [SerializeField] private List<InventoryItem> _inventoryItems = new();


}


public struct InventoryItem
{

    public ItemPreset preset;

    public int quantity;


}
