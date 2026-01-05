using System.Collections.Generic;
using UnityEngine;


namespace ItemManagement
{

    public class ItemConstructor : MonoBehaviour
    {

        private Dictionary<string, ItemPresetSO> _itemPreset = new();

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            var presets = Resources.LoadAll<ItemPresetSO>("");

            foreach (var preset in presets)
            {
                if (!_itemPreset.TryAdd(preset.uid, preset))
                    Debug.LogError($"Duplicate inventoryItem preset UID found ({preset.uid})");

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

        public GameObject InstantiateItem(Item itemToInstantiate, Vector3 pos, Quaternion rot)
        {

            Debug.Log("Instantiating object " + itemToInstantiate.itemName);

            GameObject createdItem = Instantiate(itemToInstantiate.itemPrefab, pos, rot);

            createdItem.GetComponent<interactableItem>().item = itemToInstantiate;

            return createdItem;


        }
        public Item CreateItem(ItemPresetSO preset)
        {

            return preset.CreateItem();

        }
    }
}
