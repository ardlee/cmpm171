
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer _lineRenderer;
    public DistanceJoint2D _distanceJoint;

    [SerializeField] private float grappleLength;
    
    [SerializeField] private float ropeSpeed = 5f;
    [SerializeField] private float swingForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        _distanceJoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _lineRenderer.SetPosition(0, mousePos);
            _lineRenderer.SetPosition(1, transform.position);
            _distanceJoint.connectedAnchor = mousePos;
            _distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
        }
        if (_distanceJoint.enabled) 
        {
            _lineRenderer.SetPosition(1, transform.position);
            float ropeInput = Input.GetAxis("Vertical");
            _distanceJoint.distance += ropeInput * ropeSpeed * Time.deltaTime;
            _distanceJoint.distance = Mathf.Clamp(_distanceJoint.distance, 0, grappleLength + 4);

            // Allow swinging using A and D keys
            float swingInput = Input.GetAxis("Horizontal");
            Vector2 swingForceVector = new Vector2(swingInput * swingForce, 0f);
            GetComponent<Rigidbody2D>().AddForce(swingForceVector, ForceMode2D.Force);
        }
        
    }

}