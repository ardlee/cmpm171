using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    [SerializeField] private float grappleLength;
    [SerializeField] private float initialRopeMultiplier = 2f; // Adjust the initial rope length multiplier
    [SerializeField] private float ropeSpeed = 5f; // Adjust the speed as needed
    [SerializeField] private float swingForce = 20f; // Adjust the swing force as needed
    [SerializeField] private LayerMask grappleLayer;
    [SerializeField] private LineRenderer rope;

    private Vector3 grapplePoint;
    private DistanceJoint2D joint;

    void Start()
    {
        joint = gameObject.GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        rope.enabled = false;

        // Set initial rope length
        joint.distance = grappleLength * initialRopeMultiplier;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(
                origin: Camera.main.ScreenToWorldPoint(Input.mousePosition),
                direction: Vector2.zero,
                distance: Mathf.Infinity,
                layerMask: grappleLayer
            );

            if (hit.collider != null)
            {
                grapplePoint = hit.point;
                grapplePoint.z = 0;
                joint.connectedAnchor = grapplePoint;
                joint.enabled = true;
                rope.SetPosition(0, grapplePoint);
                rope.SetPosition(1, transform.position);
                rope.enabled = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            joint.enabled = false;
            rope.enabled = false;
        }

        if (rope.enabled == true)
        {
            rope.SetPosition(1, transform.position);

            // Adjust rope length using W and S keys
            float ropeInput = Input.GetAxis("Vertical"); // W: 1, S: -1, No input: 0
            joint.distance += ropeInput * ropeSpeed * Time.deltaTime;

            // Clamp rope length to avoid unexpected behavior
            joint.distance = Mathf.Clamp(joint.distance, 0, grappleLength + 4);

            // Allow swinging using A and D keys
            float swingInput = Input.GetAxis("Horizontal"); // A: -1, D: 1, No input: 0
            Vector2 swingForceVector = new Vector2(swingInput * swingForce, 0f);
            GetComponent<Rigidbody2D>().AddForce(swingForceVector, ForceMode2D.Force);
        }
    }
}