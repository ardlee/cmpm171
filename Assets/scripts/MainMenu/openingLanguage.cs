using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openingLanguage : MonoBehaviour
{
    public GameObject englishLang;
    public GameObject frenchLang;
    public GameObject spanishLang;

    public void english()
    {

        SceneManager.LoadScene("postStartScene");
        Debug.Log("english working");
    }

    public void french()
    {
        SceneManager.LoadScene("postStartScene");
        Debug.Log("french working");
    }

    public void spanish()
    {
        
        SceneManager.LoadScene("postStartScene");
        Debug.Log("spanish working");
    }
}
