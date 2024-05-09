using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public Transform teleportDestination; // Set this in the Inspector by dragging the destination object

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Teleport the player to the destination
            other.transform.position = teleportDestination.position;
        }
    }
}
