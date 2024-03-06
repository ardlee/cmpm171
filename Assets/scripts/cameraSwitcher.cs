using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitcher : MonoBehaviour
{

    //public Camera[] cameras;
    //public Collider2D[] triggers;

    //private Camera currentCamera;

    //private void Start()
    //{
    //    // Set the first camera as the current camera
    //    currentCamera = cameras[0];
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("entered");
    //    // Check if the collider trigger was entered by the player
    //    if (other.CompareTag("Player"))
    //    {
    //        // Find the index of the triggered collider
    //        int index = System.Array.IndexOf(triggers, other) + 1;

    //        Debug.Log("entered");

    //        if (index >= 0 && index < cameras.Length)
    //        {
    //            // Disable the current camera
    //            currentCamera.enabled = false;

    //            // Enable the camera corresponding to the triggered collider
    //            cameras[index].enabled = true;

    //            // Update the current camera
    //            currentCamera = cameras[index];
    //        }
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    // Check if the collider trigger was exited by the player
    //    if (other.CompareTag("Player"))
    //    {
    //        // Disable the current camera
    //        currentCamera.enabled = false;


    //        cameras[0].enabled = true;

    //        // Update the current camera
    //        currentCamera = cameras[0];
    //    }
    //}

    public GameObject camold, camnew;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("hit");
        if (other.CompareTag("Player"))
        {
            //Debug.Log("hit");
            camold.SetActive(false);
            camnew.SetActive(true);
        }
    }
}