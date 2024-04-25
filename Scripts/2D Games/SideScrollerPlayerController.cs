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
    public WaitForSeconds WaitForSeconds;
    
    void Start()
    {
        WaitForSeconds = new WaitForSeconds(playerObj.dashRefillTime);
        refillDashes = true;
        remainingDashes = playerObj.maxDashes;
        playerObj.health = playerObj.maxHealth;
        dashForce = playerObj.dashForce;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);
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
                yield return WaitForSeconds;
            }
            else
            {
                yield return WaitForSeconds;
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
        if (context.performed)
        {
            if (remainingDashes > 0)
            {
                dashVelocity.x = rb.velocity.x * dashForce;
                rb.AddForce(dashVelocity, ForceMode2D.Impulse);
                remainingDashes--;
            }
            
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    
        Vector3 localScale = transform.localScale;
    
        if (moveVector.x > 0)
            localScale.x = Mathf.Abs(localScale.x);
        else if (moveVector.x < 0)
            localScale.x = -Mathf.Abs(localScale.x);
        
        transform.localScale = localScale;
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
