//script based upon 3rd Person Controller - Unity's New Input System tutorial from One Wheel Studio
//https://www.youtube.com/watch?v=WIl6ysorTE0


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OneWheelMovement : MonoBehaviour

{
    
    //reference to Input Actions Asset PlayerControl
    private PlayerControl playerActions;
    private InputAction move;

    //movement fields
    private Rigidbody rb; //using physics engine
    [SerializeField]
    private float movementForce = 1f;//player speed acceleration
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float maxSpeed = 5f; //limits acceleration
    private Vector3 forceDirection = Vector3.zero;

    [SerializeField]
    private Camera playerCamera; //to allow character movement relative to camera
    private Animator animator;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        playerActions = new PlayerControl(); //create new instance of input action map
        //reference to animator 
        animator = this.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        //subscribe to input events
        playerActions.Player.Jump.started += DoJump;
        playerActions.Player.Attack.started += DoAttack;
        move = playerActions.Player.Move; 
        playerActions.Player.Enable();
    }

    private void OnDisable()
    {
        //unsubscribe
        playerActions.Player.Jump.started -= DoJump;
        playerActions.Player.Attack.started -= DoAttack;
        playerActions.Player.Disable();
    }

    private void FixedUpdate()
    {
        // get input from move (relative to the camera)

        float xInput = move.ReadValue<Vector2>().x;
        float yInput = move.ReadValue<Vector2>().y;

        if (playerActions.Player.Run.ReadValue<float>() <= 0)
        {
            movementForce = 0.4f;
        }
        else
        {
            movementForce = 1f;
        }

        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;

        rb.AddForce(forceDirection, ForceMode.Impulse);//accelerate character when moving up to max speed
        forceDirection = Vector3.zero;

        



        //improve gamefeel of jump by making character fall faster
        if (rb.velocity.y < 0f)
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime;

        //cap horizontal speed 
        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;

        //check magnitude and inperceptibly slow down when character reaches max velocity to ensure smooth 'braking'
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;

        LookAt();
    }

    //ensure that player faces in direction of movement
    private void LookAt()
    {
        Vector3 direction = rb.velocity;
        //ensure rotation around vertical axis only
        direction.y = 0f;

        //check for movement input and rotate character to face direction of movement
        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            this.rb.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            //stop character rotating when movement input stops
            rb.angularVelocity = Vector3.zero;
    }

    //allows for camera angle to ensure player movement on horizontal plane
    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }


    //Jump function
    private void DoJump(InputAction.CallbackContext obj)
    {
        if (IsGrounded())
        {
            forceDirection += Vector3.up * jumpForce;
        }
    }

    private bool IsGrounded()
    {
        //use raycasting to check if character is touching a surface or object
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.25f, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
            return true;
        else
            return false;
    }

    private void DoAttack(InputAction.CallbackContext obj)
    {
        animator.SetTrigger("attack");
    }
}
