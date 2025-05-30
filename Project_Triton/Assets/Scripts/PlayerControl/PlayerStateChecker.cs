using UnityEngine;

public class PlayerStateChecker : MonoBehaviour
{
    public enum PlayerStates
    {
        OnGround,
        InAir,


    }



    public PlayerStates currentState = PlayerStates.OnGround;

    public PlayerStates CurrentState
    {
        get { return currentState; }

    }

    ////////////////////////////////////////////////////////////////Settings////////////////////////////////////////////////////////////////////
    [Header("Settings")]
    [SerializeField] float sphereYPos;
    [SerializeField] float sphereRadius;
    [SerializeField] LayerMask FloorLayers;

    ////////////////////////////////////////////////////////////////Technical Variables////////////////////////////////////////////////////////////////////
    Vector3 checkSpherePos;


    private void FixedUpdate()
    {
        if (GroundCheck())
        {

            currentState = PlayerStates.OnGround;

        }
        else
        {
            currentState = PlayerStates.InAir;
        }



    }

    private bool GroundCheck()
    {

        checkSpherePos = new Vector3(transform.position.x, (transform.position.y + sphereYPos), transform.position.z);

        return Physics.CheckSphere(checkSpherePos, sphereRadius, FloorLayers);


    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(checkSpherePos, sphereRadius);
        Debug.Log("Current player state is:" + currentState);
    }

}
