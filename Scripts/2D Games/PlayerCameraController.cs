using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody rb;
    private float maxPlayerSpeed;
    [Header("Camera")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float smoothness = 5f;
    [SerializeField] private float distanceChangeSpeed = 2f;
    [SerializeField] private float minDistance = 2f;
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private float fixedCameraDistance = 10f; // Adjust this value
    [SerializeField] private float dampingFactor = 0.1f; // Adjust this value
    [SerializeField] private float cameraHeightScale = 1.0f;
    [SerializeField] private float followDelay;
    private Vector3 cameraVelocity = Vector3.zero;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Camera movement
        UpdateCameraPosition();

        // Zoom-out effect based on player's speed
        UpdateZoomEffect();
    }
    private void UpdateCameraPosition()
    {
        float currentDistance = Vector3.Distance(playerCamera.transform.position, transform.position);
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, -fixedCameraDistance);
        playerCamera.gameObject.transform.position = Vector3.SmoothDamp(
            playerCamera.gameObject.transform.position,
            targetPosition,
            ref cameraVelocity,
            dampingFactor * smoothness,
            Mathf.Infinity,
            Time.deltaTime * followDelay
        );
    }

    private void UpdateZoomEffect()
    {
        float zoomFactor = 1f + rb.linearVelocity.magnitude / maxPlayerSpeed;
        float currentDistance = Vector3.Distance(playerCamera.transform.position, transform.position);
        float targetDistance = Mathf.Clamp(currentDistance + distanceChangeSpeed * rb.linearVelocity.magnitude * zoomFactor, minDistance, maxDistance);
        playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y+cameraHeightScale, -targetDistance);
    }
    private void AdjustCameraDistance()
    {
        float currentDistance = Vector3.Distance(playerCamera.transform.position, transform.position);
        playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y+cameraHeightScale, -fixedCameraDistance);
    }

    private void FixedUpdate()
    {
        // Camera adjustment
        AdjustCameraDistance();
    }
}
