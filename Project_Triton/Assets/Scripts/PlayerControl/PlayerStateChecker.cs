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

    ContactPoint[] contactPoints = new ContactPoint[6];
    public ContactPoint[] getContactPoints
    {
        get { return contactPoints; }

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
    [SerializeField] float wallPointRadius;


    ////////////////////////////////////////////////////////////////Technical Variables////////////////////////////////////////////////////////////////////
    //GroundCheck
    Vector3 checkSpherePos;

    //WallCheck
    public RaycastHit wallhit;
    Vector3 startPos;
    Vector3 endPos;
    public bool nearWall = false;
    int wallsTouched = 1;
    // Layers


    private void Start()
    {
        Debug.Log(contactPoints[0]);
    }

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

    private void OnCollisionEnter(Collision collision)
    {
        if (nearWall)
        {
            //   Debug.Log("Enter in touch with another object");

            contactPoints[wallsTouched] = contactPoints[0];
            wallsTouched++;

        }


    }

    private void OnCollisionStay(Collision collision)
    {
        if ((wallLayers.value & (1 << collision.collider.gameObject.layer)) != 0)
        {

            nearWall = true;

            contactPoints[0] = collision.contacts[0];

        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (nearWall)
        {

            nearWall = false;
            contactPoints = new ContactPoint[5];
            // Debug.Log("Exit wall");
        }


    }

    private void OnDrawGizmosSelected()
    {

        //GroundCheck
        Gizmos.DrawSphere(checkSpherePos, sphereRadius);

        //WallCheck
        Gizmos.DrawWireSphere(startPos, wallCheckRadius);
        Gizmos.DrawWireSphere(endPos, wallCheckRadius);

        //Contact point check
        for (int i = 0; i < contactPoints.Length; i++)
        {
            Gizmos.DrawSphere(contactPoints[i].point, wallPointRadius);
        }
    }

}
