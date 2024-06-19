using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class boost : MonoBehaviour
{
    private cardManager cardManager;
    private movement movement;
    float timer = 5f;
    float startTime;
    bool boostActive = false;

    void Start()
    {
        cardManager = GetComponent<cardManager>();
        movement = GetComponent<movement>();
    }

    void Update()
    {
        if (cardManager != null && cardManager.currentcardIndex == 1 && cardManager.ammoCounts[cardManager.currentcardIndex] > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // Use GetKeyDown to trigger on press
            {
                startTime = Time.time;
                boostActive = true;
                movement.walkSpeed = 12f;
            }     
        }

        if (boostActive && Time.time - startTime >= timer)
        {
            boostActive = false;
            movement.walkSpeed = 4f;
        }
    }
}
