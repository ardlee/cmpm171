using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boost : MonoBehaviour
{
    private cardManager cardManager;
    private movement movement;
    
    void Start()
    {
       
        cardManager = GetComponent<cardManager>();
        movement = GetComponent<movement>();
    }

    void Update()
    {
        
        if (cardManager != null && cardManager.currentcardIndex == 1 && cardManager.ammoCounts[cardManager.currentcardIndex] > 0)
        {
            
            if (Input.GetKey(KeyCode.Space))
           
            {
                
                movement.walkSpeed = 18f;
            }
            else
            {
                movement.walkSpeed = 6f;
            }
        }

    }

}