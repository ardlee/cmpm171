using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class optionLanguage : MonoBehaviour
{
    public GameObject french;
    public GameObject english;
    public GameObject spanish;

    public void englishLangButton()
    {
        Debug.Log("working english button");
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
    }
    public void frenchLangButton()
    {
        Debug.Log("working french button");
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
    }
    
    public void spanishLangButton()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[3];
        Debug.Log("working spanish button");

    }
}
