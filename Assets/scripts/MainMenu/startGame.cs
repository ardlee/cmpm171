using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class startGame : MonoBehaviour
{
    
    public GameObject startGameMenu;
    public GameObject GameMenu;
    public bool isStart = false;

    void AskForConsent()
	{
        ConsentGiven();
        UnityServices.InitializeAsync();

		// ... show the player a UI element that asks for consent.
	}

	void ConsentGiven()
	{
		AnalyticsService.Instance.StartDataCollection();
	}
    // Start is called before the first frame update
    void Start()
    {
        startGameMenu.SetActive(false);
        UnityServices.InitializeAsync();
		AskForConsent();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void StartGame()
    {
        startGameMenu.SetActive(true);
        isStart = true;
        GameMenu.SetActive(false);
    }

    public void BacktoMainMenu()
    {
        startGameMenu.SetActive (false);
        isStart=false;
        GameMenu.SetActive(true);

    }

    public void postStart() 
    {
        SceneManager.LoadScene("postStartScene");
    }



}

public class InitWithDefault : MonoBehaviour
{
    async void Start()
    {
		await UnityServices.InitializeAsync();

		AskForConsent();
    }

	void AskForConsent()
	{
        ConsentGiven();
        UnityServices.InitializeAsync();

		// ... show the player a UI element that asks for consent.
	}

	void ConsentGiven()
	{
		AnalyticsService.Instance.StartDataCollection();
	}
}
