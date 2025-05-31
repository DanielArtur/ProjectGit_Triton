using UnityEngine;

public class PlayerStateChecker : MonoBehaviour
{
    public enum PlayerStates
    {
        OnGround,
        InAir,


    }



    PlayerStates currentState = PlayerStates.OnGround;

    public PlayerStates CurrentState
    {
        get { return currentState; }

    }

    ContactPoint contactPoint;
    public ContactPoint ContactPoint
    {
        get { return contactPoint; }

    }

    ////////////////////////////////////////////////////////////////Settings////////////////////////////////////////////////////////////////////
    [Header("Settings")]
    [SerializeField] float sphereYPos;
    [SerializeField] float sphereRadius;
    [SerializeField] LayerMask FloorLayers;
    [SerializeField] LayerMask wallLayers;


    [SerializeField] float wallCheckRadius;
    [SerializeField] float upperPos;
    [SerializeField] float lowerPos;


    ////////////////////////////////////////////////////////////////Technical Variables////////////////////////////////////////////////////////////////////
    //GroundCheck
    Vector3 checkSpherePos;

    //WallCheck
    public RaycastHit wallhit;
    Vector3 startPos;
    Vector3 endPos;
    public bool nearWall = false;
    // Layers


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

        // Check if we are close to an obstacle that we have to move along
        // nearWall = WallCheck();

    }

    //bool WallCheck()
    //{
    //    startPos = new Vector3(transform.position.x, transform.position.y + upperPos, transform.position.z);
    //    endPos = new Vector3(transform.position.x, transform.position.y + lowerPos, transform.position.z);

    //    //Physics.CapsuleCast(startPos, endPos, wallCheckRadius, transform.up, out wallhit, 1, wallLayers);
    //   // return Physics.SphereCast(transform.position, wallCheckRadius, transform.up, out wallhit, 1, wallLayers);
    //}

    private bool GroundCheck()
    {

        checkSpherePos = new Vector3(transform.position.x, (transform.position.y + sphereYPos), transform.position.z);

        return Physics.CheckSphere(checkSpherePos, sphereRadius, FloorLayers);


    }



    private void OnCollisionStay(Collision collision)
    {
        if ((wallLayers.value & (1 << collision.collider.gameObject.layer)) != 0)
        {

            nearWall = true;


            contactPoint = collision.contacts[0];

        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (nearWall)
        {

            nearWall = false;
            Debug.Log("Exit wall");
        }


    }

    private void OnDrawGizmosSelected()
    {
        Debug.Log("Current player state is:" + currentState);

        //GroundCheck
        Gizmos.DrawSphere(checkSpherePos, sphereRadius);

        //WallCheck
        Gizmos.DrawWireSphere(startPos, wallCheckRadius);
        Gizmos.DrawWireSphere(endPos, wallCheckRadius);





    }

}
