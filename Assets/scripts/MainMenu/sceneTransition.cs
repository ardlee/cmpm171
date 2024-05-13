using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTransition : MonoBehaviour
{
    /*
    public GameObject mainMenu; 
    public GameObject optionsMenu;
    public GameObject creditsMenu; 
    public GameObject loadMenu;
    public GameObject leaderBoardScene;
    public GameObject levelSelectionScene;
    */

    public void StartGame()
    {
        SceneManager.LoadScene("TileMap");
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    public void StartStealthGame()
    {
        SceneManager.LoadScene("StealthScene");
    }

    public void StartPCGGame()
    {
        SceneManager.LoadScene(" ");
    }
    public void startTutorial(){
        SceneManager.LoadScene("TutorialScene");
    }
    /*
    public void OpenLoad()
    {
        SceneManager.LoadScene("loadScene");
    }

    public void OpenLeaderBoard()
    {
        SceneManager.LoadScene("leaderBoardScene");
    }


    public void OpenOptions()
    {
        SceneManager.LoadScene("optionScene");

    }

    public void OpenCredits()
    {
        SceneManager.LoadScene("creditScene");
    }

    public void OpenLevelSelection()
    {
        SceneManager.LoadScene("levelSelectionScene");
    }

  

    public void BackToMainMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        loadMenu.SetActive(false);
        leaderBoardScene.SetActive(false);
        levelSelectionScene.SetActive(false);
    }
    */
}
