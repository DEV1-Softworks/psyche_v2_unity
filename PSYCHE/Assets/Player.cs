using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public InputMaster controls;
    private Vector2 moveInput;
    private Rigidbody2D rigidBody;

    public Animator animator;

    void Awake()
    {
        controls = new InputMaster();

        rigidBody = GetComponent<Rigidbody2D>();

        if (rigidBody is null)
            Debug.LogError("Rigidbody2D is NULL");

        controls.Player.Shoot.performed += _ => Shoot();
    }

    void FixedUpdate()
    {
        moveInput = controls.Player.Movement.ReadValue<Vector2>();
        moveInput.y = 0;
        rigidBody.velocity = moveInput * speed;
        animator.SetFloat("Speed", moveInput.x);
    }

    void Shoot()
    {
        Debug.Log("We shot");
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
