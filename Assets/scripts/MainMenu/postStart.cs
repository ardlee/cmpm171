using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class postStart : MonoBehaviour
{
    public GameObject levelSelection;
    public GameObject GameMenu;
    public GameObject option;

    public bool isStart = false;
    // Start is called before the first frame update
    void Start()
    {
        levelSelection.SetActive(false);
        option.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToStartLevelSelection();
        }
    }

    public void optionSelection()
    {
        option.SetActive(true);
        isStart = true;
        GameMenu.SetActive(false);
    }

    public void BackToStartOptionSelection()
    {
        option.SetActive(false);
        isStart = false;
        GameMenu.SetActive(true);
    }


    public void levelSelect()
    {
        levelSelection.SetActive(true);
        isStart = true; 
        GameMenu.SetActive(false);
    }

    public void BackToStartLevelSelection()
    {
        levelSelection.SetActive(false);
        isStart = false;
        GameMenu.SetActive(true);
    }

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
