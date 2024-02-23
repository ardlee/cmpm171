using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{

    public GameObject startGameMenu;
    public GameObject GameMenu;
    public bool isStart = false;
    // Start is called before the first frame update
    void Start()
    {
        startGameMenu.SetActive(false);
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
