using UnityEngine;

public class TestInteraction : MonoBehaviour, IInteractable
{

    //Item shotgunItem;


    public void doInteraction()
    {

        // shotgunItem = new Shotgun_Weapon();
        // shotgunItem.model

        Debug.Log("You have interacted with object:" + gameObject.name);

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
