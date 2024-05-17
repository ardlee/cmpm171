using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class onTopFinishTutorial : MonoBehaviour
{

    public GameObject openCanvas;
    

    public async void Start()
    {
        openCanvas.SetActive(false);
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("working1");

        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0.0f;
            openCanvas.SetActive(true);
            Debug.Log("working2");
            AudioManager.instance.PlayOneShot(FMODEvents.instance.victorySound, this.transform.position);

            CustomEvent tutorialComplete = new CustomEvent("TutorialComplete"){};
            Debug.Log(tutorialComplete);
            AnalyticsService.Instance.RecordEvent(tutorialComplete);
            //AnalyticsResult analyticsResult = Analytics.Instance.CustomData("TutorialComplete");
            //AnalyticsResult analyticsResult = Analytics.CustomEvent("TutorialComplete");
            //Debug.Log("analyticsResult: " + analyticsResult);
        }
    }

    public void congratulations()
    {
       
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("postStartScene");

    }
}
