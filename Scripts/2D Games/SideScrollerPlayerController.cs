using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SideScrollerPlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveVector = new(0, 0);
    [SerializeField] private PlayerData playerObj;
    [SerializeField] private Transform groundCheck; // A Transform representing where to check if the player is grounded.
    [SerializeField] private float checkRadius; // Radius of the overlap circle.
    [SerializeField] private LayerMask groundLayer; // A LayerMask indicating what layer(s) to check for collisions to consider the player grounded.
    public LayerMask enemyLayer;
    [SerializeField] private Weapon currentWeapon;
    private bool isJumping;
    private SpriteRenderer spriteRenderer;
    private float dashForce;
    private Vector2 dashVelocity = new(0,0);
    public int remainingDashes;
    public bool refillDashes;
    private WaitForSeconds waitForSeconds;
    public IInteractable currentInteractTarget;
    public Coroutine RefillDashes;
    public float dashDuration;
    private float lastMoveDirection=1;

    void Start()
    {
        waitForSeconds = new WaitForSeconds(playerObj.dashRefillTime);
        refillDashes = true;
        dashDuration = playerObj.dashDuration;
        remainingDashes = playerObj.maxDashes;
        playerObj.health = playerObj.maxHealth;
        dashForce = playerObj.dashForce;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);
        RefillDashes = StartCoroutine(RefillDash());
    }
    public void SetInteractionTarget(IInteractable target)
    {
        currentInteractTarget = target;
    }
    void FixedUpdate()
    {
        isJumping = IsJumping();
        var vector2 = rb.velocity;
        vector2.x = playerObj.speed * moveVector.x;
        rb.velocity = vector2;
    }

    public IEnumerator RefillDash()
    {
        while (refillDashes)
        {
            if (remainingDashes < playerObj.maxDashes)
            {
                remainingDashes++;
                yield return waitForSeconds;
            }
            else
            {
                yield return waitForSeconds;
            }
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!isJumping)
        {
            rb.velocity = Vector2.up*playerObj.jumpForce;
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed && remainingDashes > 0)
        {
            Debug.Log("Dash performed");
            StartCoroutine(PerformDash());
            remainingDashes--; 
        }
    }

    private IEnumerator PerformDash()
    {
        float startTime = Time.time;
    
        while (Time.time < startTime + dashDuration)
        {
            transform.position += new Vector3(lastMoveDirection * dashForce * Time.deltaTime, 0, 0);
            yield return null; // wait for next frame
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed&&currentInteractTarget!=null)
        {
            currentInteractTarget.Interact();
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();

        if (moveVector.x > 0)
        {
            lastMoveDirection = 1;
        }
        else if (moveVector.x < 0)
        {
            lastMoveDirection = -1;
        }
    }

    public void OnNormalAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (currentWeapon != null) currentWeapon.NormalAttack();
        }
    }

    public void OnHeavyAttack(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            if (currentWeapon != null) currentWeapon.HeavyAttack();
        }
    }

    public void OnSpecialAttack(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            if (currentWeapon != null) currentWeapon.SpecialAttack();
        }
    }

    private bool IsJumping()
    {
        // Check if there's any collider coming into contact with the overlap circle.
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer) == null;
    }
}
