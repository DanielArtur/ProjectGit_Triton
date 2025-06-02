using Unity.Netcode;
using UnityEngine;


public class Item : NetworkBehaviour
{

    [SerializeField] ItemPreset _preset;
    public ItemPreset preset => _preset;


    void AddItemToInventory()
    {



    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
