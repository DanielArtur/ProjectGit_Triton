using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject PlayerMenuObject;
    [SerializeField] GameObject PlayerInventoryObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Let the system initialize first and only then disable:
        StartCoroutine(DisableUIMenu());

    }

    IEnumerator DisableUIMenu()
    {
        yield return null;

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
