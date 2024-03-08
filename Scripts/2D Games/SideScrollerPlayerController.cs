using Enemy;
using Tools.Scripts.Scriptable_Objects;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class SideScrollerPlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveVector = new(0, 0);
    [SerializeField] private IntDataScriptableObject healthObj;
    [SerializeField] private FloatDataScriptableObject moveObj;
    [SerializeField] private FloatDataScriptableObject jumpObj;
    [SerializeField] private Transform groundCheck; // A Transform representing where to check if the player is grounded.
    [SerializeField] private float checkRadius; // Radius of the overlap circle.
    [SerializeField] private LayerMask groundLayer; // A LayerMask indicating what layer(s) to check for collisions to consider the player grounded.
    public LayerMask enemyLayer;
    [SerializeField] private Weapon currentWeapon;
    private bool isJumping;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(gameObject);
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
            rb.velocity = Vector2.up*jumpObj.value;
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
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
