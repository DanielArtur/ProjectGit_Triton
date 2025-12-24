using Inventory;
using UnityEngine;


public class Interactor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform camLook;
    public PlayerInventory inventory;


    [Header("Settings")]
    [SerializeField] float distance;


    RaycastHit hit;
    public bool canInteract = false;

    private void Start()
    {
        inventory = GetComponent<PlayerInventory>();



    }



    void Update()
    {

        if (Physics.Raycast(camLook.position, camLook.forward, out hit, distance))
        {
            if (hit.transform.CompareTag("Interactable"))
            {
                canInteract = true;
                return;
            }

        }


        canInteract = false;
    }


    void OnInteract()
    {

        if (!canInteract)
            return;


        if (hit.transform.TryGetComponent(out IInteractable interactObj))
        {
            if (interactObj == null)
            {
                Debug.LogWarning("Interactable object " + interactObj + " is null");
                return;
            }

            interactObj.Interact(this);

        }

    }



    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(camLook.position, camLook.forward * distance, Color.red);
    }
}
