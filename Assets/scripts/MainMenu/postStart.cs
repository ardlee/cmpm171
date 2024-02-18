using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class postStart : MonoBehaviour
{
    public GameObject selection;
    public GameObject GameMenu;
    public bool isStart = false;
    // Start is called before the first frame update
    void Start()
    {
        selection.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToPostStart();
        }
    }

    public void levelSelect()
    {
        selection.SetActive(true);
        isStart = true;
        GameMenu.SetActive(false);
    }

    public void BackToPostStart()
    {
        selection.SetActive(false);
        isStart = false;
        GameMenu.SetActive(true);
    }

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
