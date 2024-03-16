using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeImage : MonoBehaviour
{
    public Image panelImage;

    public Sprite newImage;
    public Sprite oldImage;

    public void ChangePanelImage()
    {
        panelImage.sprite = newImage;
        Debug.Log("new image working");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelImage.sprite = oldImage;
            Debug.Log("old image working");

        }
    }

}

