using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class cardManager : MonoBehaviour
{
    public GameObject[] cards; // Array of card game objects
    public TextMeshProUGUI[] ammoTexts; // Array of UI text elements for displaying ammo counts

    public int currentcardIndex = 0; // Index of the current card
    public int[] ammoCounts; // Array to store ammo counts for each card

    private Coroutine hideUICoroutine; // Coroutine reference for hiding UI

    void Start()
    {
        // Initialize ammo counts for each card
        ammoCounts = new int[cards.Length];

        // Set initial ammo counts for each card
        ammoCounts[0] = 3;
        ammoCounts[1] = 4;
        ammoCounts[2] = 3;

        // Update UI with initial ammo counts
        UpdateAmmoUI();

        // Start coroutine to hide UI after 5 seconds
        hideUICoroutine = StartCoroutine(HideUIAfterDelay(5f));
    }

    void Update()
    {
        // Handle card swapping input
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            ShowUI(); // Show UI if Q, E, or Space is pressed
            if (hideUICoroutine != null)
            {
                StopCoroutine(hideUICoroutine); // Stop previous coroutine
            }
            // Start coroutine to hide UI after 5 seconds
            hideUICoroutine = StartCoroutine(HideUIAfterDelay(5f));
        }

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
        // Check if there's ammo to fire
        if (ammoCounts[currentcardIndex] >= 1)
        {
            ammoCounts[currentcardIndex]--;
            UpdateAmmoUI(); // Update UI with new ammo count

            Debug.Log("Fired from card " + currentcardIndex + ", Ammo Count: " + ammoCounts[currentcardIndex]);
        }
        else
        {
            Debug.Log("No ammo to fire from card " + currentcardIndex);
        }
    }

    public void UpdateAmmoUI()
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

    IEnumerator HideUIAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        HideUI();
    }

    void HideUI()
    {
        // Hide UI text elements
        foreach (var text in ammoTexts)
        {
            text.gameObject.SetActive(false);
        }

        // Hide card images
        foreach (var card in cards)
        {
            card.SetActive(false);
        }
    }

    void ShowUI()
    {
        // Show UI text elements
        foreach (var text in ammoTexts)
        {
            text.gameObject.SetActive(true);
        }

        // Show only the card at the current index
        for (int i = 0; i < cards.Length; i++)
        {
            if (i == currentcardIndex)
            {
                cards[i].SetActive(true);
            }
            else
            {
                cards[i].SetActive(false);
            }
        }
    }
}
