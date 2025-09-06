using System.Data.SqlTypes;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]
    public float moveSpeed;
    public float crouchSpeed;
    public float crouchYscale;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool canJump = true;


    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask Ground;
    bool grounded;

    float horizontalInput;
    float verticalInput;

    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode crouchKey = KeyCode.LeftControl;

    public Transform orientation;

    Vector3 moveDirection;
    
    Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");   
        verticalInput = Input.GetAxisRaw("Vertical");  
        

        if(Input.GetKeyDown(crouchKey))
        {
            rb.AddForce(Vector3.down * 20, ForceMode.Impulse);
        }
        if(Input.GetKey(crouchKey))
        {
            moveSpeed = crouchSpeed;
            transform.localScale = new Vector3(transform.localScale.x, crouchYscale, transform.localScale.z);
        }
        else if(Input.GetKey(jumpKey) && canJump && grounded)
        {
            canJump = false;

            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }

        if(Input.GetKeyUp(crouchKey))
        {
            moveSpeed = 8;
            transform.localScale = Vector3.one;

        }
    }

    // Update is called once per frame
    void Update()
    {
        grounded = GroundCheck();
        MyInput();

        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;

        //Debug.Log($"grounded: {grounded} input: {Input.GetKey(jumpKey)} canJump: {canJump}");
    }

    private void FixedUpdate()
    {
        MovePlayer();
        SpeedControl();
    }

    void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    bool GroundCheck()
    {
        return Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, Ground);
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void ResetJump()
    {
        canJump = true;
    }
}
