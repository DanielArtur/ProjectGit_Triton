using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject PlayerMenuObject;
    [SerializeField] GameObject PlayerInventoryObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerMenuObject.SetActive(false);
        PlayerInventoryObject.SetActive(true);

    }



    void OnToggle_PlayerMenu()
    {
        if (PlayerMenuObject.activeSelf == true)
            PlayerMenuObject.SetActive(false);

        else PlayerMenuObject.SetActive(true);



    }


    void OnToggle_PlayerInventory()
    {
        if (PlayerMenuObject.activeSelf == true && PlayerInventoryObject.activeSelf == true)
        {
            PlayerMenuObject.SetActive(false);

        }

        else
        {
            PlayerMenuObject.SetActive(true);
            PlayerInventoryObject.SetActive(true);


        }


    }
}
