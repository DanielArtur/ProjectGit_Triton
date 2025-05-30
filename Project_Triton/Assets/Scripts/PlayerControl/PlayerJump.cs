using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////References////////////////////////////////////////////////////////////////////
    PlayerInput playerInput;
    Rigidbody rb;
    PlayerStateChecker stateChecker;


    ////////////////////////////////////////////////////////////////Settings////////////////////////////////////////////////////////////////////
    [Header("Settings")]
    [SerializeField] float jumpHeight;


    ////////////////////////////////////////////////////////////////Technical variables////////////////////////////////////////////////////////////////////
    Vector3 startVelocity;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        stateChecker = GetComponent<PlayerStateChecker>();
    }

    void OnJump()
    {
        if (stateChecker.CurrentState == PlayerStateChecker.PlayerStates.OnGround)
        {
            //reduce our velocity on the y axis so our jump force can be added
            startVelocity = rb.linearVelocity;
            startVelocity.y = 0;

            rb.linearVelocity = startVelocity;

            //add our jump force
            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);

        }

    }
}
