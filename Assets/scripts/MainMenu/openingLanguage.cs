using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

public class openingLanguage : MonoBehaviour
{
    public GameObject englishLang;
    public GameObject frenchLang;
    public GameObject spanishLang;

    public void english()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        SceneManager.LoadScene("postStartScene");
        //SetLocale(0);
        Debug.Log("english working");
    }

    public void french()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
        SceneManager.LoadScene("postStartScene");
        //SetLocale(1);
        Debug.Log("french working");
    }

    public void spanish()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[3];
        SceneManager.LoadScene("postStartScene");
        //SetLocale(2);
        Debug.Log("spanish working");
    }
}
