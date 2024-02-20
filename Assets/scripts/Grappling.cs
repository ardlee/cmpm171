
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    [SerializeField] private float grappleLength;
    [SerializeField] private float initialRopeMultiplier = 2f;
    [SerializeField] private float ropeSpeed = 5f;
    [SerializeField] private float swingForce = 20f;
    [SerializeField] private LayerMask grappleLayer;
    [SerializeField] private LineRenderer rope;

    private Vector3 grapplePoint;
    private DistanceJoint2D joint;
    private cardManager cardManager; 

    void Start()
    {
        joint = gameObject.GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        rope.enabled = false;

        // Set initial rope length
        joint.distance = grappleLength * initialRopeMultiplier;

        // Get reference to the cardManager script
        cardManager = GetComponent<cardManager>();
    }

    void Update()
    {
        // Check if the player is on the card that allows grappling\
        if (cardManager != null && cardManager.currentcardIndex == 0 && cardManager.ammoCounts[cardManager.currentcardIndex] > 0)
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
                if(hit.collider == null){
                    cardManager.ammoCounts[cardManager.currentcardIndex]++;
                    cardManager.UpdateAmmoUI();
                }
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
            float ropeInput = Input.GetAxis("Vertical");
            joint.distance += ropeInput * ropeSpeed * Time.deltaTime;
            joint.distance = Mathf.Clamp(joint.distance, 0, grappleLength + 4);

            // Allow swinging using A and D keys
            float swingInput = Input.GetAxis("Horizontal");
            Vector2 swingForceVector = new Vector2(swingInput * swingForce, 0f);
            GetComponent<Rigidbody2D>().AddForce(swingForceVector, ForceMode2D.Force);
        }
    }

    // Check if there is enough ammo for the grapple
    bool CanUseGrapple()
    {   

        return cardManager.ammoCounts[cardManager.currentcardIndex]> 0;
    }
}