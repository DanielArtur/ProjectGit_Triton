using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    ////////////////////////////////////////////////////////////////Refrences////////////////////////////////////////////////////////////////////
    Rigidbody rb;
    PlayerInput playerInput;
    InputAction moveAction;
    PlayerStateChecker stateChecker;


    [Header("Refrences")]
    public Transform orientation;


    ////////////////////////////////////////////////////////////////Player Atributes////////////////////////////////////////////////////////////////////

    [Header("Player Atributes")]
    [SerializeField] float directionControl = 8;
    [SerializeField] float inAirControl = 3;
    [SerializeField] float defaultMoveSpeed;
    [Tooltip("Speed when you move along the wall")]
    [SerializeField] float onWallSpeed;

    ////////////////////////////////////////////////////////////////Technical Variables////////////////////////////////////////////////////////////////////

    //Input
    float horizontalInput;
    float verticalInput;

    //Movement directrion
    Vector3 moveDirection;
    Vector3 yRot;
    Vector3 point;

    // Movement acceleration
    float AdjustmentAmt = 1; //the amount added to our player acceleration, this is used for adjusting to new speeds such as when we slide
    Vector3 lerpVelocityOfMovement;
    float currentmoveSpeed;





    ////////////////////////////////////////////////////////////////Start////////////////////////////////////////////////////////////////////
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        stateChecker = GetComponent<PlayerStateChecker>();


        currentmoveSpeed = defaultMoveSpeed;
    }




    ////////////////////////////////////////////////////////////////Update////////////////////////////////////////////////////////////////////

    void FixedUpdate()
    {
        verticalInput = moveAction.ReadValue<Vector2>().y;
        horizontalInput = moveAction.ReadValue<Vector2>().x;

        if (stateChecker.CurrentState == PlayerStateChecker.PlayerStates.OnGround)
        {
            MovePlayer();
        }

        else if (stateChecker.CurrentState == PlayerStateChecker.PlayerStates.InAir)
        {
            MovePlayerInAir();
        }


    }

    ////////////////////////////////////////////////////////////////MovePlayer////////////////////////////////////////////////////////////////////

    private void MovePlayer()
    {




        yRot = new Vector3(orientation.forward.x, 0, orientation.forward.z);
        yRot = yRot.normalized;

        moveDirection = (yRot * verticalInput) + (orientation.right * horizontalInput);

        if (stateChecker.nearWall && moveDirection.magnitude > 0)
        {

            //if()
            //float maxAngle;
            //ContactPoint bestPoint;

            //foreach (ContactPoint p in stateChecker.getContactPoints)
            //{



            //}


            point = stateChecker.getContactPoints[0].normal;

            float wallAngle = Vector3.Angle(moveDirection, point);

            if (-90 > wallAngle || wallAngle > 90)
            {

                moveDirection = Vector3.ProjectOnPlane(moveDirection, point).normalized;
                Debug.Log("Project on plane");


                currentmoveSpeed = onWallSpeed;
            }

            // Debug.Log("Angle:" + wallAngle);

        }


        moveDirection = moveDirection * currentmoveSpeed;

        moveDirection.y = rb.linearVelocity.y;


        float Acceleration = directionControl * AdjustmentAmt;
        lerpVelocityOfMovement = Vector3.Lerp(rb.linearVelocity, moveDirection, Acceleration * Time.fixedDeltaTime);

        rb.linearVelocity = lerpVelocityOfMovement;

    }

    private void MovePlayerInAir()
    {

        yRot = new Vector3(orientation.forward.x, 0, orientation.forward.z);
        yRot = yRot.normalized;

        moveDirection = (yRot * verticalInput) + (orientation.right * horizontalInput);

        moveDirection = moveDirection * defaultMoveSpeed;

        moveDirection.y = rb.linearVelocity.y;


        float inAirAcceleration = inAirControl * AdjustmentAmt;
        lerpVelocityOfMovement = Vector3.Lerp(rb.linearVelocity, moveDirection, inAirAcceleration * Time.fixedDeltaTime);

        rb.linearVelocity = lerpVelocityOfMovement;

    }
    ////////////////////////////////////////////////////////////////Debug methods////////////////////////////////////////////////////////////////////

    private void OnDrawGizmos()
    {
        Debug.DrawRay(orientation.position, lerpVelocityOfMovement, Color.red);
        Debug.DrawRay(transform.position, point, Color.blue);
    }



}
