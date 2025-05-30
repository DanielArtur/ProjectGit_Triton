using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    ////////////////////////////////////////////////////////////////Refrences////////////////////////////////////////////////////////////////////
    Rigidbody rb;
    PlayerInput playerInput;
    InputAction moveAction;

    [Header("Refrences")]
    public Transform orientation;


    ////////////////////////////////////////////////////////////////Player Atributes////////////////////////////////////////////////////////////////////

    [Header("Player Atributes")]
    [SerializeField] float directionControl = 8;
    [SerializeField] float moveSpeed;


    ////////////////////////////////////////////////////////////////Technical Variables////////////////////////////////////////////////////////////////////

    //Input
    float horizontalInput;
    float verticalInput;

    //Movement directrion
    Vector3 moveDirection;
    Vector3 yRot;

    // Movement acceleration
    float AdjustmentAmt = 1; //the amount added to our player acceleration, this is used for adjusting to new speeds such as when we slide
    Vector3 lerpVelocityOfMovement;






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
        verticalInput = moveAction.ReadValue<Vector2>().y;
        horizontalInput = moveAction.ReadValue<Vector2>().x;

        MovePlayer();
    }

    ////////////////////////////////////////////////////////////////MovePlayer////////////////////////////////////////////////////////////////////

    private void MovePlayer()
    {

        yRot = new Vector3(orientation.forward.x, 0, orientation.forward.z);
        yRot = yRot.normalized;

        moveDirection = (yRot * verticalInput) + (orientation.right * horizontalInput);

        moveDirection = moveDirection * moveSpeed;

        moveDirection.y = rb.linearVelocity.y;


        float Acceleration = directionControl * AdjustmentAmt;
        lerpVelocityOfMovement = Vector3.Lerp(rb.linearVelocity, moveDirection, Acceleration * Time.fixedDeltaTime);

        rb.linearVelocity = lerpVelocityOfMovement;

    }


    ////////////////////////////////////////////////////////////////Debug methods////////////////////////////////////////////////////////////////////

    private void OnDrawGizmos()
    {
        Debug.DrawRay(orientation.position, lerpVelocityOfMovement, Color.red);
    }



}
