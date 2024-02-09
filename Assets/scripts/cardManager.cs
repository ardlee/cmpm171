using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class cardManager : MonoBehaviour
{

    public GameObject[] cards; // Array of card game objects
    public TextMeshProUGUI[] ammoTexts; // Array of UI text elements for displaying ammo counts

    private int currentcardIndex = 0; // Index of the current card
    private int[] ammoCounts; // Array to store ammo counts for each card

    void Start()
    {
        // Initialize ammo counts for each card
        ammoCounts = new int[cards.Length];

        // Set initial ammo counts for each card
        ammoCounts[0] = 2;  
        ammoCounts[1] = 4;  
        ammoCounts[2] = 3; 

        // Update UI with initial ammo counts
        UpdateAmmoUI();
    }

    void Update()
    {
        // Handle card swapping input
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Cyclecard(-1); // Cycle to the previous card
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Cyclecard(1); // Cycle to the next card
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Cyclecard(int direction)
    {
        int newIndex = currentcardIndex + direction;

        // Ensure index loops around if it goes out of bounds
        if (newIndex < 0)
        {
            newIndex = cards.Length - 1;
        }
        else if (newIndex >= cards.Length)
        {
            newIndex = 0;
        }

        cards[currentcardIndex].SetActive(false); // Deactivate current card
        currentcardIndex = newIndex;
        cards[currentcardIndex].SetActive(true); // Activate new card
        UpdateAmmoUI(); // Update UI with new ammo count
    }

    void Fire()
    {
        // Check if there's enough ammo to fire
        if (ammoCounts[currentcardIndex] > 0)
        {
            ammoCounts[currentcardIndex]--;
            UpdateAmmoUI(); // Update UI with new ammo count
        }
    }

    void UpdateAmmoUI()
    {
        // Update UI text elements with current ammo counts
        for (int i = 0; i < ammoTexts.Length; i++)
        {
            if (i == currentcardIndex)
            {
                ammoTexts[i].text = "Ammo: " + ammoCounts[i].ToString();
            }
            else
            {
                ammoTexts[i].text = "";
            }
        }
    }
}


