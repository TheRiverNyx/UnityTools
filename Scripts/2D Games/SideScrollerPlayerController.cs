using System;
using System.Collections;
using System.Collections.Generic;
using Tools.Scripts.Scriptable_Objects;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class SideScrollerPlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 moveVector = new(0, 0);
    [SerializeField] private IntDataScriptableObject healthObj;
    [SerializeField] private FloatDataScriptableObject moveObj;
    [SerializeField] private FloatDataScriptableObject jumpObj;
    [SerializeField] private Transform groundCheck; // A Transform representing where to check if the player is grounded.
    [SerializeField] private float checkRadius; // Radius of the overlap circle.
    [SerializeField] private LayerMask groundLayer; // A LayerMask indicating what layer(s) to check for collisions to consider the player grounded.
    private bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        isJumping = IsJumping();
        var vector2 = rb.velocity;
        vector2.x = moveObj.value * moveVector.x;
        rb.velocity = vector2;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!isJumping)
        {
            rb.AddForce(Vector2.up * jumpObj.value, ForceMode2D.Impulse);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    private bool IsJumping()
    {
        // Check if there's any collider coming into contact with the overlap circle.
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer) == null;
    }
}