using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float speed = 2.0f;

    public movement playerMovement;
    private Vector3 nextPosition;
    public int knockbackCount = 0;


    public void Start()
    {
        nextPosition = end.position;
    }

    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

        // Check if the platform has reached near the next position
        if (Vector3.Distance(transform.position, nextPosition) < 0.01f)
        {
            // Toggle the next position between start and end
            nextPosition = (nextPosition == start.position) ? end.position : start.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            knockbackCount++;
            playerMovement.KBCounter = playerMovement.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                playerMovement.knockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                playerMovement.knockFromRight = false;
            }

            if (knockbackCount >= 4)
            {
                knockbackCount = 0;
            }
        }
    }
}