using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField] 
    private float jumpForce = 400f;
    [SerializeField]
    private Transform groundPoint;
    [SerializeField]
    private LayerMask whatIsGround;

    public InputMaster controls;
    private Vector2 moveInput;
    private Rigidbody2D rigidBody;
    private bool isGrounded;

    void Awake()
    {
        controls = new InputMaster();

        rigidBody = GetComponent<Rigidbody2D>();

        if (rigidBody is null)
            Debug.LogError("Rigidbody2D is NULL");

        controls.Player.Shoot.performed += _ => Shoot();
        controls.Player.Jump.performed += ctx => Jump(ctx);
    }

    void FixedUpdate()
    {
        moveInput = controls.Player.Movement.ReadValue<Vector2>();
        rigidBody.velocity = new Vector2(moveInput.x * speed, rigidBody.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);
    }

    void Shoot()
    {
        Debug.Log("We shot");
    }

    void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            Debug.Log(rigidBody.velocity);
            Debug.Log("We jumped !!!");
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
