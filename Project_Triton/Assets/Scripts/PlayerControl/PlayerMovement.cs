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
    Vector3 yRot;
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

        rb.linearVelocity = moveDirection;

    }


    ////////////////////////////////////////////////////////////////Debug methods////////////////////////////////////////////////////////////////////

    private void OnDrawGizmos()
    {
        Debug.DrawRay(orientation.position, moveDirection, Color.red);

    }



}
