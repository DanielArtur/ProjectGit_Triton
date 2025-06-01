using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkUIManager : MonoBehaviour
{

    [SerializeField] Button serverButton;
    [SerializeField] Button hostButton;
    [SerializeField] Button clientButton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        serverButton.onClick.AddListener(() => { NetworkManager.Singleton.StartServer(); });
        hostButton.onClick.AddListener(() => { NetworkManager.Singleton.StartHost(); });
        clientButton.onClick.AddListener(() => { NetworkManager.Singleton.StartClient(); });


    }

    // Update is called once per frame
    void Update()
    {

    }
}
