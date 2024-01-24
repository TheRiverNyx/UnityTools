using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.Tilemaps;
using Random = System.Random;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour {
    [SerializeField] private Tilemap tilemap;
    [Header("Movement")]
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private TileBase[] blockerTiles;
    private Rigidbody2D rb;
    private Vector2 moveVector2;
    private bool isMovingLeft;
    [Header("Camera")] 
    [SerializeField] private Camera playerCamera;
    
    [Header("Animation")] 
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveVector2.x * speed, moveVector2.y * speed);
        
        // Perform collision check before applying the movement.
        Vector2 newPosition = rb.position + movement;
        Vector3Int gridPositionNew = tilemap.WorldToCell(new Vector3(newPosition.x, newPosition.y, 0));
        rb.velocity = movement;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector2 = context.ReadValue<Vector2>();
        if (context.started)
        {
            isMovingLeft = moveVector2.x > 0.0f;
            spriteRenderer.flipX = isMovingLeft;
            if (moveVector2.y > 0)
            {
                animator.SetBool("isFacingBack",true);
            }
            else if(moveVector2.y<0)
            {
                animator.SetBool("isFacingBack", false);
            }
            animator.SetBool("isWalking",true);
        }else if (context.canceled)
        {
            animator.SetBool("isWalking",false);
        }
        
    }
    

}
