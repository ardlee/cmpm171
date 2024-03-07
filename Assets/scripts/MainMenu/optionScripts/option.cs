using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class option : MonoBehaviour
{
    public GameObject audioPanel;
    public GameObject controlPanel;
    public GameObject languagePanel;
    public GameObject displayPanel;

    // Start is called before the first frame update
    void Start()
    {
        displayPanel.SetActive(true);
        audioPanel.SetActive(false);
        controlPanel.SetActive(false);
        languagePanel.SetActive(false);
    }
    public void displayPanelOptions()
    {
        audioPanel.SetActive(false);
        displayPanel.SetActive(true);
        controlPanel.SetActive(false);
        languagePanel.SetActive(false);
    }

    public void audioPanelOptions()
    {
        audioPanel.SetActive(true);
        displayPanel.SetActive(false);
        controlPanel.SetActive(false);
        languagePanel.SetActive(false);
    }

    public void controlPanelOptions() 
    {
        audioPanel.SetActive(false);
        displayPanel.SetActive(false);
        controlPanel.SetActive(true);
        languagePanel.SetActive(false); ;
    }

    public void languagePanelOptions()
    {
        audioPanel.SetActive(false);
        displayPanel.SetActive(false);
        controlPanel.SetActive(false);
        languagePanel.SetActive(true);
    }

}
