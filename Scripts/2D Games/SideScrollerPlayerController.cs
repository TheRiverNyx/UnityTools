using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class SideScrollerPlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 moveVector;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = new Vector2(context.ReadValue<float>(),0);
    }
}
