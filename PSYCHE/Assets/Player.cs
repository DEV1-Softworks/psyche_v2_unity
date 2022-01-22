using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InputMaster controls;

    void Awake()
    {
        controls = new InputMaster();
        controls.Player.Shoot.performed += _ => Shoot();
        controls.Player.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    void Shoot()
    {
        Debug.Log("We shot");
    }

    void Move(Vector2 direction)
    {
        Debug.Log("Player wants to move: " + direction);
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
