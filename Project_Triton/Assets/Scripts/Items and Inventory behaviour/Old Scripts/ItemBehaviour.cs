using UnityEngine;

public class ItemBehaviour : MonoBehaviour, IInteractable
{
    public void doInteraction()
    {

        Debug.Log("You have interacted with object:" + gameObject.name);
        Object.Destroy(gameObject);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
