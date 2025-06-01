using Unity.Cinemachine;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayerCameraControl : NetworkBehaviour
{

    GameObject InstanceOfCinemachineCam;
    public GameObject GetInstanceOfCinemachineCam
    {

        get { return InstanceOfCinemachineCam; }

    }

    [Header("References")]
    [SerializeField] GameObject FirstPersonCameraPrefab;





    void Start()
    {
        if (IsOwner)
        {
            InstanceOfCinemachineCam = Instantiate(FirstPersonCameraPrefab);
            InstanceOfCinemachineCam.GetComponent<CinemachineCamera>().Follow = transform;
            Debug.Log("Cam created");

            GetComponentInParent<NetworkPlayerMovement>().SetOrientation = InstanceOfCinemachineCam.transform;

        }

    }





}
