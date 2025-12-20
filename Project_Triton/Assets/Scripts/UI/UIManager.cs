using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    PlayerInput PlayerInput;
    [SerializeField] GameObject PlayerMenuObject;
    [SerializeField] GameObject PlayerInventoryObject;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerInput = GetComponent<PlayerInput>();
        PlayerMenuObject.SetActive(false);
        PlayerInventoryObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnToggle_PlayerMenu()
    {
        if (PlayerMenuObject.activeSelf == true)
            PlayerMenuObject.SetActive(false);

        else PlayerMenuObject.SetActive(true);

        Debug.Log("Open Player Menu");


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
        Debug.Log("Open Player Menu");


    }
}
