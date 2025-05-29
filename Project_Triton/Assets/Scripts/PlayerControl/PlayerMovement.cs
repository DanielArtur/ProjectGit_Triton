using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    ////////////////////////////////////////////////////////////////Refrences////////////////////////////////////////////////////////////////////
    Rigidbody rb;


    [Header("Refrences")]
    [SerializeField] public PlayerInput playerInput;
    [SerializeField] float moveSpeed;
    public Transform orientation;


    ////////////////////////////////////////////////////////////////Technical Variables////////////////////////////////////////////////////////////////////
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    InputAction moveAction;





    ////////////////////////////////////////////////////////////////Start////////////////////////////////////////////////////////////////////
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];

    }




    ////////////////////////////////////////////////////////////////Update////////////////////////////////////////////////////////////////////

    void FixedUpdate()
    {
        MovePlayer();
    }

    ////////////////////////////////////////////////////////////////MovePlayer////////////////////////////////////////////////////////////////////

    private void MovePlayer()
    {
        // Where does the camera look on y-axis?
        Vector3 yRot = orientation.transform.localEulerAngles;
        //transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, yRot.y, transform.localEulerAngles.z);

        moveDirection = (orientation.forward * moveAction.ReadValue<Vector2>().y) + (orientation.right * moveAction.ReadValue<Vector2>().x);

        moveDirection = moveDirection * moveSpeed;

        moveDirection.y = rb.linearVelocity.y;

        rb.AddForce(moveDirection, ForceMode.VelocityChange);


    }


    ////////////////////////////////////////////////////////////////Debug methods////////////////////////////////////////////////////////////////////

    private void OnDrawGizmos()
    {
        Debug.DrawRay(orientation.position, moveDirection, Color.red);

    }



}
