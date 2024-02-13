using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public Transform grappleSource; // Assign the empty object as the grapple source
    public float grapplingSpeed = 10f;
    public float swingingSpeed = 20f; // Increased swinging speed

    private bool isGrappling = false;
    private Vector2 grapplingPoint;
    private Rigidbody2D playerRigidbody;
    private SpringJoint2D springJoint;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>(); // Assuming the script is attached to the same GameObject as the Rigidbody2D
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isGrappling)
            {
                ShootGrapple();
            }
            else
            {
                DestroyGrapple();
            }
        }

        if (isGrappling)
        {
            HandleGrapple();
            HandleSwingingInput();
        }
    }

    void ShootGrapple()
    {
        // Shoot a raycast upward from the grapple source
        RaycastHit2D hit = Physics2D.Raycast(grappleSource.position, Vector2.up, Mathf.Infinity);

        if (hit.collider != null && hit.collider.CompareTag("platform"))
        {
            isGrappling = true;
            grapplingPoint = hit.point;

            // Create a SpringJoint2D dynamically
            springJoint = gameObject.AddComponent<SpringJoint2D>();
            springJoint.connectedAnchor = grapplingPoint;
            springJoint.distance = Vector2.Distance(grappleSource.position, grapplingPoint);
            springJoint.frequency = 5f; // Adjust the spring frequency as needed
            springJoint.dampingRatio = 0.7f; // Adjust the damping ratio as needed

            // Log the hit object's name to the console
            Debug.Log("Hit: " + hit.collider.gameObject.name);
        }
    }

    void DestroyGrapple()
    {
        isGrappling = false;

        // Destroy the SpringJoint2D
        if (springJoint != null)
        {
            Destroy(springJoint);
        }
    }

    void HandleGrapple()
    {
        // Apply velocity towards the grappling point
        Vector2 direction = (grapplingPoint - (Vector2)transform.position).normalized;
        playerRigidbody.velocity = direction * grapplingSpeed;

        // Check if the distance to the grappling point is close enough to stop grappling
        float distance = Vector2.Distance(transform.position, grapplingPoint);

        if (distance < 0.5f)
        {
            DestroyGrapple();
        }
    }

    void HandleSwingingInput()
    {
        // Allow the player to swing left (A key) and right (D key)
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 swingingForce = new Vector2(horizontalInput * swingingSpeed, 0f);

        // Apply the swinging force to the player
        playerRigidbody.AddForce(swingingForce, ForceMode2D.Force);
    }
}