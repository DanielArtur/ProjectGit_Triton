using UnityEngine;



interface IInteractable
{
    public void doInteraction();


}

public class Interaction : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Transform camLook;

    [Header("Settings")]
    [SerializeField] float distance;


    RaycastHit hit;
    public bool canInteract = false;


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
            interactObj.doInteraction();

        }

    }



    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(camLook.position, camLook.forward * distance, Color.red);
    }
}
