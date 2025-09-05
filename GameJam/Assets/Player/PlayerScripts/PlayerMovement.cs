using System.Data.SqlTypes;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement")]
    public float moveSpeed;

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
        
        if(Input.GetKey(jumpKey) && canJump && grounded)
        {
            canJump = false;

            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
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
