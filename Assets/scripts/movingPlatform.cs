using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class movingPlatform : MonoBehaviour
{
    public Transform start; 
    public Transform end;
    public float speed = 2.0f;

    private Vector3 nextPosition;
    private EventInstance movingPlatforms;


    public void Start()
    {
        nextPosition = end.position;
        movingPlatforms = AudioManager.instance.CreateInstance(FMODEvents.instance.MovingPlatforms);
        float volume = 0.2f;
        movingPlatforms.setVolume(volume);
        //movingPlatforms.start();

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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player collided with platform");
            collision.gameObject.transform.parent = transform;
            Rigidbody2D pRb = collision.gameObject.GetComponent<Rigidbody2D>();

            pRb.interpolation = RigidbodyInterpolation2D.None;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player exited platform");
            collision.gameObject.transform.parent = null;

            Rigidbody2D pRb = collision.gameObject.GetComponent<Rigidbody2D>();

            pRb.interpolation = RigidbodyInterpolation2D.Interpolate;
        }
    }
    private void OnDestroy()
    {
        // Release FMOD event instance when object is destroyed
        movingPlatforms.release();
    }
}