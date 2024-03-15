using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class onTopFinish : MonoBehaviour
{

    public GameObject openCanvas;

    public void Start()
    {
        openCanvas.SetActive(false);
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
